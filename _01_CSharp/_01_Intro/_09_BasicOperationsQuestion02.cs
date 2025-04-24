/*
 * 02. Read an integer number and print the three predecessors and successors.
 */
using System;
class _006_BasicOperationsQuestions02
{
  public static void Main(string[] args)
  {
    Console.Write("Type an integer number: ");
    int number = Convert.ToInt32(Console.ReadLine());
    Console.WriteLine($"Predecessors: {number - 3}, {number - 2}, {number - 1} ");
    Console.WriteLine($"Successors: {number + 1}, {number + 2}, {number + 3}");

    Console.WriteLine("Press any key to close");
    Console.ReadKey();
  }
}