/*
 * 12. Read two integer numbers and swap the variables content
 */
using System;
class _006_BasicOperationsQuestions12
{
  public static void Main(string[] args)
  {
    Console.Write("Number 1: ");
    int number1 = Convert.ToInt32(Console.ReadLine());
    Console.Write("Number 2: ");
    int number2 = Convert.ToInt32(Console.ReadLine());

    Console.WriteLine($"Number 1 = {number1}; Number 2 = {number2}");
    int aux = number1;
    number1 = number2;
    number2 = aux;
    Console.WriteLine($"Number 1 = {number1}; Number 2 = {number2}");
  }
}