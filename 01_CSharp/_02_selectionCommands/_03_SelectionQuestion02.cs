/*
02. Read two integer numbers and print the one with highest value.
    If the values are equal, print "EQUALS".
 */

using System;
class SelectionQuestion02
{
  public static void Main(string[] args)
  {
    Console.Write("Number 1: ");
    int number1 = Convert.ToInt32(Console.ReadLine());
    Console.Write("Number 2: ");
    int number2 = Convert.ToInt32(Console.ReadLine());

    // if (number1 == number2) {
    //     Console.WriteLine("EQUALS");
    // } else if (number1 > number2) {
    //     Console.WriteLine($"Highest = {number1}");
    // } else {
    //     Console.WriteLine($"Highest = {number2}");
    // }

    if (number1 == number2)
    {
      Console.WriteLine("EQUALS");
    }
    else
    {
      Console.WriteLine($"Highest = {Math.Max(number1, number2)}");
    }
  }
}