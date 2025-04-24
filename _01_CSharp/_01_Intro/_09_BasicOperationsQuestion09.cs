/*
 * 09. Read the buying price (cost), the desired profit percentage and the sales tax % and
 *     calculate the final sales price of a product.
 */
using System;
class _006_BasicOperationsQuestions09
{
  public static void Main(string[] args)
  {
    Console.Write("Buying Price = ");
    double buyingPrice = Convert.ToDouble(Console.ReadLine());
    Console.Write("Profit Percentage = ");
    double profitPercentage = Convert.ToDouble(Console.ReadLine());
    Console.Write("Sales Tax Percentage = ");
    double salesTaxPercentage = Convert.ToDouble(Console.ReadLine());

    double profit = buyingPrice * (profitPercentage / 100);
    double salesPrice = buyingPrice + profit;
    double salesTax = salesPrice * (salesTaxPercentage / 100);
    double finalSalesPrice = salesPrice + salesTax;

    Console.WriteLine($"Profit = {profit}");
    Console.WriteLine($"Sales Tax = {salesTax}");
    Console.WriteLine($"Final Sales Price = {finalSalesPrice}");
  }
}