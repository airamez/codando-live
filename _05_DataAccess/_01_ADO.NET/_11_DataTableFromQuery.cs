using System;
using System.Data;
using Microsoft.Data.SqlClient;

namespace ADO.NET.DataAccess;

public class DataTableFromQueryApp
{
  public static void Main(string[] args)
  {
    var products = GetProducts();
    PrintDataTable(products);
  }

  public static DataTable GetProducts()
  {
    string query = "SELECT ProductID, ProductName, UnitPrice FROM Products";
    using (var connection = new SqlConnection(ConnectionString.GetConnectionString()))
    {
      SqlDataAdapter adapter = new SqlDataAdapter(query, connection);
      DataTable products = new DataTable();
      adapter.Fill(products);
      return products;
    }
  }

  public static void PrintDataTable(DataTable products)
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