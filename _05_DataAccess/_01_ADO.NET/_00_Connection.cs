using System.IO;
using Microsoft.Extensions.Configuration;

namespace ADO.NET;

public class ConnectionString
{
  private static IConfigurationRoot Configurations => new ConfigurationBuilder()
    .SetBasePath(Directory.GetCurrentDirectory())
    .AddJsonFile("appsettings.json")
    .Build();

  public static string GetConnectionString()
  {
    return Configurations.GetConnectionString("MySQLConnection");
  }
}