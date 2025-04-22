using System;
using OurCompany;

/*
 *  9. Implement a routine to indicate if two arrays of integer are equals 
       (have the same values on same indexes)
 */
public class ArrayQuestion09
{
  public static void Main(string[] args)
  {
    int[] array1 = { 1, 2, 3, 4, 5 };
    int[] array2 = { 1, 2, 3, 4, 5 };
    int[] array3 = { 1, 2, 3, 4, 5, 6, 7 };
    int[] array4 = { 1, 2, 3, 4, 5 };
    int[] array5 = { 1, 2, 0, 4, 5 };
    int[] array6 = { 1, 2, 3, 4, 5 };

    Console.WriteLine($"Test Paseed: {ArrayEquals(array1, array2)}");
    Console.WriteLine($"Test Paseed: {ArrayEquals(array3, array4) == false}");
    Console.WriteLine($"Test Paseed: {ArrayEquals(array5, array6) == false}");

    Console.WriteLine($"Test Paseed: {ArrayEquals2(array1, array2)}");
    Console.WriteLine($"Test Paseed: {ArrayEquals2(array3, array4)}");
    Console.WriteLine($"Test Paseed: {ArrayEquals2(array5, array6) == false}");

  }

  public static bool ArrayEquals(int[] array1, int[] array2)
  {
    if (array1.Length != array2.Length)
    {
      return false;
    }
    for (int i = 0; i < array1.Length; i++)
    {
      if (array1[i] != array2[i])
      {
        return false;
      }
    }
    return true;
  }

  public static bool ArrayEquals2(int[] array1, int[] array2)
  {
    int i = 0;
    while (i < array1.Length && i < array2.Length)
    {
      if (array1[i] != array2[i])
      {
        return false;
      }
      i++;
    }
    return true;
  }
}