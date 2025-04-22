/*
Create the OurStore Class Diagram and a Demo App
 */

using System;

namespace OurStore;

public class OurStoreApp2
{
  public static void Main(string[] args)
  {
    Customers customers = new Customers();
    customers.Add("mjordan@nba.com", "Michael Jordan", "Los Angeles");
    customers.Add("spipens@nba.com", "Scotch Pipens", "San Diego");
    customers.Add("ljames@nba.com", "Lebron James", "San Francisco");

    Products prodcuts = new Products();
    prodcuts.Add(1, "Basketball", 250);
    prodcuts.Add(2, "Bull's TShirt", 450);
    prodcuts.Add(3, "Water bottle", 45);

    Customer customer = customers.FindByEmail("mjordan@nba.com");
    Console.WriteLine(customer);
    Order order = customer.AddOrder();
    order.AddProduct(prodcuts.FindById(3), 30);
    order.AddProduct(prodcuts.FindById(1), 5);
    order.AddProduct(prodcuts.FindById(2), 15);
    Console.WriteLine($"Order Total: {order.Total}");
    customer.PrintOrders();
    order.UpdateStatus(OrderStatus.Completed);
    customer.PrintOrders();
  }
}