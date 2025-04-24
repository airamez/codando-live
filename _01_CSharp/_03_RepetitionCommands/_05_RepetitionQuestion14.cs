/*
14. Read an integer number and determine if it is a prime number or not.
*/
using System;
class RepetitionQuestion14
{
  public static void Main(string[] args)
  {
    Console.Write("Number: ");
    int number = Convert.ToInt32(Console.ReadLine());

    bool isPrime = true;
    for (int i = 2; i <= number / 2; i++)
    {
      if (number % i == 0)
      {
        isPrime = false;
        break;
      }
    }
    if (isPrime && number != 1 && number != 0)
    {
      Console.WriteLine($"{number} is Prime");
    }
    else
    {
      Console.WriteLine($"{number} is NOT Prime");
    }
  }
}