# .NET API Template

This is a standardized template for building ASP.NET Core Web APIs with best practices.

## Features

- Clean architecture with controllers, services, and models
- Swagger/OpenAPI documentation
- Standard RESTful API endpoints
- GUID-based entity IDs
- Error handling and logging
- Development tooling

## Getting Started

### Prerequisites

- .NET 8.0 SDK or later
- Visual Studio 2022, Visual Studio Code, or any preferred IDE

### Running the API

```bash
# Clone the repository
git clone <repository-url>

# Navigate to the project directory
cd dotnet-template

# Build the solution
dotnet build

# Run the API
dotnet run
```

The API will be available at:
- API endpoints: https://localhost:5001/api/items
- Swagger UI: https://localhost:5001/

## API Endpoints

| Method | Endpoint | Description |
|--------|----------|-------------|
| GET    | /api/items | Get all items |
| GET    | /api/items/{id} | Get item by ID |
| POST   | /api/items | Create a new item |
| PUT    | /api/items/{id} | Update an item |
| DELETE | /api/items/{id} | Delete an item |

## Project Structure

```
dotnet-template/
├── Controllers/          # API controllers
├── Models/               # Data models/DTOs
├── Services/             # Business logic services
│   └── Interfaces/       # Service interfaces
├── Properties/           # Application properties
├── appsettings.json      # Application settings
└── Program.cs            # Application entry point
```

## Documentation

API documentation is available via Swagger UI at the application's root URL.

## License

[MIT](LICENSE)
