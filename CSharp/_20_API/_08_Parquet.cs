/*
Parquet is a binary columnar storage file format designed for efficient data storage and retrieval.
It is particularly useful for big data processing and is compatible with various data processing
frameworks like Apache Hadoop, Apache Spark, and more. Parquet files support complex nested data 
structures and offer efficient data compression and encoding schemes.
- Key Features of Parquet:
  - Columnar Storage: Parquet stores data in columns rather than rows, optimizing read and write
    efficiency for specific columns.
  - Efficient Data Compression: Parquet provides better compression ratios due to its columnar
    storage format.
  - Schema Evolution: Parquet supports schema evolution, allowing changes to the schema over time
    without compromising data compatibility.
  - Compatibility: Parquet is compatible with a wide range of data processing frameworks and tools.
- Libraries to handle Parquet files in C#:
  - Parquet.Net: is a fully managed, safe, and extremely fast .NET library designed to read and 
    write Apache Parquet files. Unlike some other libraries, it is not a wrapper around native 
    implementations but is built specifically for the .NET ecosystem.
    - https://github.com/aloneguid/parquet-dotnet
    - dotnet add package Parquet.Net
  - ParquetSharp: This is a cross-platform .NET library for reading and writing Apache Parquet files.
    - It is implemented in C# as a PInvoke wrapper around Apache Parquet C++ to provide high performance
      and compatibility.
    - https://github.com/G-Research/ParquetSharp
  - ParquetViewer: This is a simple Windows desktop application for viewing and querying Apache
    - Parquet files. It is part of the parquet-dotnet repository, which provides a fully managed,
      safe, and fast .NET library to read and write Apache Parquet files.
    - https://github.com/mukunku/ParquetViewer
*/

using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using OurStore;
using Parquet;
using Parquet.Data;
using Parquet.Schema;

namespace DotNetAPI;

public class ParquetApp
{
  public static async Task Main(string[] args)
  {
    string folder = $"{Directory.GetCurrentDirectory()}\\CSharp\\_20_API\\";
    var productsFromCSV = CSVApp.LoadProductsFromCsv(folder + "_05_Products.csv");

    // Define schema
    var schema = new ParquetSchema(
      new DataField<int>("ID"),
      new DataField<string>("Description"),
      new DataField<decimal>("Price")
    );

    var ids = productsFromCSV.Select(p => p.ID).ToArray();
    var descriptions = productsFromCSV.Select(p => p.Description).ToArray();
    var prices = productsFromCSV.Select(p => p.Price).ToArray();

    using (var stream = File.Create(folder + "_08_Products.parquet"))
    {
      using (var writer = await ParquetWriter.CreateAsync(schema, stream))
      {
        writer.CompressionMethod = CompressionMethod.Gzip;
        using (ParquetRowGroupWriter rgw = writer.CreateRowGroup())
        {
          await rgw.WriteColumnAsync(new DataColumn((DataField<int>)schema[0], ids));
          await rgw.WriteColumnAsync(new DataColumn((DataField<string>)schema[1], descriptions));
          await rgw.WriteColumnAsync(new DataColumn((DataField<decimal>)schema[2], prices));
        }
      }
    }
    Console.WriteLine("Parquet files created by columns");

    // Read the Parquet file into a collection
    List<Product> products = await ReadProductsFromParquet(folder + "_08_Products.parquet");
    foreach (var product in products)
    {
      Console.WriteLine(product);
    }
  }

  private static async Task<List<Product>> ReadProductsFromParquet(string filePath)
  {
    var products = new List<Product>();

    using (var stream = File.OpenRead(filePath))
    {
      using (var reader = await ParquetReader.CreateAsync(stream))
      {
        var schema = reader.Schema;

        for (int i = 0; i < reader.RowGroupCount; i++)
        {
          using (ParquetRowGroupReader rowGroupReader = reader.OpenRowGroupReader(i))
          {
            var idColumn = await rowGroupReader.ReadColumnAsync(schema.DataFields[0]);
            var descriptionColumn = await rowGroupReader.ReadColumnAsync(schema.DataFields[1]);
            var priceColumn = await rowGroupReader.ReadColumnAsync(schema.DataFields[2]);

            var ids = idColumn.Data.OfType<int>().ToArray();
            var descriptions = descriptionColumn.Data.OfType<string>().ToArray();
            var prices = priceColumn.Data.OfType<decimal>().ToArray();

            for (int j = 0; j < ids.Length; j++)
            {
              products.Add(new Product(ids[j], descriptions[j], prices[j]));
            }
          }
        }
      }
    }
    return products;
  }
}