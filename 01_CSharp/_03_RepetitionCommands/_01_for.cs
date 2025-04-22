/*
 * https://learn.microsoft.com/en-us/dotnet/csharp/language-reference/statements/iteration-statements
 * https://learn.microsoft.com/en-us/dotnet/csharp/language-reference/language-specification/statements#1394-the-for-statement
 */
using System;
class forCommand
{
  public static void Main(string[] args)
  {
    for (int i = 0; i <= 10; i++)
    {
      Console.Write($"{i}, ");
    }
  }
}