/*
Read the quantity of a product in a shopping card and calculate 
the total price using the rules below:
    Quantity    Unit price
      1  to 5     $1.50
      6  to 10    $1.45
      11 to 50    $1.40
      50 to 100   $1.30
      > 100       $1.20
 */
using System;
class SelectionQuestion15
{
  public static void Main(string[] args)
  {
    Console.Write("Quantity: ");
    double quantity = Convert.ToDouble(Console.ReadLine());

    double unitPrice = 0;
    // Getting the unit price
    if (quantity <= 5)
    {
      unitPrice = 1.5;
    }
    else if (quantity <= 10)
    {
      unitPrice = 1.45;
    }
    else if (quantity <= 50)
    {
      unitPrice = 1.40;
    }
    else if (quantity <= 100)
    {
      unitPrice = 1.3;
    }
    else
    {
      unitPrice = 1.2;
    }
    // Calculating the total  price
    double totalPrice = quantity * unitPrice;
    Console.WriteLine($"Total = {totalPrice}");
  }
}