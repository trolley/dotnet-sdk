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

python3 - "${1:-}" <<'PY'
import re
import sys
import xml.etree.ElementTree as ET
from pathlib import Path

repo = Path(".")
expected = sys.argv[1] if len(sys.argv) > 1 and sys.argv[1] else None

project_file = repo / "trolley/trolley.csproj"
semver_file = repo / "trolley/Types/Supporting/SemVer.cs"
assembly_info_file = repo / "trolley/Properties/AssemblyInfo.cs"
nuspec_file = repo / "trolley/trolley.nuspec"

csproj = ET.parse(project_file)
project_version = csproj.find(".//Version").text or ""
application_version = csproj.find(".//ApplicationVersion").text or ""

semver_text = semver_file.read_text()
semver_parts = {}
for name in ("MAJOR", "PATCH", "MINOR"):
    match = re.search(rf"public\s+static\s+int\s+{name}\s*=\s*(\d+)", semver_text)
    semver_parts[name] = match.group(1) if match else ""
semver_version = f"{semver_parts['MAJOR']}.{semver_parts['PATCH']}.{semver_parts['MINOR']}"

assembly_text = assembly_info_file.read_text()
file_version_match = re.search(r'AssemblyFileVersion\("([^"]+)"\)', assembly_text)
info_version_match = re.search(r'AssemblyInformationalVersion\("([^"]+)"\)', assembly_text)
file_version = file_version_match.group(1) if file_version_match else ""
info_version = info_version_match.group(1) if info_version_match else ""

nuspec_text = nuspec_file.read_text()
nuspec_match = re.search(r"<version>([^<]+)</version>", nuspec_text)
nuspec_version = nuspec_match.group(1) if nuspec_match else ""

if expected is None:
    expected = project_version

errors = []

def check(label, actual, want):
    if actual != want:
        errors.append(f"{label}: expected {want!r}, found {actual!r}")

check("trolley/trolley.csproj <Version>", project_version, expected)
check("trolley/trolley.csproj <ApplicationVersion>", application_version, f"{expected}.0")
check("trolley/Types/Supporting/SemVer.cs", semver_version, expected)
check("trolley/Properties/AssemblyInfo.cs AssemblyFileVersion", file_version, f"{expected}.0")
check("trolley/Properties/AssemblyInfo.cs AssemblyInformationalVersion", info_version, expected)
check("trolley/trolley.nuspec <version>", nuspec_version, expected)

if errors:
    print("Version metadata mismatch:", file=sys.stderr)
    for error in errors:
        print(f"  - {error}", file=sys.stderr)
    print(
        "\nUpdate every location above when bumping the SDK version.",
        file=sys.stderr,
    )
    sys.exit(1)

print(f"Version metadata is consistent at {expected}.")
PY
