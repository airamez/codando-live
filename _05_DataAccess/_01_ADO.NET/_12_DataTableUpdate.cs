using System;
using System.Data;
using Microsoft.Data.SqlClient;

namespace ADO.NET.DataAccess;

public class DataTableUpdateApp
{
  public static void Main(string[] args)
  {
    var products = GetProductsForUpdate();

    while (true)
    {
      Console.Write("ProductID (0 to exit): ");
      int productId = int.Parse(Console.ReadLine());

      if (productId == 0)
        break;

      DataRow product = products.Rows.Find(productId);
      if (product == null)
      {
        Console.WriteLine("Product ID not found.");
      }
      else
      {
        Console.WriteLine($" Name: {product["ProductName"]}");
        Console.WriteLine($"Price: {product["UnitPrice"]}");

        Console.Write(" New Name: ");
        string newName = Console.ReadLine();

        Console.Write("New Price: ");
        decimal newPrice = decimal.Parse(Console.ReadLine());

        // Update values
        product["ProductName"] = newName;
        product["UnitPrice"] = newPrice;
      }
    }

    UpdateProducts(products);
  }

  public static DataTable GetProductsForUpdate()
  {
    string query = "SELECT ProductID, ProductName, UnitPrice FROM Products";
    using (var connection = new SqlConnection(ConnectionString.GetConnectionString()))
    {
      SqlDataAdapter adapter = new SqlDataAdapter(query, connection);
      SqlCommandBuilder commandBuilder = new SqlCommandBuilder(adapter);

      DataTable products = new DataTable();
      adapter.Fill(products);

      // Define Primary Key
      products.PrimaryKey = [products.Columns["ProductID"]];

      // Attach adapter for future updates
      products.ExtendedProperties["Adapter"] = adapter;

      return products;
    }
  }

  public static void UpdateProducts(DataTable products)
  {
    if (products.ExtendedProperties["Adapter"] is SqlDataAdapter adapter)
    {
      using (var connection = new SqlConnection(ConnectionString.GetConnectionString()))
      {
        connection.Open();
        adapter.SelectCommand.Connection = connection;  // Explicitly assign connection
        adapter.Update(products);
        products.AcceptChanges();
        connection.Close();
      }
    }
    else
    {
      throw new Exception("The DataTable does not have a Adapter as extended Property");
    }
  }
}
