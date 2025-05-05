using System;
using System.Data;
using Microsoft.Data.SqlClient;

namespace ADO.NET;

public class DataTableFromQueryApp
{
  public static void Main(string[] args)
  {
    string query = "SELECT ProductID, ProductName, UnitPrice FROM Products";
    using (var connection = new SqlConnection(ConnectionString.GetConnectionString()))
    {
      SqlDataAdapter adapter = new SqlDataAdapter(query, connection);

      // Auto-generates INSERT, UPDATE, DELETE
      SqlCommandBuilder commandBuilder = new SqlCommandBuilder(adapter);

      DataTable products = new DataTable();
      adapter.Fill(products);

      // Define Primary Key
      products.PrimaryKey = new DataColumn[] { products.Columns["ProductID"] };

      PrintDataTable(products);

      // Changing the price
      foreach (DataRow product in products.Rows)
      {
        decimal increase = (decimal)product["UnitPrice"] * 50 / 100;
        product["UnitPrice"] = increase + (decimal)product["UnitPrice"];
      }
      PrintDataTable(products);

      // Persiting the changes
      adapter.Update(products);
    }
  }

  private static void PrintDataTable(DataTable products)
  {
    foreach (DataRow product in products.Rows)
    {
      int id = (int)product["ProductID"];
      string name = (string)product["ProductName"];
      decimal price = (decimal)product["UnitPrice"];

      Console.WriteLine($"{id}; {name}; {price}");
    }
  }
}