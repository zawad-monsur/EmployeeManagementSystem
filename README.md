# Employee Management System

This project is an Employee Management System built with ASP.NET Core and Entity Framework Core. It demonstrates a full-stack application with RESTful API endpoints for Employee CRUD operations, along with a robust database design that includes Departments, Employee Performance Reviews, and indexing for performance. Demo data is provided for quick testing.

---

## Project Overview and Features

The **Employee Management System** is designed to:

- **Perform CRUD operations on employees:**
  - **Create** new employee records.
  - **Retrieve** a list of employees with pagination.
  - **Search** employees by name.
  - **Update** employee details.
  - **Soft-delete** employees by marking them inactive.

- **Manage Relational Data:**
  - Each Employee is associated with a Department via a foreign key.
  - Performance Reviews are stored in a separate table and linked to Employees.

- **Performance Considerations:**
  - Indexes are created at the database level on frequently queried columns (e.g., Employee Name, Department Name, PerformanceReview Score).

- **Clean Architecture:**
  - The project is organized into Controllers, Services, Repositories, DTOs, Domain Entities, and Infrastructure layers.
  - AutoMapper is used to map between domain entities and DTOs, reducing repetitive code and improving maintainability.

---

## Setup Instructions

### Prerequisites

- [.NET 6 SDK (or later)](https://dotnet.microsoft.com/download)
- [SQL Server / LocalDB](https://docs.microsoft.com/en-us/sql/database-engine/configure-windows/sql-server-express-localdb)
  
### Getting Started

1. **Clone the Repository:**

   ```bash
   git clone https://github.com/yourusername/EmployeeManagementSystem.git
   cd EmployeeManagementSystem
   
2. **Update the Connection String::**

   ```bash
    {
    "ConnectionStrings": {
      "DefaultConnection": "Server=(localdb)\\MSSQLLocalDB;Database=EMS;Trusted_Connection=True;"
    },
    "Logging": {
      "LogLevel": {
        "Default": "Information",
        "Microsoft.AspNetCore": "Warning"
      }
    },
    "AllowedHosts": "*"
    }

3. **Run the Application:**

   ```bash
    # In one terminal (API)
    cd API
    dotnet run
    
    # In another terminal (Frontend)
    cd Client
    npm start
