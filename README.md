# MyMvcApp

## Overview
MyMvcApp is an MVC framework 4.8 project following Clean Architecture principles with a Repository Pattern and Unit of Work pattern. The project uses Entity Framework with a Code-First approach and an MS SQL database. It also incorporates partial views, filters, and various other features to ensure a scalable and maintainable architecture.

## Features
- User Management (Create, Update, Delete Users)
- Authentication System (Login/Logout)
- Secure access (Users cannot be accessed without login)
- Clean Architecture implementation
- Repository Pattern with Unit of Work
- Entity Framework Code-First Approach
- Partial Views for better UI structuring
- Custom Filters for request handling
- MS SQL Database integration

## Project Structure
The solution is divided into multiple layers:

1. **MyMvcApp.Domain** - Contains core domain entities and interfaces.
2. **MyMvcApp.Application** - Handles business logic and service interfaces.
3. **MyMvcApp.Infrastructure** - Implements repository pattern, Unit of Work, Manages database connections, migrations and EF Core configurations.
5. **MyMvcApp.Web** - The MVC project for UI and user interactions.

## Prerequisites
- .NET Framework 4.8
- MS SQL Server
- Entity Framework

## Setup Instructions
1. Clone the repository:
   ```sh
   git clone https://github.com/your-repo/MyMvcApp.git
   ```
2. Open the solution in Visual Studio.
3. Update database connection string in `appsettings.json`.
4. Run the following commands in the Package Manager Console:
   ```sh
   Update-Database
   ```
5. Start the application from Visual Studio.

## Contributing
Feel free to contribute by creating a pull request or opening an issue for discussion.

## License
This project is licensed under the MIT License.

