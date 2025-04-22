using System;
using System.Collections.Generic;
using System.Linq;
using Collections;

namespace Collections;

public class DictionaryDemoApp
{
  public static void Main(string[] args)
  {
    Dictionary<int, Product> products = new Dictionary<int, Product>();
    for (int i = 0; i < 1_000_000; i++)
    {
      var newProduct = Product.GenerateRandom();
      products.Add(newProduct.Id, newProduct);
    }

    while (true)
    {
      Console.Write("Product ID: ");
      string idAsString = Console.ReadLine();
      if (string.IsNullOrEmpty(idAsString))
      {
        break;
      }
      int id = int.Parse(idAsString);
      var product = products.GetValueOrDefault(id);
      if (product == null)
      {
        Console.WriteLine("Id not found:");
      }
      else
      {
        Console.WriteLine(product);
      }
    }
  }
}