/*
 * Print the Fibonacci sequence while the term is smaller than 5000.
 * Fibonacci = 0, 1, 1, 2, 3, 5, 8, 13, 21, 34, 55, 89, ...
*/
using System;
class RepetitionQuestion08
{
  public static void Main(string[] args)
  {
    int term1 = 0;
    int term2 = 1;
    Console.Write($"{term1}, ");
    int newTerm = term1 + term2;
    while (newTerm < 5000)
    {
      Console.Write($"{newTerm}, ");
      newTerm = term1 + term2;
      term1 = term2;
      term2 = newTerm;
    }
  }
}