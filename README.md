# 📋 Project Task Management API

> A scalable backend API built with **ASP.NET Core** following **Clean Architecture**, **CQRS**, **JWT Authentication**, and **Entity Framework Core**.

---

## ✨ Overview

This API allows authenticated users to manage **Projects** and **Tasks** with a clean, maintainable, and scalable architecture.

---

## 🚀 Tech Stack

| Technology | Purpose |
|---|---|
| **.NET 9** | Runtime |
| **ASP.NET Core Web API** | API Framework |
| **Entity Framework Core** | ORM |
| **SQL Server** | Database |
| **MediatR** | CQRS Implementation |
| **FluentValidation** | Input Validation |
| **JWT Bearer** | Authentication |

---

## 🏛️ Architecture

The project follows **Clean Architecture** principles with a strict separation of concerns:

```
ProjectTaskManagement
│
├── 📡 API                          → Entry point, Program.cs, DI registration
│
├── 🖥️  Presentation                → Controllers, Middlewares, Filters
│   ├── Controllers
│   ├── Middlewares
│   └── Filters
│
├── ⚙️  Application                 → Business Logic, CQRS, Validation
│   ├── Features
│   ├── DTOs
│   ├── Validators
│   ├── Behaviors
│   ├── Interfaces
│   └── Services
│
├── 🗄️  Persistence                 → Database, Repositories
│   ├── DbContext
│   ├── Configurations
│   └── Repositories
│
├── 🔧 Infrastructure               → External Services, JWT
│   ├── JWT
│   └── External Services
│
└── 🏗️  Domain                      → Entities, Enums, Core Models
    ├── Models
    ├── Enums
    └── Common
```

### Design Principles

- ✅ **Clean Architecture**
- ✅ **SOLID Principles**
- ✅ **CQRS with MediatR**
- ✅ **Repository Pattern**
- ✅ **Validation Pipeline**
- ✅ **Global Exception Handling**
- ✅ **Scalable Layered Design**

---

## 🔐 Authentication

The API uses **JWT Bearer Authentication**.

### Endpoints

| Method | Endpoint | Description |
|---|---|---|
| `POST` | `/api/Auth/register` | Register a new user |
| `POST` | `/api/Auth/login` | Login and receive JWT token |

### Using the Token

After login, include the token in every request header:

```http
Authorization: Bearer YOUR_TOKEN_HERE
```

---

## 📁 Features

### Projects Module

| Method | Endpoint | Description |
|---|---|---|
| `POST` | `/api/Projects` | Create a new project |
| `GET` | `/api/Projects` | Get all projects |
| `GET` | `/api/Projects/{id}` | Get project by ID |
| `PUT` | `/api/Projects/{id}` | Update project |
| `DELETE` | `/api/Projects/{id}` | Delete project |

### Task Items Module

| Method | Endpoint | Description |
|---|---|---|
| `POST` | `/api/TaskItems` | Create a new task |
| `GET` | `/api/TaskItems/{projectId}` | Get tasks by project |
| `PUT` | `/api/TaskItems/{id}/status` | Update task status |
| `DELETE` | `/api/TaskItems/{id}` | Delete task |

---

## 📦 Data Models

### Project
```json
{
  "id": 1,
  "name": "Project Name",
  "description": "Project Description",
  "createdAt": "2026-05-22T10:00:00Z"
}
```

### Task Item
```json
{
  "id": 1,
  "title": "Task Title",
  "description": "Task Description",
  "status": 1,
  "dueDate": "2026-05-30T00:00:00",
  "priority": 2,
  "projectId": 1
}
```

### Task Status Enum

| Value | Status |
|---|---|
| `1` | Todo |
| `2` | Pending |
| `3` | In Progress |
| `4` | Completed |

---

## ⚡ CQRS Pattern

Each feature follows the **CQRS pattern** with MediatR:

```
Features/
 └── Projects/
      ├── Commands/
      │    ├── CreateProject/
      │    │    ├── CreateProjectCommand.cs
      │    │    ├── CreateProjectCommandHandler.cs
      │    │    └── CreateProjectCommandValidator.cs
      │    ├── UpdateProject/
      │    └── DeleteProject/
      └── Queries/
           ├── GetAllProjects/
           └── GetProjectById/
```

---

## ✅ Validation

Validation is implemented using **FluentValidation** with **MediatR Pipeline Behaviors** — all validation happens before the handler is invoked.

```
Request → ValidationPipelineBehavior → Handler
               ↓ (if invalid)
          GenericResponse (400 Bad Request)
```

Examples of validators:
- `LoginCommandValidator`
- `CreateProjectCommandValidator`
- `CreateTaskItemCommandValidator`

---

## 🌐 Global Exception Handling

All unhandled exceptions and HTTP errors are caught by `GlobalExceptionHandlingMiddleware`:

- ✅ Centralized exception handling
- ✅ Consistent API response structure
- ✅ Handles `401 Unauthorized` with custom response
- ✅ JSON formatted responses

---

## 📬 Generic Response Structure

All endpoints return a **unified response model**:

```json
{
  "isSuccess": true,
  "message": "Project created successfully",
  "statusCode": 200,
  "data": null
}
```

### Error Response Example
```json
{
  "isSuccess": false,
  "message": "User not signed in",
  "statusCode": 401,
  "data": null
}
```

---

## 🗄️ Database

- **Provider:** SQL Server
- **Approach:** Code First with EF Core Migrations

### Setup

```bash
# Add migration
dotnet ef migrations add Init \
  --project ProjectTaskManagement.Presistance \
  --startup-project ProjectTaskManagement.Api

# Apply migration
dotnet ef database update \
  --project ProjectTaskManagement.Presistance \
  --startup-project ProjectTaskManagement.Api
```

### Connection String (`appsettings.json`)
```json
"ConnectionStrings": {
  "DefaultConnection": "Server=.;Database=ProjectTaskManagementDb;User Id=sa;Password=YourPassword;TrustServerCertificate=True"
}
```

---

## ⚙️ Configuration (`appsettings.json`)

```json
{
  "ConnectionStrings": {
    "DefaultConnection": "YOUR_CONNECTION_STRING"
  },
  "JWT": {
    "Key": "YOUR_SECRET_KEY_MIN_32_CHARS",
    "Issuer": "ProjectTaskManagement",
    "Audience": "ProjectTaskManagementUsers",
    "DurationInDays": 7
  }
}
```

---

## 🏃 Getting Started

```bash
# 1. Clone the repository
git clone https://github.com/your-username/ProjectTaskManagement.git

# 2. Navigate to the project
cd ProjectTaskManagement

# 3. Update connection string in appsettings.json

# 4. Apply migrations
dotnet ef database update --startup-project ProjectTaskManagement.Api

# 5. Run the API
dotnet run --project ProjectTaskManagement.Api
```

Then navigate to:
```
https://localhost:7273/swagger
```

---

