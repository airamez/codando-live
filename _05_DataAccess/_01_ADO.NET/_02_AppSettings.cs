using System;
using Microsoft.Extensions.Configuration;

public class AppSettingsApp
{
  static void Main(string[] args)
  {
    // @Note: Explain the .csproj entries and the BaseDirectory
    var configuration = new ConfigurationBuilder()
        .SetBasePath(AppContext.BaseDirectory)
        .AddJsonFile("appsettingsDEMO.json", optional: false, reloadOnChange: true)
        .Build();

    string primaryDb = configuration.GetConnectionString("PrimaryDatabase");
    string secondaryDb = configuration.GetConnectionString("SecondaryDatabase");
    string userApi = configuration["WebApis:UserApi"];
    string orderApi = configuration["WebApis:OrderApi"];
    string inventoryApi = configuration["WebApis:InventoryApi"];
    int timeout = int.Parse(configuration["Constants:TimeoutSeconds"]);
    string readFolder = configuration["Constants:ReadFolderPath"];
    string writeFolder = configuration["Constants:WriteFolderPath"];

    Console.WriteLine($"Primary Database: {primaryDb}");
    Console.WriteLine($"Secondary Database: {secondaryDb}");
    Console.WriteLine($"User API: {userApi}");
    Console.WriteLine($"Order API: {orderApi}");
    Console.WriteLine($"Inventory API: {inventoryApi}");
    Console.WriteLine($"Timeout: {timeout} seconds");
    Console.WriteLine($"Read Folder Path: {readFolder}");
    Console.WriteLine($"Write Folder Path: {writeFolder}");
  }
}
