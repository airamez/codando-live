/*
- The simplest ways to avoid race conditions with async and await are:
   - Interlocked: Provides atomic operations for variables that are shared by multiple threads.
     - https://learn.microsoft.com/en-us/dotnet/api/system.threading.interlocked?view=net-9.0
   - SemaphoreSlim: Is a lightweight, async-friendly alternative to traditional locks.
     It allows you to control access to resources in an asynchronous environment.
     - https://learn.microsoft.com/en-us/dotnet/api/system.threading.semaphoreslim?view=net-9.0
 */
using System;
using System.Threading;
using System.Threading.Tasks;

namespace Async;

public class RaceConditionApp
{
  private static int counter = 0;

  static async Task Main(string[] args)
  {

    /*
     * With Race Conditions
     */
    Console.WriteLine("With Race Conditions");
    var tasks = new Task[10];
    // Start 10 tasks that increment the counter 1000 times
    for (int i = 0; i < tasks.Length; i++)
    {
      tasks[i] = Run(i);
    }
    await Task.WhenAll(tasks);
    Console.WriteLine($"\nFinal counter value: {counter}");

    // counter = 0;

    /*
     * Without Race Condition using Interlocked
     */
    Console.WriteLine(" Without Race Condition using Interlocked");
    var tasksSafe1 = new Task[10];
    for (int i = 0; i < tasksSafe1.Length; i++)
    {
      tasksSafe1[i] = RunSafe1(i);
    }
    await Task.WhenAll(tasksSafe1);
    Console.WriteLine($"\nFinal counter value: {counter}");

    counter = 0;

    /*
     * Without Race Condition using SemaphoreSlim
     */
    Console.WriteLine("Without Race Condition using SemaphoreSlim");
    var tasksSafe2 = new Task[10];
    for (int i = 0; i < tasksSafe2.Length; i++)
    {
      tasksSafe2[i] = RunSafe1(i);
    }
    await Task.WhenAll(tasksSafe2);
    Console.WriteLine($"\nFinal counter value: {counter}");
  }

  public static async Task Run(int id)
  {
    for (int j = 0; j < 1000; j++)
    {
      /*
       * The counter++ is not atomic. At low level it is accomplish with 3 operations:
       *   1. Read the current value of counter (load it into the CPU register).
       *   2. Increment the value (add 1 to the loaded value).
       *   3. Write the new value back to counter.
       * Something like:
       *   int temp = counter;
       *   temp = temp + 1;
       *   counter = temp;
       */
      counter++; // Not thread-safe, leads to a race condition
      Console.Write(id);
      await Task.Delay(10); // Run without Delay
      /*
       * Without the Delay, the chance to have race condition is very low:
         1. Each task runs in rapid succession, often completing its loop 
            iterations entirely before another task has a chance to interfere. 
         2. In a high-speed loop with no delay, modern CPUs and compilers can optimize
            the execution of instructions. This might result in tasks executing their
            operations more independently, and thus fewer overlaps between reading,
            incrementing, and writing the counter variable.
         3. The absence of Task.Delay means the task has no reason to yield control back
            to the thread scheduler, allowing each task to complete its loop without
            interruptions. However, when you introduce a Task.Delay, even a small one,
            it forces tasks to yield control, greatly increasing the chances of interleaving
            between multiple tasks and amplifying the race condition.
       */
    }
  }

  public static async Task RunSafe1(int id)
  {
    for (int j = 0; j < 1000; j++)
    {
      Interlocked.Increment(ref counter); // Thread safe
      Console.Write(id);
      await Task.Delay(10);
    }
  }

  public static async Task RunSafe2(int id)
  {
    SemaphoreSlim semaphore = new SemaphoreSlim(1, 1);
    for (int j = 0; j < 1000; j++)
    {
      {
        await semaphore.WaitAsync();
        try
        {
          counter++; // Thread-safe within the semaphore
        }
        finally
        {
          semaphore.Release();
        }
        Console.Write(id);
        await Task.Delay(10);
      }
    }
  }
}