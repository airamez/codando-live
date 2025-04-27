using System;
using Microsoft.Data.SqlClient;

namespace ADO.NET.DataAcces;

public class SqlInjectionApp
{

  public static void Main(string[] args)
  {
    Console.Write("Product ID: ");
    string productId = Console.ReadLine();

    // What is the attacker type:
    // 1; UPDATE Products SET UnitPrice = 1 WHERE ProductId = 1; --

    PrintProdcutData(productId);
  }

  private static void PrintProdcutData(string productId)
  {
    string query = @$"SELECT ProductID, ProductName, UnitPrice 
                      FROM Products 
                      WHERE ProductID = {productId}";
    using (SqlConnection connection = new SqlConnection(ConnectionString.Value))
    {
      connection.Open();
      using (SqlCommand command = new SqlCommand(query, connection))
      {
        using (SqlDataReader reader = command.ExecuteReader())
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
}