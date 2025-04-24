/*
URL: https://learn.microsoft.com/en-us/dotnet/api/system.collections.generic.list-1?view=net-8.0
*/

using System;
using System.Collections.Generic;

namespace Collections;

public class ListApp
{
  public static void Main(string[] args)
  {
    List<string> names = new List<string>();
    names.Add("Cazuza");
    names.Add("Michael Jackson");
    names.Add("Tupac");
    names.Add("Alanis Moriset");
    names.Add("Bono Vox");
    names.Add("Luiz Gonzaga");
    foreach (string name in names)
    {
      Console.WriteLine(name);
    }
    Console.WriteLine(names.Count);
    Console.WriteLine(names.Contains("Tupac"));
    Console.WriteLine(names.Contains("Roberto Carlos"));
    Console.WriteLine(names.IndexOf("Tupac"));
    Console.WriteLine(names.IndexOf("Roberto Carlos"));
    names.Insert(4, "Roberto Carlos");
    Console.WriteLine(names.Count);
    Console.WriteLine(names.Contains("Roberto Carlos"));
    names.Remove("Roberto Carlos");
    Console.WriteLine(names.Contains("Roberto Carlos"));

    names.Sort();
    names.ForEach(name => Console.WriteLine(name));

    List<Product> products =
    [
        new Product(1, "Soccer Ball", 24.99),
        new Product(2, "Basketball", 29.99),
        new Product(3, "Tennis Racket", 89.99),
        new Product(4, "Baseball Glove", 49.99),
        new Product(5, "Golf Club", 149.99),
        new Product(6, "Running Shoes", 79.99),
        new Product(7, "Yoga Mat", 29.99),
        new Product(8, "Dumbbell Set", 99.99),
        new Product(9, "Resistance Bands", 19.99),
        new Product(10, "Water Bottle", 14.99),
        new Product(11, "Hockey Stick", 89.99),
        new Product(12, "Skateboard", 79.99),
        new Product(13, "Boxing Gloves", 49.99),
        new Product(14, "Football", 29.99),
        new Product(15, "Jump Rope", 15.99),
        new Product(16, "Rugby Ball", 39.99),
        new Product(17, "Swim Goggles", 14.99),
        new Product(18, "Baseball Bat", 59.99),
        new Product(19, "Cycling Helmet", 49.99),
        new Product(20, "Fitness Tracker", 99.99),
    ];

    Console.WriteLine("List of products:");
    foreach (var product in products)
    {
      Console.WriteLine(product);
    }

    Console.WriteLine($"Count: {products.Count}");

    Console.WriteLine(products.Exists(p => p.Id == 0));
    Console.WriteLine(products.Exists(p => p.Id == 1));
    Console.WriteLine(products.Exists(p => p.Id == 20));

    var prod1 = products.Find(p => p.Id == 1);
    Console.WriteLine(prod1);

    var football = products.Find(p => p.Description.Equals("Football"));
    Console.WriteLine(football);

    Console.WriteLine("Products above 45");
    foreach (var productsAbove45 in products.FindAll(p => p.Price > 45))
    {
      Console.WriteLine(productsAbove45);
    }

    Console.WriteLine("Products with price between 10 and 45 and start with letter B");
    foreach (var productsBelow45 in products.FindAll(
      p => p.Price > 10 && p.Price < 45 && p.Description.StartsWith("B"))
    )
    {
      Console.WriteLine(productsBelow45);
    }

    products.ForEach(p => Console.WriteLine(p));
    products.RemoveAll(p => p.Price > 70);
    products.ForEach(p => Console.WriteLine(p));
  }
}