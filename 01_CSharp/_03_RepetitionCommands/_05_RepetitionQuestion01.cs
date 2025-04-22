/*
 * Print the numbers from 1 to 1000 without 
   using new lines after each number.
 */
using System;
class RepetitionQuestion01
{
  public static void Main(string[] args)
  {
    const int MIN = 1;
    const int MAX = 10;

    for (int i = MIN; i <= MAX; i++)
    {
      Console.Write($"{i},");
    }

    int j = MIN;
    while (j <= MAX)
    {
      Console.Write($"{j},");
      j++;
    }

    int k = MIN;
    do
    {
      Console.Write($"{k},");
      k++;
    } while (k <= MAX);
  }
}