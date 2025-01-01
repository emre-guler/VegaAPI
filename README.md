# Vega API

A secure and scalable ASP.NET Core Web API project with user authentication, email verification, and content management features.

## Features

- User Authentication with JWT
- Email Verification System
- Password Reset Functionality
- User Management
- Content Management
- Swagger API Documentation
- SQL Server Database Integration
- Background Job Processing (Hangfire)
- Auto Mapping (AutoMapper)

## Technologies

- ASP.NET Core 5.0
- Entity Framework Core 6.0
- SQL Server
- JWT Authentication
- Hangfire
- AutoMapper
- BCrypt.Net
- Swagger/OpenAPI

## Prerequisites

- .NET 5.0 SDK
- SQL Server
- SMTP Server (for email functionality)

## Configuration

The application uses `appsettings.json` for configuration. You need to set up the following:

- Database Connection String
- JWT Settings
- Mail Service Settings

Example configuration:

```json
{
  "JWT": {
    "SecureKey": "your-secure-key"
  },
  "ConnectionStrings": {
    "DefaultConnectionString": "your-connection-string"
  },
  "MailService": {
    "MailAddress": "your-email@domain.com",
    "Password": "your-password",
    "Port": "587",
    "Host": "your-smtp-host",
    "SSL": "true"
  }
}
```

## Getting Started

1. Clone the repository
2. Update the connection string in `appsettings.json`
3. Run database migrations:
   ```bash
   dotnet ef database update
   ```
4. Run the application:
   ```bash
   dotnet run
   ```

The API will be available at:
- HTTPS: https://localhost:5001
- HTTP: http://localhost:5000
- Swagger UI: https://localhost:5001/swagger

## API Endpoints

The API includes the following main endpoints:

- `/User` - User management and authentication
- `/Admin` - Administrative functions
- `/Content` - Content management

For detailed API documentation, visit the Swagger UI endpoint when running the application.