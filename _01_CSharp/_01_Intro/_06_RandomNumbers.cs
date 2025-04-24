/*
 * The class Random Represents a pseudo-random number generator, 
 * which is an algorithm that produces a sequence of numbers that 
 * meet certain statistical requirements for randomness.
 * https://learn.microsoft.com/en-us/dotnet/api/system.random?view=net-7.0
 */
using System;
class RundomNumbers
{
  public static void Main(string[] args)
  {
    Random random = new Random();
    int number1 = random.Next(); // Greater or equals to 0 and smaller than Int32.MaxValue
    int number2 = random.Next(10); // Greater or equals to 0 and smaller than 10
    int number3 = random.Next(10, 15); //Greater or equals to 10 and smaller than 15

    Console.WriteLine(number1);
    Console.WriteLine(number2);
    Console.WriteLine(number3);
  }
}