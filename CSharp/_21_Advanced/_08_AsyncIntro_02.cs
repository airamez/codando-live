using System;

using System.Collections.Generic;
using System.Diagnostics;
using System.Threading.Tasks;

namespace Async;

public class AsyncIntro02App
{
  static async Task Main()
  {
    Random rnd = new Random();
    Stopwatch stopwatch = Stopwatch.StartNew();

    // Calling the tasks in Sync mode
    await DoSomethingAsync("Task 1", 1000);
    await DoSomethingAsync("Task 2", 2000);
    await DoSomethingAsync("Task 3", 3000);
    await DoSomethingAsync("Task 4", 4000);
    Console.WriteLine($"Elapsed Time: {stopwatch.ElapsedMilliseconds} ms");

    stopwatch.Restart();

    // Starting all tasks at the same time
    var tasks = new Task<string>[]
    {
      DoSomethingAsync("Task 1", 1000),
      DoSomethingAsync("Task 2", 2000),
      DoSomethingAsync("Task 3", 3000),
      DoSomethingAsync("Task 4", 4000),
    };
    await Task.WhenAll(tasks);

    Console.WriteLine($"Elapsed Time: {stopwatch.ElapsedMilliseconds} ms");
    stopwatch.Restart();

    var newTasks = new List<Task<string>>();
    for (int i = 1; i <= 10; i++)
    {
      newTasks.Add(DoSomethingAsync($"Task {i}", 1000 * rnd.Next(4)));
    }
    await Task.WhenAll(newTasks);
    Console.WriteLine($"Elapsed Time: {stopwatch.ElapsedMilliseconds} ms");
    foreach (var task in newTasks)
    {
      Console.WriteLine($"Task ID: {task.Id}; Result: {task.Result}");
    }
  }

  static async Task<string> DoSomethingAsync(string action, int delay, bool withRandomExceptions = false)
  {
    Console.WriteLine($"Starting : {action}");
    await Task.Delay(delay); // Simulating something that would take time to complete
    Random rnd = new Random();
    if (withRandomExceptions && rnd.Next(3) == 0)
    {
      throw new Exception($"Exception on {action}");
    }
    Console.WriteLine($"Completed: {action}");
    return $"{action} result";
  }
}