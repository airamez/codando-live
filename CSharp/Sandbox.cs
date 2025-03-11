using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace Sandbox;

public class SandboxApp
{
  public delegate void ProcessUrlDelegate(string url);
  private SemaphoreSlim semaphore;

  private Random Random;

  public SandboxApp()
  {
    semaphore = new SemaphoreSlim(10);
    Random = new Random();
  }

  public static async Task Main(string[] args)
  {
    SandboxApp app = new SandboxApp();
    await app.Run();
  }

  private async Task Run()
  {
    List<(string Item, int Weight)> items = new List<(string, int)>();
    for (int i = 0; i < 1_000; i++)
    {
      int weight = Random.Next(20);
      items.Add(($"Item_{i} [{weight}]", weight));
    }
    List<Task> tasks = new List<Task>();
    items
    .OrderByDescending(i => i.Weight)
    .ToList()
    .ForEach(url => tasks.Add(ProcessUrl(url.Item, MyProcessUrl)));
    await Task.WhenAll(tasks);
  }


  private async Task ProcessUrl(string url, ProcessUrlDelegate processItem)
  {
    try
    {
      await semaphore.WaitAsync();
      processItem(url);
      await Task.Delay(Random.Next(200));
    }
    finally
    {
      semaphore.Release();
    }
  }

  private void MyProcessUrl(string url)
  {
    //Console.Write(".");
    Console.WriteLine(url);
  }
}