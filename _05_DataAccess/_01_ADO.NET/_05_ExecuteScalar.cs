using System;
using System.Text;
using Microsoft.Data.SqlClient;

namespace ADO.NET.DataAccess;

public class ExecuteScalarApp
{

  public static void Main(string[] args)
  {
    while (true)
    {
      Console.Write("Customer Id: ");
      string customerId = Console.ReadLine();
      if (string.IsNullOrWhiteSpace(customerId)) break;
      decimal? total = GetCustomerOrdersTotal(customerId);
      if (total.HasValue)
      {
        Console.WriteLine($"Total from Orders = ${total:F2}");
      }
      else
      {
        Console.WriteLine($"No records found!");
      }
    }
  }

  public static decimal? GetCustomerOrdersTotal(string customerId)
  {
    string query = @"SELECT SUM(od.Quantity * od.UnitPrice)
                       FROM [Order Details] od
                       INNER JOIN Orders o on o.OrderID = od.OrderID
                       WHERE o.CustomerID = @customerId";
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
}