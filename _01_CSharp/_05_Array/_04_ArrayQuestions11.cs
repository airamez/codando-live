using System;
using System.Linq;
using System.Reflection;
using OurCompany;

/*
 * 11. Implement a routine to reverse an integer array. Try it in-place
 */
public class ArrayQuestion11
{
  public static void Main(string[] args)
  {
    int[] array = { 0, 1, 2, 3, 4, 5, 6, 7, 8, 9 };
    MyArray.Print(array, "Original");
    ArrayReverse(ref array);
    MyArray.Print(array, "Reversed1");
    ArrayReverseinPlace(array);
    MyArray.Print(array, "Reversed2");
  }

  public static void ArrayReverseinPlace(int[] array)
  {
    int left = 0;
    int right = array.Length - 1;
    while (left < right)
    {
      MyArray.swap(array, left, right);
      left++;
      right--;
    }
  }

  public static void ArrayReverse(ref int[] array)
  {
    int[] reversed = new int[array.Length];
    int j = reversed.Length - 1;
    for (int i = 0; i < array.Length; i++)
    {
      reversed[j] = array[i];
      j--;
    }
    array = reversed;
  }
}
