/*
15. Read two integer numbers and calculate the "integer" division 
    without use the division operator.
*/
using System;
class RepetitionQuestion15
{
  public static void Main(string[] args)
  {
    Console.Write("Dividend: ");
    int dividend = Convert.ToInt32(Console.ReadLine());
    Console.Write("Divisor: ");
    int divisor = Convert.ToInt32(Console.ReadLine());

    if (divisor == 0)
    {
      Console.WriteLine("Sorry but I can't divide by zero");
      return;
    }

    int originalDividend = dividend;
    int originalDivisor = divisor;
    dividend = Math.Abs(dividend);
    divisor = Math.Abs(divisor);

    int remainder = dividend;
    int quocient = 0;
    while (remainder >= divisor)
    {
      quocient++;
      remainder -= divisor;
    }
    // Setting the quocient to negative when:
    //   dividend positive and divisor negative
    //                     Or
    //   dividend negativa and divisor positive
    if ((originalDividend >= 0 && originalDivisor < 0) ||
        (originalDividend < 0 && originalDivisor >= 0))
    {
      quocient = -quocient;
    }

    Console.WriteLine($"{originalDividend} / {originalDivisor} = {quocient}");
    Console.WriteLine($"{originalDividend} / {originalDivisor}: Quocient = {quocient}; Remainder = {remainder}");
  }
}