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
* Example

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

> ⚠️ **Warning**: You need to add the ADO.NET package to your project

```bash
dotnet add package Microsoft.Data.SqlClient
```

> ⚠️ **Warning**: This `System.Data.SqlClient` was the most common package in the paste, but it is depracated

### Executing a Non-Query Command

Non-Query commands are used to execute operations like `INSERT`, `UPDATE`, and `DELETE`. They do not return any data but indicate the number of rows affected.

```csharp
    connection.Open();
    SqlCommand command = new SqlCommand("UPDATE Employees SET Name = 'John' WHERE Id = 1", connection);
    int rowsAffected = command.ExecuteNonQuery();
    Console.WriteLine($"{rowsAffected} row(s) updated.");
```

### Executing a Scalar Query

Scalar commands return a single value, such as a count, a sum, or a specific column value.

```csharp
SqlCommand command = new SqlCommand("SELECT COUNT(*) FROM Employees", connection);
int employeeCount = (int)command.ExecuteScalar();
Console.WriteLine($"Total employees: {employeeCount}");
```

### Executing Functions and Stored Procedure

Functions and stored procedures help encapsulate SQL logic for reuse and can return results or perform operations.

```csharp
SqlCommand command = new SqlCommand("GetEmployeeById", connection);
command.CommandType = CommandType.StoredProcedure;
command.Parameters.AddWithValue("@Id", 1);
using (SqlDataReader reader = command.ExecuteReader())
{
    while (reader.Read())
    {
        Console.WriteLine($"Name: {reader["Name"]}, Age: {reader["Age"]}");
    }
}
```

## SQL Injection

SQL Injection is a vulnerability where attackers manipulate SQL queries to gain unauthorized access to the database.
I happens when the parameters for the queries are obtain from user input added to the SQL string by concatenation.

> 🚨 **Alert**: SQL injection is one of the most common and dangerous security vulnerabilities.
Always use parameterized queries or stored procedures to protect your applications from this threat.

* Open Web Application Security Project
  * (<https://owasp.org/>)
  * [OWASP TOP Ten](https://owasp.org/www-project-top-ten/)
  * [Injection](https://owasp.org/Top10/A03_2021-Injection/)

### Examples of SQL Injection

* Example 1
  * Consider the following insecure code, where the userInput is a content provided by the user:

    ```csharp
    string query = $"SELECT * FROM Employees WHERE Name = '{userInput}'";
    ```

  * If attacker provides: ```"'; DROP TABLE Employees;--"```
    * from:

      ```sql
      SELECT * FROM Employees WHERE Name = '1'
      ```

    * to:

      ```sql
      SELECT * FROM Employees WHERE Name = ''; DROP TABLE Employees;--'
      ```

* Example 2

  ```csharp
  string query = $"SELECT * FROM Users WHERE Username = '{username}' AND Password = '{password}'";
  ```

  * If the attacker provides:
    * username: ```admin'--```
    * password: ```anything```
    * from:

      ```sql
      SELECT * FROM Users WHERE Username = 'jose' AND Password = '12345'
      ```

    * to:

      ```sql
      SELECT * FROM Users WHERE Username = 'admin' -- AND Password = '12345'
      ```

  * If the attacker provides:
    * username: ```admin' OR '1'='1```
    * password: ```anything```
    * from:

      ```sql
      SELECT * FROM Users WHERE Username = 'jose' AND Password = '12345'
      ```

    * to:

      ```sql
      SELECT * FROM Users WHERE Username = 'admin' OR '1'='1' AND Password = '123454321'
      ```

### How to prevent SQL Injection

* Use Parameterized Queries
  * Parameterized queries ensure that user input is treated as data, not executable SQL.

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
