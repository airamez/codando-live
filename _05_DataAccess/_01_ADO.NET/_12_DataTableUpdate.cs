using System;
using System.Data;
using Microsoft.Data.SqlClient;

namespace ADO.NET.DataAccess;

public class DataTableUpdateApp
{
  public static void Main(string[] args)
  {
    var productManager = new ProductDataManager(ConnectionString.GetConnectionString());
    var products = productManager.GetProductsForUpdate();

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

        product["ProductName"] = newName;
        product["UnitPrice"] = newPrice;
      }
    }

    productManager.UpdateProducts(products);
  }
}

public class ProductDataManager
{
  public const string PRODUCTS_QUERY = "SELECT ProductID, ProductName, UnitPrice FROM Products";
  private readonly SqlConnection Connection;
  private readonly SqlDataAdapter Adapter;

  public ProductDataManager(string connectionString)
  {
    Connection = new SqlConnection(connectionString);
    Adapter = new SqlDataAdapter(PRODUCTS_QUERY, Connection);
    new SqlCommandBuilder(Adapter); // Enable automatic command generation
  }

  public DataTable GetProductsForUpdate()
  {
    DataTable products = new DataTable();
    Adapter.Fill(products);

    // Define Primary Key
    products.PrimaryKey = [products.Columns["ProductID"]];

    return products;
  }

  public void UpdateProducts(DataTable products)
  {
    Adapter.Update(products);
    products.AcceptChanges();
  }
}
