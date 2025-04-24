using System;
using System.Linq;
using OurCompany;

/*
 *  6. Implement a routine to return the first and last elements of an array of integers as output parameters:
       GetFirstAndLast(array, out first, out last)
 */
public class ArrayQuestion06
{
  public static void Main(string[] args)
  {
    int[] array = { 1, 2, 3, 4, 5, 6, 7, 8, 9 };
    int firstElement;
    int lastElement;
    GetFirstAndLast(array, out firstElement, out lastElement);

    Console.Write($"Test Passed: {firstElement == 1 && lastElement == 9}");
  }

  public static void GetFirstAndLast(int[] array, out int first, out int last)
  {
    first = array.First();
    last = array.Last();
    // first = array[0];
    // last = array[array.Length - 1];
  }
}