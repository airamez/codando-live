using System;
using System.Collections.Generic;
using Microsoft.VisualStudio.TestPlatform.Common.DataCollection;
using NUnit.Framework;


namespace LRU;

public class LRUApp
{
  public static void Main(string[] args)
  {
    var lru = new MyLRUCache<int, string>(5);
    lru.Put(1, "One");
    lru.Put(2, "Two");
    lru.Put(3, "Three");
    lru.Put(4, "Four");
    lru.Put(5, "Five");

    Console.WriteLine(lru.ContainsKey(1));
    Console.WriteLine(lru.Get(1));
    Console.WriteLine(lru.ContainsKey(6));
    Console.WriteLine(lru.Get(6));

    for (int i = 1; i <= lru.Count; i++)
    {
      Console.WriteLine(lru[i]);
    }

    Console.WriteLine(lru.Get(1));
    lru.Put(6, "Six");
    Console.WriteLine(lru.ContainsKey(2));
    lru.Put(7, "Seven");
    lru.Put(8, "Eight");
    lru.Put(9, "Nine");

    for (int i = 0; i < 9; i++)
    {
      Console.WriteLine(lru[i]);
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
  private Dictionary<K, MyLRUCacheNode<K, V>> dict;
  private readonly int CAPACITY;
  public int Count => dict.Count;

  public MyLRUCache(int capacity)
  {
    list = new LinkedList<MyLRUCacheNode<K, V>>();
    dict = new Dictionary<K, MyLRUCacheNode<K, V>>();
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
    var newNode = new MyLRUCacheNode<K, V>(existingNode.Key, existingNode.Value);
    dict.Remove(key);
    list.Remove(existingNode);
    list.AddLast(newNode);
    dict[key] = newNode;
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
      dict[key] = newNode;
      list.AddLast(newNode);
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
      dict[key] = newNode;
      list.AddLast(newNode);
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