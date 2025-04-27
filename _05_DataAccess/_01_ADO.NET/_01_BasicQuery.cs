using System;
using Microsoft.Data.SqlClient;

namespace ADO.NET.DataAcces;

public class BasicQueryApp
{
  static void Main(string[] args)
  {
    string connectionString = "Server=localhost,1433;Database=NorthWind;User Id=sa;Password=Password!;TrustServerCertificate=True;";
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
            Console.Write($"Name: {reader["ProductName"]}; ");
            Console.WriteLine($"Price: {reader["UnitPrice"]}");
          }
        }
      }
    }
  }
}