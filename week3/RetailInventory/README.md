```sh
dotnet new console -n RetailInventory && cd RetailInventory
dotnet add package Microsoft.EntityFrameworkCore.SqlServer --version 9.0.5
dotnet add package Microsoft.EntityFrameworkCore.Design --version 9.0.6

docker compose up --build -d # start the sql server
dotnet new tool-manifest
dotnet tool install --local dotnet-ef --version 9.0.6

# generate migrations. note that only after running migrations will you be able to interact with the generated db
dotnet ef migrations add InitialCreate
dotnet ef database update

# Uncomment the Lab 4 part in Program.cs to insert data first, comment out the Lab 5 part
dotnet run

# Now comment out Lab 4 and run Lab 5
dotnet run
```