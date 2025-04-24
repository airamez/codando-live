using System;
using System.Linq;
using System.Reflection;
using OurCompany;

/*
 * 22. Implement a routine to rotate an array n positions to the left: RotateLeft(array, offset)
       Can you do it in-place?
 */
public class ArrayQuestion22
{
  public static void Main(string[] args)
  {
    int[] a = { 0, 1, 2, 3, 4, 5, 6, 7, 8, 9 };
    MyArray.Print(a);

    RotateLeft(a, 4);
    MyArray.Print(a);

    RotateLeft(a, 6);
    MyArray.Print(a);

    RotateLeftInPlace(a, 4);
    MyArray.Print(a);
  }

  private static void RotateLeft(int[] array, int offset)
  {
    int[] rotated = new int[array.Length];
    Array.Copy(array, 0, rotated, array.Length - offset, offset);
    Array.Copy(array, offset, rotated, 0, array.Length - offset);
    Array.Copy(rotated, 0, array, 0, array.Length);
  }

  private static void RotateLeftInPlace(int[] array, int offset)
  {
    ReverseArray(array, 0, array.Length - 1);
    ReverseArray(array, 0, array.Length - offset - 1);
    ReverseArray(array, array.Length - offset, array.Length - 1);
  }

  private static void ReverseArray(int[] array, int left, int right)
  {
    while (left < right)
    {
      int aux = array[left];
      array[left] = array[right];
      array[right] = aux;
      left++;
      right--;
    }
  }
}