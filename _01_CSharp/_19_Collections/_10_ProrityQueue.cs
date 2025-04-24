// https://learn.microsoft.com/en-us/dotnet/api/system.collections.generic.priorityqueue-2?view=net-9.0

using System;
using System.Collections.Generic;

namespace Collections;

public class PriorityQueueApp
{
  public static void Main(string[] args)
  {
    var heap = new PriorityQueue<string, int>();

    heap.Enqueue("Three", 3);
    heap.Enqueue("Four", 4);
    heap.Enqueue("One", 1);
    heap.Enqueue("Zero", 0);
    heap.Enqueue("Five", 5);
    heap.Enqueue("Two", 2);
    while (heap.Count > 0)
    {
      var number = heap.Dequeue();
      Console.Write($"{number} ");
    }
    Console.WriteLine();

    heap.Clear();
    heap.Enqueue("Three", -3);
    heap.Enqueue("Four", -4);
    heap.Enqueue("One", -1);
    heap.Enqueue("Zero", 0);
    heap.Enqueue("Five", -5);
    heap.Enqueue("Two", -2);
    while (heap.Count > 0)
    {
      var number = heap.Dequeue();
      Console.Write($"{number} ");
    }
    Console.WriteLine();

    PriorityQueue<string, int> taskQueue = new PriorityQueue<string, int>();
    taskQueue.Enqueue("Fix critical bug in production", 1);
    taskQueue.Enqueue("Refactor legacy code", 5);
    taskQueue.Enqueue("Write user documentation", 3);
    taskQueue.Enqueue("Test new feature deployment", 2);
    taskQueue.Enqueue("Feed the office cat", 1);
    taskQueue.Enqueue("Call wife at lunch time", 0);
    taskQueue.Enqueue("Water the plant in the break room", 6);
    taskQueue.Enqueue("Organize team pizza party", 4);
    taskQueue.Enqueue("Find the coffee mug thief", 3);
    taskQueue.Enqueue("Watch funny cat videos for 'research'", 7);
    taskQueue.Enqueue("Fix typo in the company email signature", 4);

    Console.WriteLine("\nProcessing tasks by priority:");

    while (taskQueue.Count > 0)
    {
      if (taskQueue.TryDequeue(out string task, out int priority))
      {
        Console.WriteLine($"{priority} - {task}");
      }
    }
  }
}