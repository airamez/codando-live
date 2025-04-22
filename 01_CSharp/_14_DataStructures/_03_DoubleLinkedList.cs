using System;
using System.Diagnostics;
using System.Runtime.ExceptionServices;

namespace DataStructures.DoubleLinkedList;

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
      Node node = list.GetAtIndex(random.Next(LIMIT));
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
  public Node Head { get; private set; }
  public Node Tail { get; private set; }

  public int Count { get; private set; }

  public MyDoubleLinkedList()
  {
    Head = null;
    Tail = null;
    Count = 0;
  }

  public bool IsEmpty => Head == null;

  public void AddAtHead(string data)
  {
    var newNode = new Node(data);
    if (IsEmpty)
    {
      Head = newNode;
      Tail = newNode;
    }
    else
    {
      newNode.Next = Head;
      Head.Previous = newNode;
      Head = newNode;
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
      Tail.Next = newNode;
      newNode.Previous = Tail;
      Tail = newNode;
      Count++;
    }
  }

  public Node GetAtIndex(int index)
  {
    if (index < 0 || index >= Count)
    {
      throw new IndexOutOfRangeException();
    }
    if (index == 0)
    {
      return Head;
    }
    if (index == Count - 1)
    {
      return Tail;
    }

    Node runner;
    if (index < Count / 2)
    {
      runner = Head;
      for (int i = 0; i < index; i++)
      {
        runner = runner.Next;
      }
    }
    else
    {
      runner = Tail;
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
      var atIndex = GetAtIndex(index);
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
      Head = null;
      Tail = null;
    }
    else
    {
      Head = Head.Next;
      Head.Previous = null;
    }
    Count--;
  }

  public void RemoveAtTail()
  {
    if (IsEmpty)
    {
      throw new InvalidOperationException("List is empty!");
    }
    if (Count == 1)
    {
      RemoveAtHead();
    }
    else
    {
      Tail = Tail.Previous;
      Tail.Next = null;
      Count--;
    }
  }

  public void RemoveAtIndex(int index)
  {
    if (index < 0 || index >= Count)
    {
      throw new IndexOutOfRangeException($"Invali index: {index}");
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
      var atIndex = GetAtIndex(index);
      atIndex.Previous.Next = atIndex.Next;
      atIndex.Next.Previous = atIndex.Previous;
      Count--;
    }
  }
}