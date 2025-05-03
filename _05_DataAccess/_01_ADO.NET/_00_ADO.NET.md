# ADO.NET Overview

## What is ADO.NET?

[ADO.NET (ActiveX Data Objects for .NET)](https://learn.microsoft.com/en-us/dotnet/framework/data/adonet/) is a data access technology from the Microsoft .NET Framework. It provides a bridge between the front-end application (Server-Side if web) and back-end databases, enabling interaction through SQL queries or stored procedures.

## Key Features

* Works with a variety of databases (e.g., SQL Server, Oracle, MySQL).
* Supports disconnected data access using `DataSet` and `DataTable`.
* Provides robust support for transactions, error handling, and performance.

## Database Connection

 A **Connection** establishes a link between the application and the database.

* [**Connection String**](https://learn.microsoft.com/en-us/dotnet/framework/data/adonet/connection-string-syntax): A string that specifies details for connecting to the database, including server name, database name and type, credentials, and configuration options.

  ```csharp
  string connectionString = "Server=myServerAddress;Database=myDataBase;User Id=myUsername;Password=myPassword;";
  ```

> ⚠️ **Warning**: A best practice is to keep the Connection String in a [Application Configuration File](https://learn.microsoft.com/en-us/dotnet/framework/data/adonet/connection-strings-and-configuration-files)

* [Connection Strings Templates](https://www.connectionstrings.com/)
* Opening and Closing Database Connection
  * Always open the connection before performing operations.
  * Close the connection as soon as operations are complete to release resources.

    ```csharp
    ...
    string connectionString = "Server=myServerAddress;Database=myDataBase;User Id=myUsername;Password=myPassword;";
    SqlConnection connection = new SqlConnection(connectionString);
    connection.Open(); // Opens the connection

    // Perform database operations here

    connection.Close(); // Closes the connection
    ```

    ```csharp
    ...
    // Best practice way
    using (SqlConnection connection = new SqlConnection(connectionString))
    {
        connection.Open(); // Opens the connection
        Console.WriteLine("Connection opened!");

        // Perform database operations here

        // No need to explicitly close the connection; the using statement handles it.
    }
    ```

## Executing SQL Commands

ADO.NET uses the SqlCommand object to execute any type of SQL statements from quries to stored procedures.

* Types of SQL Commands:
  * `SELECT`: Retrieve data from the database.
  * `INSERT`: Add new records.
  * `UPDATE`: Modify existing records.
  * `DELETE`: Remove records.
  * `CREATE`, `ALTER`, `DROP` database objects,
  * Execute: Functions and Stored Procedures
* Example: Executing a query to read data from Products table

  ```csharp
  string query = "SELECT ProductID, ProductName, UnitPrice FROM Products";
  using (SqlConnection connection = new SqlConnection(connectionString))
  {
      connection.Open();
      using (SqlCommand command = new SqlCommand(query, connection))
      {
          using (SqlDataReader reader = command.ExecuteReader())
          {
              while (reader.Read())
              {
                  Console.Write($"ID: {reader["ProductID"]}; ");
                  Console.Write($"Name: {reader["ProductName"]}");
                  Console.WriteLine($"Price: {reader["UnitPrice"]}");
              }
          }
      }
  }
  ```

> ⚠️ **Warning**: It is necessary to add this package to the project

```bash
dotnet add package Microsoft.Data.SqlClient
```

> ⚠️ **Warning**: This `System.Data.SqlClient` was the most common package but now it is deprecated

### Defining the Connection String in a configuration file

#### Configuration Files in .NET Core

* [Configuration management](https://learn.microsoft.com/en-us/dotnet/core/extensions/configuration) is a critical part of building applications, as it allows developers to manage settings and secrets outside of the source code.
In .NET Core, configuration is highly flexible, enabling you to load configurations.
* Configuration in .NET Core allows applications to:
  * Read settings from various sources (JSON files, environment variables, command-line arguments, etc.).
  * Adapt to different environments (development, E2E, staging, production).
* `appsettings.json` file
  * The `appsettings.json` file is the primary configuration file in .NET Core projects and it is used to store application-level settings in a key-value pair format.
* Example:

  ```json
  {
    "ConnectionStrings": {
      "PrimaryDatabase": "Server=remotehost1,1433;Database=NorthWind;User Id=sa;Password=Password!",
      "SecondaryDatabase": "Server=remotehost2,1434;Database=Products;User Id=admin;Password=SecurePassword!"
    },
    "WebApis": {
      "UserApi": "https://api.myapp.com/users",
      "OrderApi": "https://api.myapp.com/orders",
      "InventoryApi": "https://api.myapp.com/inventory"
    },
    "Constants": {
      "TimeoutSeconds": 30,
      "ReadFolderPath": "C:\\MyApp\\InputFiles",
      "WriteFolderPath": "C:\\MyApp\\OutputFiles"
    }
  }
  ```

* Configuration file location
  * The configuration files can be stored anywhere in the file system.
  * In a console application, usually they are copied to the target folder.
  * It can be added to the project file (.csproj)

    ```xml
    <Project Sdk="Microsoft.NET.Sdk">
      <PropertyGroup>
        <OutputType>Exe</OutputType>
        <TargetFramework>net9.0</TargetFramework>
        <StartupObject>AppSettingsApp</StartupObject>
      </PropertyGroup>
      <ItemGroup>
        ...
        <None Update="appsettings.json">
          <CopyToOutputDirectory>PreserveNewest</CopyToOutputDirectory>
        </None>
        <None Update="appsettingsDEMO.json">
          <CopyToOutputDirectory>PreserveNewest</CopyToOutputDirectory>
        </None>
      </ItemGroup>
    </Project>
    ```

* How to read (load or build) the configurations from C#

  ```csharp
  var configuration = new ConfigurationBuilder()
      .SetBasePath(AppContext.BaseDirectory)directory
      .AddJsonFile("appsettingsDEMO.json", optional: false, reloadOnChange: true)
      .Build();

  string primaryDb = configuration.GetConnectionString("PrimaryDatabase");
  string secondaryDb = configuration.GetConnectionString("SecondaryDatabase");
  string userApi = configuration["WebApis:UserApi"];
  string orderApi = configuration["WebApis:OrderApi"];
  string inventoryApi = configuration["WebApis:InventoryApi"];
  int timeout = int.Parse(configuration["Constants:TimeoutSeconds"]);
  string readFolder = configuration["Constants:ReadFolderPath"];
  string writeFolder = configuration["Constants:WriteFolderPath"];

  Console.WriteLine($"Primary Database: {primaryDb}");
  Console.WriteLine($"Secondary Database: {secondaryDb}");
  Console.WriteLine($"User API: {userApi}");
  Console.WriteLine($"Order API: {orderApi}");
  Console.WriteLine($"Inventory API: {inventoryApi}");
  Console.WriteLine($"Timeout: {timeout} seconds");
  Console.WriteLine($"Read Folder Path: {readFolder}");
  Console.WriteLine($"Write Folder Path: {writeFolder}");
  ```

> ⚠️ **Warning**: It is necessary to add these packages to the project

```bash
dotnet add package Microsoft.Extensions.Configuration
dotnet add package Microsoft.Extensions.Configuration.Json
```

### Executing SQL commands with parameters

> 🚨 **Alert**: This class is about what we should NOT do. We must eliminate this type of vulneralibity.

### SQL Injection

* [SQL Injection](https://www.w3schools.com/sql/sql_injection.asp) is a vulnerability where attackers manipulate SQL queries to gain 'unauthorized' access to the database and execute SQL commands.
* It happens when the parameters for the queries are obtained from user input and added to the SQL command as string by concatenation or interpolation.

> 🚨 **Alert**: SQL injection is one of the most common and dangerous security vulnerabilities.

#### Open Web Application Security Project (OWASP)

* <https://owasp.org/>
* [OWASP TOP Ten](https://owasp.org/www-project-top-ten/)
* [Injection](https://owasp.org/Top10/A03_2021-Injection/)

#### Examples of SQL Injection

* Example 1
  * Consider the following insecure code, where the userInput is a content provided by the user:

    ```csharp
    string query = $"SELECT * FROM Employees WHERE FirstName = '{userInput}'";
    ```

  * If attacker provides: ```"bye bye'; DROP TABLE Employees;--"```

    ```sql
    SELECT * FROM Employees WHERE FirstName = 'bye bye'; DROP TABLE Employees;--'
    ```

* Example 2

  ```csharp
  string query = $"SELECT * FROM Users WHERE Username = '{username}' AND Password = '{password}'";
  ```

  * If the attacker provides:
    * username: ```admin'--```
    * password: ```anything```

    ```sql
    SELECT * FROM Users WHERE Username = 'admin' -- AND Password = ''
    ```

  * If the attacker provides:
    * username: ```admin' OR '1'='1```
    * password: ```anything```

    ```sql
    SELECT * FROM Users WHERE Username = 'admin' OR '1'='1' AND Password = ''
    ```

### Executing SQL commands with parameters (How to prevent SQL Injection)

  Parameterized queries ensure that user input is treated as data, not executable SQL.

  ```csharp
  int supplierStart = 1;
  int supplierEnd = 30;
  int categoryID = 1;
  int unitPrice = 25;

  string query = @"
      SELECT *
      FROM Products
      WHERE SupplierID BETWEEN @SupplierStart AND @SupplierEnd
        AND CategoryID = @CategoryID
        AND UnitPrice < @UnitPrice
  ";
  using (SqlConnection connection = new SqlConnection(connectionString))
  {
      connection.Open();
      using (SqlCommand command = new SqlCommand(query, connection))
      {
        command.Parameters.AddWithValue("@SupplierStart", supplierStart);
        command.Parameters.AddWithValue("@SupplierEnd", supplierEnd);
        command.Parameters.AddWithValue("@CategoryID", categoryID);
        command.Parameters.AddWithValue("@UnitPrice", unitPrice);
        using (SqlDataReader reader = command.ExecuteReader())
        {
          while (reader.Read())
          {
              Console.WriteLine($"ProductID: {reader["ProductID"]}, ProductName: {reader["ProductName"]}, UnitPrice: {reader["UnitPrice"]}");
          }
        }
      }
  }
  ```

### Executing a Non-Query Command

Non-Query commands are used to execute operations like `INSERT`, `UPDATE`, and `DELETE`.
They do not return any data but indicate the number of rows affected.

* Example 1: Update product price based on a percentage

  ```csharp
  public static bool UpdateProductPrice(int productId, double percentage)
  {
    string query = @"UPDATE Products
                    SET UnitPrice = UnitPrice * (1 + @UnitPrice  / 100)
                    WHERE ProductID = @productId";
    using (var connection = new SqlConnection(ConnectionString.GetConnectionString()))
    {
      connection.Open();
      using (var command = new SqlCommand(query, connection))
      {
        command.Parameters.AddWithValue("@productId", productId);
        command.Parameters.AddWithValue("@Percentage", percentage);
        return command.ExecuteNonQuery() != 0;
      }
    }
  }
  ```

* Example 2: Update all products price based on a percentage

  ```csharp
  public static int UpdateProductPrices(double percentage)
  {
    string query = @"UPDATE Products
                      SET UnitPrice = UnitPrice * (1 + @Percentage  / 100)";
    using (var connection = new SqlConnection(ConnectionString.GetConnectionString()))
    {
      connection.Open();
      using (var command = new SqlCommand(query, connection))
      {
        command.Parameters.AddWithValue("@Percentage", percentage);
        return command.ExecuteNonQuery();
      }
    }
  }
  ```

* Example 3: Update all or a specific product price based on a percentage

  ```csharp
  public static int UpdatePrices(double percentage, int? productId = null)
  {
    StringBuilder query = new StringBuilder();
    query.Append(@"UPDATE Products
                  SET UnitPrice = UnitPrice * (1 + @Percentage  / 100)");
    if (productId.HasValue)
    {
      query.Append(" WHERE ProductID = @productId");
    }
    using (var connection = new SqlConnection(ConnectionString.GetConnectionString()))
    {
      connection.Open();
      using (var command = new SqlCommand(query.ToString(), connection))
      {
        command.Parameters.AddWithValue("@Percentage", percentage);
        if (productId.HasValue)
        {
          command.Parameters.AddWithValue("@productId", productId);
        }
        return command.ExecuteNonQuery();
      }
    }
  }
  ```

### Executing a Scalar Query

Scalar commands return a single value, such as COUNT, SUM, MIN, MAX, etc or a specific column value.
The command.ExecuteScalar returns the fist column of the first row, or DBNull.Value if empty.

* Example: Get the total amount of all orders for a customer

  ```csharp
  public static decimal? GetCustomerOrdesTotal(string customerId)
  {
    string query = @"SELECT SUM(od.Quantity * od.UnitPrice)
                        FROM [Order Details] od
                        INNER JOIN Orders o on o.OrderID = od.OrderID
                        WHERE o.CustomerID = @customerID";
    using (var connection = new SqlConnection(ConnectionString.GetConnectionString()))
    {
      connection.Open();
      using (var command = new SqlCommand(query, connection))
      {
        command.Parameters.AddWithValue("@customerId", customerId);
        var result = command.ExecuteScalar();
        if (result == DBNull.Value)
        {
          return null;
        }
        else
        {
          return (decimal)result;
        }
      }
    }
  }
  ```

### Executing Stored Procedure

To execute a Stored Procedure is necessary to set the command type to `CommandType.StoredProcedure`

* Example: Executing the `Sales by Year` stored procedure

  ```csharp
  public class SalesByYearResult
  {
    public DateTime ShippedDate { get; set; }
    public int OrderID { get; set; }
    public decimal Subtotal { get; set; }
    public int Year { get; set; }
    public override string ToString()
      => $" | {Year} | {ShippedDate:MM-dd} | {OrderID} | {Subtotal,8:N2}";
  }

  public class DatabaseHelper
  {
    public static List<SalesByYearResult> ExecuteSalesByYearProcedure(DateTime beginningDate, DateTime endingDate)
    {
      var results = new List<SalesByYearResult>();
      using (var connection = new SqlConnection(ConnectionString.GetConnectionString()))
      {
        connection.Open();
        using (SqlCommand command = new SqlCommand("[dbo].[Sales by Year]", connection))
        {
          command.CommandType = CommandType.StoredProcedure;
          command.Parameters.AddWithValue("@Beginning_Date", beginningDate);
          command.Parameters.AddWithValue("@Ending_Date", endingDate);
          using (SqlDataReader reader = command.ExecuteReader())
          {
            while (reader.Read())
            {
              results.Add(new SalesByYearResult
              {
                ShippedDate = reader.GetDateTime("ShippedDate"),
                OrderID = reader.GetInt32("OrderID"),
                Subtotal = reader.GetDecimal("Subtotal"),
                Year = int.Parse(reader.GetString("Year"))
              });
            }
          }
        }
      }
      return results;
    }
  }
  ```

### Transactions

ADO.NET provides [transaction support](https://learn.microsoft.com/en-us/dotnet/framework/data/adonet/local-transactions) to ensure data integrity when performing multiple related operations. Transactions allow committing all changes if successful or rolling back in case of failure.

> 🚨 **Alert**: A **single connection instance** must be used for all SQL commands participating in the transaction.

#### TransactionScope

[TransactionScope](https://learn.microsoft.com/en-us/dotnet/api/system.transactions.transactionscope?view=net-9.0) is a powerful feature in ADO.NET that provides an easy way to manage transactions across multiple operations. It ensures **atomicity**, meaning all operations within the scope either complete successfully or none take effect.

> 🚨 **Alert**: **Transaction Scope** allow distributed transaction so multiple connections could be used.

* Why Use TransactionScope?
  * **Automatic rollback on failure:** If an exception occurs, all changes are reverted automatically.
  * **Simplifies transaction management:** No need to manually commit or roll back transactions.
  * **Supports distributed transactions:** Can handle multiple database connections.
  * **Encapsulates transaction logic:** Makes code cleaner and easier to maintain.

* Examples SQL prep

  ```sql
  CREATE TABLE Account (
      id INT PRIMARY KEY,
      amount DECIMAL(18,2) NOT NULL
  );

  INSERT INTO Account (id, amount) values 
    (1, 1000),
    (2, 1000),
    (3, 1000)

  SELECT * FROM Account WITH(NOLOCK)
  ```

* Example 1: Bank Account Transfer

  ```csharp
  public void Transfer(int sourceId, int targetId, decimal amount)
  {
    using (var connection = new SqlConnection(ConnectionString.GetConnectionString()))
    {
      connection.Open();
      using (SqlTransaction transaction = connection.BeginTransaction())
      {
        try
        {
          Debit(sourceId, amount, connection, transaction);

          // Simulating a connection issue
          Random random = new Random();
          if (random.Next(4) == 3)
          {
            throw new Exception("Connection Lost");
          }

          Credit(targetId, amount, connection, transaction);
          transaction.Commit();
          Console.WriteLine("Transfer completed");
        }
        catch (Exception ex)
        {
          Console.WriteLine(ex.Message);
          transaction.Rollback();
        }
      }
    }
  }

  public void Debit(int accountId, decimal amount,
                    SqlConnection connection,
                    SqlTransaction transaction)
  {
    string sql = "UPDATE Account SET amount = amount - @Amount WHERE id = @AccountId";
    using (SqlCommand command = new SqlCommand(sql, connection, transaction))
    {
      command.Parameters.AddWithValue("@Amount", amount);
      command.Parameters.AddWithValue("@AccountId", accountId);
      command.ExecuteNonQuery();
    }
  }

  public void Credit(int accountId, decimal amount,
                    SqlConnection connection,
                    SqlTransaction transaction)
  {
    string sql = "UPDATE Account SET amount = amount + @Amount WHERE id = @AccountId";
    using (SqlCommand command = new SqlCommand(sql, connection, transaction))
    {
      command.Parameters.AddWithValue("@Amount", amount);
      command.Parameters.AddWithValue("@AccountId", accountId);
      command.ExecuteNonQuery();
    }
  }
  ```

  > 🚨 **RED ALERT**: The example above has a serious security issue: Allow an attacker to call the Transfer, Credit or Debit methods with account ids that don't exis, and this will cause the operation to 'create' or 'destoy' money.

  * The solution is to check if the update commands on Credit and Debit methods affected one line: ```if (command.ExecuteNonQuery() == 0)``` and throw an exception if not.
  * This is a good example how important is to pay great attention to security when designing software.

  ```csharp
    public void Debit(int accountId, decimal amount,
                    SqlConnection connection,
                    SqlTransaction transaction)
  {
    string sql = "UPDATE Account SET amount = amount - @Amount WHERE id = @AccountId";
    using (SqlCommand command = new SqlCommand(sql, connection, transaction))
    {
      command.Parameters.AddWithValue("@Amount", amount);
      command.Parameters.AddWithValue("@AccountId", accountId);
      // This fixes the security issue when account id does not exist
      if (command.ExecuteNonQuery() == 0)
      {
        throw new Exception($"Account ID not found: {accountId}");
      }
    }
  }

  public void Credit(int accountId, decimal amount,
                    SqlConnection connection,
                    SqlTransaction transaction)
  {
    string sql = "UPDATE Account SET amount = amount + @Amount WHERE id = @AccountId";
    using (SqlCommand command = new SqlCommand(sql, connection, transaction))
    {
      command.Parameters.AddWithValue("@Amount", amount);
      command.Parameters.AddWithValue("@AccountId", accountId);
      // This closes the security issue when account id does not exist
      if (command.ExecuteNonQuery() == 0)
      {
        throw new Exception($"Account ID not found: {accountId}");
      }
    }
  }
  ```

* Example 2: Bank Account Transfer with TransactionScope

  ```csharp
  public void Transfer(int sourceId, int targetId, decimal amount)
  {
    using (var transactionScope = new TransactionScope())
    {
      using (var connection = new SqlConnection(ConnectionString.GetConnectionString()))
      {
        Debit(sourceId, amount, connection);

        // Simulating a connection issue
        Random random = new();
        if (random.Next(4) == 3)
        {
          throw new Exception("Connection Lost");
        }

        Credit(targetId, amount, connection);
        transactionScope.Complete();
        Console.WriteLine("Transfer completed!");
      }
    }
  }

  public void Debit(int accountId, decimal amount, SqlConnection connection = null)
  {
    bool shouldClose = CheckConnection(ref connection);
    try
    {
      string sql = "UPDATE Account SET amount = amount - @Amount WHERE id = @AccountId";
      using (SqlCommand command = new SqlCommand(sql, connection))
      {
        command.Parameters.AddWithValue("@Amount", amount);
        command.Parameters.AddWithValue("@AccountId", accountId);
        if (command.ExecuteNonQuery() == 0)
        {
          throw new Exception($"Account ID not found: {accountId}");
        }
      }
    }
    finally
    {
      if (shouldClose)
      {
        connection.Close();
      }
    }
  }

  public void Credit(int accountId, decimal amount, SqlConnection connection = null)
  {
    bool shouldClose = CheckConnection(ref connection);
    try
    {
      string sql = "UPDATE Account SET amount = amount + @Amount WHERE id = @AccountId";
      using (SqlCommand command = new SqlCommand(sql, connection))
      {
        command.Parameters.AddWithValue("@Amount", amount);
        command.Parameters.AddWithValue("@AccountId", accountId);
        if (command.ExecuteNonQuery() == 0)
        {
          throw new Exception($"Account ID not found: {accountId}");
        }
      }
    }
    finally
    {
      if (shouldClose)
      {
        connection.Close();
      }
    }
  }

  private static bool CheckConnection(ref SqlConnection connection)
  {
    if (connection == null)
    {
      connection = new SqlConnection(ConnectionString.GetConnectionString());
    }
    if (connection.State == System.Data.ConnectionState.Closed)
    {
      connection.Open();
      return true;
    }
    return false;
  }
  ```
