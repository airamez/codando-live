using System;
using System.Linq;

public class MyArray
{
  public static int[] Clone(int[] inputArray)
  {
    int[] clonedArray = new int[inputArray.Length];
    for (int i = 0; i < clonedArray.Length; i++)
    {
      clonedArray[i] = inputArray[i];
    }
    return clonedArray;
  }

  public static int[] ReadIntArray(string label, int length)
  {
    // Creating the array
    int[] array = new int[length];
    // Reading values for each index of the array
    for (int i = 0; i < array.Length; i++)
    {
      Console.Write($"{label}[{i}] = ");
      array[i] = Convert.ToInt32(Console.ReadLine());
    }
    // Returnin the array
    return array;
  }

  public static void Print(int[] array, string label = "Array", bool inline = true)
  {
    if (array == null)
    {
      Console.WriteLine("Nothing to print: Array is null");
      return;
    }
    if (inline)
    {
      PrintInline(array, label);
    }
    else
    {
      PrintMultiLine(array, label);
    }
  }

  private static void PrintInline(int[] array, string label)
  {
    Console.Write($"{label}: [");
    for (int i = 0; i < array.Length - 1; i++)
    {
      Console.Write($"{array[i]},");
    }
    Console.WriteLine($"{array.Last()}]");
  }

  private static void PrintMultiLine(int[] array, string label)
  {
    for (int i = 0; i < array.Length; i++)
    {
      Console.WriteLine($"{label}[{i}]: {array[i]}");
    }
  }

  public static void swap(int[] array, int left, int right)
  {
    int aux = array[left];
    array[left] = array[right];
    array[right] = aux;
  }

}