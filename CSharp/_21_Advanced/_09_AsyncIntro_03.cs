using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Async;

public class AsyncIntro03App
{
  static async Task Main()
  {
    Random rnd = new Random();
    var tasks = new List<Task<string>>();

    for (int i = 1; i <= 10; i++)
    {
      tasks.Add(DoSomethingAsync($"Task {i}", 1000 * rnd.Next(4), true));
    }

    try
    {
      await Task.WhenAll(tasks);
    }
    catch (Exception ex)
    {
      Console.WriteLine("Exception on Task.WhenAll: " + ex.Message);
      foreach (var failedTask in tasks.FindAll(t => t.IsFaulted))
      {
        Console.WriteLine(failedTask.Exception.InnerException.Message); // Check InnerException
      }
    }

    Console.WriteLine("EXCEPTIONS:");
    foreach (var task in tasks.FindAll(t => t.IsFaulted))
    {
      Console.WriteLine($"Task ID: {task.Id} failed with exception: {task.Exception?.InnerException?.Message}");
    }
    Console.WriteLine("SUCCESS:");
    tasks.FindAll(t => t.IsCompletedSuccessfully).ForEach(t => Console.WriteLine($"Task ID: {t.Id} Result: {t.Result}"));
  }

  static async Task<string> DoSomethingAsync(string action, int delay, bool withRandomExceptions = false)
  {
    Console.WriteLine($"Starting : {action}");
    await Task.Delay(delay); // Simulate async work
    Random rnd = new Random();
    if (withRandomExceptions && rnd.Next(3) == 0)
    {
      throw new Exception($"Exception on {action}");
    }
    Console.WriteLine($"Completed: {action}");
    return $"{action} result";
  }
}
