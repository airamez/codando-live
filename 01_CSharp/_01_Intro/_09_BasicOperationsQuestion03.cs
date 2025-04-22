/*
 * 03. Read two integer numbers A and B and print the result of all 
 *     arithmetic operations you know for A and B.
*      Operations: + - * / %
 */
using System;
class _006_BasicOperationsQuestions03
{
  public static void Main(string[] args)
  {
    Console.Write("A = ");
    int a = Convert.ToInt32(Console.ReadLine());
    Console.Write("B = ");
    int b = Convert.ToInt32(Console.ReadLine());
    Console.WriteLine($"A + B = {a + b}");
    Console.WriteLine($"A - B = {a - b}");
    Console.WriteLine($"A * B = {a * b}");
    Console.WriteLine($"A / B = {a / b} (Integer)");
    Console.WriteLine($"A / B = {a / (double)b} (Double)");
    Console.WriteLine($"A % B = {a % b}");

    Console.WriteLine("Press any key to close");
    Console.ReadKey();
  }
}