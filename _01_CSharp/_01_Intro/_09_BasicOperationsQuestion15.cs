/*
 * 15. Read an integer number with 6 digits and generate a new number with the digits in reverse order
 */
using System;
class _006_BasicOperationsQuestions15
{
  public static void Main(string[] args)
  {
    Console.Write("Type a number with 6 digits: ");
    int number = Convert.ToInt32(Console.ReadLine());
    int invertedNumber = 0;

    int lastDigit = number % 10;
    invertedNumber = lastDigit;
    int numberAux = number / 10;

    lastDigit = numberAux % 10;
    invertedNumber = invertedNumber * 10 + lastDigit;

    numberAux = numberAux / 10;
    lastDigit = numberAux % 10;
    invertedNumber = invertedNumber * 10 + lastDigit;

    numberAux = numberAux / 10;
    lastDigit = numberAux % 10;
    invertedNumber = invertedNumber * 10 + lastDigit;

    numberAux = numberAux / 10;
    lastDigit = numberAux % 10;
    invertedNumber = invertedNumber * 10 + lastDigit;

    numberAux = numberAux / 10;
    lastDigit = numberAux % 10;
    invertedNumber = invertedNumber * 10 + lastDigit;

    Console.WriteLine($"Inverted number: {invertedNumber}");
  }
}