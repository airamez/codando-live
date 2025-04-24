using System;

/*
# Method overloading is a feature that allows you to define multiple
  methods with the same name in a class, but with different parameters.
# The paremeter list are differentiated based on type, quantity and order
  of the parameters
# The returning type of a method is not considering to differented an
  overloaded method
# Class Content
  # Demo with a method to Add numbers
  # Show Math.Max()
*/
public class OverloadApp
{
  public static void Main(string[] args)
  {
    Console.WriteLine(Sum(5, 9));
    Console.WriteLine(Sum(5, 9, 3));
    Console.WriteLine(Sum(4, 8, 1, 3));
    Console.WriteLine(Sum(9.6, 25.8));
    Console.WriteLine(Math.Max(5, 9.5));
  }

  public static int Sum(int number1, int number2)
  {
    return number1 + number2;
  }

  public static long Sum(int number1, long number2)
  {
    return number1 + number2;
  }

  public static long Sum(long number1, int number2)
  {
    return number1 + number2;
  }

  public static int Sum(int number1, int number2, int number3)
  {
    return Sum(number1, number2) + number3;
  }

  public static int Sum(int number1, int number2, int number3, int number4)
  {
    return number1 + number2 + number3 + number4;
  }

  public static double Sum(double number1, double number2)
  {
    return number1 + number2;
  }
}