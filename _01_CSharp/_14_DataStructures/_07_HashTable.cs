/*
# Hash Table
  # Hash Table is a data structure that implements an associative array abstract data type.
    This structure allows it to map keys to values. It is called Hash Table because it uses
    a Hash Function to trasnform the key into an index into an array of buckets or slots.
    If two keys map to the same hash value (index), a collision occurs ad must the handled.
  # Operations
    # Add
    # Remove
    # Retrieve or Lookup
*/

using System;
using System.Collections.Generic;


namespace DataStructures.HashTable;

public class MyHashTable
{

  public int TABLE_SIZE = 1000;
  private List<int>[] table;

  public int Size { private set; get; }

  public MyHashTable()
  {
    table = new List<int>[TABLE_SIZE];
    Size = 0;
  }

  public void Add(int value)
  {
    int index = GetHashCode(value);
    if (table[index] == null)
    {
      table[index] = new List<int>();
    }
    if (!table[index].Contains(value))
    {
      table[index].Add(value);
      Size++;
    }
  }

  private int GetHashCode(int value)
  {
    return value % TABLE_SIZE;
  }

  public void Remove(int value)
  {
    int index = GetHashCode(value);
    if (table[index] == null)
    {
      return;
    }
    if (table[index].Contains(value))
    {
      table[index].Remove(value);
      Size--;
    }
  }

  public bool Contains(int value)
  {
    int index = GetHashCode(value);
    if (table[index] == null)
    {
      return false;
    }
    return table[index].Contains(value);
  }
}

