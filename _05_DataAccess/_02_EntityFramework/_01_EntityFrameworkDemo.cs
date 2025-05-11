using System;
using System.Collections.Generic;
using System.Linq;
using DataAccess.Models;
using Microsoft.EntityFrameworkCore;

namespace ADO.NET.DataAccess.EF;

public class UsingDbContext
{

  public static void Main(string[] args)
  {
    var optionsBuilder = new DbContextOptionsBuilder<NorthWindContext>();
    optionsBuilder.UseSqlServer(ConnectionString.GetConnectionString());
    using (var context = new NorthWindContext(optionsBuilder.Options))
    {
      // Listing All
      List<Product> products = context.Products.ToList();
      products.ForEach(p => Console.WriteLine($"[{p.ProductId}; {p.ProductName}; {p.UnitPrice}]"));

      // Adding
      var newCustomer = new Customer
      {
        CustomerId = "NEWC1",
        CompanyName = "New Customer Inc.",
        ContactName = "John Doe"
      };
      context.Customers.Add(newCustomer);
      context.SaveChanges();

      // Find
      var foundCustomer = context.Customers.FirstOrDefault(c => c.CustomerId == "NEWC1");
      if (newCustomer != null)
      {
        Console.WriteLine($"{foundCustomer.CustomerId}; {foundCustomer.CompanyName}; {foundCustomer.ContactName}");
      }

      // Updating
      foundCustomer.CompanyName = "Updated Customer Inc.";
      context.SaveChanges();

      // Deleting
      context.Customers.Remove(foundCustomer);
      context.SaveChanges();

      // Querying
      var customers = context.Customers.Where(c => c.Country == "Brazil" && c.City == "Sao Paulo").ToList();
      customers.ForEach(c => Console.WriteLine($"{c.CustomerId}; {c.CompanyName}; {c.Country}, {c.City}"));

      // Accessing relationships
      var customersWithOrder =
        context.Customers
          .Include(c => c.Orders)           // Orders
          .ThenInclude(o => o.OrderDetails) // OrderDetails
          .ThenInclude(od => od.Product)    // Product
          .ToList();
      foreach (var customer in customers)
      {
        Console.WriteLine($"[{customer.CustomerId}]: {customer.CompanyName}");
        foreach (var order in customer.Orders)
        {
          Console.WriteLine($"* {order.OrderId}; {order.OrderDate}");
          foreach (var detail in order.OrderDetails)
          {
            Console.Write($"  - {detail.ProductId}; {detail.Product.ProductName}; ");
            Console.Write($"{detail.Quantity}; ${detail.UnitPrice:N2}; ");
            Console.WriteLine($"${detail.Quantity * detail.UnitPrice:N2}");
          }
        }
        Console.WriteLine("".PadLeft(60, '-'));
      }
    }
  }
}
