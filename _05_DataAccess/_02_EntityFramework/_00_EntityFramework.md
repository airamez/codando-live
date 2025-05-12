# Entity Framework with C# and .NET Core

[Entity Framework (EF)](https://learn.microsoft.com/en-us/ef/) is an Object-Relational Mapping (ORM) framework for .NET applications that simplifies database access. It allows developers to work with databases using strongly-typed objects rather than SQL queries.

>Entity Framework is a modern object-relation mapper that lets you build a clean, portable, and high-level data access layer with .NET (C#) across a variety of databases, including SQL Database (on-premises and Azure), SQLite, MySQL, PostgreSQL, and Azure Cosmos DB. It supports LINQ queries, change tracking, updates, and schema migrations.

* Object-Relational Mapping (ORM)

  * Object-Relational Mapping (ORM) is a programming technique that allows developers to interact with a relational database using object-oriented principles rather than writing raw SQL queries. It essentially acts as a bridge between an application's code and its database, converting data between incompatible systems—objects in a programming language and tables in a database.
  * With ORM, each database table corresponds to a class in the code, and each row in the table represents an instance of that class. This abstraction simplifies data manipulation, making it easier to create, read, update, and delete records without manually handling SQL syntax.
  * ORM frameworks, such as Hibernate for Java, Entity Framework for .NET, and SQLAlchemy for Python, automate the mapping process, improving efficiency, reducing boilerplate code, and enhancing security by preventing SQL injection attacks.

* Setting Up Entity Framework Core

  ```shell
  dotnet add package Microsoft.EntityFrameworkCore
  dotnet add package Microsoft.EntityFrameworkCore.SqlServer
  dotnet add package Microsoft.EntityFrameworkCore.Tools
  ```

* Installing the [dotnet-ef tool](https://learn.microsoft.com/en-us/ef/core/cli/dotnet)

  ```shell
  dotnet tool install --global dotnet-ef

  dotnet ef
  ```

* Generate the ORM model from the database

  * Providing the Connection String

    ```shell
    dotnet ef dbcontext scaffold 'Server=localhost,1433;Database=NorthWind;User Id=sa;Password=Password!;TrustServerCertificate=True;' Microsoft.EntityFrameworkCore.SqlServer --output-dir Models --force
    ```

  * Using a connection from the `appsettings.json` file

    ```shell
    connectionString=$(jq -r '.ConnectionStrings.MySQLConnection' appsettings.json)
    dotnet ef dbcontext scaffold "$connectionString" Microsoft.EntityFrameworkCore.SqlServer --output-dir Models --force
    ```

>Note: The `--force` option indicate to overwrite existing files

* The Model classes
  * Explore the content of the Model folder
  * Explore the [NorthWindContext.cs](../Models/NorthWindContext.cs) class

* Using the DB Context

  ```csharp
  var optionsBuilder = new DbContextOptionsBuilder<NorthWindContext>();
  optionsBuilder.UseSqlServer(ConnectionString.GetConnectionString());
  using (var context = new NorthWindContext(optionsBuilder.Options))
  {
    // Coding here
  }
  ```

* Listing all Products

  ```csharp
  var optionsBuilder = new DbContextOptionsBuilder<NorthWindContext>();
  optionsBuilder.UseSqlServer(ConnectionString.GetConnectionString());
  using (var context = new NorthWindContext(optionsBuilder.Options))
  {
    List<Product> products = context.Products.ToList();
    foreach (var product in products)
    {
      Console.WriteLine($"[{product.ProductId}; {product.ProductName}; {product.UnitPrice}]");
    }
  }  
  ```

* Add new Customer

  ```csharp
  var customer = new Customer
  {
      CustomerID = "NEWC1",
      CompanyName = "New Customer Inc.",
      ContactName = "John Doe"
  };
  context.Customers.Add(customer);
  context.SaveChanges();
  ```

* Find a specific Customer

  ```csharp
  var foundCustomer = context.Customers.FirstOrDefault(c => c.CustomerId == "NEWC1");
  if (newCustomer != null)
  {
    Console.WriteLine($"{foundCustomer.CustomerId}; {foundCustomer.CompanyName}; {foundCustomer.ContactName}");
  }
  ```

* Updating

  ```csharp
  foundCustomer.CompanyName = "Updated Customer Inc.";
  context.SaveChanges();
  ```

* Deleting

  ```csharp
  context.Customers.Remove(foundCustomer);
  context.SaveChanges();
  ```

* Querying with LINQ

  ```csharp
      var customers = context.Customers
        .Where(c => c.Country == "Brazil" && c.City == "Sao Paulo")
        .ToList();
      customers.ForEach(c => Console.WriteLine($"{c.CustomerId}; {c.CompanyName}; {c.Country}, {c.City}"));
  ```

* Accessing Relationships

  ```csharp
  var customersWithOrder = context.Customers
    .Include(c => c.Orders)           // Orders
    .ThenInclude(o => o.OrderDetails) // OrderDetails
    .ThenInclude(od => od.Product)    // Product
    .ToList();

  foreach (var customer in customers)
  {
    Console.WriteLine($"[{customer.CustomerId}]: {customer.CompanyName}");
    foreach (var order in customer.Orders)
    {
      Console.WriteLine($"* {order.OrderId}; {order.OrderDate}");
      foreach (var detail in order.OrderDetails)
      {
        Console.Write($"  - {detail.ProductId}; {detail.Product.ProductName}; ");
        Console.Write($"{detail.Quantity}; ${detail.UnitPrice:N2}; ");
        Console.WriteLine($"${detail.Quantity * detail.UnitPrice:N2}");
      }
    }
    Console.WriteLine("".PadLeft(60, '-'));
  }
  ```

* Using Transaction

  ```csharp
  using (var transaction = context.Database.BeginTransaction())
  {
    try
    {
      int sourceAccountId = 1;
      int targetAccountId = 2;
      decimal amount = 100;
      var sourceAccount = context.Accounts.Find(sourceAccountId);
      var targetAccount = context.Accounts.Find(targetAccountId);
      if (sourceAccount == null) throw new Exception("Source Account ID is invalid");
      if (targetAccount == null) throw new Exception("Target Account ID is invalid");
      if (sourceAccount.Amount < amount)
      {
        throw new Exception("Insufficient funds.");
      }
      sourceAccount.Amount -= amount;
      targetAccount.Amount += amount;
      context.SaveChanges();
      transaction.Commit();
    }
    catch (Exception ex)
    {
      transaction.Rollback();
      Console.WriteLine($"Transaction failed: {ex.Message}");
    }
  }
  ```

* Calling Stored Procedure

  ```csharp
  try
  {
    var sourceAccountIdParam = new SqlParameter("@SourceAccountId", 2);
    var targetAccountIdParam = new SqlParameter("@TargetAccountId", 1);
    var amountParam = new SqlParameter("@Amount", 100);

    context.Database.ExecuteSqlRaw("EXEC TransferAmount @SourceAccountId, @TargetAccountId, @Amount",
                                    sourceAccountIdParam, targetAccountIdParam, amountParam);
  }
  catch (Exception ex)
  {
    Console.WriteLine(ex.Message);
  }
  ```
