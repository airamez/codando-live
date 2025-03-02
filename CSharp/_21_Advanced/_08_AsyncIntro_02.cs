using System;
using System.Threading.Tasks;

namespace Async;

public class AsyncIntro02App
{
  public static async Task Main(string[] args)
  {
    Console.WriteLine("Starting data fetch...");

    // Start the async task
    Task<string> fetchDataTask = DoSomethingLong();

    // Keep printing dots while waiting for the task to complete
    while (!fetchDataTask.IsCompleted)
    {
      Console.Write(".");
      await Task.Delay(500); // Wait for 500ms before printing the next dot
    }

    // Get the result of the completed task
    string result = await fetchDataTask;
    Console.WriteLine($"\nData received: {result}");
    Console.WriteLine("Program finished.");
  }


  static async Task<string> DoSomethingLong()
  {
    for (int i = 0; i < 10; i++)
    {
      Console.Write("*");
      await Task.Delay(1000); // Simulate a long-running operation (e.g., network request)

    }
    return "Hello from async world!";
  }
}