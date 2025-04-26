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

* A best practice is to keep the Connection String in a [Application Configuration File](https://learn.microsoft.com/en-us/dotnet/framework/data/adonet/connection-strings-and-configuration-files)
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

ADO.NET uses the SqlCommand object to execute any type of SQL statements from quries to and stored procedures.

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

> ⚠️ **Warning**: This was the most common package in the paste, but it is depracated: `System.Data.SqlClient`
