/*
 * This class will be used on all Collections Example
*/
using System;

namespace Collections;

public class Product
{

  static int nextId = 0;
  public int Id { get; set; }
  public string Description { get; set; }
  public double Price { get; set; }

  public Product(int id, string description, double price)
  {
    Id = id;
    Description = description;
    Price = price;
  }

  public override string ToString()
    => $"[ID: {Id}; Description: {Description}; Price: ${Price:#.##}]";

  public static Product GenerateRandom()
  {
    var rnd = new Random();
    var newId = nextId++;
    return new Product(
      newId,
      $"Product {newId}", // First 8 chars of Id
      rnd.NextDouble() * 500 + 10); // from 10.00 to 500.00
  }

  public static void Main(string[] args)
  {
    for (int i = 0; i < 10; i++)
    {
      Console.WriteLine(GenerateRandom());
    }
  }
}