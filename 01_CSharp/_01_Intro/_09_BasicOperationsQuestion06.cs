/*
 * 06. Read an integer and print True if the number is Even and False if it is Odd.
 */
using System;
class _006_BasicOperationsQuestions06
{
  public static void Main(string[] args)
  {
    Console.Write("Number: ");
    int number = Convert.ToInt32(Console.ReadLine());
    Console.WriteLine(number % 2 == 0);

    Console.WriteLine("Press any key to close");
    Console.ReadKey();
  }
}