# Product API

A simple ASP.NET Core Web API for managing products using Entity Framework Core.

## Database Schema

This API works with the following database table:

```sql
CREATE TABLE Products (
    Id INT PRIMARY KEY,
    Name NVARCHAR(100),
    Price DECIMAL(10,2)
);
```

## Features

- **GET /api/products** - Returns a JSON array of all products
- Entity Framework Core with in memory database
- Swagger/OpenAPI documentation
- Comprehensive error handling and logging

## Technology Stack

- **Framework**: ASP.NET Core (.NET 9)
- **ORM**: Entity Framework Core
- **Documentation**: Swagger/OpenAPI

## Getting Started

### Prerequisites
  dotnet add package Microsoft.EntityFrameworkCore.InMemory
- .NET 9.0 SDK
- In memory database


4. **Run the application**

   dotnet run --launch-profile https
  

### Database Setup

used in memory database 

## API Endpoints

| Method | Endpoint | Description |
|--------|----------|-------------|
| GET | `/api/products` | Get all products |

### Example Response

```json
[
  {
    "id": 1,
    "name": "Laptop",
    "price": 1299.99
  },
  {
    "id": 2,
    "name": "Smartphone", 
    "price": 899.99
  }
]
```

### Project Structure

```
ProductApi/
├── Controllers/
│   └── ProductsController.cs    # API endpoints
├── Data/
│   └── ProductDbContext.cs      # Entity Framework DbContext
├── Models/
│   └── Product.cs               # Product data model
├── Services/
│   ├── IProductService.cs       # Service interface
│   └── ProductService.cs        # Service implementation
├── appsettings.json             # Configuration
└── Program.cs                   # Application startup
```

### Running the Application

The application will start on `http://localhost:5280` by default.

- **API Endpoint**: `http://localhost:5280/api/products`
- **Swagger UI**: `http://localhost:5280/swagger`

### Building for Production

```bash
dotnet publish -c Release -o ./publish
```



