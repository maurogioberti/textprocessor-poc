# Poc.TextProcessor

## Description
Poc.TextProcessor is an integrated solution offering tools for text processing and analysis. 
This project demonstrates the use of .NET technologies with a WPF application and a RESTful API. 
It includes functionalities for text sorting and generating text statistics. 
Additionally, it's a concise project that verifies a tech concept by delivering numerous simplified features, validating assumptions, and ensuring the concept is implementable.

## Features
- Text sorting based on various criteria (alphabetical, length).
- Text analysis for statistics (word count, spaces count, etc.).
- WPF user interface.
- RESTful API for text processing.

## Technologies Used
- .NET 8
- WPF
- Web API

## Project Structure
The Poc.TextProcessor project is organized into several key directories, each serving a specific role in the application:

- **ResourceAccess.Contracts**: Contains the contracts and interfaces for data access.
- **Business.Logic**: Implements the core business logic of the application.
- **Business.Logic.Tests**: Contains unit tests for the business logic layer.
- **ResourceAccess.Domains**: Holds the domain models used throughout the application.
- **ResourceAccess.Mappers**: Manages mapping between domain models and other layers.
- **ResourceAccess.Repositories**: Includes adapters to connect the application with external services or databases.
- **ResourceAccess.Database**: The data persistence layer, responsible for database interactions.
- **CrossCutting.Exceptions**: Handles application-wide exception management.
- **CrossCutting.Globalization**: Supports internationalization and localization.
- **CrossCutting.Utils**: Provides utility functions used across the application.
- **CrossCutting.Infrastructure**: Contains infrastructure setup and configuration.
- **ResourceAccess.Services**: Implements service layer to interact with business logic and data access layers.
- **Presentation.ServiceApi**: The RESTful API layer of the application.
- **Presentation.Desktop**: The WPF-based desktop user interface.

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
- Navigate to the `Business.Logic.Tests` project.
- Use the Test Explorer in Visual Studio to run unit tests.
