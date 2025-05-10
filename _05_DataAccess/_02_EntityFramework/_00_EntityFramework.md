# Introduction to Entity Framework with C# and .NET Core

Entity Framework (EF) is an Object-Relational Mapping (ORM) framework for .NET applications that simplifies database access. It allows developers to work with databases using strongly-typed objects rather than raw SQL queries.

* Setting Up Entity Framework Core
Run the following command in the terminal to install EF Core:

  ```shell
  dotnet add package Microsoft.EntityFrameworkCore
  dotnet add package Microsoft.EntityFrameworkCore.SqlServer
  dotnet add package Microsoft.EntityFrameworkCore.Tools
  ```

  ```shell
  dotnet tool install --global dotnet-ef
  dotnet ef --version
  ```

  ```shell
  dotnet ef dbcontext scaffold 'Server=localhost,1433;Database=NorthWind;User Id=sa;Password=Password!;TrustServerCertificate=True;' Microsoft.EntityFrameworkCore.SqlServer --output-dir Models
  ```

  ```shell
  connectionString=$(jq -r '.ConnectionStrings.MySQLConnection' appsettings.json)
  dotnet ef dbcontext scaffold "$connectionString" Microsoft.EntityFrameworkCore.SqlServer --output-dir Models
  ```

  ```shell
  $connectionString = (Get-Content appsettings.json | ConvertFrom-Json).ConnectionStrings.DefaultConnection
  dotnet ef dbcontext scaffold "$connectionString" Microsoft.EntityFrameworkCore.SqlServer --output-dir Models
  ```

  ```csharp
  using Microsoft.EntityFrameworkCore;

  public class NorthwindContext : DbContext
  {
      public DbSet<Customer> Customers { get; set; }
      public DbSet<Order> Orders { get; set; }
      protected override void OnConfiguring(DbContextOptionsBuilder options)
      {
          options.UseSqlServer("Server=your_server;Database=Northwind;Trusted_Connection=True;");
      }
  }
  ```

* Add new Customer

  ```csharp
  using (var context = new NorthwindContext())
  {
      var customer = new Customer
      {
          CustomerID = "NEWC1",
          CompanyName = "New Customer Inc.",
          ContactName = "John Doe"
      };
      context.Customers.Add(customer);
      context.SaveChanges();
  }
  ```

* Fetching all customers

  ```csharp
  using (var context = new NorthwindContext())
  {
      var customers = context.Customers.ToList();
      foreach (var customer in customers)
      {
          Console.WriteLine($"{customer.CompanyName} - {customer.ContactName}");
      }
  }
  ```

* Query for a specific Customer

  ```csharp
  using (var context = new NorthwindContext())
  {
      var customer = context.Customers.FirstOrDefault(c => c.CustomerID == "NEWC1");
      if (customer != null)
      {
          Console.WriteLine($"Customer: {customer.CompanyName}");
      }
  }  
  ```

* Updating

  ```csharp
  using (var context = new NorthwindContext())
  {
      var customer = context.Customers.FirstOrDefault(c => c.CustomerID == "NEWC1");
      if (customer != null)
      {
          customer.CompanyName = "Updated Customer Inc.";
          context.SaveChanges();
      }
  }
  ```

* Deleting

  ```csharp
  using (var context = new NorthwindContext())
  {
      var customer = context.Customers.FirstOrDefault(c => c.CustomerID == "NEWC1");
      if (customer != null)
      {
          context.Customers.Remove(customer);
          context.SaveChanges();
      }
  }
  ```

* Querying with LINQ

  ```csharp
  using (var context = new NorthwindContext())
  {
      var customers = context.Customers.Where(c => c.CompanyName.Contains("Food")).ToList();
  }
  ```

* Joins

  ```csharp
  using (var context = new NorthwindContext())
  {
      var orders = context.Orders.Include(o => o.Customer).ToList();
  }
  ```
