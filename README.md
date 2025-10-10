# Thread City 2.0 Backend - .NET 8 Web API

## 📌 Overview
This project is **a demo of a social networking web application**. It consists of 2 parts: **Backend** and **Frontend**.  
This is the Backend API repository in the project built with **.NET 8**, using **Entity Framework Core** with **SQL Server** or **PostgreSQL** as the database, support authentication with **JWT**.

Frontend repository: [thread-city-2.0-frontend](https://github.com/nguyenhbtrung/thread-city-2.0-frontend)

---

## 🚀 Tech Stack
- [.NET 8](https://dotnet.microsoft.com/download/dotnet/8.0)
- [Entity Framework Core](https://docs.microsoft.com/ef/core/)
- [SQL Server](https://www.microsoft.com/sql-server)
- [PostgreSQL](https://www.postgresql.org/)
- [ASP.NET Core Identity](https://docs.microsoft.com/aspnet/core/security/authentication/identity)
- [JWT Authentication](https://jwt.io/)

---

## 📂 Project Structure

```
.
├── Controllers/               # API Controllers
├── Services/                  # Business Logic Services
├── Models/                    # Data Models & DTOs & Mappers
├── Data/                      # DbContext & Database Configuration
├── Extensions/                # Extension Methods
├── Helpers/                   # Helper Functions
├── Migrations/                # Migrations for SQL Server
├── Migrations.PostgreSQL/     # Migrations for PostgresSQL
└── Program.cs                 # Application Entry Point
```

---

## ⚙️ Configuration
- Create an `appsettings.json` file in the project root and configure as follows.
- Set `"DatabaseProvider"` to `"Postgres"` or `"SqlServer"` depending on the database provider you use.
- set connection string for database connection.
```
{
  "Logging": {
    "LogLevel": {
      "Default": "Information",
      "Microsoft.AspNetCore": "Warning"
    }
  },
  "AllowedHosts": "*",
  "DatabaseProvider": "SqlServer", // or "Postgres"
  "ConnectionStrings": {
    "SqlServerConnection": "Server=your-server;Database=ThreadCity;Trusted_Connection=True;MultipleActiveResultSets=true;TrustServerCertificate=True",
    "PostgresConnection": "Host=localhost;Database=ThreadCity;Username=postgres;Password=your-password"
  },
  "JWT": {
    "Issuer": "https://localhost:7135",
    "Audience": "https://localhost:7135",
    "SigningKey": "your-512-bit-key"
  },
  "ClientUrls": [
    "http://localhost:3000"
  ]
}
```

---

## 📦 Installation & Setup

### 1. Prerequisites
- Visual Studio 2022
- .NET 8 SDK
- SQL Server or PostgreSQL

### 2. Database Setup
1. Open Package Manager Console in Visual Studio
2. Run the following command:
```
update-database

```

### 3. Running the Application
1. Open the solution in Visual Studio 2022
2. Build the solution
3. Press F5 to run the application

The API will be available at:
- HTTPS: [https://localhost:7135](https://localhost:7135)
- Swagger UI: [https://localhost:7135/swagger](https://localhost:7135/swagger)

---

## 🔑 Authentication

* The backend uses **JWT** for authentication.
* On successful login, the server returns a **JWT token**.
* Include the token in request headers for protected routes:
```
Authorization: Bearer <token>
```

---

## 🌐 Client Integration

The frontend application is available at: [thread-city-2.0-frontend](https://github.com/nguyenhbtrung/thread-city-2.0-frontend)

The frontend is expected to run at:
[http://localhost:3000](http://localhost:3000) (configured in `appsettings.json`).

---

## 📝 Notes

- Ensure proper CORS configuration for your production environment
- Secure your JWT signing key, database connection strings
- For production deployment, update the JWT issuer and audience URLs
