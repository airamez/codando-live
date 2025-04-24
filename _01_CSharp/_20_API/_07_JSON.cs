/*
- What is a JSON File?
  - JSON (JavaScript Object Notation) is a lightweight data interchange format.
  - It is human-readable and machine-readable.
  - Uses key-value pairs similar to a dictionary or object.
  - Common file extension: .json.
  - Based on JavaScript object syntax but is language-independent.
- When to Use JSON?
  - Storing and exchanging data (e.g., configurations, API responses).
  - Web applications for sending/receiving structured data.
  - Inter-process communication (e.g., between client-server apps).
  - Databases (e.g., MongoDB, Firebase) that use JSON-like structures.
  - Serialization of objects in programming languages like C#, Python, and Java.
- Common APIs for JSON in C#:
  - System.Text.Json (Recommended)
    - Introduced in .NET Core 3.0.
    - Provides high-performance JSON serialization and deserialization.
    - Supports both synchronous and asynchronous methods.
    - https://learn.microsoft.com/en-us/dotnet/api/system.text.json?view=net-9.0
  - Newtonsoft.Json (Json.NET)
    - Older but widely used library, especially in older .NET versions.
    - Supports more advanced features (e.g., LINQ to JSON).
    - https://www.newtonsoft.com/json
  - Since System.Text.Json is the preferred API in modern C# applications, 
    we'll use it in our examples.  
*/
using System;
using System.Collections.Generic;
using System.IO;
using System.Text.Json;
using System.Threading.Tasks;
using OurStore;

namespace DotNetAPI;

public class JSONApp
{
  public static void Main(string[] args)
  {
    string folder = $"{Directory.GetCurrentDirectory()}\\CSharp\\_20_API\\";
    var productsFromCSV = CSVApp.LoadProductsFromCsv(folder + "_05_Products.csv");

    // Writing the entire file at once
    string jsonSerializer = JsonSerializer.Serialize(
      productsFromCSV, new JsonSerializerOptions { WriteIndented = true });
    File.WriteAllText(folder + "_07_Products.json", jsonSerializer);

    // Reading the entire file at once
    string readJson = File.ReadAllText(folder + "_07_Products.json");
    List<Product> productsFromJSON = JsonSerializer.Deserialize<List<Product>>(readJson);
    foreach (var product in productsFromJSON)
    {
      Console.WriteLine(product);
    }

    // Writing in batch mode
    Task.Run(async () =>
    {
      using (FileStream fs = new FileStream(
        folder + "_07_ProductsBatch.json",
        FileMode.Create,
        FileAccess.Write,
        FileShare.None))
      using (Utf8JsonWriter writer = new Utf8JsonWriter(fs, new JsonWriterOptions { Indented = true }))
      {
        writer.WriteStartArray(); // Start JSON array
        foreach (var product in productsFromJSON)
        {
          JsonSerializer.Serialize(writer, product); // Serialize each product
        }
        writer.WriteEndArray(); // End JSON array
      }
    }).GetAwaiter().GetResult();

    // Reading in batch mode
    Task.Run(async () =>
    {
      using (FileStream fs = new FileStream(
            folder + "_07_ProductsBatch.json",
            FileMode.Open,
            FileAccess.Read,
            FileShare.Read))
      using (JsonDocument document = await JsonDocument.ParseAsync(fs))
      {
        foreach (JsonElement element in document.RootElement.EnumerateArray())
        {
          Product product = JsonSerializer.Deserialize<Product>(element.GetRawText());
          Console.WriteLine(product);
        }
      }
    }).GetAwaiter().GetResult();
  }
}