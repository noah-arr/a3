## Project Setup Commands

Run the following commands in your terminal to initialize the **Shop** solution, create the projects, set up references, and install the required NuGet packages.

### 1. Initialize Solution and Create Projects
```bash
# Create the solution file
dotnet new sln -n Shop

# Create the project libraries and applications
dotnet new classlib -o Shop.Data
dotnet new webapi -o Shop.Api --use-controllers --no-openapi
dotnet new mvc -o Shop.Portal
dotnet new mvc -o Shop.Web

# Add projects to the solution
dotnet sln add Shop.Data/Shop.Data.csproj \
               Shop.Api/Shop.Api.csproj \
               Shop.Portal/Shop.Portal.csproj \
               Shop.Web/Shop.Web.csproj
```

### 2. Configure Project References
```bash
# Reference the Data layer in the API, Portal, and Web applications
dotnet add Shop.Api reference Shop.Data
dotnet add Shop.Portal reference Shop.Data
dotnet add Shop.Web reference Shop.Data
```

### 3. Install NuGet Packages
```bash
# Install Entity Framework Core SQL Server provider to the Data layer
dotnet add Shop.Data package Microsoft.EntityFrameworkCore.SqlServer

# Install Entity Framework Core Design tools to the Web layer
dotnet add Shop.Web package Microsoft.EntityFrameworkCore.Design

# Install SimpleHashing package to the Web layer
dotnet add Shop.Web package SimpleHashing.Net
```

### 4. database stuffs
dotnet ef migrations add InitialCreate --project School.Data --startup-project School.Web
dotnet ef database update --project School.Data --startup-project School.Web