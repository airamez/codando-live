using System;
using System.Linq;
using System.Reflection;
using OurCompany;

/*
 * 21. Implement a routine to receive two sorted arrays and return a new array with 
       all elements and sorted as well
 */
public class ArrayQuestion21
{
  public static void Main(string[] args)
  {
    int[] a = { 1, 4, 7, 8, 11, 15 };
    int[] b = { 2, 3, 4, 7, 9, 18, 21, 40 };
    int[] merge = ArrayMerge(a, b);
    MyArray.Print(merge);
    int[] merge2 = ArrayMerge2(a, b);
    MyArray.Print(merge2);
  }

  private static int[] ArrayMerge(int[] a, int[] b)
  {
    int[] merge = new int[a.Length + b.Length];
    Array.Copy(a, 0, merge, 0, a.Length);
    Array.Copy(b, 0, merge, a.Length, b.Length);
    Array.Sort(merge);
    return merge;
  }

  private static int[] ArrayMerge2(int[] a, int[] b)
  {
    int[] merge = new int[a.Length + b.Length];
    int ia = 0;
    int ib = 0;
    int im = 0;
    while (ia < a.Length && ib < b.Length)
    {
      if (a[ia] < b[ib])
      {
        merge[im] = a[ia];
        ia++;
      }
      else
      {
        merge[im] = b[ib];
        ib++;
      }
      im++;
    }
    while (ia < a.Length)
    {
      merge[im] = a[ia];
      ia++;
      im++;
    }
    while (ib < b.Length)
    {
      merge[im] = b[ib];
      ib++;
      im++;
    }
    return merge;
  }
}
