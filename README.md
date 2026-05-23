## Project Task Management API

## A scalable backend API built with ASP.NET Core using Clean Architecture, CQRS, JWT Authentication, and Entity Framework Core.

This project allows authenticated users to manage:

Projects
## Tasks inside projects

The solution demonstrates:

Clean Architecture
SOLID Principles
CQRS with MediatR
JWT Authentication
Repository Pattern
Validation Pipeline
Global Exception Handling
Scalable Layered Design
Tech Stack
.NET 9
ASP.NET Core Web API
Entity Framework Core
SQL Server
JWT Authentication
## Architecture

The project follows Clean Architecture principles.
ProjectTaskManagement
│
├── API
│
├── Presentation
│   ├── Controllers
│   ├── Middlewares
│   └── Filters
│
├── Application
│   ├── Features
│   ├── DTOs
│   ├── Validators
│   ├── Behaviors
│   ├── Interfaces
│   └── Services
│
├── Persistence
│   ├── DbContext
│   ├── Configurations
│   └── Repositories
│
├── Infrastructure
│   ├── JWT
│   └── External Services
│
└── Domain
    ├── Models
    ├── Enums
    └── Common
## Features
## ## Authentication
Register
Login
JWT Token Generation
Projects Module
Create Project
Get All Projects
Get Project By Id
Update Project
Delete Project
Task Items Module
Create Task
Update Task Status
Get Tasks By Project
Delete Task
Authentication

The API uses JWT Bearer Authentication.

After login, include the token in request headers:
Authorization: Bearer YOUR_TOKEN
## Project Model
{
  "id": "id",
  "name": "Project Name",
  "description": "Project Description",
  "createdAt": "2026-05-22T10:00:00Z"
}
## Task Model
{
  "id": "id",
  "title": "Task Title",
  "description": "Task Description",
  "status": 1,
  "dueDate": "2026-05-30T00:00:00",
  "priority": 2,
  "projectId": "id"
}
## Task Status Enum
1= TODO
2= Pending
3 = InProgress
4 = Completed

## CQRS Pattern
The application uses CQRS with MediatR.

Each feature contains:

Command / Query
Handler
Validator
DTOs
Example:
Features/
 └── Projects/
      ├── Commands/
      └── Queries/
## Validation

Validation is implemented using:

FluentValidation
MediatR Pipeline Behaviors

Example:

LoginCommandValidator
CreateProjectCommandValidator
CreateTaskItemCommandValidator
Global Exception Handling

## Unhandled exceptions are handled using custom middleware.

Features:

Centralized exception handling
Consistent API response structure
JSON formatted responses

## Generic Response Structure

All endpoints return a unified response model.

Example:
{
  "isSuccess": true,
  "message": "Project created successfully",
  "statusCode": 200,
  "data": null
}
## Database

Database provider:

SQL Server

Entity Framework Core is used with:

Code First Approach
Migrations
