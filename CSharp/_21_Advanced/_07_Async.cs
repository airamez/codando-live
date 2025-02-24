using System;

using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Async;

public class Async2App
{
  static async Task Main()
  {
    Console.WriteLine("Starting multiple data fetch operations...");

    // Start multiple async tasks
    Task<string>[] fetchDataTasks = new Task<string>[]
    {
            FetchDataAsync(1),
            FetchDataAsync(2),
            FetchDataAsync(3),
            FetchDataAsync(4)
    };

    //    await Task.WhenAll(fetchDataTasks);

    // Keep printing dots while waiting for the tasks to complete
    while (fetchDataTasks.Any(task => !task.IsCompleted))
    {
      Console.Write(".");
      await Task.Delay(500); // Wait for 500ms before printing the next dot
    }
    Console.WriteLine();

    // Once all tasks are completed, print their results
    foreach (var task in fetchDataTasks)
    {
      string result = await task;
      Console.WriteLine($"Data received: {result}");
    }

    Console.WriteLine("All tasks completed. Program finished.");
  }

  static async Task<string> FetchDataAsync(int taskId)
  {
    for (int i = 0; i < 10; i++)
    {
      Console.Write($"[{taskId}]");
      await Task.Delay(500 * taskId); // Simulate varying lengths of work
    }
    return $"Result from Task {taskId}";
  }
}