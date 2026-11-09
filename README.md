# PortfolioApi

Backend voor mijn portfoliosite (WPFW opdracht 3). Met deze API kun je **projecten** en **blogposts** aanmaken, opvragen, wijzigen en verwijderen (CRUD).

## Overzicht

| Onderdeel | Keuze |
|---|---|
| .NET-versie | .NET 10 (`net10.0`) |
| API-stijl | Controllers (`[ApiController]`) |
| Codestructuur | Lagen: Controllers, Services en Data |
| Database | SQL Server (LocalDB) met EF Core |
| Database aanmaken | EF Core-migratie (`InitialCreate`) |
| Testen | Swagger UI (Swashbuckle.AspNetCore) |

## Mappen

```
PortfolioApi/
  Controllers/   Laag 3 (Presentation): ontvangt HTTP-requests en kiest het HTTP-resultaat
  Services/      Laag 2 (Business Logic): de logica en de omzetting tussen entity en DTO
  Data/          Laag 1 (Data Access): PortfolioDb (DbContext) en de migraties
  Models/        Entities: Project en Blogpost (zo staan ze in de database)
  DTOs/          Wat de API ontvangt (Create/Update...Request) en terugstuurt (...Response)
  Program.cs     Startpunt: services registreren (DI), Swagger en controllers
```

## Endpoints

| Methode | Route | Wat het doet |
|---|---|---|
| GET | `/api/Projects` | Alle projecten |
| GET | `/api/Projects/{id}` | Eén project (404 als het niet bestaat) |
| POST | `/api/Projects` | Project aanmaken (201) |
| PUT | `/api/Projects/{id}` | Project wijzigen (204 of 404) |
| DELETE | `/api/Projects/{id}` | Project verwijderen (204 of 404) |
| GET | `/api/Blogposts` | Alle blogposts |
| GET | `/api/Blogposts/{id}` | Eén blogpost (404 als het niet bestaat) |
| POST | `/api/Blogposts` | Blogpost aanmaken (201) |
| PUT | `/api/Blogposts/{id}` | Blogpost wijzigen (204 of 404) |
| DELETE | `/api/Blogposts/{id}` | Blogpost verwijderen (204 of 404) |

## SQL Server instellen

Ik gebruik **SQL Server LocalDB**. Die wordt mee geïnstalleerd met Visual Studio. Controleer of je hem hebt:

```
sqllocaldb info
```

Je moet dan `MSSQLLocalDB` zien.

De connection string staat in `appsettings.json` onder `ConnectionStrings:Portfolio`:

```
Server=(localdb)\MSSQLLocalDB;Database=PortfolioDb;Trusted_Connection=True;
```

LocalDB logt in met je Windows-account. Er staat dus geen wachtwoord in. Gebruik je een andere SQL Server, pas dan alleen deze connection string aan.

## Database aanmaken (migratie)

De database wordt gemaakt met een **EF Core-migratie**. De migratie staat in `Data/Migrations`.

1. Installeer de EF Core-tool (één keer):
   ```
   dotnet tool install --global dotnet-ef --version 10.0.14
   ```
2. Voer de migratie uit. Dit maakt de database `PortfolioDb` met de tabellen `Projects` en `Blogposts`:
   ```
   dotnet ef database update
   ```

## Applicatie starten

```
dotnet run
```

Open daarna Swagger UI: http://localhost:5068/swagger

## Gebruikte NuGet-pakketten

- `Swashbuckle.AspNetCore`: Swagger UI
- `Microsoft.EntityFrameworkCore.SqlServer`: EF Core-provider voor SQL Server
- `Microsoft.EntityFrameworkCore.Design`: nodig voor migraties
- `System.Security.Cryptography.Pkcs`: nieuwere versie, om een beveiligingswaarschuwing van een onderliggend pakket op te lossen
