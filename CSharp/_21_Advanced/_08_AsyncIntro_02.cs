using System;

using System.Collections.Generic;
using System.Diagnostics;
using System.Threading.Tasks;

namespace Async;

public class AsyncIntro02App
{
  static async Task Main()
  {
    Stopwatch stopwatch = Stopwatch.StartNew();

    // Calling the tasks in Sync mode
    Console.WriteLine("Executing the Tasks in Sync mode");
    await DoSomethingAsync("Task 1", 1_000);
    await DoSomethingAsync("Task 2", 2_000);
    await DoSomethingAsync("Task 3", 3_000);
    await DoSomethingAsync("Task 4", 4_000);
    Console.WriteLine($"Elapsed Time: {stopwatch.ElapsedMilliseconds} ms");

    stopwatch.Restart();

    // Starting all tasks at the same time
    Console.WriteLine("Executing the Tasks in Async mode");
    var tasks = new Task<string>[]
    {
      DoSomethingAsync("Task 1", 1_000),
      DoSomethingAsync("Task 2", 2_000),
      DoSomethingAsync("Task 3", 3_000),
      DoSomethingAsync("Task 4", 4_000),
    };
    await Task.WhenAll(tasks);

    Console.WriteLine($"Elapsed Time: {stopwatch.ElapsedMilliseconds} ms");

    Console.WriteLine("Starting the tasks dynamically");
    Random rnd = new Random();
    var newTasks = new List<Task<string>>();
    for (int i = 1; i <= 10; i++)
    {
      newTasks.Add(DoSomethingAsync($"Task {i}", 1_000 * rnd.Next(5)));
    }
    await Task.WhenAll(newTasks);

    Console.WriteLine("Accesing the return of all Tasks");
    foreach (var task in newTasks)
    {
      Console.WriteLine($"Task ID: {task.Id}; Result: {task.Result}");
    }
  }

  static async Task<string> DoSomethingAsync(string action, int delay)
  {
    Console.WriteLine($"Starting: {action}; Delay: {delay}");
    await Task.Delay(delay); // Simulating something that would take time to complete
    Console.WriteLine($"Completed: {action}");
    return $"{action} result";
  }
}