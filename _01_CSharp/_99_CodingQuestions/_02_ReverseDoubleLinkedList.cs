/*
 * Reverse a double linked list
 */

using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using System.Security;
using System.Security.Cryptography.X509Certificates;

namespace CodingQuestions;

public class ReverseDoubleLinedListApp
{
  public static void Main(string[] args)
  {
    var listOfStrings = new LinkedList<string>();
    var data = "ABCDEFGIJKL";
    foreach (var item in data)
    {
      listOfStrings.AddLast(item.ToString());
    }

    // Candidate Zero
    var reversedList0 = new LinkedList<string>(listOfStrings.Reverse());
    Print(reversedList0);

    // Candidate one
    var reversedList1 = new LinkedList<string>();
    foreach (var item in listOfStrings)
    {
      reversedList1.AddFirst(item);
    }
    foreach (var item in reversedList1)
    {
      Console.Write($"{item}, ");
    }

    // Candidate two
    Print(listOfStrings);
    var reversedList2 = ReverseLinkedList(listOfStrings);
    Print(reversedList2);

    // Candidate three
    var reversedList3 = ReverseLinkedList<string>(listOfStrings);
    Print<string>(reversedList3);

    var listOfIntegers = new LinkedList<int>();
    for (int i = 0; i < 10; i++)
    {
      listOfIntegers.AddLast(i);
    }
    Print(listOfIntegers);
    Print(ReverseLinkedList<int>(listOfIntegers));

    // Candidate four
    ReverseLinkedListInPlace(listOfStrings);
    Print(listOfStrings);

    ReverseLinkedListInPlace(listOfIntegers);
    Print(listOfIntegers);
  }

  private static void ReverseLinkedListInPlace<T>(LinkedList<T> list)
  {
    if (list == null || list.Count == 0 || list.Count == 1)
    {
      return;
    }
    var left = list.First;
    var right = list.Last;
    while (true)
    {
      var aux = left.Value;
      left.Value = right.Value;
      right.Value = aux;
      left = left.Next;
      if (left == right)
      {
        return;
      }
      right = right.Previous;
      if (left == right)
      {
        return;
      }
    }
  }

  private static LinkedList<T> ReverseLinkedList<T>(LinkedList<T> list)
  {
    LinkedList<T> reversedList = new LinkedList<T>();
    foreach (var item in list)
    {
      reversedList.AddFirst(item);
    }
    return reversedList;
  }

  private static LinkedList<string> ReverseLinkedList(LinkedList<string> list)
  {
    var reversedList = new LinkedList<string>();
    foreach (var item in list)
    {
      reversedList.AddFirst(item);
    }
    return reversedList;
  }

  private static void Print<T>(LinkedList<T> list)
  {
    Console.Write("\nList: ");
    foreach (var item in list)
    {
      Console.Write($"{item} <-> ");
    }
    Console.WriteLine();
  }
}