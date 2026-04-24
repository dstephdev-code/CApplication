# Student Records Console App

A small C# console application for loading student data from JSON, validating file paths, and calculating average grades.

## Overview

This project was created as a practice step toward C# backend development.  
The main goal was not just to solve a simple task, but to structure the code in a more scalable way by separating:

- domain model
- repository abstraction
- JSON-based persistence
- utility methods
- basic tests

At the moment, the application reads a list of students from a JSON file, calculates each student's average grade, prints the results to the console, and saves the data back to the file.

## Features

- Load student records from a JSON file
- Calculate average grade for each student
- Save student data asynchronously
- Validate file paths and restrict file extension to `.json`
- Separate repository interface from concrete implementation
- Include a test data repository for development/testing scenarios
- Include basic xUnit tests for file path validation

## Project Structure

```text
CApplication.sln
├── src/
│   └── CApplication.Main/
│       ├── Models/
│       │   └── Student.cs
│       ├── Repositories/
│       │   ├── IStudentRepository.cs
│       │   ├── JsonStudentRepository.cs
│       │   └── TestDataStudentRepository.cs
│       ├── Utils/
│       │   └── UtilMethods.cs
│       ├── Configuration.cs
│       ├── Program.cs
│       └── CApplication.csproj
└── tests/
    └── CApplication.Tests/
        ├── StudentValidationTests.cs
        └── CApplication.Tests.csproj
```

## Technologies Used

- C#
- .NET 10
- System.Text.Json
- xUnit

## How It Works

1. The application creates a JSON-based student repository.
2. It loads students from `Data/students_data.json`.
3. For each student, it calculates and prints the average grade.
4. It saves the student list back to the same JSON file.

## Student Model

Each student contains:

- `Name`
- `Grades`
- computed `AverageGrade`

The model also includes a simple validation method to ensure:

- name is not empty
- grades array is not empty
- all grades are between 0 and 100

## Example JSON

```json
[
  {
    "name": "Sophia",
    "grades": [93, 87, 98, 95, 100]
  },
  {
    "name": "Nicolas",
    "grades": [80, 83, 82, 88, 85]
  }
]
```

## Running the Project

### Prerequisites

- .NET 10 SDK installed

### Run

```bash
dotnet run
```

## Tests

The project currently includes basic xUnit tests for file path validation.

To run tests:

```bash
dotnet test
```

## What This Project Demonstrates

This project is mainly focused on practicing:

- code organization
- basic abstraction via interfaces
- asynchronous file operations
- JSON serialization/deserialization
- simple validation
- introductory automated testing

## Current Limitations

This is still a learning project and has several limitations:

- tests are currently minimal
- validation is basic
- error handling can be improved
- there is no API layer yet

## Next Step

The next planned step is to evolve this console application into an ASP.NET Core Web API version with:

- controllers/endpoints
- DTOs
- service layer
- dependency injection
- database persistence
- improved tests

## License

MIT
