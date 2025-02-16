/*

*/
using System;

namespace OurStore;

public class Product
{
  public int ID { get; set; }
  public string Description { get; set; }
  public decimal Price { get; set; }

  public Product(int id, string description, decimal price)
  {
    ID = id;
    Description = description;
    Price = price;
  }

  // Default constructor required for XML serialization
  public Product()
  {

  }

  public override string ToString()
  {
    return $"Product: [ID: {ID}; Description: {Description}; Price: {Price}]";
  }
}