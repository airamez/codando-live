using System;
using System.Linq;
using System.Reflection;
using OurCompany;

/*
16. Implement a routine to receive two arrays of integers (ascending order)
    and return an array with the intersection
 */
public class ArrayQuestion16
{
  public static void Main(string[] args)
  {
    int[] a = { 3, 6, 8, 13, 17, 21, 40 };
    int[] b = { 1, 3, 5, 17, 60 };
    int[] intersection = ArrayIntersection(a, b);
    MyArray.Print(a, "Array a");
    MyArray.Print(b, "Array b");
    MyArray.Print(intersection, "Array intersection");
  }

  private static int[] ArrayIntersection(int[] a, int[] b)
  {
    int[] intersection = new int[Math.Min(a.Length, b.Length)];
    int ia = 0;
    int ib = 0;
    int ii = 0;
    while (ia < a.Length && ib < b.Length)
    {
      if (a[ia] == b[ib])
      {
        intersection[ii] = a[ia];
        ia++;
        ib++;
        ii++;
      }
      else if (a[ia] < b[ib])
      {
        ia++;
      }
      else
      {
        ib++;
      }
    }
    int[] result = new int[ii]; // Error with there is no intersection
    Array.Copy(intersection, 0, result, 0, ii);
    return result;
  }
}
