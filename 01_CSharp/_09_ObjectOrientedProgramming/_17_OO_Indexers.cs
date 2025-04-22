using System;
/*
# Indexers allow instances of a class to be indexed just like arrays.
# The indexed value can be set or retrieved without explicitly 
  specifying a type or instance member.
# Indexers resemble properties except that their accessors take
  parameters.
# An indexer is a special type of property that allows a class to
  be accessed like an array for its internal collection.
# An indexer can be defined the same way as property with this keyword
  and square brackets []
  public string this[int i]
  {
    get { 
      return Collection[i]; 
    }
    set { 
      Collection[i] = value; 
    }
  }
# An indexer can:
  # be overloaded with different parameter types and return types.
  # be declared as read-only or write-only.
  # be declared as static.
  # be declared as virtual, abstract, or sealed.

# Class Content
  # Create an example to show it
  # Class: 
    # Customers
      # Add
      # Indexer by email
      # PrintAll
      # Print(email)
    # Customer
      # Email
      # Name
      # override string ToString
*/

namespace OurCompany.LearnCoding.OOP.Indexers;

public class IndexersApp
{
  public static void Main(string[] args)
  {
    Customers customers = new Customers(10);
    customers.Add(new Customer("mjordan@nba.com", "Michael Jordan"));
    customers.Add(new Customer("ppipens@nba.com", "Scotch Pippens"));
    customers.Add(new Customer("barkley@nba.com", "Charles Barkley"));
    customers.Add(new Customer("shaq@nba.com", "Shark Oneil"));

    Customer jordan = customers["mjordan@nba.com"];
    Console.WriteLine(jordan);

    Customer oscar = customers["oscar@nba.com"];
    Console.WriteLine(oscar);

    Console.WriteLine(customers["shaq@nba.com"]);
    customers["shaq@nba.com"] = new Customer("Shaquil@nba.com", "Shaquille Rashaun O'Neal ");
    Console.WriteLine(customers["shaq@nba.com"]);
    Console.WriteLine(customers["Shaquil@nba.com"]);
  }
}

public class Customer
{
  public string Email { get; set; }
  public string Name { get; set; }

  public Customer(string email, string name)
  {
    Email = email;
    Name = name;
  }
  public override string ToString()
  {
    return $"[Email:{Email}; Name:{Name}]";
  }
}

public class Customers
{
  private Customer[] customers;
  private int newCustomerIndex;

  public Customers(int capacity)
  {
    customers = new Customer[capacity];
    newCustomerIndex = 0;
  }

  public Customer this[string email]
  {
    get
    {
      for (int i = 0; i < newCustomerIndex; i++)
      {
        if (customers[i].Email == email)
        {
          return customers[i];
        }
      }
      return null;
    }
    set
    {
      for (int i = 0; i < newCustomerIndex; i++)
      {
        if (customers[i].Email == email)
        {
          customers[i] = value;
          return;
        }
      }
    }
  }

  public void Add(Customer customer)
  {
    customers[newCustomerIndex] = customer;
    newCustomerIndex++;
  }
}