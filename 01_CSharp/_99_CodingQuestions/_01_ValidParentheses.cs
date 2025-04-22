/*
  Write a function to validate if a string containing only the parentheses is valid
  Examples:
   {[()]} = Valid
   {[(]}  = Invalid
   Questions:
   - Could be empty = Yes
   - Any other character = No
 */

namespace CodingQuestions;
using System;
using System.Collections.Generic;

public class ValidParentheses
{
  public static void Main(string[] args)
  {
    Console.WriteLine(ValidParentheses.IsValid("{([])}") == true);
    Console.WriteLine(ValidParentheses.IsValid("()") == true);
    Console.WriteLine(ValidParentheses.IsValid("}") == false);
    Console.WriteLine(ValidParentheses.IsValid("{([])})") == false);
    Console.WriteLine(ValidParentheses.IsValid("{([])}{[") == false);
  }

  public static bool IsValid(string s)
  {
    string open = "[{(";
    string close = "]})";
    var stack = new Stack<char>();
    foreach (var c in s)
    {
      int openIndex = open.IndexOf(c);
      int closeIndex = close.IndexOf(c);
      if (openIndex != -1) // If open
      {
        stack.Push(c);
      }
      else // If close
      {
        if (stack.Count == 0) // No openning to validate
        {
          return false;
        }
        char lastOpen = stack.Pop();
        if (lastOpen != open[closeIndex]) // Not the corresponding open
        {
          return false;
        }
      }
    }
    return stack.Count == 0;
  }
}