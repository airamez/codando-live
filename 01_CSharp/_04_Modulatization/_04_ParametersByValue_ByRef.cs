using System;
using OurCompany;

public class ParameterByValueByRef
{

  public static void Main(string[] args)
  {
    int number1 = Library.ReadInteger("Number_1", "=");
    int number2 = Library.ReadInteger("Number_2", "=");
    Console.WriteLine($"number_1 = {number1}; number_2 = {number2}");

    SwapByValue(number1, number2);
    Console.WriteLine($"number_1 = {number1}; number_2 = {number2}");

    SwapByRef(ref number1, ref number2);
    Console.WriteLine($"number_1 = {number1}; number_2 = {number2}");
  }

  // This is just to demonstrate the difference.The swap doesn't work
  public static void SwapByValue(int a, int b)
  {
    int aux = a;
    a = b;
    b = aux;
  }

  public static void SwapByRef(ref int a, ref int b)
  {
    int aux = a;
    a = b;
    b = aux;
  }
}