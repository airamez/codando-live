/*
 * 07. Read a temperature in Celsius and convert to Fahrenheit: F = C x 1.8 + 32.
 */
using System;
class _006_BasicOperationsQuestions07
{
  public static void Main(string[] args)
  {
    Console.Write("Celsius: ");
    double celsius = Convert.ToDouble(Console.ReadLine());
    double fahrenheit = celsius * 1.8 + 32;
    Console.WriteLine($"Fahrenheit = {fahrenheit}");
  }
}