#!/usr/bin/env bash
set -euo pipefail

usage() {
  cat <<'EOF'
Usage: scripts/cut-release.sh <version> [--publish]

Validates a release candidate for the trolleyhq NuGet package.

Examples:
  scripts/cut-release.sh 2.3.1
  scripts/cut-release.sh 2.3.1 --publish

Options:
  --publish   Trigger the manual NuGet publish workflow for the current commit.

The --publish option must be run from main after the release PR is merged.
EOF
}

if [[ $# -lt 1 ]]; then
  usage
  exit 1
fi

version="$1"
publish="false"

shift
while [[ $# -gt 0 ]]; do
  case "$1" in
    --publish)
      publish="true"
      ;;
    -h|--help)
      usage
      exit 0
      ;;
    *)
      echo "Unknown option: $1" >&2
      usage
      exit 1
      ;;
  esac
  shift
done

if [[ ! "$version" =~ ^[0-9]+\.[0-9]+\.[0-9]+$ ]]; then
  echo "Version must be SemVer in the form MAJOR.MINOR.PATCH, got: $version" >&2
  exit 1
fi

repo_root="$(git rev-parse --show-toplevel)"
cd "$repo_root"

if [[ -n "$(git status --porcelain)" ]]; then
  echo "Working tree is not clean. Commit or stash changes before cutting a release." >&2
  exit 1
fi

echo "Checking version metadata..."
scripts/verify-version.sh "$version"

package_file="trolley/bin/Release/trolleyhq.${version}.nupkg"

echo "Restoring dependencies..."
dotnet restore trolley.sln

echo "Building release package..."
dotnet build trolley.sln --configuration Release --no-restore

echo "Running local release helper tests..."
dotnet test tests/tests.sln \
  --configuration Release \
  --no-build \
  --filter FullyQualifiedName~ClientRequestTest

if [[ -n "${TROLLEY_ACCESS_KEY:-}" && -n "${TROLLEY_SECRET_KEY:-}" ]]; then
  echo "Running integration tests with configured Trolley credentials..."
  dotnet test tests/tests.sln --configuration Release --no-build
else
  echo "Skipping full integration tests because TROLLEY_ACCESS_KEY/TROLLEY_SECRET_KEY are not set."
fi

if [[ ! -f "$package_file" ]]; then
  echo "Expected package was not created: $package_file" >&2
  exit 1
fi

status="$(curl -s -o /dev/null -w "%{http_code}" "https://api.nuget.org/v3-flatcontainer/trolleyhq/${version}/trolleyhq.${version}.nupkg")"
if [[ "$status" == "200" ]]; then
  echo "trolleyhq $version already exists on NuGet." >&2
  exit 1
fi

if [[ "$status" != "404" ]]; then
  echo "Unexpected NuGet availability check status: $status" >&2
  exit 1
fi

echo "Release candidate $version is ready."

if [[ "$publish" != "true" ]]; then
  echo "To publish after merge, run: scripts/cut-release.sh $version --publish"
  exit 0
fi

branch="$(git branch --show-current)"
if [[ "$branch" != "main" ]]; then
  echo "--publish must be run from main, current branch: $branch" >&2
  exit 1
fi

git fetch origin main --quiet
if [[ "$(git rev-parse HEAD)" != "$(git rev-parse origin/main)" ]]; then
  echo "Local main is not at origin/main. Pull the latest main before publishing." >&2
  exit 1
fi

echo "Triggering NuGet publish workflow..."
gh workflow run publish-netcore.yml --ref main

echo "Publish workflow triggered. Monitor with: gh run list --workflow publish-netcore.yml --limit 1"
