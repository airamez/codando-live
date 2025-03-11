using System;
using System.Collections.Generic;
using System.Linq;

namespace Advanced;

public class FunctinalProgrammingApp
{
  static void Main(string[] args)
  {
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