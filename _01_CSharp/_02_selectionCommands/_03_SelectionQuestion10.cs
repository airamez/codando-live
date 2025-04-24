/*
 Read two numbers, desired operation (+, -, *, /) and 
 print a string representing the operation with the result
 */
using System;
class SelectionQuestion10
{
  public static void Main(string[] args)
  {
    Console.Write("Number 1 = ");
    int number1 = Convert.ToInt32(Console.ReadLine());
    Console.Write("Number 2 = ");
    int number2 = Convert.ToInt32(Console.ReadLine());
    Console.Write("Operation = ");
    string operation = Console.ReadLine();

    double result = 0;

    if (operation != "+" && operation != "-" &&
        operation != "*" && operation != "/")
    {
      Console.WriteLine($"Invalid Operation: {operation}");
    }
    else
    {
      if (operation == "/" && number2 == 0)
      {
        Console.WriteLine("Invalid Operation: Division by Zero");
      }
      else
      {
        if (operation == "+")
        {
          result = number1 + number2;
        }
        else if (operation == "-")
        {
          result = number1 - number2;
        }
        else if (operation == "*")
        {
          result = number1 * number2;
        }
        else
        {
          result = number1 / (double)number2;
        }
        Console.WriteLine($"{number1} {operation} {number2} = {result}");
      }
    }
  }
}