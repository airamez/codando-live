using System;
using System.Net;
using OurCompany;

/*
 * 04. Implement a routine to receive an integer array and return
 * the min and max values as output parameters: FindMinAndMax(array, out min, out max)
 */
public class ArrayQuestion04
{
  public static void Main(string[] args)
  {
    int[] array = { 7, 1, 9, 0, 35, 40, 8, 17, 40, 0, 8, 3, 7, 15 };
    int minimum;
    int maximum;

    // Case 1
    FindMinAndMax(array, out minimum, out maximum);
    Console.WriteLine($"Min: {minimum}; Max: {maximum}");
    Console.WriteLine($"Test result: {minimum == 0 && maximum == 40}");

    // Case 2
    FindMinAndMax2(array, out minimum, out maximum);
    Console.WriteLine($"Min: {minimum}; Max: {maximum}");
    Console.WriteLine($"Test result: {minimum == 0 && maximum == 40}");

    // Case 3: Test FindMin
    int min = FindMin(array);
    Console.WriteLine($"Test result: {min == 0}");

    // Case 4: Test FindMax
    int max = FindMax(array);
    Console.WriteLine($"Test result: {max == 40}");
  }

  public static void FindMinAndMax(int[] array, out int min, out int max)
  {
    min = array[0];
    max = array[0];
    for (int i = 1; i < array.Length; i++)
    {
      min = Math.Min(min, array[i]);
      max = Math.Max(max, array[i]);
    }
  }

  public static void FindMinAndMax2(int[] array, out int min, out int max)
  {
    min = FindMin(array);
    max = FindMax(array);
  }

  public static int FindMin(int[] array)
  {
    int min = array[0];
    for (int i = 1; i < array.Length; i++)
    {
      min = Math.Min(min, array[i]);
    }
    return min;
  }

  public static int FindMax(int[] array)
  {
    int max = array[0];
    for (int i = 1; i < array.Length; i++)
    {
      max = Math.Max(max, array[i]);
    }
    return max;
  }

}