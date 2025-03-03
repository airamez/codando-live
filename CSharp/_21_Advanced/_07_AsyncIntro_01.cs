/*
- https://learn.microsoft.com/en-us/dotnet/csharp/asynchronous-programming/
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
      - Declaration
        async Task[<RETURN_TYPE>] METHOD_NAME (PARAM_LIST)
    - Async and Await
      - The async keyword makes a method asynchonous.
      - The await keyword pauses execution until the awaited task completes.
*/
using System;
using System.Threading.Tasks;

namespace Async;

public class AsyncIntro01App
{
  public static async Task Main(string[] args) // Note: The main signature changed because of the async
  {
    // Pay attention this method does not completed as we don't wait for it. WE ARE NOT USING await!
    var something1 = DoSomethingAsync("Something 1", 2000); // Without the await, the return type is a Task (promise)
    Console.WriteLine(something1.Id);
    Console.WriteLine(something1.IsCompleted);
    //Console.WriteLine(something1.Result); // Accessing the Result property works like using await

    var something2 = await DoSomethingAsync("Something 2", 5000); // With await, the return type is string
    Console.WriteLine(something2);

    Console.WriteLine("The End!");
  }

  static async Task<string> DoSomethingAsync(string action, int delay)
  {
    Console.WriteLine($"Doing: {action}!!!");
    await Task.Delay(delay); // Simulating something that would take time to complete
    var message = $"{action} done!!!";
    Console.WriteLine(message);
    return message;
  }
}