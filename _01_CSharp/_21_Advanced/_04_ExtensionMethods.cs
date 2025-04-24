/*
- https://learn.microsoft.com/en-us/dotnet/csharp/programming-guide/classes-and-structs/extension-methods
- Extension methods enable you to add methods to an existing class or interface without altering its structure.
  They are defined as static methods in a static class but are called as if they were instance methods on the 
  extended type.
- Key Points:
  - Static Class and Methods: Extension methods must be defined in a static class and be static themselves.
  - this Keyword: The first parameter of the extension method specifies the type it extends, preceded by the this keyword.
  - Enhanced Readability: Extension methods can make your code more readable by providing intuitive method calls on existing types.
- Sintaxe
  public static class MyExtensions
  {
      public static void MyExtensionMethod(this SomeType obj)
      {
          // Method implementation
      }   
  }
*/

using System;
using System.Collections.Generic;

namespace Advanced;

public class ExtensionMethodsApp
{
  public static void Main(string[] args)
  {
    string sentence = "Hello, Do you really like coding?";
    int wordCount = sentence.WordCount();
    Console.WriteLine($"The sentence '{sentence}' has {wordCount} words.");

    var charCounter = sentence.CharCounter();
    foreach (var c in charCounter.Keys)
    {
      Console.WriteLine($"{c}: {charCounter[c]}");
    }

    Console.WriteLine("acegi".CombineAlternating("bdfh"));
  }
}

public static class StringExtensions
{
  public static int WordCount(this string str)
  {
    if (string.IsNullOrEmpty(str))
      return 0;
    return str.Split(new char[] { ' ', '.', '?' }, StringSplitOptions.RemoveEmptyEntries).Length;
  }

  public static Dictionary<char, int> CharCounter(this string str)
  {
    Dictionary<char, int> dict = new Dictionary<char, int>();
    foreach (char c in str)
    {
      if (!dict.ContainsKey(c))
      {
        dict.Add(c, 0);
      }
      dict[c]++;
    }
    return dict;
  }

  public static string CombineAlternating(this string str, string other)
  {
    char[] combined = new char[str.Length + other.Length];
    int index = 0, i = 0, j = 0;
    while (i < str.Length && j < other.Length)
    {
      combined[index++] = str[i++];
      combined[index++] = other[j++];
    }
    string notEmpty = str;
    int k = i;
    if (j < other.Length)
    {
      notEmpty = other;
      k = j;
    }
    while (k < notEmpty.Length)
    {
      combined[index++] = notEmpty[k++];
    }
    return new string(combined);
  }
}
