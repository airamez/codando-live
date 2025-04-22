using System;

namespace Extras;

public class ParamsApp
{
  public static void Main()
  {
    Console.WriteLine($"Sum: {Sum(1, 2, 3)}");
    Console.WriteLine($"Sum: {Sum(1, 2, 3, 4, 5, 6)}");
    Console.WriteLine($"Sum: {Sum(1, 2, 3, 4, 5, 6, 7, 8, 9, 10)}");
    Console.WriteLine($"Average: {Average(1, 2, 3)}");
    Console.WriteLine($"Average: {Average(1, 2, 3, 4, 5, 6)}");
    Console.WriteLine($"Average: {Average(1, 2, 3, 4, 5, 6, 7, 8, 9, 10)}");
  }

  public static int Sum(params int[] numbers)
  {
    int sum = 0;
    foreach (int number in numbers)
    {
      sum += number;
    }
    return sum;
  }

  public static decimal Average(params int[] numbers)
  {
    int sum = 0;
    foreach (int number in numbers)
    {
      sum += number;
    }
    return sum / (decimal)numbers.Length;
  }
}