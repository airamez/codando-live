using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace Async;

public class HeavyProcessingApp
{
  public delegate void ProcessItemDelegate(string item);
  private SemaphoreSlim semaphore;

  private Random Random;

  public HeavyProcessingApp()
  {
    semaphore = new SemaphoreSlim(20);
    Random = new Random();
  }

  public static async Task Main(string[] args)
  {
    Console.Clear();
    HeavyProcessingApp app = new HeavyProcessingApp();
    await app.Run();
  }

  private async Task Run()
  {
    List<string> items = new List<string>();
    for (int i = 0; i < 1_000; i++)
    {
      items.Add($"Item_{i} ");
    }
    List<Task> tasks = new List<Task>();
    items.ToList().ForEach(item => tasks.Add(ProcessItem(item, MyProcessItem)));
    await Task.WhenAll(tasks);
  }

  private async Task ProcessItem(string item, ProcessItemDelegate processItem)
  {
    try
    {
      await semaphore.WaitAsync(); // Waiting for a turn

      await Task.Delay(Random.Next(500, 1_000)); // Simulating a slow operation

      processItem(item);
    }
    finally
    {
      semaphore.Release(); // Making sure to release the semaphore
    }
  }

  private void MyProcessItem(string item)
  {
    Console.Write(item + " ");
  }
}