/*
20. Write a program that prints the numbers from 1 to 100 each one in a new line.
    But for multiples of three print “Fizz” instead of the number and for the multiples of five print “Buzz”.
    For numbers which are multiples of both three and five print “FizzBuzz”.
*/
using System;
class RepetitionQuestion20
{
  public static void Main(string[] args)
  {
    /*
    3 = Fizz
    5 = Buzz

    1
    2
    Fizz
    4
    Buzz
    Fizz
    7
    8
    Fizz
    10
    11
    Fizz
    13
    14
    FizzBuzz
    16
    17
    Fizz
    ..
    */
    for (int i = 1; i <= 100; i++)
    {
      if (i % 3 == 0 && i % 5 == 0)
      {
        Console.WriteLine("FizzBuzz");
      }
      else if (i % 3 == 0)
      {
        Console.WriteLine("Fizz");
      }
      else if (i % 5 == 0)
      {
        Console.WriteLine("Buzz");
      }
      else
      {
        Console.WriteLine(i);
      }
    }
  }
}