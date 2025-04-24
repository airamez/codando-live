/*
# What is a Stack?
  # A stack is a type of data structure that stores elements in a sequence which is enforced by the operations used.
  # It follows the LIFO (Last-In-First-Out) methodology, meaning the data that gets in last, gets out first.
  # The process to add an element into stack is called push, and to remove an element from the stack is called pop.
# Key Operations
  # Push: Add an element to the top of the stack.
  # Pop: Remove an element from the top of the stack.
  # IsEmpty: Check if the stack is empty.
  # IsFull: Check if the stack is full.
  # Length/Size
  # Peek/Top: Get the value of the top of the stack without removing it.

# Real World Examples of Stacks
  # Back Button in Web Browsers
  # Undo Functionality
  # Expression Evaluation ((x + 3) + (y / 2))
  # Memory Management
*/
using System;
using DataStructures.DoubleLinkedList.Improved;

namespace DataStructures.Stack;
public class MyStack
{
  private const string STACK_EMPTY_MESSAGE = "The stack is Emtpy.";
  private const string STACK_FULL_MESSAGE = "The stack is FULL.";

  private MyDoubleLinkedList List { set; get; }

  public MyStack(int capacity = int.MaxValue)
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
        throw new InvalidOperationException(STACK_EMPTY_MESSAGE);
      }
      return List.Head;
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

  public void Push(string data)
  {
    if (IsFull)
    {
      throw new InvalidOperationException(STACK_FULL_MESSAGE);
    }
    List.AddAtHead(data);
  }

  public string Pop()
  {
    if (IsEmpty)
    {
      throw new InvalidOperationException(STACK_EMPTY_MESSAGE);
    }
    string value = List.Head;
    List.RemoveAtHead();
    return value;
  }
}