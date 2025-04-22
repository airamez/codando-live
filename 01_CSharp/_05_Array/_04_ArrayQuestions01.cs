using System;
using OurCompany;

/*
 1. Implement a routine to clone an array of integers: int[] Clone(int[])
 */
public class ArrayQuestion01
{
  public static void Main(string[] args)
  {
    int[] array1 = { 1, 2, 3, 4, 5, 6, 7, 8, 9 };
    int[] array1Clone = MyArray.Clone(array1);

    Library.PrintIntArray(array1);
    Library.PrintIntArray(array1Clone);

    array1[0] = 100;

    Library.PrintIntArray(array1);
    Library.PrintIntArray(array1Clone);

    int[] array2 = new int[5];
    array2[0] = 3;
    array2[1] = 6;
    array2[2] = 9;
    array2[3] = 2;
    array2[4] = 8;

    int[] array2Clone = MyArray.Clone(array2);
    array2Clone[0] = 0;
    Library.PrintIntArray(array2);
    Library.PrintIntArray(array2Clone);
  }
}