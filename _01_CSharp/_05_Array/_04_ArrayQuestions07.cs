using System;
using System.Data;
using OurCompany;

/*
 *  7. Implement a routine to fill an integer array with an specific value: 
       Fill(array, start, end, value)
 */
public class ArrayQuestion07
{
  public static void Main(string[] args)
  {
    int[] array = { 1, 2, 3, 4, 5, 6, 7, 8, 9, 10, 11, 12, 13, 14 };
    MyArray.Print(array, "Original");
    Fill(array, 3, 9, 3);
    MyArray.Print(array, "After Fill");
    //Array.Fill(array, 5, 9, 6);
    Fill(array, -3, 9, 3);
    MyArray.Print(array, "After Fill with invalid parameter");
    Fill(array, 0, array.Length - 1, -1);
    MyArray.Print(array, "After Fill with -1");
  }

  public static void Fill(int[] array, int start, int end, int value)
  {
    if (start >= 0 && end >= 0 && start <= end &&
        start < array.Length && end < array.Length)
    {
      for (int i = start; i <= end; i++)
      {
        array[i] = value;
      }
    }
  }
}