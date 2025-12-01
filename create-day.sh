#!/bin/bash

if [ -z "$1" ]; then
    echo "Usage: ./create-day.sh <day_number>"
    echo "Example: ./create-day.sh 02"
    exit 1
fi

DAY_NUM=$1
DAY_NAME="Day${DAY_NUM}"
DAY_PATH="Days/${DAY_NAME}"

if [ -d "$DAY_PATH" ]; then
    echo "Error: ${DAY_NAME} already exists!"
    exit 1
fi

echo "Creating ${DAY_NAME}..."

# Create directory
mkdir -p "$DAY_PATH"

# Copy template files
cp Templates/DayTemplate/Program.cs "$DAY_PATH/"
cp Templates/DayTemplate/input.txt "$DAY_PATH/"
cp Templates/DayTemplate/example.txt "$DAY_PATH/"
cp Templates/DayTemplate/DayTemplate.csproj "$DAY_PATH/${DAY_NAME}.csproj"

# Update Program.cs with correct day number
sed -i "s/Day XX/Day ${DAY_NUM}/g" "$DAY_PATH/Program.cs"

# Add to solution
dotnet sln add "$DAY_PATH/${DAY_NAME}.csproj"

echo "✓ ${DAY_NAME} created successfully!"
echo "  Run with: dotnet run --project ${DAY_PATH}"
