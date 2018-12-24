# Migrations

Define the path where migration folder will be created when you create you first migration (initial migration)

[Stackoverflow Link](https://stackoverflow.com/questions/40696305/how-to-change-the-output-folder-for-migrations-with-asp-net-core)
```
dotnet ef migrations add InitialCreate -o DataAccess/Database/Migrations
```