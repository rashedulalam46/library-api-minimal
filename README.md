# Library API (Minimal API)
Library API is a Minimal API project for managing a library system, built with .NET 9, SQL Server, and the Repository Pattern. It provides CRUD operations for Books, Authors, Categories, and Publishers, along with dropdown endpoints to support frontend selection.

Minimal APIs in .NET allow you to build lightweight, fast HTTP APIs without controllers or Startup classes. Introduced in .NET 6, they simplify the development of microservices, small apps, or prototypes while remaining production-ready.

**Key Idea:**
Instead of using the traditional MVC pattern, endpoints are defined directly in Program.cs (or via organized endpoint classes), using simple route mappings for clean and efficient API design.

## 🛠️ Features

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

## 📂 Folder Structure
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

## ⚙️ Requirements
- .NET 9 SDK
- SQL Server (local or remote)
- Visual Studio 2022 / Visual Studio Code

## 🔧 Installation

**1. Clone the repository:**
```
git clone https://github.com/rashedulalam46/library-api-minimal.git
cd library-api-minimal
```

Configure the database in appsettings.json:
```
"ConnectionStrings": {
  "DefaultConnection": "Server=YOUR_SERVER;Database=LibraryDb;Trusted_Connection=True;"
}
```

**2. Apply migrations / create database**

Run the SQL script located in **Library.Infrastructure/Data/DatabaseScript.sql** to create the database and tables.   
Alternatively, to create the database and tables using Entity Framework, run the following command in the Infrastructure project (or from the solution root):

```
dotnet ef database update
```

This will create the database and necessary tables.

## 🚀 API Endpoints

**Books:**

- GET /api/books – Get all books
- GET /api/books/{id} – Get book by ID
- POST /api/books – Add new book
- PUT /api/books/{id} – Update book
- DELETE /api/books/{id} – Delete book
  
**Authors**

- GET /api/authors – Get all authors
- GET /api/authors/{id} – Get author by ID
- POST /api/authors – Add new author
- PUT /api/authors/{id} – Update author
- DELETE /api/authors/{id} – Delete author

**Categories:**

- GET /api/categories – Get all categories
- GET /api/categories/{id} – Get category by ID
- POST /api/categories – Add new category
- PUT /api/categories/{id} – Update category
- DELETE /api/categories/{id} – Delete category

**Publishers:**

- GET /api/publishers – Get all publishers
- GET /api/publishers/{id} – Get publisher by ID
- POST /api/publishers – Add new publisher
- PUT /api/publishers/{id} – Update publisher
- DELETE /api/publishers/{id} – Delete publisher

**Dropdowns:**

- GET /api/dropdown/countries – Get country list
- GET /api/dropdown/authors – Get authors list
- GET /api/dropdown/publishers – Get publishers list
- GET /api/dropdown/categories – Get categories list




