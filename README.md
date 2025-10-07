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
- Entity Framework Core with SQL Server
- Swagger/OpenAPI documentation
- Dependency injection
- Comprehensive error handling and logging

## Technology Stack

- **Framework**: ASP.NET Core (.NET 9)
- **ORM**: Entity Framework Core
- **Database**: SQL Server
- **Documentation**: Swagger/OpenAPI
- **Architecture**: Repository Pattern with Dependency Injection

## Getting Started

### Prerequisites

- .NET 9.0 SDK
- SQL Server (LocalDB, SQL Server Express, or full SQL Server)

### Installation

1. **Clone the repository**
   ```bash
   git clone <repository-url>
   cd ProductApi
   ```

2. **Restore packages**
   ```bash
   dotnet restore
   ```

3. **Update the connection string**
   
   Edit `appsettings.json` and update the connection string to point to your SQL Server instance:
   ```json
   {
     "ConnectionStrings": {
       "DefaultConnection": "Server=your-server;Database=ProductApiDb;Trusted_Connection=true;MultipleActiveResultSets=true"
     }
   }
   ```

4. **Run the application**
   ```bash
   dotnet run
   ```

### Database Setup

Make sure your SQL Server database has the Products table with the schema shown above. The API will connect to the existing table.

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

## Development

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

The application will start on `http://localhost:5299` by default.

- **API Endpoint**: `http://localhost:5299/api/products`
- **Swagger UI**: `http://localhost:5299/swagger`

### Building for Production

```bash
dotnet publish -c Release -o ./publish
```

## Configuration

The application uses the following configuration in `appsettings.json`:

```json
{
  "ConnectionStrings": {
    "DefaultConnection": "Server=(localdb)\\mssqllocaldb;Database=ProductApiDb;Trusted_Connection=true;MultipleActiveResultSets=true"
  },
  "Logging": {
    "LogLevel": {
      "Default": "Information",
      "Microsoft.AspNetCore": "Warning",
      "Microsoft.EntityFrameworkCore.Database.Command": "Information"
    }
  }
}
```

## Contributing

1. Fork the repository
2. Create a feature branch
3. Make your changes
4. Add tests if applicable
5. Submit a pull request

## License

This project is licensed under the MIT License.