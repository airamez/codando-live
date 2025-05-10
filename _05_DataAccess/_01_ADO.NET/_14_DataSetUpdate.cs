using System;
using System.Data;
using Microsoft.Data.SqlClient;

namespace ADO.NET.DataAccess;

public class DataSetUpdateApp
{
  public static void Main(string[] args)
  {
    var ordersDS = DataSetApp.LoadDataSet();

    Console.WriteLine("Initial Data:");
    DataSetApp.PrintCustomerOrders(ordersDS);

    ModifyDataSet(ordersDS);

    Console.WriteLine("Modified Data:");
    DataSetApp.PrintCustomerOrders(ordersDS);

    UpdateDatabase(ordersDS);
  }

  public static void ModifyDataSet(DataSet dataSet)
  {
    var ordersTable = dataSet.Tables["Orders"];

    // Adding a new row
    DataRow newOrder = ordersTable.NewRow();
    // OrderId is Auto Incremented
    newOrder["CustomerID"] = "WOLZA";
    newOrder["OrderDate"] = DateTime.Now;
    newOrder["ShipCountry"] = "USA";
    ordersTable.Rows.Add(newOrder);

    // Updating an existing row
    DataRow[] orderToUpdate = ordersTable.Select("OrderID = 10374");
    if (orderToUpdate.Length > 0)
    {
      orderToUpdate[0]["ShipCountry"] = "Brazil";
    }
  }

  public static void UpdateDatabase(DataSet dataSet)
  {
    using (var connection = new SqlConnection(ConnectionString.GetConnectionString()))
    {
      SqlDataAdapter adapter = new SqlDataAdapter("SELECT OrderID, CustomerID, OrderDate, ShipCountry FROM Orders", connection);
      SqlCommandBuilder builder = new SqlCommandBuilder(adapter);
      adapter.Update(dataSet, "Orders");
    }
  }
}
