using System;
using System.Collections;
using System.Diagnostics;

namespace DataStructures.LinkedList;

public class LinkedListApp
{
  public static void Main(string[] args)
  {
    //ForEachDemo();
    PerformanceConsiderations();
  }

  private static void PerformanceConsiderations()
  {
    Stopwatch stopwatch = new Stopwatch();
    stopwatch.Start();

    var list = new LinkedList();
    Random random = new Random();
    for (int i = 0; i < 10000; i++)
    {
      list.AddAt(random.Next(1000000).ToString(), random.Next(0, list.Count + 1));
      //list.AddAtTail(random.Next(1000000).ToString());
      if (i % 1000 == 0)
        Console.Write(".");
    }
    Console.WriteLine($"\nList Count: {list.Count}");

    stopwatch.Stop();
    Console.WriteLine($"Elapsed Time: {stopwatch.Elapsed}");
  }

  private static void ForEachDemo()
  {
    var linkedList = new LinkedList();
    linkedList.AddAtHead("Node 3");
    linkedList.AddAtHead("Node 2");
    linkedList.AddAtHead("Node 1");
    foreach (var node in linkedList)
    {
      Console.WriteLine(node);
    }
    foreach (Node node in linkedList)
    {
      Console.WriteLine($"Node Data: {node.Data}");
    }
  }
}

/// <summary>
/// Represents a node in a linked list.
/// </summary>
public class Node
{
  /// <summary>
  /// Gets or sets the data stored in the node.
  /// </summary>
  public string Data { set; get; }

  /// <summary>
  /// Gets or sets the reference to the next node in the linked list.
  /// </summary>
  public Node Next { set; get; }

  /// <summary>
  /// Initializes a new instance of the <see cref="Node"/> class with the specified data.
  /// </summary>
  /// <param name="data">The data to be stored in the node.</param>
  public Node(string data)
  {
    Data = data;
    Next = null;
  }

  public override string ToString()
  {
    return $"[{Data}]";
  }
}

/// <summary>
/// Represents a singly linked list data structure.
/// </summary>
public class LinkedList : IEnumerable
{
  /// <summary>
  /// Gets the head node of the linked list.
  /// </summary>
  public Node Head { get; private set; }

  /// <summary>
  /// Gets the tail node of the linked list.
  /// </summary>
  public Node Tail { get; private set; }

  /// <summary>
  /// Gets the number of nodes in the linked list.
  /// </summary>
  public int Count { get; private set; }

  /// <summary>
  /// Initializes a new instance of the <see cref="LinkedList"/> class.
  /// </summary>
  public LinkedList()
  {
    Head = null;
    Tail = null;
    Count = 0;
  }

  /// <summary>
  /// Adds a new node with the specified data at the head of the linked list.
  /// </summary>
  /// <param name="data">The data to be added.</param>
  public void AddAtHead(string data)
  {
    Node newNode = new Node(data);
    Count++;
    if (Head == null)
    {
      Head = newNode;
      Tail = newNode;
    }
    else
    {
      newNode.Next = Head;
      Head = newNode;
    }
  }

  /// <summary>
  /// Adds a new node with the specified data at the tail of the linked list.
  /// </summary>
  /// <param name="data">The data to be added.</param>
  public void AddAtTail(string data)
  {
    if (Head == null)
    {
      AddAtHead(data);
    }
    else
    {
      Node newNode = new Node(data);
      Count++;
      Tail.Next = newNode;
      Tail = newNode;
    }
  }

  /// <summary>
  /// Adds a new node with the specified data at the give index
  /// Raise exception if the index is out of range.
  /// </summary>
  /// <param name="data">The data to be added.</param>
  /// <param name="index">The index at which to add the node.</param>
  /// <exception cref="System.IndexOutOfRangeException"></exception>
  public void AddAt(string data, int index)
  {
    if (index < 0 || index > Count)
    {
      string msg = $"Invalid Index: {index}. Valid range: 0 to {Count - 1}";
      throw new IndexOutOfRangeException(msg);
    }
    else if (index == 0)
    {
      AddAtHead(data);
    }
    else if (index == Count)
    {
      AddAtTail(data);
    }
    else
    {
      Node newNode = new Node(data);
      // Node runner = Head;
      // Node follower = null;
      // for (int i = 0; i < index; i++)
      // {
      //   follower = runner;
      //   runner = runner.Next;
      // }
      Node previous = Get(index - 1);
      Node next = previous.Next;

      newNode.Next = next;
      previous.Next = newNode;
      Count++;
    }
  }

  /// <summary>
  /// Gets the node at the specified index in the linked list.
  /// </summary>
  /// <param name="index">The index of the node to retrieve.</param>
  /// <returns>The node at the specified index.</returns>
  /// <exception cref="IndexOutOfRangeException">If invalid index</exception>
  public Node Get(int index)
  {
    if (index < 0 || index >= Count)
    {
      string msg = $"Invalid Index: {index}. Valid range: 0 to {Count - 1}";
      throw new IndexOutOfRangeException(msg);
    }
    else if (index == 0)
    {
      return Head;
    }
    else if (index == Count - 1)
    {
      return Tail;
    }
    else
    {
      Node runner = Head;
      for (int i = 0; i < index; i++)
      {
        runner = runner.Next;
      }
      return runner;
    }
  }

  /// <summary>
  /// Deletes the node at the head of the linked list.
  /// </summary>
  public void DeleteAtHead()
  {
    if (Count == 0)
    {
      throw new InvalidOperationException("The list is empty.");
    }
    Head = Head.Next;
    Count--;
    if (Count == 0) // Head == null
    {
      Tail = null;
    }
  }

  /// <summary>
  /// Deletes the node at the tail of the linked list.
  /// </summary>
  public void DeleteAtTail()
  {
    if (Count == 0)
    {
      throw new InvalidOperationException("The list is empty.");
    }
    if (Count == 1)
    {
      DeleteAtHead();
    }
    else
    {
      var secondLast = Get(Count - 2);
      Tail = secondLast;
      Tail.Next = null;
      Count--;
    }
  }

  /// <summary>
  /// Deletes the node at the specified index in the linked list.
  /// Raise exception if the index is out of range.
  /// </summary>
  /// <param name="index">The index of the node to delete.</param>
  /// <exception cref="System.IndexOutOfRangeException"></exception>
  public void DeleteAt(int index)
  {
    if (Count == 0 || index < 0 || index >= Count)
    {
      throw new IndexOutOfRangeException("Invalid index.");
    }
    if (index == 0)
    {
      DeleteAtHead();
    }
    else if (index == Count - 1)
    {
      DeleteAtTail();
    }
    else
    {
      var previous = Get(index - 1);
      previous.Next = previous.Next.Next;
      Count--;
    }
  }

  /// <summary>
  /// Returns an enumerator that iterates through the linked list.
  /// </summary>
  /// <returns>Enumerator</returns>
  public IEnumerator GetEnumerator()
  {
    Node current = Head;
    while (current != null)
    {
      yield return current;
      current = current.Next;
    }
  }
}