using System.IO;
using Microsoft.Extensions.Configuration;

namespace ADO.NET;

public class ConnectionString
{
  public static string GetConnectionString()
  {
    var configuration = new ConfigurationBuilder()
        .SetBasePath(Directory.GetCurrentDirectory())
        .AddJsonFile("appsettings.json")
        .Build();
    var connectionString = configuration.GetConnectionString("MySQLConnection");
    return connectionString;
  }
}