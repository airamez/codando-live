using System;
using System.Collections.Generic;
using System.Linq;
using DataAccess.Models;
using Microsoft.Data.SqlClient;
using Microsoft.EntityFrameworkCore;

namespace ADO.NET.DataAccess.EF;

public class EntityFrameworkApp
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
        ContactName = "Jose Santos"
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
      var customers = context
        .Customers
        .Where(c => c.Country == "Brazil" && c.City == "Sao Paulo")
        .ToList();
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

      // Using Transactions
      using (var transaction = context.Database.BeginTransaction())
      {
        try
        {
          int sourceAccountId = 1;
          int targetAccountId = 2;
          decimal amount = 100;
          var sourceAccount = context.Accounts.Find(sourceAccountId);
          var targetAccount = context.Accounts.Find(targetAccountId);
          if (sourceAccount == null) throw new Exception("Source Account ID is invalid");
          if (targetAccount == null) throw new Exception("Target Account ID is invalid");
          if (sourceAccount.Amount < amount)
          {
            throw new Exception("Insufficient funds.");
          }
          sourceAccount.Amount -= amount;
          targetAccount.Amount += amount;
          context.SaveChanges();
          transaction.Commit();
        }
        catch (Exception ex)
        {
          transaction.Rollback();
          Console.WriteLine($"Transaction failed: {ex.Message}");
        }
      }

      // Calling a procedure
      try
      {
        var sourceAccountIdParam = new SqlParameter("@SourceAccountId", 2);
        var targetAccountIdParam = new SqlParameter("@TargetAccountId", 1);
        var amountParam = new SqlParameter("@Amount", 100);
        context.Database.ExecuteSqlRaw("EXEC TransferAmount @SourceAccountId, @TargetAccountId, @Amount",
                                       sourceAccountIdParam, targetAccountIdParam, amountParam);
      }
      catch (Exception ex)
      {
        Console.WriteLine(ex.Message);
      }
    }
  }
}
