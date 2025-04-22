using System;
using OurCompany;

/*
 * The recursion definition is very siple: A routine can call itself
 * - Direct recursion is when a routine call itself directly
 * - Undirect recursion is when a routine call other routine and
 *   in some point the initial routine is called again
 * - Concepts:
 *   - Every recursion must have a stop condition
 *     - Usually called: base case or base condition
 *   - While the stop condition is not reached the routine
 *     execution is stacked
 *   - Many data-structures and advanced algorithm use recursion
 */

public class RecursionIntro
{
  public static void Main(string[] args)
  {
    int value = Library.ReadInteger("Number");
    CountingReverse(value);
    Console.WriteLine();
    Counting(value);
  }

  public static void CountingReverse(int number)
  {
    if (number == 0)
    {
      return;
    }
    Console.Write($"{number}, ");
    CountingReverse(number - 1);
  }

  public static void Counting(int number)
  {
    if (number == 0)
    {
      return;
    }
    Counting(number - 1);
    Console.Write($"{number}, ");
  }
}