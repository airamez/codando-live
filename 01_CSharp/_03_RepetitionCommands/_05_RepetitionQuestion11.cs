/*
11. Read a integer number and calculate its Factorial.
 f(n) = n(n-1)(n-2)(n-3)...1
    e.g
    n! 
    f(0) = 1 (Exception)
    f(1) = 1
    f(2) = 2 x 1
    f(4) = 4 x 3 x 2 x 1 = 48
    f(5) = 5 x 4 x 3 x 2 x 1 = 120
    f(6) = 6 x 5 x 4 x 3 x 2 x 1 = 720
*/
using System;
class RepetitionQuestion11
{
  public static void Main(string[] args)
  {
    Console.Write("Number: ");
    int number = Convert.ToInt32(Console.ReadLine());
    int factorial = 1;
    // for (int i = number; i > 1; i--) {
    //     factorial *= i; // fatorial = fatorial * i;
    // }
    for (int i = 2; i <= number; i++)
    {
      factorial *= i; // fatorial = fatorial * i;
    }
    Console.WriteLine($"The factorial is {factorial}");
  }
}