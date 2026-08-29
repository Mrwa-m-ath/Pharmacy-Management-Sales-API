# Pharmacy Management & Sales API 💊

A RESTful Web API for managing pharmacy operations, built with **ASP.NET Core Web API, C#, Entity Framework Core, and SQL Server**.

## 🚀 Features

* 🔐 JWT Authentication
* 🔄 Refresh Token
* 👤 User Management
* 🛡️ Role-Based Authorization
* 💊 Product Management
* 📂 Category Management
* 👥 Customer Management
* 🧾 Sales Management
* 📦 Stock Management
* 💰 SubTotal Calculation
* 🔒 BCrypt Password Hashing
* ✅ FluentValidation
* 🔄 AutoMapper
* 🗄️ Entity Framework Core
* 📚 Swagger / OpenAPI
* 🧩 Repository Pattern
* ⚠️ Exception Handling
* 💉 DTO Pattern
* 💉 Dependency Injection

## 🛠️ Technologies

| Technology            | Usage                |
| --------------------- | -------------------- |
| C#                    | Programming Language |
| ASP.NET Core Web API  | Backend Framework    |
| .NET 10               | Runtime              |
| Entity Framework Core | ORM                  |
| SQL Server            | Database             |
| JWT                   | Authentication       |
| BCrypt                | Password Hashing     |
| AutoMapper            | Object Mapping       |
| FluentValidation      | Input Validation     |
| Swagger               | API Documentation    |

## 📌 Main Modules

### 👤 Users

* Register
* Login
* Update User
* Delete User
* Get All Users
* JWT Authentication
* Refresh Token

### 💊 Products

* Add Product
* Update Product
* Delete Product
* Stock Management

### 📂 Categories

* Add Category
* Update Category
* Delete Category

### 👥 Customers

* Add Customer
* Update Customer
* Delete Customer

### 🧾 Sales

* Add Sale
* Update Sale
* Delete Sale
* Get All Sales
* Customer Validation
* Product Stock Validation

## 💰 Sales Calculation

### SubTotal

```text
SubTotal = Quantity × Product Cost
```

### Stock

```text
New Stock = Current Stock - Sold Quantity
```

The API validates that the requested quantity is available before reducing the stock.

## 🔐 Authorization

Administrative operations are protected using role-based authorization:

```csharp
[Authorize(Roles = "Admin")]
```

## 🏗️ Architecture

The project follows a layered structure:

```text
Controllers
    ↓
Services
    ↓
Repository
    ↓
Entity Framework Core
    ↓
SQL Server
```

## 📁 Project Structure

```text
Pharmacy-Management-Sales-API
│
├── Configration
├── Control
├── DTO
├── Model
├── Resposter
└── Servies
```

## ⚙️ Installation

Clone the repository:

```bash
git clone https://github.com/Mrwa-m-ath/Pharmacy-Management-Sales-API.git
```

Open the project in **Visual Studio**.

Configure your SQL Server connection and JWT settings.

Then run:

```bash
dotnet restore
dotnet ef database update
dotnet run
```

## 📚 API Documentation

The project includes **Swagger/OpenAPI** for testing and documenting API endpoints.

## 👩‍💻 Author

**Marwa Mostataa Athamneh**

Junior Backend .NET Developer

GitHub:
https://github.com/Mrwa-m-ath

---

⭐ **Pharmacy Management & Sales API** — Backend project built with ASP.NET Core.
