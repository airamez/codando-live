// https://learn.microsoft.com/en-us/dotnet/api/system.collections.generic.sorteddictionary-2?view=net-9.0
using System;
using System.Collections.Generic;
using System.Linq;

namespace Collections;

public class SortedDictionaryApp
{
  public static void Main(string[] args)
  {
    // Review the time complexity of operations
    var dic = new SortedDictionary<int, string>();
    dic.Add(7, "Seven");
    dic.Add(8, "Eight");
    dic.Add(1, "One");
    dic.Add(6, "Six");
    dic.Add(3, "Three");
    dic.Add(4, "Four");
    dic.Add(2, "Two");
    dic.Add(5, "Five");

    foreach (var key in dic.Keys)
    {
      Console.Write($"{key} ");
    }
    Console.WriteLine();

    foreach (var value in dic.Values)
    {
      Console.Write($"{value} ");
    }
    Console.WriteLine();

    foreach (var key in dic.Keys)
    {
      Console.WriteLine($"{key} = {dic[key]}");
    }

    foreach (var value in dic.OrderBy(entry => entry.Value))
    {
      Console.Write($"{value} ");
    }
    Console.WriteLine();

  }
}