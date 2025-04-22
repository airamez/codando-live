/*
04. Read 5 integer numbers and print the biggest one.
 */
using System;
class SelectionQuestion04
{
  public static void Main(string[] args)
  {
    Console.Write("Number 1: ");
    int number1 = Convert.ToInt32(Console.ReadLine());
    Console.Write("Number 2: ");
    int number2 = Convert.ToInt32(Console.ReadLine());
    Console.Write("Number 3: ");
    int number3 = Convert.ToInt32(Console.ReadLine());
    Console.Write("Number 4: ");
    int number4 = Convert.ToInt32(Console.ReadLine());
    Console.Write("Number 5: ");
    int number5 = Convert.ToInt32(Console.ReadLine());

    // Console.WriteLine(Math.Max(number1, Math.Max(number2, Math.Max(number3, Math.Max(number4, number5)))));

    int highest = number1;

    if (number2 > highest)
    {
      highest = number2;
    }
    if (number3 > highest)
    {
      highest = number3;
    }
    if (number4 > highest)
    {
      highest = number4;
    }
    if (number5 > highest)
    {
      highest = number5;
    }
    Console.WriteLine(highest);
  }
}