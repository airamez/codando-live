/*
Create the OurStore Class Diagram and a Demo App
 */

using System;

namespace OurStore;

public class OurStoreApp
{
  public static void Main(string[] args)
  {
    Customers customers = new Customers();
    customers.Add("customer1@noemail.com", "Customer One",
                  "1234 Street 1, San Diego, CA. 921278");
    customers.Add("customer2@noemail.com", "Customer 2",
                  "4321 Street 2, San Diego, CA");

    Customer customer1 =
        customers.FindByEmail("customer1@noemail.com");
    Console.WriteLine(customer1);

    Customer customer2 =
        customers.FindByEmail("customer2@noemail.com");
    customer2.Address = "4321 Street 2, San Diego, CA. 92189";
    Console.WriteLine(customer2);

    Customer customerNotFound =
        customers.FindByEmail("customer@noemail.com");
    Console.WriteLine(customerNotFound);

    Product product1 = new(1, "Product 1", (decimal)10.50);
    Product product2 = new(2, "Product 2", (decimal)20.75);

    Console.WriteLine(product1);
    Console.WriteLine(product2);

    Products products = new();
    products.Add(product1);
    products.Add(product2);
    products.Add(3, "Product 3", (decimal)30.30);

    Product prod1 = products.FindById(1);
    Console.WriteLine(prod1);
    Console.WriteLine(products.FindById(2));
    Product prod4 = products.FindById(4);
    Console.WriteLine(prod4);

    customers.Print();
    products.Print();

    Order order1 = customer1.AddOrder();
    Console.WriteLine(order1);
    _ = customer1.AddOrder();
    Order order3 = customer1.AddOrder();
    Console.WriteLine(order3);
    Order currentOpenOrder = customer1.GetCurrentOpenOrder();
    Console.WriteLine(currentOpenOrder);
    Order newOrder1 = customer1.AddOrder();
    Console.WriteLine(newOrder1);

    Order order3Ref = customer1.FindOrderById(3);
    Console.WriteLine(order3Ref);

    customer1.PrintOrders();

    Order order4Ref = customer1.FindOrderById(4);

    Console.WriteLine(order4Ref);
    order4Ref.UpdateStatus(OrderStatus.Completed);
    Console.WriteLine(order4Ref);

    Console.WriteLine(customer1.FindOrderById(1));
    customer1.FindOrderById(1).UpdateStatus(OrderStatus.Open);
    Console.WriteLine(customer1.FindOrderById(1));

    // OrderProduct orderProduct = new OrderProduct(products.FindById(1), 2);
    // Console.WriteLine(orderProduct);

    customers.FindByEmail("customer1@noemail.com")
        .FindOrderById(1)
        .AddProduct(products.FindById(1), 5);
    customers.FindByEmail("customer1@noemail.com")
        .FindOrderById(1)
        .AddProduct(products.FindById(2), 3);
    customers.FindByEmail("customer1@noemail.com")
        .FindOrderById(1)
        .AddProduct(products.FindById(3), 2);

    Order currentOrder = customers.FindByEmail("customer1@noemail.com")
        .FindOrderById(2);
    currentOrder.UpdateStatus(OrderStatus.Open);
    currentOrder.AddProduct(products.FindById(1), 4);
    currentOrder.AddProduct(products.FindById(2), 3);
    currentOrder.AddProduct(products.FindById(3), 5);
  }
}