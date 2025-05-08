using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using Microsoft.Data.SqlClient;

namespace ADO.NET.DataAccess;

public class ExecuteProcedureApp
{

  public static void Main(string[] args)
  {
    DateTime startDate = DateTime.Parse("1990-01-01");
    DateTime endDate = DateTime.Parse("2025-12-31");

    var salesData = DatabaseHelper.ExecuteSalesByYearProcedure(startDate, endDate);

    salesData
      .OrderBy(entry => entry.Year)
      .ThenBy(entry => entry.ShippedDate)
      .ToList()
      .ForEach(Console.WriteLine);
  }

  public class SalesByYearResult
  {
    public DateTime ShippedDate { get; set; }
    public int OrderID { get; set; }
    public decimal Subtotal { get; set; }
    public int Year { get; set; }
    public override string ToString()
      => $" | {Year} | {ShippedDate:yyyy-MM-dd} | {OrderID} | {Subtotal,8:N2}";
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
}