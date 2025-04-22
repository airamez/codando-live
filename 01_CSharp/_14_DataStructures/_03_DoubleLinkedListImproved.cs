using System;
using System.Diagnostics;

namespace DataStructures.DoubleLinkedList.Improved;

public class DoubleLinkedListApp
{
  public static void Main(string[] args)
  {
    PerformanceTest();
    // DoubleLinkedList list = new DoubleLinkedList();
    // for (int i = 0; i < 100; i++)
    // {
    //     list.AddAtTail($"Node {i}");
    // }
    // Node nodeAt2 = list.GetAtIndex(2);
    // Node nodeAt50 = list.GetAtIndex(50);
    // Node nodeAt90 = list.GetAtIndex(90);
    // Node nodeAt98 = list.GetAtIndex(98);
  }

  private static void PerformanceTest()
  {
    const int LIMIT = 1000000;
    MyDoubleLinkedList list = new MyDoubleLinkedList();
    Random random = new Random();
    for (int i = 0; i < LIMIT; i++)
    {
      list.AddAtTail($"Value: {random.Next(LIMIT)}");
    }
    Stopwatch stopwatch = new Stopwatch();
    stopwatch.Start();
    for (int i = 0; i < 10000; i++)
    {
      var node = list.GetAtIndex(random.Next(LIMIT));
      if (i % 1000 == 0)
      {
        Console.Write(".");
      }
    }
    stopwatch.Stop();
    Console.WriteLine($"\nElapsedMilliseconds: {stopwatch.ElapsedMilliseconds}");

    stopwatch.Restart();
    list.GetAtIndex(list.Count - 5);
    stopwatch.Stop();
    Console.WriteLine($"ElapsedMilliseconds: {stopwatch.ElapsedMilliseconds}");
  }
}

public class Node
{
  public string Data { get; set; }
  public Node Previous { get; set; }
  public Node Next { get; set; }

  public Node(string data)
  {
    Data = data;
    Previous = null;
    Next = null;
  }

  public override string ToString()
  {
    return $"[Data: {Data}]";
  }
}

public class MyDoubleLinkedList
{
  private Node _Head { get; set; }
  private Node _Tail { get; set; }

  public string Head
  {
    get
    {
      if (IsEmpty)
      {
        throw new InvalidOperationException("The list is empty");
      }
      return _Head.Data;
    }
    set
    {
      _Head.Data = value;
    }
  }

  public string Tail
  {
    get
    {
      if (IsEmpty)
      {
        throw new InvalidOperationException("The list is empty");
      }
      return _Tail.Data;
    }
    set
    {
      _Tail.Data = value;
    }
  }

  public int Count { get; private set; }

  public MyDoubleLinkedList()
  {
    _Head = null;
    _Tail = null;
    Count = 0;
  }

  public bool IsEmpty => _Head == null;

  public void AddAtHead(string data)
  {
    var newNode = new Node(data);
    if (IsEmpty)
    {
      _Head = newNode;
      _Tail = newNode;
    }
    else
    {
      newNode.Next = _Head;
      _Head.Previous = newNode;
      _Head = newNode;
    }
    Count++;
  }

  public void AddAtTail(string data)
  {
    if (IsEmpty)
    {
      AddAtHead(data);
    }
    else
    {
      var newNode = new Node(data);
      _Tail.Next = newNode;
      newNode.Previous = _Tail;
      _Tail = newNode;
      Count++;
    }
  }

  public string GetAtIndex(int index)
  {
    return _GetAtIndex(index).Data;
  }

  private Node _GetAtIndex(int index)
  {
    if (index < 0 || index >= Count)
    {
      throw new IndexOutOfRangeException();
    }
    if (index == 0)
    {
      return _Head;
    }
    if (index == Count - 1)
    {
      return _Tail;
    }

    Node runner;
    if (index < Count / 2)
    {
      runner = _Head;
      for (int i = 0; i < index; i++)
      {
        runner = runner.Next;
      }
    }
    else
    {
      runner = _Tail;
      for (int i = Count - 1; i > index; i--)
      {
        runner = runner.Previous;
      }
    }
    return runner;
  }

  public void AddAtIndex(int index, string data)
  {
    if (index < 0 || index > Count)
    {
      throw new IndexOutOfRangeException();
    }
    if (index == 0)
    {
      AddAtHead(data);
    }
    else if (index == Count)
    {
      AddAtTail(data);
    }
    else
    {
      var newNode = new Node(data);
      var atIndex = _GetAtIndex(index);
      atIndex.Previous.Next = newNode;
      newNode.Previous = atIndex.Previous;
      newNode.Next = atIndex;
      atIndex.Previous = newNode;
      Count++;
    }
  }

  public void RemoveAtHead()
  {
    if (IsEmpty)
    {
      throw new InvalidOperationException("The list is empty");
    }
    if (Count == 1)
    {
      _Head = null;
      _Tail = null;
    }
    else
    {
      _Head = _Head.Next;
      _Head.Previous = null;
    }
    Count--;
  }

  public void RemoveAtTail()
  {
    if (IsEmpty)
    {
      throw new InvalidOperationException("The list is empty!");
    }
    if (Count == 1)
    {
      RemoveAtHead();
    }
    else
    {
      _Tail = _Tail.Previous;
      _Tail.Next = null;
      Count--;
    }
  }

  public void RemoveAtIndex(int index)
  {
    if (index < 0 || index >= Count)
    {
      throw new IndexOutOfRangeException($"Invalid index: {index}");
    }
    if (index == 0)
    {
      RemoveAtHead();
    }
    else if (index == Count - 1)
    {
      RemoveAtTail();
    }
    else
    {
      var atIndex = _GetAtIndex(index);
      atIndex.Previous.Next = atIndex.Next;
      atIndex.Next.Previous = atIndex.Previous;
      Count--;
    }
  }
}