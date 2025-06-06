# Supplier Due Diligence Backend

Backend API for supplier screening and due diligence built with .NET 9.0 (ASP.NET Core).

This backend provides endpoints to manage suppliers, perform entity screening, and authenticates requests using JWT tokens. It internally communicates with a Risk Entity Scraper backend service for advanced screening functionality.

## 📁 Repository Structure

```bash
SupplierDueDiligence-backend/
│
├── SupplierDueDiligence.API/
│ ├── Api/
│ │ ├── Controllers/ # API Controllers
│ │ ├── Filters/ # Custom filters (e.g. model validation)
│ │ ├── Middlewares/ # Custom middlewares (e.g. exception handling)
│ ├── Config/ # Configuration files & helpers
│ ├── Data/ # Database context and data-related classes
│ ├── Domain/ # Business domain models and logic
│ ├── Infraestructure/ # Infrastructure layer (DB, external services)
│ ├── Migrations/ # EF Core database migrations
│ ├── appsettings.json # Main config file
│ ├── appsettings.Development.json # Development config overrides
│ ├── Program.cs # Main application entry point
│ └── SupplierDueDiligence.API.csproj
│
└── SupplierDueDiligence.sln # Solution file
```

---

## ⚙️ Prerequisites

- [.NET 9.0 SDK](https://dotnet.microsoft.com/en-us/download/dotnet/9.0)
- SQL Server instance (local or remote)
- [Risk Entity Scraper Backend](https://github.com/JexUgaz/risk-entity-scraper) running and accessible

---

## 🚀 Getting Started

### 1. Clone the repository

```bash
git clone https://github.com/JexUgaz/SupplierDueDiligence-backend.git
cd SupplierDueDiligence-backend/SupplierDueDiligence.API
```

### 2. Configure environment variables and settings

Copy and edit your config files:

```bash
cp appsettings.Development.json.example appsettings.Development.json
```

Or edit appsettings.Development.json to update values like:

- ConnectionStrings:DefaultConnection — your SQL Server connection string

- Jwt — JWT configuration (Key, Issuer, Audience, Expiry)

- Internal — Internal API URL and secret key for communication with Risk Entity Scraper backend

- Cors:AllowedOrigins — an array of allowed origins for Cross-Origin Resource Sharing (CORS).  
   This should include the base URL(s) of the frontend application(s) consuming this API.  
   For example, if your React frontend runs on `http://localhost:5173` during development, include this URL here.  
   When deploying, replace or add the production frontend URL(s) to ensure proper communication and security.
  Example snippet:

```json
{
  "ConnectionStrings": {
    "DefaultConnection": "Server=localhost\\SQLEXPRESS;Database=SupplierDueDiligence;Trusted_Connection=True;TrustServerCertificate=True"
  },
  "Settings": {
    "Cors": {
      "AllowedOrigins": ["http://localhost:5173"]
    },
    "Jwt": {
      "Key": "your_jwt_secret_key",
      "Issuer": "https://localhost:5001",
      "Audience": "https://localhost:3000",
      "ExpiresInMinutes": 60
    },
    "Internal": {
      "InternalSecretKey": "your_internal_secret_key",
      "InternalApiUrl": "http://localhost:3000/internal"
    },
    "ChromeExecutablePath": "C:\\Program Files\\Google\\Chrome\\Application\\chrome.exe"
  }
}
```

Note: The InternalSecretKey must exactly match the key configured in the Risk Entity Scraper backend.

### 3. Setup and run the Risk Entity Scraper backend

This project depends on the scraper backend for /internal/screening API routes:

Clone the scraper backend:

```bash
git clone https://github.com/JexUgaz/risk-entity-scraper.git
cd risk-entity-scraper
```

- Follow its README instructions to install dependencies and run it.

- Ensure it is running and reachable at the URL set in InternalApiUrl.

### 4. Install dependencies

Restore all NuGet packages before running or building the project:

```bash
dotnet restore
```

### 5. Apply database migrations

Make sure your database is accessible, then apply migrations:

```bash
dotnet ef database update
```

### 6. Run the backend API

Run the API locally:

```bash
dotnet run
```

By default, the API will listen on the port specified in your configuration.

## 🛠️ API Overview

- AuthController — JWT authentication endpoints

- SuppliersController — CRUD operations for suppliers

- ScreeningController — Screening endpoints that communicate internally with the scraper backend

- CountriesController — Country related data

## ⚠️ Important Notes

- Internal communication with the scraper backend is secured using the InternalSecretKey. Both backends must use the same key for authorization.

- SQL Server must allow connections and be accessible by the backend.

- The backend is configured for development with appsettings.Development.json. Adjust accordingly for production.

## 🧰 Tech Stack

- .NET 9.0 / ASP.NET Core Web API

- Entity Framework Core with SQL Server

- JWT Authentication

- Internal HTTP client communication between microservices

- Google Chrome headless for scraping
