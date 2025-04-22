/*
# What is a Queue?
  # A queue is a type of data structure that stores elements in a sequence which is enforced by the operations used.
  # It follows the FIFO (First-In-First-Out) methodology, meaning the data that gets in first, gets out first.
  # The process to add an element into queue is called enqueue, and to remove an element from the queue is called dequeue.
# Key Operations/Properties
  # Enqueue: Add an element to the end of the queue.
  # Dequeue: Remove an element from the front of the queue.
  # Peek/Top: Get the value of the front of the queue without removing it.
  # IsEmpty: Check if the queue is empty.
  # IsFull: Check if the queue is full.
  # Length: Number of elements in the queue.
  # Capacity: Max length of the queue
# Real World Examples of Queues
  # Computer Buffers: Printers use queues to manage printing processes.
  # Call Center Systems: These use queues to hold people calling them in an order.
  # CPU Scheduling: The processes are kept into a queue according to their priority.
  # E-commerce Websites: Customers making purchases follow a queue-like structure to make payments.
  # Queue Services: Scalling system by queueing requests and processing them as fast as possible with load balance
 */
using System;
using DataStructures.DoubleLinkedList.Improved;

namespace DataStructures.Queue;
public class MyQueue
{
  private const string QUEUE_EMPTY_MESSAGE = "The queue is Emtpy.";
  private const string QUEUE_FULL_MESSAGE = "The queue is FULL.";

  private MyDoubleLinkedList List { set; get; }

  public MyQueue(int capacity = int.MaxValue)
  {
    List = new MyDoubleLinkedList();
    Capacity = capacity;
  }


  public string Peek
  {
    get
    {
      if (IsEmpty)
      {
        throw new InvalidOperationException(QUEUE_EMPTY_MESSAGE);
      }
      return List.Tail;
    }
  }

  public bool IsEmpty
  {
    get
    {
      return List.IsEmpty;
    }
  }

  public bool IsFull
  {
    get
    {
      return List.Count == Capacity;
    }
  }

  public int Length
  {
    get
    {
      return List.Count;
    }
  }

  public int Capacity { private set; get; }

  public void Enqueue(string data)
  {
    if (IsFull)
    {
      throw new InvalidOperationException(QUEUE_FULL_MESSAGE);
    }
    List.AddAtHead(data);
  }

  public string Dequeue()
  {
    if (IsEmpty)
    {
      throw new InvalidOperationException(QUEUE_EMPTY_MESSAGE);
    }
    string value = List.Tail;
    List.RemoveAtTail();
    return value;
  }
}