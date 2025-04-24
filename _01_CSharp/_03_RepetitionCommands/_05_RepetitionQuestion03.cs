/*
Read two integer numbers representing an interval and 
print all even numbers inside the interval.
*/
using System;
class RepetitionQuestion03
{
  public static void Main(string[] args)
  {
    Console.Write("Minimum: ");
    int min = Convert.ToInt32(Console.ReadLine());
    Console.Write("Maximum: ");
    int max = Convert.ToInt32(Console.ReadLine());

    // for (int i = min; i <= max; i++) {
    //     if (i % 2 == 0) {
    //         Console.Write($"{i},");
    //     }
    // }

    Console.WriteLine();

    if (min % 2 != 0)
    {
      min++;
    }
    for (int i = min; i <= max; i += 2)
    {
      Console.Write($"{i},");
    }
  }
}