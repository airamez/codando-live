using System;
using System.Linq;
using System.Reflection;
using OurCompany;

/*
14. Implement a routine to return a new array with only unique
    values from an array of integers
 */
public class ArrayQuestion14
{
  public static void Main(string[] args)
  {
    int[] array = { 3, 5, 8, 9, 3, 5, 1, 2, 5, 5, 5, 6, 8, 0, 4 };
    int[] unique = GetUnique(array);
    MyArray.Print(array, "Array");
    MyArray.Print(unique, "Unique");

    int[] array2 = { 1, 2, 3, 4, 5, 6, 7, 8, 9 };
    int[] unique2 = GetUnique(array2);
    MyArray.Print(array2, "Array");
    MyArray.Print(unique2, "Unique");


    int[] unique3 = GetUnique2(array);
    MyArray.Print(array, "Array");
    MyArray.Print(unique3, "Unique3");
  }

  private static int[] GetUnique(int[] array)
  {
    int[] unique = new int[array.Length];
    int uniqueIndex = 0;
    for (int i = 0; i < array.Length; i++)
    {
      bool found = false;
      for (int j = 0; j < uniqueIndex; j++)
      {
        if (array[i] == unique[j])
        {
          found = true;
          break;
        }
      }
      if (!found)
      {
        unique[uniqueIndex] = array[i];
        uniqueIndex++;
      }
    }
    // Generating a new array with only necessary values
    int[] result = new int[uniqueIndex];
    Array.Copy(unique, 0, result, 0, uniqueIndex);
    return result;
  }

  private static int[] GetUnique2(int[] array)
  {
    int[] unique = new int[array.Length];
    int uniqueIndex = 0;
    for (int i = 0; i < array.Length; i++)
    {
      int count = array.Count(e => e == array[i]);
      if (count == 1)
      {
        unique[uniqueIndex] = array[i];
        uniqueIndex++;
      }
    }
    // Generating a new array with only necessary values
    int[] result = new int[uniqueIndex];
    Array.Copy(unique, 0, result, 0, uniqueIndex);
    return result;
  }
}
