using System;
using OurCompany;

public class RecursionFactorial
{
  public static void Main(string[] args)
  {
    for (int i = 0; i <= 15; i++)
    {
      Console.WriteLine($"{i}! = {FactorialRecursive(i):n0}");
    }
  }

  public static long FactorialRecursive(int value)
  {
    if (value == 0 || value == 1)
    {
      return 1;
    }
    else return value * FactorialRecursive(value - 1);
  }
}