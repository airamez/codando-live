using System;
using System.Linq;
using System.Reflection;
using OurCompany;

/*
15. Implement a routine to receive two arrays of integers and
    return an array with the intersection
 */
public class ArrayQuestion15
{
  public static void Main(string[] args)
  {
    int[] a = { 3, 9, 5, 2, 8, 0 };
    int[] b = { 0, 3, 4, 6, 7, 9, 8, 1 };
    int[] intersection = ArrayIntersection(a, b);
    MyArray.Print(a, "Array a");
    MyArray.Print(b, "Array b");
    MyArray.Print(intersection, "Array intersection");

    int[] a1 = { 3, 9, 5, 2, 8, 0 };
    int[] b1 = { 4, 6, 7, 1 };
    int[] intersection1 = ArrayIntersection(a1, b1);
    MyArray.Print(a1, "Array a1");
    MyArray.Print(b1, "Array b1");
    MyArray.Print(intersection1, "Array intersection 1");

  }

  private static int[] ArrayIntersection(int[] a, int[] b)
  {
    int ii = 0;
    int[] intersection = new int[Math.Min(a.Length, b.Length)];
    for (int ia = 0; ia < a.Length; ia++)
    {
      for (int ib = 0; ib < b.Length; ib++)
      {
        if (a[ia] == b[ib])
        {
          intersection[ii] = a[ia];
          ii++;
          break;
        }
      }
    }
    if (ii == 0)
    { // Better to deal with Exception
      return null;
    }
    int[] result = new int[ii]; // Error with there is no intersection
    Array.Copy(intersection, 0, result, 0, ii);
    return result;
  }
}
