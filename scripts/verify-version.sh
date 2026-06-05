#!/usr/bin/env bash
set -euo pipefail

usage() {
  cat <<'EOF'
Usage: scripts/verify-version.sh [version]

Verify SDK version metadata is consistent across all release files.

If version is omitted, the canonical version is read from trolley/trolley.csproj.

Checked locations:
  - trolley/trolley.csproj (<Version>, <ApplicationVersion>)
  - trolley/Types/Supporting/SemVer.cs (MAJOR, PATCH, MINOR -> User-Agent)
  - trolley/Properties/AssemblyInfo.cs (AssemblyFileVersion, AssemblyInformationalVersion)
  - trolley/trolley.nuspec (<version>)
EOF
}

if [[ "${1:-}" == "-h" || "${1:-}" == "--help" ]]; then
  usage
  exit 0
fi

repo_root="$(git rev-parse --show-toplevel)"
cd "$repo_root"

project_file="trolley/trolley.csproj"
semver_file="trolley/Types/Supporting/SemVer.cs"
assembly_info_file="trolley/Properties/AssemblyInfo.cs"
nuspec_file="trolley/trolley.nuspec"

first_match() {
  awk 'NF { print; exit }'
}

xml_value() {
  local file="$1"
  local tag="$2"

  sed -nE "s/.*<${tag}>([^<]+)<\\/${tag}>.*/\\1/p" "$file" | first_match
}

semver_part() {
  local name="$1"

  sed -nE "s/.*public[[:space:]]+static[[:space:]]+int[[:space:]]+${name}[[:space:]]*=[[:space:]]*([0-9]+).*/\\1/p" "$semver_file" | first_match
}

assembly_attribute() {
  local name="$1"

  sed -nE "s/.*${name}\\(\"([^\"]+)\"\\).*/\\1/p" "$assembly_info_file" | first_match
}

project_version="$(xml_value "$project_file" "Version")"
application_version="$(xml_value "$project_file" "ApplicationVersion")"
semver_version="$(semver_part "MAJOR").$(semver_part "PATCH").$(semver_part "MINOR")"
file_version="$(assembly_attribute "AssemblyFileVersion")"
info_version="$(assembly_attribute "AssemblyInformationalVersion")"
nuspec_version="$(xml_value "$nuspec_file" "version")"
expected="${1:-$project_version}"

errors=()

check() {
  local label="$1"
  local actual="$2"
  local want="$3"

  if [[ "$actual" != "$want" ]]; then
    errors+=("${label}: expected '${want}', found '${actual}'")
  fi
}

check "trolley/trolley.csproj <Version>" "$project_version" "$expected"
check "trolley/trolley.csproj <ApplicationVersion>" "$application_version" "${expected}.0"
check "trolley/Types/Supporting/SemVer.cs" "$semver_version" "$expected"
check "trolley/Properties/AssemblyInfo.cs AssemblyFileVersion" "$file_version" "${expected}.0"
check "trolley/Properties/AssemblyInfo.cs AssemblyInformationalVersion" "$info_version" "$expected"
check "trolley/trolley.nuspec <version>" "$nuspec_version" "$expected"

if (( ${#errors[@]} > 0 )); then
  echo "Version metadata mismatch:" >&2
  printf '  - %s\n' "${errors[@]}" >&2
  echo >&2
  echo "Update every location above when bumping the SDK version." >&2
  exit 1
fi

echo "Version metadata is consistent at ${expected}."
