/*
13. Read an integer number with any length and reverse it's digits.
    e.g
    Input = 12345
    Output = 54321
*/
using System;
class RepetitionQuestion13
{
  public static void Main(string[] args)
  {
    Console.Write("Number: ");
    long number = Convert.ToInt64(Console.ReadLine());
    long numberAux = number;
    long numberInverted = 0;

    while (numberAux != 0)
    {
      // Extract last digit
      int lastDigit = (int)numberAux % 10;
      // Add last digit to the end of the inverted number
      numberInverted = numberInverted * 10 + lastDigit;
      // Update the numberAux to all digits but the last
      numberAux /= 10; // NumberAux = NumberAux / 10;
    }
    Console.WriteLine($"The inverse of {number} is {numberInverted}");
  }
}