// https://learn.microsoft.com/en-us/dotnet/api/system.collections.generic.linkedlist-1?view=net-8.0
// https://learn.microsoft.com/en-us/dotnet/api/system.collections.generic.linkedlistnode-1?view=net-8.0
using System;
using System.Collections.Generic;
using System.Linq;

namespace Collections;

/*
 * Node:
     Value: T
     Next
     Previous
 */

public class LinkedListApp
{
  public static void Main(string[] args)
  {
    var monthNames = new string[]{
      "January", "Feb", "Mar", "April", "May", "Jun",
      "Jul", "Aug", "Sep", "Oct", "Nov", "December"};

    var months = new LinkedList<string>(monthNames);

    Console.WriteLine(months.Count);
    Print(months);

    var firstValue = months.First(); // First Value
    Console.WriteLine(firstValue);
    var firstNode = months.First; // First Node
    Console.WriteLine(firstNode.Value);
    Console.WriteLine(firstNode.Previous);
    Console.WriteLine(firstNode.Next.Value);

    var lastValue = months.Last(); // Last Value
    Console.WriteLine(lastValue);
    var lastNode = months.Last; // Last Node
    Console.WriteLine(lastNode.Value);

    months.RemoveFirst();
    months.RemoveLast();
    Print(months);

    months.AddFirst("Jan");
    months.AddLast("Dec");
    Print(months);

    var runner = months.Last;
    while (runner != null)
    {
      Console.Write($"{runner.Value} ");
      runner = runner.Previous;
    }
    Console.WriteLine();

    var marchNode = months.Find("Mar");
    Console.WriteLine(marchNode.Value);
    Console.WriteLine(marchNode.Previous.Value);
    Console.WriteLine(marchNode.Next.Value);

    months.AddBefore(marchNode, new LinkedListNode<string>("Before_March"));
    months.AddAfter(marchNode, new LinkedListNode<string>("After_March"));
    Print(months);

    months.Remove(marchNode.Previous);
    months.Remove(marchNode.Next);
    Print(months);

    Console.WriteLine(months.First.Next.Next.Next.Next.Value);
    Console.WriteLine(months.Last.Previous.Previous.Previous.Previous.Value);
  }

  public static void Print(LinkedList<string> list)
  {
    Console.WriteLine("Months: ");
    foreach (var entry in list)
      Console.Write($"{entry} ");
    Console.WriteLine();
  }
}