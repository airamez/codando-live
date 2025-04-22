// https://learn.microsoft.com/en-us/dotnet/api/system.collections.generic.sortedset-1?view=net-9.0

using System;
using System.Collections.Generic;

namespace Collections;

public class SortedSetApp
{
  public static void Main(string[] args)
  {
    // @review documentation focusing on Big O
    var sortedSet = new SortedSet<int>();
    sortedSet.Add(7);
    sortedSet.Add(3);
    sortedSet.Add(8);
    sortedSet.Add(4);
    sortedSet.Add(6);
    sortedSet.Add(1);
    sortedSet.Add(7);
    for (int i = 0; i < 10; i++)
    {
      Console.WriteLine($"{i} countains = {sortedSet.Contains(i)}");
    }

    Console.WriteLine();
    foreach (var num in sortedSet)
    {
      Console.Write($"{num} ");
    }
    Console.WriteLine();

    sortedSet.Remove(4);

    foreach (var num in sortedSet.Reverse())
    {
      Console.Write($"{num} ");
    }
    Console.WriteLine();

    Console.WriteLine($"Max = {sortedSet.Max}");
    Console.WriteLine($"Min = {sortedSet.Min}");
  }
}