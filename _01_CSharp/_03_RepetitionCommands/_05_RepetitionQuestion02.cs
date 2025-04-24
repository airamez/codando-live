/*
 * Read two integer numbers representing an 
 interval and print all numbers inside the interval.
 */
using System;
class RepetitionQuestion02
{
  public static void Main(string[] args)
  {
    Console.Write("Minimum: ");
    int min = Convert.ToInt32(Console.ReadLine());
    Console.Write("Maximum: ");
    int max = Convert.ToInt32(Console.ReadLine());

    // Making sure the interval is in ascending order
    // if  (min > max) {
    //     int aux = min;
    //     min = max;
    //     max = aux;
    // }
    // for (int i = min; i <= max; i++) {
    //     Console.Write($"{i},");
    // }

    // if (min <= max) {
    //     for (int i = min; i <= max; i++) {
    //         Console.Write($"{i},");
    //     }   
    // } else {
    //     for (int i = max; i <= min; i++) {
    //         Console.Write($"{i},");
    //     }
    // }
    Console.WriteLine();

    if (min <= max)
    {
      for (int i = min; i <= max; i++)
      {
        Console.Write($"{i},");
      }
    }
    else
    {
      if (min > max)
      {
        int aux = min;
        min = max;
        max = aux;
      }
      for (int i = max; i >= min; i--)
      {
        Console.Write($"{i},");
      }
    }
  }
}