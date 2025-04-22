using System;
using System.Linq;
using System.Reflection;
using OurCompany;

/*
17. Implement a routine to receive two arrays of integers and
    return a new array with the union
 */
public class ArrayQuestion17
{
  public static void Main(string[] args)
  {
    int[] a = { 3, 1, 5, 9, 6, 2 };
    int[] b = { 8, 3, 4, 7, 9, 2, 6, 1, 0 };
    int[] union = ArrayUnion(a, b);
    MyArray.Print(a, "Array a");
    MyArray.Print(b, "Array b");
    MyArray.Print(union, "Array Union");
  }

  private static int[] ArrayUnion(int[] a, int[] b)
  {
    int[] union = new int[a.Length + b.Length];
    Array.Copy(a, 0, union, 0, a.Length);
    int iu = a.Length;
    for (int i = 0; i < b.Length; i++)
    {
      // Searching for b[i] in the a array
      if (Array.IndexOf(a, b[i]) == -1)
      {
        union[iu] = b[i];
        iu++;
      }
    }
    // Trim result array
    int[] result = new int[iu];
    Array.Copy(union, 0, result, 0, iu);
    return result;
  }
}
