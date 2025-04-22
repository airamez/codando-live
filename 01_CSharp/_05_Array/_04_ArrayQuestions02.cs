using System;
using OurCompany;

/*
 *  2. Implement a routine to read an array of integers from the Console: int[] ReadIntArray(string: label, int: length)
    Use 'label[index] = ' for each element
 */
public class ArrayQuestion02
{
  public static void Main(string[] args)
  {
    int[] myArray1 = MyArray.ReadIntArray("My Array", 10);
    Library.PrintIntArray(myArray1, "My Array 1");
  }
}