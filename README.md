# Reactivities

Reactivities is a web application built with C# and ASP.NET Core. The project serves as a learning platform for building modern web APIs and client-side applications.

## Features

- ASP.NET Core backend API
- Entity Framework Core for data access
- Basic CRUD operations for activities
- RESTful API endpoints

## DB Migration Steps

> [!NOTE]
> Make sure that the db container is running

1. Create a Migration

```bash
dotnet ef migrations add MIGRATION_NAME --project Persistence --startup-project API
```

2. Apply the migration

```bash
dotnet ef database update --project Persistence --startup-project API
```

3. Run the application

```bash
dotnet run --project API
```

## Status

This project is under active development. More features and a client-side application will be added soon.
