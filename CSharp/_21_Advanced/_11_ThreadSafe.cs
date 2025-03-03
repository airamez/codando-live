/*
- https://learn.microsoft.com/en-us/dotnet/standard/collections/thread-safe/
- Thread-safe collections are a crucial topic when working in asynchronous programming in C#,
  especially in scenarios where multiple threads access shared data
- Key reasons include:
  - Avoiding Race Conditions: Ensures data is not corrupted or invalidated by simultaneous reads/writes.
  - Simplicity: Reduces the complexity of writing your synchronization logic.
- What Makes Thread-Safe Collections "Thread-Safe"?
  - Thread-safe collections are designed to handle multiple threads accessing or modifying them simultaneously, 
    without requiring additional synchronization from the developer. They achieve thread safety through:
    - Internal Synchronization:
      Thread-safe collections use mechanisms like locks (Monitor, Mutex, SpinLock) or lock-free algorithms
      (e.g., Compare-And-Swap (CAS) operations) to ensure that only one thread can access a critical
      section of code at a time.
    - Atomic Operations:
      Their methods (e.g., Add, TryAdd, TryRemove, etc.) are implemented as atomic, meaning they cannot be
      interrupted partway through. This ensures operations like adding or removing items complete entirely
      or not at all.
    - Lock-Free or Fine-Grained Locking:
      Some thread-safe collections (e.g., ConcurrentBag, ConcurrentQueue) use lock-free algorithms, which 
      rely on atomic operations instead of traditional locking, reducing contention and improving performance.
      Others, like BlockingCollection, use fine-grained locking to minimize blocking and allow high throughput.
   - Scalability:
     - They optimize performance in multi-threaded environments by reducing contention between threads and 
       efficiently managing concurrent access.

- Thread-safe collections
  - ConcurrentDictionary<TKey, TValue>: A thread-safe dictionary
  - ConcurrentQueue<T>: A thread-safe Queue.
  - ConcurrentStack<T>: A thread-safe Stack.
  - ConcurrentBag<T>: A thread-safe List.
  - BlockingCollection<T>: A powerful and flexible thread-safe collection for producer-consumer scenarios
*/

using System;
using System.Collections.Concurrent;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;

namespace Async;

public class ThreadSafeApp
{
  public static void Main(string[] args)
  {
    var rnd = new Random();
    Parallel.For(0, 10, i =>
    {
      for (int j = 0; j < 10; j++)
      {
        Thread.Sleep(rnd.Next(5) * 500);
        Console.Write(i);
      }
    });
    Console.WriteLine();

    // Race Condition using List
    var list = new List<int>(); // Try a few times to cause exception
    Parallel.For(0, 1000, i =>
    {
      list.Add(i); // Not thread-safe!
    });
    Console.WriteLine($"List count: {list.Count}");

    // Thread Safe using ConcurentBag
    var bag = new ConcurrentBag<int>();
    Parallel.For(0, 1000, i =>
    {
      bag.Add(i); // Thread-safe
    });
    Console.WriteLine($"Bag count: {bag.Count}");
  }
}