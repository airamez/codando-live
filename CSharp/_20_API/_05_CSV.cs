/*
- CSV
  - CSV Format Overview: A CSV (Comma-Separated Values) file stores tabular 
    data in plain text, with values separated by commas.
  - CsvHelper for advanced scenarios.
    - https://joshclose.github.io/CsvHelper/
    - dotnet add package CsvHelper
- Handling Special Cases
  - Escaping Commas in Strings: Wrap values in double quotes ("Description with, comma").
  - Handling Double Quotes: Double quotes inside a field should be doubled ("Example ""quoted"" text").
  - Newlines in Fields: Fields with newlines must be enclosed in double quotes.
  - Trimming Spaces: Some CSV parsers may retain spaces; use .Trim() to remove unwanted whitespace.
*/
using System;
using System.Collections.Generic;
using System.Globalization;
using System.IO;
using System.Linq;
using CsvHelper;
using CsvHelper.Configuration;
using OurStore;

namespace DotNetAPI;

public class CSVApp
{
  public static void Main()
  {
    string baseFolder = Directory.GetCurrentDirectory() + "\\CSharp\\_20_API";
    string filePath = $"{baseFolder}\\_05_Products.csv";
    var products = LoadProductsFromCsv(filePath);

    Console.WriteLine("All Prodcuts");
    foreach (var product in products)
    {
      Console.WriteLine(product);
    }

    Console.WriteLine("Prodcuts with price over $200");
    foreach (var product in products.FindAll(p => p.Price > 200))
    {
      Console.WriteLine(product);
    }

    Console.WriteLine("Smart Products");
    foreach (var product in products.FindAll(p => p.Description.IndexOf("Smart") != -1))
    {
      Console.WriteLine(product);
    }

    Console.WriteLine("Smart Products over $200");
    foreach (var product in products.FindAll(p => p.Description.Contains("Smart") && p.Price > 200))
    {
      Console.WriteLine(product);
    }
  }

  public static List<Product> LoadProductsFromCsv(string filePath)
  {
    var config = new CsvConfiguration(CultureInfo.InvariantCulture)
    {
      PrepareHeaderForMatch = (args) => args.Header.ToLower()
    };
    using (var reader = new StreamReader(filePath))
    using (var csv = new CsvReader(reader, config))
    {
      return csv.GetRecords<Product>().ToList();
    }
  }
}