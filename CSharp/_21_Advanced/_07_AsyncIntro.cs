/*
- Overview
  - Asynchronous programming enables non-blocking execution of code, 
    improving responsiveness and performance, especially for I/O-bound operations.
    The 'async' and 'await' keywords simplify working with asynchronous code.
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
using System.Collections.Generic;
using System.Reflection;
using System.Threading.Tasks;

namespace Async;

public class AsyncIntroApp
{
  public static async Task Main(string[] args)
  {
    // Pay attention this method does not completed as we don't wait for it
    var something1 = DoSomething("Something 1", 5000); // Without the await, the return type is a Task (promise)
    Console.WriteLine(something1.Id);
    Console.WriteLine(something1.IsCompleted);
    //Console.WriteLine(something1.Result); // Accessing the Result property works like using await

    var something2 = await DoSomething("Something 2", 3000); // With await, the return type is string
    Console.WriteLine(something2);

    /*
    This distinction is fundamental in asynchronous programming, as it allows you to decide whether
    to wait for the operation to complete or let it run independently while continuing other work.
    */

    //AsyncDemo();
  }

  static async Task<string> DoSomething(string action, int delay)
  {
    Console.WriteLine($"Doing: {action}!!!");
    await Task.Delay(delay); // Simulating something that would take delay microseconds to complete
    var message = $"{action} done!!!";
    Console.WriteLine(message);
    return message;
  }

  static async void AsyncDemo()
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