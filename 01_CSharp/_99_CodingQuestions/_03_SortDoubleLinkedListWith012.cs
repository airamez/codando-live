using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;

namespace CodingQuestions;

public class SortDoubleLinkedListApp
{
  public static void Main(string[] args)
  {
    Process currentProcess = Process.GetCurrentProcess();

    LinkedList<int> list = Generate(100000000);
    //Print(list);

    Stopwatch stopwatch = new Stopwatch();

    // Option 1: Time = O(NLog(N)); Space = O(N)
    stopwatch.Start();
    var sorted = new LinkedList<int>(list.OrderBy(x => x));
    //Print(sorted);
    stopwatch.Stop();
    Console.WriteLine($"Execution Time: {stopwatch.Elapsed}");

    // Option 2: Time = O(N); Space = in-place
    stopwatch.Reset();
    stopwatch.Start();
    SortInPlace(list);
    //Print(list);
    stopwatch.Stop();
    Console.WriteLine($"Execution Time: {stopwatch.Elapsed}");

    var memoryUsageMB = currentProcess.WorkingSet64 / (1024.0 * 1024.0);
    Console.WriteLine($"Memory Usage: {memoryUsageMB:F2} MB");
  }

  public static void SortInPlace(LinkedList<int> list)
  {
    int[] counters = new int[3];
    foreach (var item in list)
    {
      counters[item]++;
    }
    var runner = list.First;
    for (int currentValue = 0; currentValue < 3; currentValue++)
    {
      for (int j = 0; j < counters[currentValue]; j++)
      {
        runner.Value = currentValue;
        runner = runner.Next;
      }
    }
  }

  public static LinkedList<int> Generate(int length)
  {
    Random rnd = new Random();
    LinkedList<int> list = new LinkedList<int>();
    for (int i = 0; i < length; i++)
    {
      list.AddLast(rnd.Next(3));
    }
    return list;
  }

  private static void Print<T>(LinkedList<T> list)
  {
    Console.Write("\nList: ");
    foreach (var item in list)
    {
      Console.Write($"{item} ");
    }
    Console.WriteLine();
  }
}