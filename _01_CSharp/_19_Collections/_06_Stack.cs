/*
https://learn.microsoft.com/en-us/dotnet/api/system.collections.generic.stack-1?view=net-8.0
*/
using System;
using System.Collections.Generic;

namespace Collections;

public class StackApp
{
  public static void Main(string[] args)
  {
    var stack = new Stack<string>();
    stack.Push("Fourth");
    stack.Push("Third");
    stack.Push("Second");
    stack.Push("First");

    Console.WriteLine(stack.Count);

    var item = stack.Pop();
    Console.WriteLine(item);

    Console.WriteLine(stack.Peek());

    while (stack.Count > 0)
    {
      Console.WriteLine(stack.Pop());
    }
  }
}