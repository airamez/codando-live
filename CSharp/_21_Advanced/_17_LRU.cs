// https://leetcode.com/problems/lru-cache
/*
- Definition
  - An LRU (Least Recently Used) Cache is a data structure that stores a limited number
    of items and automatically removes the least recently used item when the cache 
    reaches its capacity. This ensures that frequently accessed elements remain available
    while efficiently managing memory.
- An LRU Cache typically consists of:
  - A HashMap (Dictionary in C#) – for O(1) access to cached items by key.
  - A Doubly Linked List – to track usage order, allowing fast eviction of the 
    least recently used item in O(1) as well
  - Capacity Constraint – ensures the cache does not exceed the predefined limit.
- How It Works:
  - When an item is accessed, it is moved to the front (most recently used).
  - If an item is added and the cache is full, the least recently used item is removed.
  - This design allows both get and put operations to be performed in O(1) time complexity.  
- Use Cases
  - Web Caching (storing recently accessed pages)
  - Database Query Caching (keeping frequently queried results)
  - Memory Management (paging systems in OS)
  - Image Processing (storing recently processed images)
- Built-in Implementations
  - Instead of implementing LRU from scratch, you can use existing C# libraries:
    - Microsoft.Extensions.Caching.Memory
      - MemoryCache supports eviction policies, including LRU-like behavior.
      - Example: MemoryCacheOptions allows setting an expiration policy.
      - https://learn.microsoft.com/en-us/dotnet/api/microsoft.extensions.caching.memory.memorycache?view=net-9.0-pp
    - System.Runtime.Caching
      - Provides MemoryCache for in-memory caching.
      - Supports time-based expiration and manual removal.
      - https://learn.microsoft.com/en-us/dotnet/api/system.runtime.caching.memorycache?view=net-9.0-pp
   - Third-Party Libraries
     - LazyCache (wraps MemoryCache for easier usage)
     - CacheManager (multi-layered caching support)
Conclusion
LRU Cache is an essential concept for optimizing memory usage and improving performance in applications.
While custom implementations provide flexibility, built-in APIs and third-party libraries simplify
its usage, save time and reduce cost.
*/

using System;
using System.Collections;
using System.Collections.Generic;

namespace LRU;

public class LRUApp
{
  public static void Main(string[] args)
  {
    Demo();

    //StressTest();
  }

  private static void Demo()
  {
    Console.WriteLine("Testing LRU Cache Implementation");

    // Step 1: Initialize an LRU cache with a capacity of 3
    var cache = new MyLRUCache<int, string>(3);

    // Step 2: Add some values
    cache.Put(1, "One");
    cache.Put(2, "Two");
    cache.Put(3, "Three");
    Console.WriteLine("Cache after inserting 3 items: ");
    PrintCacheState(cache); // Should print: 1 -> 2 -> 3

    // Step 3: Access a key to mark it as recently used
    Console.WriteLine($"Accessing key 2: {cache.Get(2)}");
    Console.WriteLine("Cache after accessing key 2: ");
    PrintCacheState(cache); // Should print: 1 -> 3 -> 2

    // Step 4: Add a new item, causing an eviction
    Console.WriteLine("Adding key 4 to the cache...");
    cache.Put(4, "Four");
    Console.WriteLine("Cache after adding key 4 (eviction should occur): ");
    PrintCacheState(cache); // Should print: 3 -> 2 -> 4 (1 evicted)

    // Step 5: Access a non-existent key
    Console.WriteLine("Trying to access key 1 (evicted):");
    Console.WriteLine("cache.Get(1)= " + cache.Get(1));

    // Step 6: Update an existing key
    Console.WriteLine("Updating key 3 with a new value...");
    cache.Put(3, "Three-Updated");
    Console.WriteLine("Cache after updating key 3: ");
    PrintCacheState(cache); // Should print: 2 -> 4 -> 3 (3 moved to the end)

    // Step 7: Test capacity limit
    Console.WriteLine("Adding key 5 to test capacity limit...");
    cache.Put(5, "Five");
    Console.WriteLine("Cache after adding key 5 (eviction should occur): ");
    PrintCacheState(cache); // Should print: 4 -> 3 -> 5 (2 evicted)
  }

  private static void PrintCacheState(MyLRUCache<int, string> cache)
  {
    foreach (var node in cache) // Requires an enumerator in your LRU cache
    {
      Console.Write($"{node.Value} -> ");
    }
    Console.WriteLine();
  }
  private static void StressTest()
  {
    Random rnd = new Random();
    int CAPACITY = 10_000;
    int ITERATIONS = 1_000_000;
    MyLRUCache<int, string> lru = new MyLRUCache<int, string>(CAPACITY);
    for (int i = 0; i < ITERATIONS; i++)
    {
      int numberToAdd = rnd.Next();
      lru.Put(numberToAdd, numberToAdd.ToString());

      int numberToAccess = rnd.Next();
      var value = lru[numberToAccess];

      if (i % 1_000 == 0)
      {
        Console.Write(".");
      }
    }
  }
}

