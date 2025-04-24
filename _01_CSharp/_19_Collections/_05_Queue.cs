/*
https://learn.microsoft.com/en-us/dotnet/api/system.collections.generic.queue-1?view=net-8.0
*/
using System;
using System.Collections.Generic;

namespace Collections;

public class QueueApp
{
  public static void Main(string[] args)
  {
    var queue = new Queue<string>();
    queue.Enqueue("First");
    queue.Enqueue("Second");
    queue.Enqueue("Third");
    queue.Enqueue("Fourth");

    Console.WriteLine(queue.Count);

    var item = queue.Dequeue();
    Console.WriteLine(item);

    Console.WriteLine(queue.Peek());

    while (queue.Count > 0)
    {
      Console.WriteLine(queue.Dequeue());
    }
  }
}