/*
- Overview
  - Asynchronous programming enables non-blocking execution of code, 
    improving responsiveness and performance, especially for I/O-bound operations.
    The async and await keywords simplify working with asynchronous code.
  - Key Concepts
    - Synchronous vs. Asynchronous Execution
      - Synchronous: The execution blocks until a task completes.
      - Asynchronous: The execution continues while waiting for a task to complete.
    - Task-based Asynchronous Pattern (TAP)
      - Uses Task and Task<T> to represent asynchronous operations.
      - Methods returning Task can be awaited.
    - Async and Await
      - The async keyword enables a method to use await.
      - The await keyword pauses execution until the awaited task completes.
*/
using System;
using System.Threading.Tasks;

namespace Async;

public class AsyncApp
{
  static async Task Main()
  {
    Console.WriteLine("Starting data fetch...");

    // Start the async task
    Task<string> fetchDataTask = FetchDataAsync();

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

  static async Task<string> FetchDataAsync()
  {
    for (int i = 0; i < 10; i++)
    {
      Console.Write("*");
      await Task.Delay(1000); // Simulate a long-running operation (e.g., network request)

    }
    return "Hello from async world!";
  }
}