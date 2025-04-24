using System;
using System.ComponentModel;

namespace OurStore;

// Homework: Finish the implementation of this application 

public class OurStoreApp3
{
  public static void Main(string[] args)
  {

    Customers customers = new Customers();
    Products products = new Products();

    while (true)
    {
      Console.Clear();
      int option = GetMenuOption();
      switch (option)
      {
        case 0:
          return;
        case 1:
          AddCustomer(customers);
          break;
        case 2:
          AddProduct(products);
          break;
        case 3:
          AddOrder(customers, products);
          break;
        case 4:
          PrintCustomers(customers);
          break;
      }
      Console.WriteLine("Press any key to continue!");
      Console.ReadKey();
    }
  }

  private static void AddCustomer(Customers customers)
  {
    customers.Add(Customer.ReadFromConsole());
  }

  private static void AddProduct(Products products)
  {
    Console.WriteLine("Add Product");
  }

  private static void AddOrder(Customers customers, Products products)
  {
    Console.WriteLine("Add Order");
  }

  private static void PrintCustomers(Customers customers)
  {
    customers.Print();
  }

  public static int GetMenuOption()
  {
    Console.WriteLine("Select an Option:");
    Console.WriteLine("0: Exit");
    Console.WriteLine("1: Add a customer");
    Console.WriteLine("2: Add a product");
    Console.WriteLine("3: Create order");
    Console.WriteLine("4: Print customers");
    Console.WriteLine("5: Print products");
    Console.Write("Option: ");
    int option = Convert.ToInt32(Console.ReadLine());
    return option;
  }
}