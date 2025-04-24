using System;
using System.Collections.Generic;

namespace OurStore;

public class Customers
{
  private List<Customer> customers;

  public Customers()
  {
    customers = new List<Customer>();
  }

  public void Add(Customer customer)
  {
    customers.Add(customer);
  }

  public Customer Add(string email, string name, string address)
  {
    Customer customer = new(email, name, address);
    customers.Add(customer);
    return customer;
  }

  public Customer FindByEmail(string email)
  {
    foreach (Customer customer in customers)
    {
      if (string.Equals(customer.Email, email, StringComparison.CurrentCultureIgnoreCase))
      {
        return customer;
      }
    }
    return null;
  }

  public void Print()
  {
    Console.WriteLine("".PadLeft(150, '-'));
    Console.WriteLine("Customer:");
    foreach (Customer customer in customers)
    {
      Console.Write("\t");
      Console.WriteLine(customer);
    }
    Console.WriteLine("".PadLeft(150, '-'));
  }

}