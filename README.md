# Fullstack Technical Assessment – Backend API

This project consists of the backend of a task management application developed using:

- .NET Web API
- SQL Server

---

## 🎯 Objective

Provide a REST API for user and task management, allowing users to:

- Create and retrieve users
- Create and retrieve tasks
- Assign tasks to users
- Manage task statuses
- Apply defined business rules

---

## 🧱 Project Architecture

The project follows a layered architecture:

```text
/Controllers -> API endpoints
/Services -> Business logic
/Repositories -> Data access
/Models -> Entities
/DTOs -> Data Transfer Objects
/Data -> DbContext
/Database -> Database scripts
```

---

## ⚙️ Project Configuration

Before running the backend, you need to configure the database connection in the following file:

`appsettings.json`

### Required Configuration

```json
{
  "Logging": {
    "LogLevel": {
      "Default": "Information",
      "Microsoft.AspNetCore": "Warning"
    }
  },
  "AllowedHosts": "*",
  "ConnectionStrings": {
    "DefaultConnections": "Server=LAPTOP-ESVUNNQO\\BUHOSQL2019; User Id=sa; Database=AppManagementTasks; Password=123456"
  }
}
```

⚠️ **Important:**

You must configure the Server, User Id, and Password according to your local environment.

Without this configuration, the API will not be able to connect to the database.

---

## 🗄️ Database

Inside the project, there is a folder named:

`/Database`

It contains the scripts required to create the database.

**SQL Server 2019**

### Execution Order

1. First, execute the script to create **Tasks**.
2. Then, execute the script to create **Users**.

⚠️ It is important to follow this order to avoid foreign key relationship errors.

---

## 🧾 Implemented Business Rules

- The task title is required.
- Every task must be assigned to a user.
- Valid task statuses:
  - Pending
  - InProgress
  - Done
- Direct status transitions from `Pending → Done` are not allowed.

---

## 🔌 Main Endpoints

### Users

| Method | Endpoint |
|---|---|
| POST | `/api/users` |
| GET | `/api/users` |

### Tasks

| Method | Endpoint |
|---|---|
| POST | `/api/tasks` |
| GET | `/api/tasks` |
| PUT | `/api/tasks/{id}/status` |

---

## ⚙️ Backend Features

- Layered architecture
- DTO implementation
- Backend validation
- Separation of concerns
- Basic error handling
- RESTful API using appropriate HTTP methods

---

## 🚀 Running the Project

Run the following commands:

```bash
dotnet restore
dotnet run
```

---

## 📌 Important Notes

- The database connection must be configured manually in `appsettings.json`.
- The database must be created by executing the scripts inside the `/Database` folder.
- The correct execution order is mandatory (Tasks → Users).

---

## 👨‍💻 Author

**Brayan Reyes**

Project developed as part of a Fullstack Technical Assessment (.NET + Angular + SQL Server).
