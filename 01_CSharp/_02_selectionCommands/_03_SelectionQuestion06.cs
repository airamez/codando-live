/*
 * Read a integer number and print if it is positive or negative.
 */

using System;
class SelectionQuestion06
{
  public static void Main(string[] args)
  {
    Console.Write("Number = ");
    int number = Convert.ToInt32(Console.ReadLine());
    if (number < 0)
    {
      Console.WriteLine("Negative");
    }
    else if (number > 0)
    {
      Console.WriteLine("Positive");
    }
  }
}