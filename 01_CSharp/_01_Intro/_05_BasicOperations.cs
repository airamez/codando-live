/*
 https://learn.microsoft.com/en-us/dotnet/csharp/language-reference/operators/
- Assignment: =
- Compound Assignment: += -= *= /=
- Increment: ++ --
- Arithmetic: + - * / %
  - Warning for: / %
- Concatenation: +
- Comparison: == != < <= > >=
- Operation precedence/priority
  - Use parentheses to increase priority: ()
 */
using System;
class BasicOperations
{
  public static void Main(string[] args)
  {
    int counter = 0;
    counter += 1;
    counter += 3; // counter = counter + 3
    counter -= 2; // counter = counter - 2
    counter++; // counter += 1
    int test1 = counter++;
    int test2 = ++counter;
    int a = 1;
    int b = 2;
    int c = 7;
    int sum = a + b - c;

    double d = c / b;
    d = c / (double)b;
    c = 15;
    b = 4;
    int rest = c % b;

    Console.WriteLine(c > b);
    Console.WriteLine(c == b);
    Console.WriteLine(c >= b);
    Console.WriteLine(c <= b);
    Console.WriteLine(c != b);

    double average = (a + b + c) / (double)3;
    Console.WriteLine($"Average: {average}");


  }
}