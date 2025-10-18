# Library API Minimal
A Minimal API project for managing a library system, built with .NET 9, SQL Server, and the Repository Pattern.
This project provides CRUD operations for Books, Authors, Categories, Publishers, and Members, along with endpoints for dropdown lists to facilitate frontend selection.

# 🛠️ Features

Minimal API with .NET 9
- CRUD operations for all main entities:
  - Books
  - Authors
  - Categories
  - Publishers
- Repository Pattern for clean separation of concerns
- DTOs for optimized data transfer
- Swagger/OpenAPI documentation
- Dropdown endpoints for UI forms: Authors, Categories, Publishers, Countries

# 📂 Folder Structure
```
LibraryApiMinimal/
├── Application/
│   ├── DTOs/
│   └── Interfaces/
│       └── IDropdownRepository.cs
├── Domain/
│   └── Entities/
├── Infrastructure/
│   ├── Data/           # DbContext
│   ├── Repositories/   # Repository implementations
│   └── Services/       # Optional services
├── Endpoint/          # Minimal API endpoints
│   ├── BookEndpoint.cs
│   ├── AuthorEndpoint.cs
│   ├── CategoryEndpoint.cs
│   ├── PublisherEndpoint.cs
│   └── DropdownEndpoint.cs
├── Program.cs
└── appsettings.json
```

