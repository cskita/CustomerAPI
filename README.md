# CustomerAPI

**_CustomerAPI_** is an ASP.NET API Core case solution create to implement a authorization pages using Json Web Token (JWT) and to demonstrate the behavior of a routes of method type GET with some filters using EF Core.

## Design Patterns

Model-View-Controller  
Repository  
Dependency Injection  
Inversion of Control  

## Solution Projects

| Project | Application Layer |
| :--- | :---
| CustomerAPI.Application | User Interface Rest (controllers) |
| CustomerAPI.Application.DTO | Models Views Using in project CustomerAPI.Application |
| CustomerAPI.Core | Data Entities and Interfaces |
| CustomerAPI.Infra.CrossCutting | Automapper and IoC |
| CustomerAPI.Infra.Data | Data Context and Repositories |
| CustomerAPI.Framework | Filters and Extensions |

## Technologies

| Dependency | Version
| :--- | ---:
| .NET Core | 3.1
| AutoMapper | 10.1.1
| EntityFramework Core | 3.1.10
| C# | 8
| Microsoft VisualStudio Web CodeGeneration Design | 3.1.4
| Swashbuckle AspNetCore Swagger | 5.6.3
| SQL Server LocalDB | 2019

## Getting Started

1. Download or clone this repository.
1. Open the solution in Visual Studio 2017 or higher.
1. Select **Customer.Application** for Default Project.
1. Run the application.

* If occors error after build project related of version of the database you have to update the SQL Server LocalDB for version 2018 or higher. [Learn More](https://medium.com/cloudnimble/upgrade-visual-studio-2019s-localdb-to-sql-2019-da9da71c8ed6)

## Configuration

* The project contains a configuration which may require modification for the developer's specific environment:

    | Project | File
    | :--- | :---
    | CustomerWeb.Application | appsettings.json
    | CustomerWeb.Application | appsettings.Development.json

* The configuration string specifies the target database server: `Server=(localdb)\\mssqllocaldb;AttachDbFilename=|DataDirectory|App_Data\\customerdb.mdf;Database=customerdb;`. Developers using a different target database will have to change the connection string.
