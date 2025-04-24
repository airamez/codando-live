using System;
using System.ComponentModel;
using System.Linq;
using System.Net;
using System.Reflection;
using OurCompany;

/*
 * 23. Implement a routine to move all zeros of an integer array to the left side.
       Can you do it in-place?
 */
public class ArrayQuestion23
{
  public static void Main(string[] args)
  {

    int[] array1 = { 0, 1, 2, 0, 0, 3, 0, 0, 4, 5, 0, 0, 0, 7, 0, 0 };
    MyArray.Print(array1);
    MoveZeroesLeftInPlaceSimplest(array1);
    MyArray.Print(array1);
    Console.WriteLine();

    int[] array2 = { 1, 2, 3, 0, 0, 0, 0, 4, 5, 0, 0, 0, 7, 0, 8, 0, 0, 0, 0 };
    MyArray.Print(array2);
    MoveZeroesLeftInPlaceSimplest(array2);
    MyArray.Print(array2);
    Console.WriteLine();

    int[] array3 = { 1, 2, 3, 4, 5, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 6 };
    MyArray.Print(array3);
    MoveZeroesLeftInPlaceSimplest(array3);
    MyArray.Print(array3);
    Console.WriteLine();

    int[] array4 = { 1, 2, 3, 4, 5, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 6, 7, 8 };
    MyArray.Print(array4);
    MoveZeroesLeftInPlaceSimplest(array4);
    MyArray.Print(array4);
    Console.WriteLine();

    int[] array5 = { 1, 0 };
    MyArray.Print(array5);
    MoveZeroesLeftInPlaceSimplest(array5);
    MyArray.Print(array5);
    Console.WriteLine();

    int[] array6 = { 0, 1 };
    MyArray.Print(array6);
    MoveZeroesLeftInPlaceSimplest(array6);
    MyArray.Print(array6);
    Console.WriteLine();

    int[] array7 = { 1, 2, 3, 4, 5 };
    MyArray.Print(array7);
    MoveZeroesLeftInPlaceSimplest(array7);
    MyArray.Print(array7);
    Console.WriteLine();

    int[] array8 = { 1 };
    MyArray.Print(array8);
    MoveZeroesLeftInPlaceSimplest(array8);
    MyArray.Print(array8);
    Console.WriteLine();

    int[] array9 = { 0 };
    MyArray.Print(array9);
    MoveZeroesLeftInPlaceSimplest(array9);
    MyArray.Print(array9);
    Console.WriteLine();

    int[] array10 = { 0, 0, 0, 0, 0 };
    MyArray.Print(array10);
    MoveZeroesLeftInPlaceSimplest(array10);
    MyArray.Print(array10);
    Console.WriteLine();
  }

  private static void MoveZersLeft(int[] array)
  {
    int[] aux = new int[array.Length];
    int iAux = aux.Length - 1;
    for (int i = array.Length - 1; i >= 0; i--)
    {
      if (array[i] != 0)
      {
        aux[iAux] = array[i];
        iAux--;
      }
    }
    Array.Copy(aux, 0, array, 0, array.Length);
  }

  private static void MoveZeroesLeftInPlace(int[] array)
  {
    int zero = array.Length - 1; // Index looking for Zero
    int nonZero = zero; // Index looking for non zero
    while (zero >= 0 && nonZero >= 0)
    {
      // Swap a zero with a non zero element
      if (array[zero] == 0 && array[nonZero] != 0)
      {
        array[zero] = array[nonZero];
        array[nonZero] = 0;
      }
      if (array[zero] != 0)
      {
        zero--;
      }
      if (array[nonZero] == 0)
      {
        nonZero--;
      }
      // Make sure the nonZero index is always at the left size of the zero index
      if (nonZero > zero)
      {
        nonZero = zero - 1;
      }
    }
  }

  private static void MoveZeroesLeftInPlaceBest(int[] array)
  {
    // If array legth is 1, no work need
    if (array.Length == 1)
    {
      return;
    }
    int end = array.Length - 1;
    for (int i = end; i >= 0; i--)
    {
      if (array[i] != 0)
      {
        array[end] = array[i];
        if (i != end)
        {
          array[i] = 0;
        }
        end--;
      }
    }
  }

  private static void MoveZeroesLeftInPlaceSimplest(int[] array)
  {
    int end = array.Length - 1;
    while (end >= 0 && array[end] != 0)
    {
      end--;
    }
    for (int i = end - 1; i >= 0; i--)
    {
      if (array[i] != 0 && array[end] == 0)
      {
        array[end] = array[i];
        end--;
        array[i] = 0;
      }
    }
  }
}