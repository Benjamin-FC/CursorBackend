#!/bin/bash

echo "=== FrankCrum CRM API Build Verification ==="
echo ""

# Check if dotnet is available
if ! command -v dotnet &> /dev/null; then
    echo "❌ .NET SDK not found. Please install .NET 8.0 SDK"
    echo "   Visit: https://dotnet.microsoft.com/download"
    exit 1
fi

echo "✓ .NET SDK found: $(dotnet --version)"
echo ""

# Check project files exist
echo "Checking project files..."
projects=(
    "FrankCrumCrm.Domain/FrankCrumCrm.Domain.csproj"
    "FrankCrumCrm.Application/FrankCrumCrm.Application.csproj"
    "FrankCrumCrm.Infrastructure/FrankCrumCrm.Infrastructure.csproj"
    "FrankCrumCrm.Api/FrankCrumCrm.Api.csproj"
)

for project in "${projects[@]}"; do
    if [ -f "$project" ]; then
        echo "✓ $project exists"
    else
        echo "❌ $project missing"
        exit 1
    fi
done

echo ""
echo "Restoring packages..."
dotnet restore FrankCrumCrm.sln

if [ $? -ne 0 ]; then
    echo "❌ Package restore failed"
    exit 1
fi

echo ""
echo "Building solution..."
dotnet build FrankCrumCrm.sln --no-restore

if [ $? -eq 0 ]; then
    echo ""
    echo "✅ Build successful!"
    echo ""
    echo "To run the API:"
    echo "  cd FrankCrumCrm.Api"
    echo "  dotnet run"
    exit 0
else
    echo ""
    echo "❌ Build failed. Please check the errors above."
    exit 1
fi
