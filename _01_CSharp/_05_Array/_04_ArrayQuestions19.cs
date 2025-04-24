using System;
using System.Linq;
using System.Reflection;
using OurCompany;

/*
 * 19. Implement a routine to indicate if an array is in ascendent order
 */
public class ArrayQuestion19
{
  public static void Main(string[] args)
  {
    int[] a1 = { 1, 2, 3, 7, 9 }; // true
    int[] a2 = { 1, 2, 3, 7, 9, 4 }; // false
    int[] a3 = { 1, 2, 3, 7, 7, 9 }; // false
    int[] a4 = { 1, 2, 3, 7, 9, 9 }; // false

    Console.WriteLine(IsAncendingOrder(a1));
    Console.WriteLine(IsAncendingOrder(a2) == false);
    Console.WriteLine(IsAncendingOrder(a3) == false);
    Console.WriteLine(IsAncendingOrder(a4) == false);
  }

  private static bool IsAncendingOrder(int[] array)
  {
    // for (int i = 0; i < array.Length - 1; i++)
    // {
    //     if (array[i] >= array[i+1]) {
    //         return false;
    //     }
    // }
    for (int i = 1; i < array.Length; i++)
    {
      if (array[i] <= array[i - 1])
      {
        return false;
      }
    }
    return true;
  }
}
