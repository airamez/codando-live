using System;
using System.ComponentModel;
using System.Linq;
using System.Net;
using System.Reflection;
using OurCompany;

/*
 * 24. Implement a routine to return the longest sequence of duplicated elements
       of an array of integers containing only 0s and 1s
 */
public class ArrayQuestion24
{
  public static void Main(string[] args)
  {
    int[] array = { 1, 0, 1, 1, 0, 0, 0, 1, 0, 1, 1, 1, 1, 1, 0, 0, 0, 1, 1, 1, 0, 0, 0, 0, 0, 0, 0, 0, 0, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 0, 0, 0, 0, 0, 1, 1, 1, 1, 1, 1, 1, 1, 1, 0 };
    int longest = GetLongestSequenceLength(array);
    Console.WriteLine(longest);
  }

  private static int GetLongestSequenceLength(int[] array)
  {
    int longest = 1;
    int longestLocal = 1;
    for (int i = 0; i < array.Length - 1; i++)
    {
      if (array[i] == array[i + 1])
      {
        longestLocal++;
      }
      else
      {
        longestLocal = 1;
      }
      if (longestLocal > longest)
      {
        longest = longestLocal;
      }
    }
    return longest;
  }
}