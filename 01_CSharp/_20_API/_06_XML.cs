/*
- XML (Extensible Markup Language) is a widely used format for storing
  and exchanging structured data.
- Human-readable and self-descriptive.
- Platform-independent.
- Useful for data serialization, configuration files, and web services.
- Small files can be loaded entirely to the memory
- Large files requires bach procesing for efficiency

// https://learn.microsoft.com/en-us/dotnet/api/system.xml?view=net-9.0
*/
using System;
using System.Collections.Generic;
using System.IO;
using System.Xml;
using System.Xml.Serialization;
using OurStore;

namespace DotNetAPI;

public class XMLApp
{
  public static void Main(string[] args)
  {
    string folder = $"{Directory.GetCurrentDirectory()}\\CSharp\\_20_API\\";
    var productsFromCSV = CSVApp.LoadProductsFromCsv(folder + "_05_Products.csv");

    WriteXml(folder + "_06_Products.xml", productsFromCSV);

    List<Product> productsFromXML = ReadXml(folder + "_06_Products.xml");

    ReadXmlInBatches(folder + "_06_Products.xml");

    WriteXmlInBatches(folder + "_06_ProductsBatch.xml", productsFromXML);
  }
  static void WriteXml(string filePath, List<Product> products)
  {
    XmlSerializer serializer = new XmlSerializer(typeof(List<Product>));
    using (StreamWriter writer = new StreamWriter(filePath))
    {
      serializer.Serialize(writer, products);
    }
  }

  static List<Product> ReadXml(string filePath)
  {
    XmlSerializer serializer = new XmlSerializer(typeof(List<Product>));
    using (StreamReader reader = new StreamReader(filePath))
    {
      return (List<Product>)serializer.Deserialize(reader);
    }
  }

  static void ReadXmlInBatches(string filePath)
  {
    using (XmlReader reader = XmlReader.Create(filePath))
    {
      while (reader.Read())
      {
        if (reader.NodeType == XmlNodeType.Element && reader.Name == "Product")
        {
          int id = 0;
          string description = "";
          decimal price = 0;
          while (reader.Read())
          {
            if (reader.NodeType == XmlNodeType.Element)
            {
              if (reader.Name == "ID")
                id = reader.ReadElementContentAsInt();
              else if (reader.Name == "Description")
                description = reader.ReadElementContentAsString();
              else if (reader.Name == "Price")
                price = reader.ReadElementContentAsDecimal();
            }
            else if (reader.NodeType == XmlNodeType.EndElement && reader.Name == "Product")
            {
              break; // End of Product element
            }
          }
          var product = new Product(id, description, price);
          Console.WriteLine(product);
        }
      }
    }
  }

  static void WriteXmlInBatches(string filePath, IEnumerable<Product> products)
  {
    using (XmlWriter writer = XmlWriter.Create(filePath, new XmlWriterSettings { Indent = true }))
    {
      writer.WriteStartDocument();
      writer.WriteStartElement("Products");
      int i = 0;
      foreach (var product in products)
      {
        writer.WriteStartElement("Product");
        writer.WriteElementString("ID", product.ID.ToString());
        writer.WriteElementString("Description", product.Description);
        writer.WriteElementString("Price", product.Price.ToString());

        writer.WriteEndElement(); // Close Product
        i++;
        if (i % 10 == 0)
        {
          writer.Flush(); // Explain this
        }
      }
      writer.WriteEndElement(); // Close Products
      writer.WriteEndDocument();
    }
  }
}