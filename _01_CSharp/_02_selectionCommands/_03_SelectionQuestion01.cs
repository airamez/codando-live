/*
01. Read two integers numbers and print the one with highest value.
    Assume the values are not the same
*/

using System;
class SelectionQuestion01
{
  public static void Main(string[] args)
  {
    Console.Write("Number 1: ");
    int number1 = Convert.ToInt32(Console.ReadLine());
    Console.Write("Number 2: ");
    int number2 = Convert.ToInt32(Console.ReadLine());

    // if (number1 > number2) {
    //     Console.WriteLine($"Highest = {number1}");
    // }
    // if (number2 > number1) {
    //     Console.WriteLine($"Highest = {number2}");
    // }

    // if (number1 > number2) {
    //     Console.WriteLine($"Highest = {number1}");
    // } else {
    //     Console.WriteLine($"Highest = {number2}");
    // }

    Console.WriteLine($"Highest = {Math.Max(number1, number2)}");
  }
}