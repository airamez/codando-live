using System;

/*
# Sintaxe: Multiple exceptions
    try {
        // block of code
    } catch (ExceptionType1 ex1) {
        // Ex 1
    } catch (ExceptionType2 ex3) {
        // Ex 2
    } catch (...) {
        // Ex N
    }
*/

namespace Exceptions;

public class MutipleApp
{
  public static void Main(string[] args)
  {
    while (true)
    {
      try
      {
        Console.Write("Number 1: ");
        int number1 = Convert.ToInt32(Console.ReadLine());

        Console.Write("Number 2: ");
        int number2 = Convert.ToInt32(Console.ReadLine());

        decimal division = number1 / (decimal)number2;
        Console.WriteLine($"{number1} / {number2} = {division}");
      }
      catch (FormatException ex)
      {
        Console.WriteLine("Value is invalid!");
      }
      catch (DivideByZeroException ex)
      {
        Console.WriteLine("Division by zero!");
      }
      catch (OverflowException ex)
      {
        Console.WriteLine("The value is too big!");
      }
      catch (Exception ex)
      {
        Console.WriteLine($"Unexpected error");
        Console.WriteLine($"Message: {ex.GetType()}");
        Console.WriteLine($"Message: {ex.Message}");
      }
    }
  }
}