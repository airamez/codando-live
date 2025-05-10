using System;
using System.Data;
using Microsoft.Data.SqlClient;

namespace ADO.NET.DataAccess;

public class DataSetApp
{
  public static void Main(string[] args)
  {
    var ordersDS = LoadDataSet();
    PrintCustomerOrders(ordersDS);

    while (true)
    {
      Console.Write("Customer ID (Flag is empty string): ");
      string customerId = Console.ReadLine();
      if (string.IsNullOrWhiteSpace(customerId))
      {
        break;
      }
      var customerSearch = ordersDS.Tables["Customers"].Select($"CustomerID = '{customerId}'");
      if (customerSearch.Length == 0)
      {
        Console.WriteLine("Customer not found.");
        continue;
      }
      var customer = customerSearch[0];
      Console.WriteLine($"Customer: {customer["CompanyName"]} ({customer["CustomerID"]})");
      foreach (DataRow order in customer.GetChildRows("CustomerOrders"))
      {
        Console.WriteLine($"   [{order["OrderID"]}; {order["OrderDate"]}; {order["ShipCountry"]}]");
      }
    }
  }

  public static DataSet LoadDataSet()
  {
    string queryCustomers = "SELECT CustomerID, CompanyName, ContactName FROM Customers";
    string queryOrders = "SELECT OrderID, CustomerID, OrderDate, ShipCountry FROM Orders";

    using (var connection = new SqlConnection(ConnectionString.GetConnectionString()))
    {
      SqlDataAdapter adapter = new SqlDataAdapter();
      DataSet ordersDS = new DataSet();

      adapter.SelectCommand = new SqlCommand(queryCustomers, connection);
      adapter.Fill(ordersDS, "Customers");

      adapter.SelectCommand = new SqlCommand(queryOrders, connection);
      adapter.Fill(ordersDS, "Orders");

      // Establish relationship
      ordersDS.Relations.Add("CustomerOrders",
          ordersDS.Tables["Customers"].Columns["CustomerID"],
          ordersDS.Tables["Orders"].Columns["CustomerID"]);

      return ordersDS;
    }
  }

  public static void PrintCustomerOrders(DataSet northwindDataSet)
  {
    foreach (DataRow customer in northwindDataSet.Tables["Customers"].Rows)
    {
      Console.WriteLine($"Customer: {customer["CompanyName"]} ({customer["CustomerID"]})");
      foreach (DataRow order in customer.GetChildRows("CustomerOrders"))
      {
        Console.WriteLine($"\t{order["OrderID"]}; {order["OrderDate"]}; {order["ShipCountry"]}");
      }
    }
  }
}