/// <summary>
/// Represents a single cache node with a generic key-value pair.
/// </summary>
/// <typeparam name="K">The type of the key.</typeparam>
/// <typeparam name="V">The type of the value.</typeparam>
public class CacheNode<K, V>
{
  /// <summary>
  /// Gets the key of the cache node.
  /// </summary>
  public K Key { private set; get; }

  /// <summary>
  /// The value associated with the key.
  /// </summary>
  public V Value;

  /// <summary>
  /// Initializes a new instance of the <see cref="CacheNode{K, V}"/> class.
  /// </summary>
  /// <param name="key">The key of the cache node.</param>
  /// <param name="value">The value associated with the key.</param>
  public CacheNode(K key, V value)
  {
    Key = key;
    Value = value;
  }
}

/// <summary>
/// A generic Least Recently Used (LRU) Cache implementation.
/// </summary>
/// <typeparam name="K">The type of the key.</typeparam>
/// <typeparam name="V">The type of the value.</typeparam>
public class MyLRUCache<K, V> : IEnumerable
{
  /// <summary>
  /// Doubly linked list to maintain the order of cache nodes.
  /// It is used to remove the LRU entry and to updated the new and recently
  /// accessed entries in constant time
  /// </summary>
  private LinkedList<CacheNode<K, V>> list;

  /// <summary>
  /// Dictionary to map keys to linked list nodes for quick lookup.
  /// </summary>
  private Dictionary<K, LinkedListNode<CacheNode<K, V>>> dict;

  /// <summary>
  /// The maximum capacity of the cache.
  /// </summary>
  private readonly int CAPACITY;

  /// <summary>
  /// Gets the current number of items in the cache.
  /// </summary>
  public int Count => dict.Count;

  /// <summary>
  /// Initializes a new instance of the <see cref="MyLRUCache{K, V}"/> class with a given capacity.
  /// </summary>
  /// <param name="capacity">The maximum number of items the cache can hold.</param>
  public MyLRUCache(int capacity)
  {
    list = new LinkedList<CacheNode<K, V>>();
    dict = new Dictionary<K, LinkedListNode<CacheNode<K, V>>>();
    CAPACITY = capacity;
  }

  /// <summary>
  /// Retrieves a value from the cache using the specified key.
  /// Update the element as recently used by removing from current position and
  /// adding to the end of the linked list
  /// </summary>
  /// <param name="key">The key of the cache item to retrieve.</param>
  /// <returns>The value associated with the key.</returns>
  /// <exception cref="KeyNotFoundException">Thrown when the key is not found in the cache.</exception>
  public V Get(K key)
  {
    if (!dict.ContainsKey(key))
    {
      if (typeof(V).IsValueType)
      {
        throw new KeyNotFoundException($"Key {key} not found");
      }
      else
      {
        return default;
      }
    }
    var existingNode = dict[key];
    list.Remove(existingNode);
    list.AddLast(existingNode);
    return existingNode.Value.Value;
  }

  /// <summary>
  /// Adds a new key-value pair or updates an existing one.
  /// </summary>
  /// <param name="key">The key to add or update.</param>
  /// <param name="value">The value associated with the key.</param>
  public void Put(K key, V value)
  {
    if (dict.ContainsKey(key)) // Update existing element
    {
      var existingNode = dict[key];
      list.Remove(existingNode);
      dict[key] = list.AddLast(existingNode.Value);
    }
    else
    {
      if (dict.Count == CAPACITY) // Eviction required
      {
        dict.Remove(list.First.Value.Key);
        list.RemoveFirst();
      }
      var newNode = new CacheNode<K, V>(key, value);
      dict[key] = list.AddLast(newNode);
    }
  }

  /// <summary>
  /// Gets or sets the value associated with the specified key.
  /// </summary>
  /// <param name="key">The key to get or set.</param>
  /// <returns>The value associated with the key.</returns>
  public V this[K key]
  {
    get => Get(key);
    set => Put(key, value);
  }

  /// <summary>
  /// Checks if a key exists in the cache.
  /// </summary>
  /// <param name="key">The key to check.</param>
  /// <returns>True if the key exists, otherwise false.</returns>
  public bool ContainsKey(K key)
  {
    return dict.ContainsKey(key);
  }

  /// <summary>
  /// Gets an enumerator for the cache nodes.
  /// </summary>
  /// <returns>An enumerator for the cache nodes.</returns>
  public IEnumerator<CacheNode<K, V>> GetEnumerator()
  {
    return list.GetEnumerator();
  }

  /// <summary>
  /// Gets an enumerator for the cache nodes (non-generic version).
  /// </summary>
  /// <returns>An enumerator for the cache nodes.</returns>
  IEnumerator IEnumerable.GetEnumerator()
  {
    return GetEnumerator();
  }
}