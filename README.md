# BDD Test Framework

This project is a basic test framework utilizing **C#**, **NUnit**, **Page Object Model (POM)**, and **SpecFlow** to implement a BDD-style test scenario.

### Prerequisites
1. **Visual Studio 2022**
2. **.Net Core SDK 8.0**
3. **Chrome Browser** (Latest version)
4. **Microsoft.NET.Test.Sdk**

### Features
- Implements Page Object Model (POM) for test scalability and maintainability.
- Supports BDD using SpecFlow.
- Includes configuration-driven URL and driver setup.
- Parallel execution enabled for faster test runs.
- Extensible architecture for adding new test cases and browsers.

### Installation and Setup
1. Clone the repository.
   ```bash
   git clone <https://github.com/omeryttnc-interview/NorthStandard>
   ```
2. Open the solution in **Visual Studio 2022**.
3. Restore NuGet packages.
   ```bash
   dotnet restore
   ```
4. Update the `appsettings.json` file with the required configuration (e.g., target URL).

### Running Tests
- Run all tests using the following command:
  ```bash
  dotnet test
  ```
- To generate test reports, integrate the framework with **ExtentReports**