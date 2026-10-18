dotnet new sln -n Shop
dotnet new classlib -o Shop.Data
dotnet new webapi -o Shop.Api --use-controllers --no-openapi
dotnet new mvc -o Shop.Portal
dotnet new mvc -o Shop.Web
dotnet sln add Shop.Data/Shop.Data.csproj Shop.Api/Shop.Api.csproj Shop.Portal/Shop.Portal.csproj Shop.Web/Shop.Web.csproj

dotnet add Shop.Api reference Shop.Data
dotnet add Shop.Portal reference Shop.Data
dotnet add Shop.Web reference Shop.Data

dotnet add Shop.Data package Microsoft.EntityFrameworkCore.SqlServer
dotnet add Shop.Web package Microsoft.EntityFrameworkCore.Design
dotnet add Shop.Web package SimpleHashing.Net