/*
 * 08. Read the buying price (cost), the desired profit percentage and
       calculate the sales price of a product.
 */
using System;
class _006_BasicOperationsQuestions08
{
  public static void Main(string[] args)
  {
    Console.Write("Buying Price = ");
    double buyingPrice = Convert.ToDouble(Console.ReadLine());
    Console.Write("Profit Percentage: ");
    double profitPercentage = Convert.ToDouble(Console.ReadLine());
    double profit = buyingPrice * (profitPercentage / 100);
    double salesPrice = buyingPrice + profit;
    Console.WriteLine($"Profit: {profit}");
    Console.WriteLine($"Sales Price = {salesPrice}");
  }
}