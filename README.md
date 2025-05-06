# 📅 **ActivityPlanner** is a project designed for users to plan activities with an **Angular frontend** and an **ASP.NET Core Web API** backend. Built with RESTful architecture principles, the project follows a modular and scalable multi-layered architecture.

## 🛠️ Technologies Used

- **ASP.NET Core (.NET 9 Preview)** – Web API development framework
- **Entity Framework Core** – ORM (Object-Relational Mapping) tool for database operations
- **SQL Server** – Relational database system
- **JWT Authentication** – Secure user authentication method
- **AutoMapper** – Simplifies object-to-object mapping and data transfer
- **Scalar.AspNetCore** – Lightweight and modern tool for API documentation
- **StackExchange.Redis** – Redis-based caching and distributed data management
- **Docker** – Used to run Redis in a containerized environment
- **User Secrets (Secret Manager)** – Secure management of sensitive configuration data during development
- **Angular** – Modern, component-based frontend framework
- **Layered Architecture** – Code separation by responsibilities for improved maintainability

## 📁 Project Structure

- [**ActivityPlanner.API**](https://github.com/omerkrmn/activity-planner/tree/main/ActivityPlanner.API): The entry point of the Web API application
- [**ActivityPlanner.Entities**](https://github.com/omerkrmn/activity-planner/tree/main/ActivityPlanner.Entities): Data models and DTO definitions
- [**ActivityPlanner.Presentation**](https://github.com/omerkrmn/activity-planner/tree/main/ActivityPlanner.Presentation): Controllers and HTTP endpoints
- [**ActivityPlanner.Repositories**](https://github.com/omerkrmn/activity-planner/tree/main/ActivityPlanner.Repositories): Data access layer (EF Core)
- [**ActivityPlanner.Services**](https://github.com/omerkrmn/activity-planner/tree/main/ActivityPlanner.Services): Application logic and service layer
- [**ActivityPlanner.Frontend**](https://github.com/omerkrmn/activity-planner/tree/main/ActivityPlanner.Frontend): Angular-based client application
- [**ActivityPlanner.Test**](https://github.com/omerkrmn/activity-planner/tree/main/ActivityPlanner.Test): Unit testing projects

## 🧑‍💻 Setup & Installation

### Prerequisites

- .NET 9 Preview or later
- Node.js and Angular CLI
- SQL Server or a compatible database
- Docker (optional for Redis)
- Redis (optional, but recommended for caching)

### Installation Steps

1. Clone the repository:
   ```bash
   git clone https://github.com/omerkrmn/activity-planner.git
>>>>>>> dc6d9783c2fa4441ac34dfff44835c471eff802e
