/*
 * Class Math: https://learn.microsoft.com/en-us/dotnet/api/system.math?view=net-7.0
 * Most Common:
 * PI
 * Abs, Max, Min, Pow, Sqrt
 * Ceiling, Floor, Round, Truncate
 */
using System;
class MathOperations
{
  public static void Main(string[] args)
  {
    Console.WriteLine($"PI = {Math.PI}");
    Console.WriteLine($"Math.Abs(10)  = {Math.Abs(10)}");
    Console.WriteLine($"Math.Abs(-10) = {Math.Abs(-10)}");

    int number1 = 15;
    int number2 = 7;
    int number3 = 3;
    Console.WriteLine($"Math.Max({number1}, {number2}) = {Math.Max(number1, number2)}");
    Console.WriteLine($"Math.Min({number1}, {number2}) = {Math.Min(number1, number2)}");
    Console.WriteLine($"Max = {Math.Max(Math.Max(number1, number2), number3)}");
    Console.WriteLine($"Min = {Math.Min(Math.Min(number1, number2), number3)}");

    Console.WriteLine($"2^4 = {Math.Pow(2, 4)}");
    Console.WriteLine($"{number2}^{number3} = {Math.Pow(number2, number3)}");

    Console.WriteLine($"Square Root of 81 = {Math.Sqrt(81)}");
    Console.WriteLine($"Square Root of 121 = {Math.Sqrt(121)}");
    Console.WriteLine($"Square Root of 541 = {Math.Sqrt(541)}");

    double value = 3.477434;
    Console.WriteLine($"Ceiling  : {Math.Ceiling(value)}");
    Console.WriteLine($"Floor    : {Math.Floor(value)}");
    Console.WriteLine($"Round    : {Math.Round(value, 2)}");
    Console.WriteLine($"Truncate : {Math.Truncate(value)}");
  }
}