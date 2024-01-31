# Poc.TextProcessor

## Description
Poc.TextProcessor is an integrated solution offering tools for text processing and analysis. 
This project demonstrates the use of .NET technologies with a WPF application and a RESTful API. 
It includes a suite of functionalities such as text sorting, statistics generation, and integrity assurance of API endpoints.
Additionally, it's a concise project that verifies a tech concept by delivering numerous simplified features, validating assumptions, and ensuring the concept is implementable.

## Features
- Providing text sorting based on various criteria (alphabetical, length).
- Analyzing text for statistics (word count, spaces count, etc.).
- Offering a WPF-based user interface for an interactive user experience.
- Providing a RESTful API with endpoints for text processing tasks.
- Validating the HTTP status codes and responses of API endpoints with the IntegrityAssurance subsystem.

## Technologies Used
- .NET 8
- WPF (Windows Presentation Foundation)
- Web API
- NUnit (for testing)
- RestSharp (for making API calls in tests)

## Project Structure
The Poc.TextProcessor project is modularly structured to promote separation of concerns and ease of maintenance. 
Below is an overview of each module and its role within the application:

`Main Solution`
- **Business.Logic**: Implements the core business logic of the application.
- **Business.Logic.Abstractions**: Defines abstract representations for business logic components.
- **Business.Logic.Tests**: Contains unit tests for the business logic layer.
- **CrossCutting.Configurations**: Contains centralized configuration management.
- **CrossCutting.Enums**: Defines enumeration types used across the application.
- **CrossCutting.Exceptions**: Handles application-wide exception management.
- **CrossCutting.Globalization**: Supports internationalization and localization.
- **CrossCutting.Utils**: Provides utility functions used across the application.
- **Presentation.Desktop**: The WPF-based desktop user interface.
- **Presentation.RestApi**: The RESTful API layer of the application.
- **ResourceAccess.Contracts**: Contains the contracts and interfaces for data access.
- **ResourceAccess.Database**: The data persistence layer, responsible for database interactions.
- **ResourceAccess.Domains**: Holds the domain models used throughout the application.
- **ResourceAccess.Entities**: Defines the entity models representing the database schema.
- **ResourceAccess.Mappers**: Manages mapping between domain models and other layers.
- **ResourceAccess.Mappers.Abstractions**: Provides abstract definitions for mappers.
- **ResourceAccess.Repositories**: Includes adapters to connect the application with external services or databases.
- **ResourceAccess.Repositories.Abstractions**: Defines abstract representations for repository components.
- **Services**: Implements service layer to interact with business logic and data access layers.
- **Services.Abstractions**: Defines abstract representations for service components.

`IntegrityAssurance Solution`
- **IntegrityAssurance.Core**: Core functionalities, models, and utilities.
- **IntegrityAssurance.Tests**: Tests for API integrity verification.
- **IntegrityAssurance.Runner**: Executable project for manual test execution.

### Integrity Assurance
The IntegrityAssurance subsystem is dedicated to ensuring the API's robustness by verifying the HTTP status codes and responses of endpoints. It focuses on confirming that the API behaves as documented, primarily validating the outer layer of the application.
It's crucial to note that IntegrityAssurance complements, but does not replace, in-depth unit and integration testing of business logic. It primarily ensures the API's contract with consumers remains intact and reliable.

## Getting Started
To set up the Poc.TextProcessor project and get it running on your local development environment, follow these steps:

### Prerequisites
- .NET SDK 8
- Visual Studio 2022

### Installation
1. Clone the repository to your local machine.
2. Open the solution file (`Poc.TextProcessor.sln`) in Visual Studio.
3. Restore all NuGet packages.

### Running the Application
- To run the WPF application, set `Presentation.Desktop` as the startup project and run it through Visual Studio.
- To start the API, set `Presentation.ServiceApi` as the startup project and run it. The API will be hosted locally (by default on `http://localhost:[port]`).

### Running Tests
Testing is a crucial part of maintaining the quality and robustness of the application. It's recommended to run tests in both the main solution and the IntegrityAssurance solution to cover all aspects of the application.

`Main Solution`
- Navigate to the `Business.Logic.Tests` project for business logic unit tests.
- Use Visual Studio's Test Explorer to execute these tests and ensure the business logic's robustness.

`IntegrityAssurance Solution`
- Navigate to the `IntegrityAssurance.Tests` project for API integrity tests.
- Use Visual Studio's Test Explorer to execute these tests and ensure the API's robustness.
- Alternatively, run the `IntegrityAssurance.Runner` project for a manual execution of the integrity tests, which is especially useful for interactive debugging and verification.