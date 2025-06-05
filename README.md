
# 📝 TodoApi

**TodoApi** is a lightweight and extensible RESTful API for managing to-do tasks, built with **ASP.NET Core**. It supports full **CRUD operations**, leverages **Entity Framework Core** for data persistence, and uses **AutoMapper** for clean DTO handling. This project is ideal for learning modern Web API development or serving as a boilerplate for production-ready APIs.

---

## 🚀 Features

- Retrieve all tasks
- Retrieve a task by ID
- Create a new task
- Update an existing task
- Delete a task
- DTO mapping using AutoMapper
- Integrated Swagger UI for API documentation

---

## 🛠️ Technologies Used

- **ASP.NET Core Web API**
- **Entity Framework Core** (with SQLite)
- **AutoMapper** for model-to-DTO mapping
- **Swagger/OpenAPI** for documentation
- **Docker** support for containerization

---

## ▶️ Getting Started

### Prerequisites

- [.NET 7 SDK](https://dotnet.microsoft.com/en-us/download)
- [SQLite](https://www.sqlite.org/index.html) (optional, unless using external tools)
- [EF Core CLI tools](https://learn.microsoft.com/en-us/ef/core/cli/dotnet)

### Running Locally

1. Navigate to the project directory:

   ```bash
   cd TodoApi
   ```

2. Restore dependencies:

   ```bash
   dotnet restore
   ```

3. Apply migrations and initialize the database:

   ```bash
   dotnet ef database update
   ```

4. Launch the API:

   ```bash
   dotnet run
   ```

By default, the API will be available at:

- `https://localhost:5001`
- `http://localhost:5000`

Swagger UI will be accessible at `/swagger`.

---

## 🐳 Docker Support (Optional)

Build and run the project inside a Docker container:

### Dockerfile

```dockerfile
FROM mcr.microsoft.com/dotnet/aspnet:7.0 AS base
WORKDIR /app
EXPOSE 80

FROM mcr.microsoft.com/dotnet/sdk:7.0 AS build
WORKDIR /src
COPY ["TodoApi/TodoApi.csproj", "TodoApi/"]
RUN dotnet restore "TodoApi/TodoApi.csproj"
COPY . .
WORKDIR "/src/TodoApi"
RUN dotnet build "TodoApi.csproj" -c Release -o /app/build

FROM build AS publish
RUN dotnet publish "TodoApi.csproj" -c Release -o /app/publish

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "TodoApi.dll"]
```

### Run Docker

```bash
docker build -t todoapi .
docker run -p 5000:80 todoapi
```

---

## 📁 Project Structure

```
TodoApi/
├── Controllers/      # Web API endpoints
├── Models/           # EF Core entity models
├── Dtos/             # Data Transfer Objects
├── Mappings/         # AutoMapper profiles
├── Data/             # DbContext and configuration
├── Migrations/       # Entity Framework migrations
├── Program.cs        # Application startup
├── Dockerfile        # Docker container definition
├── README.md         # Project documentation
```

---

## 📄 License

This project is licensed under the MIT License.
