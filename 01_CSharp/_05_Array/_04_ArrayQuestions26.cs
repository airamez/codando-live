using System;
using System.ComponentModel;
using System.Linq;
using System.Net;
using System.Reflection;
using System.Runtime.Serialization.Formatters;
using OurCompany;

/*
 * 26. Implement a routine to randomize an array of integers
 */
public class ArrayQuestion26
{
  public static void Main(string[] args)
  {
    int[] array = { 0, 1, 2, 3, 4, 5, 6, 7, 8, 9 };
    RandomizeArray(array);
    MyArray.Print(array);

    RandomizeArray(array);
    MyArray.Print(array);

    for (int j = 0; j < 10000; j++)
    {
      RandomizeArray(array);
      MyArray.Print(array, $"#{j}");
    }
  }

  public static void RandomizeArray(int[] array)
  {
    Random random = new Random();
    for (int i = 0; i < array.Length - 1; i++)
    {
      int randomIndex = random.Next(i, array.Length);
      MyArray.swap(array, i, randomIndex);
    }
  }
}