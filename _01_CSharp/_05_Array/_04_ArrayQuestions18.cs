using System;
using System.Linq;
using System.Reflection;
using OurCompany;

/*
18. Implement a routine to receive two arrays of integers
    (ascending order) and return a new array with the union
 */
public class ArrayQuestion18
{
  public static void Main(string[] args)
  {
    int[] a = { 1, 4, 5, 9, 40, 50, 90, 120 };
    int[] b = { 1, 2, 4, 5, 7, 9, 10, 12, 17, 20 };
    int[] union = ArrayUnion(a, b);
    MyArray.Print(a, "Array a");
    MyArray.Print(b, "Array b");
    MyArray.Print(union, "Array Union");
  }

  private static int[] ArrayUnion(int[] a, int[] b)
  {
    int[] union = new int[a.Length + b.Length];
    int ia = 0;
    int ib = 0;
    int iu = 0;
    while (ia < a.Length && ib < b.Length)
    {
      if (a[ia] == b[ib])
      {
        union[iu] = a[ia];
        ia++;
        ib++;
      }
      else if (a[ia] < b[ib])
      {
        union[iu] = a[ia];
        ia++;
      }
      else
      {
        union[iu] = b[ib];
        ib++;
      }
      iu++;
    }
    while (ia < a.Length)
    {
      union[iu] = a[ia];
      iu++;
      ia++;
    }
    while (ib < b.Length)
    {
      union[iu] = b[ib];
      iu++;
      ib++;
    }
    int[] result = new int[iu];
    Array.Copy(union, 0, result, 0, iu);
    return result;
  }
}
