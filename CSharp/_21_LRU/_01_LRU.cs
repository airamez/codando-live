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
    least recently used item.
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
    var lru = new MyLRUCache<int, string>(5);
    lru.Put(1, "One");
    lru.Put(2, "Two");
    lru.Put(3, "Three");
    lru.Put(4, "Four");
    lru.Put(5, "Five");

    Console.WriteLine("lru.ContainsKey(1): " + lru.ContainsKey(1));
    Console.WriteLine("lru.Get(1): " + lru.Get(1));
    Console.WriteLine("lru.ContainsKey(6): " + lru.ContainsKey(6));
    Console.WriteLine("lru.Get(6): " + lru.Get(6));

    for (int i = 1; i <= lru.Count; i++)
    {
      Console.WriteLine($"Key[{i}]: {lru[i]}");
    }

    Console.WriteLine(lru.Get(1));
    lru.Put(6, "Six");
    Console.WriteLine(lru.ContainsKey(2));
    lru.Put(7, "Seven");
    lru.Put(8, "Eight");
    lru.Put(9, "Nine");

    for (int i = 0; i < 9; i++)
    {
      Console.WriteLine($"Key[{i}]: {lru[i]}");
    }
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

      if (i % 10_000 == 0)
      {
        Console.Write(".");
      }
    }
  }
}

public class MyLRUCacheNode<K, V>
{
  public K Key { private set; get; }
  public V Value;
  public MyLRUCacheNode(K key, V value)
  {
    Key = key;
    Value = value;
  }
}

public class MyLRUCache<K, V>
{
  private LinkedList<MyLRUCacheNode<K, V>> list;
  private Dictionary<K, LinkedListNode<MyLRUCacheNode<K, V>>> dict;
  private readonly int CAPACITY;
  public int Count => dict.Count;

  public MyLRUCache(int capacity)
  {
    list = new LinkedList<MyLRUCacheNode<K, V>>();
    dict = new Dictionary<K, LinkedListNode<MyLRUCacheNode<K, V>>>();
    CAPACITY = capacity;
  }

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
    var newNode = new MyLRUCacheNode<K, V>(existingNode.Value.Key, existingNode.Value.Value);
    dict.Remove(key);
    list.Remove(existingNode);
    dict[key] = list.AddLast(newNode);
    return newNode.Value;
  }

  public void Put(K key, V value)
  {
    if (dict.ContainsKey(key))
    {
      var existingNode = dict[key];
      dict.Remove(key);
      list.Remove(existingNode);
      var newNode = new MyLRUCacheNode<K, V>(key, value);
      dict[key] = list.AddLast(newNode);
    }
    else
    {
      if (dict.Count == CAPACITY)
      {
        var nodeToEvict = list.First;
        dict.Remove(nodeToEvict.Value.Key);
        list.Remove(nodeToEvict.Value);
      }
      var newNode = new MyLRUCacheNode<K, V>(key, value);
      dict[key] = list.AddLast(newNode);
    }
  }

  public V this[K key]
  {
    get => Get(key);
    set => Put(key, value);
  }

  public bool ContainsKey(K key)
  {
    return dict.ContainsKey(key);
  }
}