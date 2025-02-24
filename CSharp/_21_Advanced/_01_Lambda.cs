/*
- https://learn.microsoft.com/en-us/dotnet/csharp/language-reference/operators/lambda-expressions
- Lambda expressions are a succinct way to write anonymous methods using a special syntax.
  They are particularly useful in LINQ queries, event handling, and when working with delegates.
- Key Points:
  - Conciseness: Lambda expressions allow for more concise and readable code.
  - Type Inference: The compiler can often infer the types of input parameters, reducing boilerplate code.
  - Functional Programming: Lambdas enable functional programming techniques within C#.
- Sintaxe
  (parameters) => expression
  That why lambda expression are commonly referred to as arrow functions.
*/

using System;
using System.Text;

namespace Advanced;

public class LambdaApp
{
  public static void Main(string[] args)
  {
    var power = (int _base, int _exponent) => (int)Math.Pow(_base, _exponent);
    for (int i = 0; i <= 10; i++)
    {
      Console.WriteLine($"2^{i} = {power(2, i)}");
    }

    var reverseString = (string input) =>
    {
      StringBuilder sb = new StringBuilder();
      foreach (var c in input)
      {
        sb.Insert(0, c);
      }
      return sb.ToString();
    };
    Console.WriteLine(reverseString("abcdedfg"));
    Console.WriteLine(reverseString("I love coding"));
  }
}