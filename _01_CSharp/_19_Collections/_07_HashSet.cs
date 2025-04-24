// https://learn.microsoft.com/en-us/dotnet/api/system.collections.generic.hashset-1?view=net-9.0
using System;
using System.Collections.Generic;
using System.Linq;

namespace Collections;

public class HashSetApp
{
  public static void Main(string[] args)
  {
    // Show documentation of method about Big O Notation
    var odd = new HashSet<int>();
    odd.Add(1);
    odd.Add(3);
    odd.Add(5);
    odd.Add(7);
    odd.Add(9);
    odd.Add(1);
    odd.Add(1);
    odd.Add(9);
    odd.Add(9);
    Console.WriteLine(odd.Count);
    PrintSet(odd);

    Console.WriteLine(odd.Contains(1));
    Console.WriteLine(odd.Contains(2));

    var even = new HashSet<int>();
    even.Add(0);
    even.Add(2);
    even.Add(4);
    even.Add(6);
    even.Add(8);
    PrintSet(even);

    var all = new HashSet<int>(even);
    PrintSet(all);
    all.UnionWith(odd);
    Console.WriteLine(all.Count);
    PrintSet(all);

    all.IntersectWith(even);
    PrintSet(all);

    // Difference
    var setA = new HashSet<int>();
    setA.Add(1);
    setA.Add(2);
    setA.Add(3);
    setA.Add(4);
    var setB = new HashSet<int>();
    setB.Add(1);
    setB.Add(4);
    var diff = new HashSet<int>(setA);
    PrintSet(setA);
    PrintSet(setB);
    diff.ExceptWith(setB);
    PrintSet(diff);

    PrintSet(even);

    Console.WriteLine(even.Count(e => e > 5));
    Console.WriteLine(even.All(e => e % 2 == 0));
    Console.WriteLine(odd.All(e => e % 2 == 0));
    Console.WriteLine(even.Min());
    Console.WriteLine(even.Max());
    Console.WriteLine(even.Average());
    Console.WriteLine(even.Sum());
  }

  private static void PrintSet(HashSet<int> all)
  {
    foreach (int n in all)
    {
      Console.Write($"{n} ");
    }
    Console.WriteLine();
  }
}