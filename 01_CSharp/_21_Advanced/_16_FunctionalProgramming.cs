/*
- Definition: SHOW THE MEMES
  1. Functional programming is a style of programming that emphasizes using functions to 
     process data, rather than changing the data itself through state or variables.
  2. Functional programming is a programming paradigm where computation is treated as the
     evaluation of mathematical functions, avoiding changing state and mutable data.
- Core Principles:
  - Immutability: Data objects are immutable.
  - First-Class Functions: Functions are treated as first-class citizens; they can be 
    passed as arguments, returned from other functions, and assigned to variables.
  - Pure Functions: Functions produce the same output for the same input without side effects.
  - Higher-Order Functions: Functions that can take other functions as arguments or 
    return them as results.
  - Declarative Code: Focuses on "what to do" rather than "how to do it."
  - Function Composition: Combining simple functions to build more complex ones.
*/

using System;
using System.Collections.Generic;
using System.Linq;

namespace Advanced;

public class FunctinalProgrammingApp
{
  static void Main(string[] args)
  {
    // Example 1
    List<int> numbers = Enumerable.Range(0, 100).ToList();
    IEnumerable<int> fivesDoubled = numbers
            .Where(n => n % 5 == 0)
            .Select(n => n + n);
    Console.WriteLine("Squared even numbers:");
    fivesDoubled.ToList().ForEach(n => Console.Write(n + " "));
    Console.WriteLine();

    // Example 2
    /*
       - Using Func to declare a method
         - Func is a built-in delegate type that represents a method with a return value.
         - It allows you to encapsulate methods in a reusable and type-safe way.
         - The last type parameter always represents the return type.
         - Declaration
           Func<parameter1Type, parameter2Type, ..., returnType>
    */

    Func<int, int, int> add = (a, b) => a + b;
    Func<int, int, int> power = (a, b) => (int)Math.Pow(a, b);
    int addResult = PerformOperation(2, 5, add);
    int powerResult = PerformOperation(2, 5, power);
    Console.WriteLine($"Sum using higher-order function: {addResult}");
    Console.WriteLine($"Power using higher-order function: {powerResult}");

    // Example 3
    var rankedProducts = Product.GetSampleData()
        .Select(p => new // Create a new list with products and the calculated Weight
        {
          Product = p,
          Weight = (p.Popularity * 0.6) + (p.Relevance * 0.4) // Calculate the Weight
        })
        .OrderByDescending(p => p.Weight) // Sort by weight in descending order
        .Take(10); // Limit to top X products

    Console.WriteLine("Top Ranked Products:");
    rankedProducts.ToList().ForEach(p => Console.WriteLine($"{p.Weight:F2}: {p.Product.Name}"));

    // Example 4
    var salesSummary = Sale.GetSampleData()
        .Where(s => s.Year == 2023) // Filter sales from 2023
        .GroupBy(s => s.Region)    // Group sales by region
        .Where(g => g.Sum(s => s.Amount) > 1_000) // HAVING: total sales > 1000
        .Select(g => new SalesSummary
        {
          Region = g.Key,
          TotalSales = g.Sum(s => s.Amount) // Calculate total sales per group
        })
        .OrderByDescending(summary => summary.TotalSales) // Order by total sales descending
        .ToList();
    Console.WriteLine("Sales Summary (2023, Total Sales > $1000):");
    foreach (var summary in salesSummary)
    {
      Console.WriteLine($"Region: {summary.Region}, Total Sales: {summary.TotalSales:C}");
    }
  }

  static int PerformOperation(int x, int y, Func<int, int, int> operation)
  {
    return operation(x, y);
  }
}

public class Product
{
  public string Name { get; set; }
  public int Popularity { get; set; }
  public int Relevance { get; set; }

