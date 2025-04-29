using System;
using Microsoft.Data.SqlClient;

namespace ADO.NET.DataAcces;

public class SqlInjectionApp
{

  public static void Main(string[] args)
  {
    while (true)
    {
      Console.Write("Product ID: ");
      string productId = Console.ReadLine();

      if (string.IsNullOrWhiteSpace(productId))
      {
        break;
      }

      // What if the attacker type:
      // 1; UPDATE Products SET UnitPrice = 18 WHERE ProductId = 1; --

      PrintProductDataWRONG(productId);
      //PrintProductData(productId);
    }
  }

  private static void PrintProductDataWRONG(string productId)
  {
    // Never do this. This is open to SQL Injection
    string query = @$"SELECT ProductID, ProductName, UnitPrice 
                      FROM Products 
                      WHERE ProductID = {productId}";
    using (var connection = new SqlConnection(ConnectionString.GetConnectionString()))
    {
      connection.Open();
      using (var command = new SqlCommand(query, connection))
      {
        using (var reader = command.ExecuteReader())
        {
          while (reader.Read())
          {
            Console.Write($"ID: {reader["ProductID"]}; ");
            Console.Write($"Name: {reader["ProductName"]}; ");
            Console.WriteLine($"Price: {reader["UnitPrice"]}");
          }
        }
      }
    }
  }

  public static void PrintProductData(string productId)
  {
    try
    {
      // Using command parameters we are protected from SQL injection
      string query = @$"SELECT ProductID, ProductName, UnitPrice 
                      FROM Products 
                      WHERE ProductID = @productId";
      using (var connection = new SqlConnection(ConnectionString.GetConnectionString()))
      {
        connection.Open();
        using (var command = new SqlCommand(query, connection))
        {
          command.Parameters.AddWithValue("@productId", productId);
          using (var reader = command.ExecuteReader())
          {
            while (reader.Read())
            {
              Console.Write($"ID: {reader["ProductID"]}; ");
              Console.Write($"Name: {reader["ProductName"]}; ");
              Console.WriteLine($"Price: {reader["UnitPrice"]}");
            }
          }
        }
      }
    }
    catch (Exception ex)
    {
      Console.WriteLine($"Error: {ex.Message}");
    }
  }
}