/*
 * 05. Read the base and length of a rectangle and calculate its area.
 */
using System;
class _006_BasicOperationsQuestions05
{
  public static void Main(string[] args)
  {
    Console.Write("Base: ");
    double baseValue = Convert.ToDouble(Console.ReadLine());
    Console.Write("Length: ");
    double lengthValue = Convert.ToDouble(Console.ReadLine());
    double area = baseValue * lengthValue;
    Console.WriteLine($"Area = {area}");

    Console.WriteLine("Press any key to close");
    Console.ReadKey();
  }
}