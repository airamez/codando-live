// https://learn.microsoft.com/en-us/dotnet/api/system.collections.generic.sortedlist-2?view=net-9.0

using System;
using System.Collections.Generic;

namespace Collections;

public class SortedListApp
{
  public static void Main(string[] args)
  {
    // Review the documentation and compare to SortedDictionary
    var sortedlist = new SortedList<int, string>();
    sortedlist.Add(7, "Seven");
    sortedlist.Add(8, "Eight");
    sortedlist.Add(1, "One");
    sortedlist.Add(6, "Six");
    sortedlist.Add(3, "Three");
    sortedlist.Add(4, "Four");
    sortedlist.Add(2, "Two");
    sortedlist.Add(5, "Five");

    foreach (var entry in sortedlist)
    {
      Console.Write($"[{entry.Key}={entry.Value}] ");
    }
    Console.WriteLine();

    Console.WriteLine(sortedlist[1]);
    Console.WriteLine(sortedlist[2]);
    Console.WriteLine(sortedlist[3]);
    try
    {
      Console.WriteLine(sortedlist[10]);
    }
    catch (Exception ex)
    {
      Console.WriteLine(ex);
    }
  }
}