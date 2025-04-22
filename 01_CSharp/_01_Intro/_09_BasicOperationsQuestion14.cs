/*
 * 14. Read an integer number with 6 digits and separate it into two integers with 3 digits each
 */
using System;
class _006_BasicOperationsQuestions14
{
  public static void Main(string[] args)
  {
    Console.Write("Type a number with 6 digits: ");
    int fullNumber = Convert.ToInt32(Console.ReadLine());
    int left = fullNumber / 1000;
    int right = fullNumber % 1000;

    Console.WriteLine($"Left = {left}; Right = {right}");
  }
}