  public static List<Product> GetSampleData()
  {
    List<Product> products = new List<Product>
    {
        new() { Name = "Laptop", Popularity = 95, Relevance = 90 },
        new() { Name = "Headphones", Popularity = 80, Relevance = 85 },
        new() { Name = "Keyboard", Popularity = 70, Relevance = 88 },
        new() { Name = "Mouse", Popularity = 85, Relevance = 80 },
        new() { Name = "Monitor", Popularity = 75, Relevance = 95 },
        new() { Name = "Smartphone", Popularity = 92, Relevance = 88 },
        new() { Name = "Tablet", Popularity = 89, Relevance = 87 },
        new() { Name = "Charger", Popularity = 65, Relevance = 70 },
        new() { Name = "Power Bank", Popularity = 78, Relevance = 83 },
        new() { Name = "Smartwatch", Popularity = 88, Relevance = 85 },
        new() { Name = "Earbuds", Popularity = 80, Relevance = 82 },
        new() { Name = "Speaker", Popularity = 77, Relevance = 84 },
        new() { Name = "Gaming Console", Popularity = 95, Relevance = 92 },
        new() { Name = "TV", Popularity = 90, Relevance = 89 },
        new() { Name = "Camera", Popularity = 85, Relevance = 88 },
        new() { Name = "Tripod", Popularity = 60, Relevance = 70 },
        new() { Name = "Memory Card", Popularity = 75, Relevance = 73 },
        new() { Name = "Hard Drive", Popularity = 78, Relevance = 79 },
        new() { Name = "SSD", Popularity = 85, Relevance = 90 },
        new() { Name = "RAM", Popularity = 83, Relevance = 86 },
        new() { Name = "Motherboard", Popularity = 80, Relevance = 85 },
        new() { Name = "Processor", Popularity = 90, Relevance = 92 },
        new() { Name = "GPU", Popularity = 92, Relevance = 95 },
        new() { Name = "Power Supply", Popularity = 70, Relevance = 80 },
        new() { Name = "PC Case", Popularity = 68, Relevance = 75 },
        new() { Name = "Cooling Fan", Popularity = 65, Relevance = 72 },
        new() { Name = "Router", Popularity = 78, Relevance = 80 },
        new() { Name = "Modem", Popularity = 72, Relevance = 75 },
        new() { Name = "Network Switch", Popularity = 68, Relevance = 73 },
        new() { Name = "Surge Protector", Popularity = 60, Relevance = 65 },
        new() { Name = "USB Cable", Popularity = 55, Relevance = 60 },
        new() { Name = "HDMI Cable", Popularity = 70, Relevance = 75 },
        new() { Name = "Microphone", Popularity = 75, Relevance = 82 },
        new() { Name = "Webcam", Popularity = 78, Relevance = 83 },
        new() { Name = "VR Headset", Popularity = 85, Relevance = 88 },
        new() { Name = "Drone", Popularity = 92, Relevance = 90 },
        new() { Name = "3D Printer", Popularity = 88, Relevance = 87 },
        new() { Name = "Flash Drive", Popularity = 72, Relevance = 75 },
        new() { Name = "Pen Tablet", Popularity = 75, Relevance = 80 },
        new() { Name = "Smart Light", Popularity = 70, Relevance = 73 },
        new() { Name = "Smart Thermostat", Popularity = 80, Relevance = 83 },
        new() { Name = "Robot Vacuum", Popularity = 88, Relevance = 85 },
        new() { Name = "Fitness Tracker", Popularity = 85, Relevance = 82 },
        new() { Name = "Electric Scooter", Popularity = 92, Relevance = 89 },
        new() { Name = "E-Reader", Popularity = 83, Relevance = 85 },
        new() { Name = "Digital Clock", Popularity = 70, Relevance = 73 },
        new() { Name = "Projector", Popularity = 88, Relevance = 90 },
        new() { Name = "Bluetooth Adapter", Popularity = 65, Relevance = 70 },
        new() { Name = "Wireless Charger", Popularity = 78, Relevance = 83 },
        new() { Name = "Noise Cancelling Headphones", Popularity = 95, Relevance = 95 }
    };
    return products;
  }
}

public class Sale
{
  public string Region { get; set; }
  public int Year { get; set; }
  public decimal Amount { get; set; }

  public static List<Sale> GetSampleData()
  {
    List<Sale> sales = new List<Sale>
        {
            new() { Region = "North", Year = 2023, Amount = 1200 },
            new() { Region = "North", Year = 2023, Amount = 800 },
            new() { Region = "North", Year = 2024, Amount = 400 },
            new() { Region = "South", Year = 2023, Amount = 500 },
            new() { Region = "South", Year = 2023, Amount = 1500 },
            new() { Region = "South", Year = 2024, Amount = 200 },
            new() { Region = "South", Year = 2023, Amount = 500 },
            new() { Region = "West", Year = 2023, Amount = 1000 },
            new() { Region = "West", Year = 2024, Amount = 300 },
        };
    return sales;
  }
}

public class SalesSummary
{
  public string Region { get; set; }
  public decimal TotalSales { get; set; }
}