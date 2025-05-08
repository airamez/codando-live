using System;
using System.Text;
using Microsoft.Data.SqlClient;

namespace ADO.NET.DataAccess;

public class ExecuteNonQueryApp
{

  public static void Main(string[] args)
  {
    while (true)
    {
      Console.Write("Product ID (Flag = 0): ");
      int productId = int.Parse(Console.ReadLine());
      if (productId == 0) break;
      SqlInjectionApp.PrintProductData(productId.ToString());
      Console.Write("Percentage: ");
      double percentage = double.Parse(Console.ReadLine());
      if (UpdateProductPrice(productId, percentage))
      {
        SqlInjectionApp.PrintProductData(productId.ToString());
      }
    }

    Console.Write("Percentage for all Prodcuts: ");
    double productsPercentage = double.Parse(Console.ReadLine());
    int count = UpdateProductPrices(productsPercentage);
    Console.WriteLine($"{count} products update");

    Console.WriteLine(UpdatePrices(25));
    Console.WriteLine(UpdatePrices(10, 1));
  }

  public static bool UpdateProductPrice(int productId, double percentage)
  {
    string query = @"UPDATE Products
                     SET UnitPrice = UnitPrice * (1 + @percentage  / 100)
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

  public static int UpdateProductPrices(double percentage)
  {
    string query = @"UPDATE Products
                     SET UnitPrice = UnitPrice * (1 + @percentage  / 100)";
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
}