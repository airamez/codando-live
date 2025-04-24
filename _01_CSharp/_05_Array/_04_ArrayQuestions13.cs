using System;
using System.Linq;
using System.Reflection;
using OurCompany;

/*
 * 13. Implement a routine to return how many times a value
       occurs in an array of integers
 */
public class ArrayQuestion13
{
  public static void Main(string[] args)
  {
    int[] arr = { 5, 8, 5, 3, 9, 5, 0, 3, 3, 5, 6 };

    Console.WriteLine($"Test with 5 passed: {CountValue(arr, 5) == 4}");
    Console.WriteLine($"Test with 7 passed: {CountValue(arr, 7) == 0}");
    Console.WriteLine($"Test with 8 passed: {CountValue(arr, 8) == 1}");
    Console.WriteLine($"Test with 3 passed: {CountValue(arr, 3) == 3}");

    Console.WriteLine($"Test with 5 passed: {CountValue2(arr, 5) == 4}");
    Console.WriteLine($"Test with 7 passed: {CountValue2(arr, 7) == 0}");
    Console.WriteLine($"Test with 8 passed: {CountValue2(arr, 8) == 1}");
    Console.WriteLine($"Test with 3 passed: {CountValue2(arr, 3) == 3}");
  }

  private static int CountValue(int[] array, int value)
  {
    int count = 0;
    for (int i = 0; i < array.Length; i++)
    {
      if (array[i] == value)
      {
        count++;
      }
    }
    return count;
  }

  private static int CountValue2(int[] array, int value)
  {
    return array.Count(e => e == value);
  }
}
