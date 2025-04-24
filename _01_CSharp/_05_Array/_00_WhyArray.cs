using System;
using OurCompany;

/*
 1 - Create a program to read 10 integer numbers and print all numbers
     after the last number is read
 2 - Change the program to read up to 10 numbers.
     The FLAG is the value 0
 */
public class WhyArray
{
  public static void Main(string[] args)
  {
    //Solution1();
    //Solution2();
    //Solution1WithArray();
    Solution2WithArray();
  }

  public static void Solution1()
  {
    int number1 = Library.ReadInteger("Number 1");
    int number2 = Library.ReadInteger("Number 2");
    int number3 = Library.ReadInteger("Number 3");
    int number4 = Library.ReadInteger("Number 4");
    int number5 = Library.ReadInteger("Number 5");
    int number6 = Library.ReadInteger("Number 6");
    int number7 = Library.ReadInteger("Number 7");
    int number8 = Library.ReadInteger("Number 8");
    int number9 = Library.ReadInteger("Number 9");
    int number10 = Library.ReadInteger("Number 10");

    Console.WriteLine($"Number 1: {number1}");
    Console.WriteLine($"Number 2: {number2}");
    Console.WriteLine($"Number 3: {number3}");
    Console.WriteLine($"Number 4: {number4}");
    Console.WriteLine($"Number 5: {number5}");
    Console.WriteLine($"Number 6: {number6}");
    Console.WriteLine($"Number 7: {number7}");
    Console.WriteLine($"Number 8: {number8}");
    Console.WriteLine($"Number 9: {number9}");
    Console.WriteLine($"Number 10: {number10}");

  }

  public static void Solution2()
  {
    int number1 = 0;
    int number2 = 0;
    int number3 = 0;
    int number4 = 0;
    int number5 = 0;
    int number6 = 0;
    int number7 = 0;
    int number8 = 0;
    int number9 = 0;
    int number10 = 0;

    // Reading
    number1 = Library.ReadInteger("Number 1");
    if (number1 != 0)
    {
      number2 = Library.ReadInteger("Number 2");
      if (number2 != 0)
      {
        number3 = Library.ReadInteger("Number 3");
        if (number3 != 0)
        {
          number4 = Library.ReadInteger("Number 4");
          if (number4 != 0)
          {
            number5 = Library.ReadInteger("Number 5");
            if (number5 != 0)
            {
              number6 = Library.ReadInteger("Number 6");
              if (number6 != 0)
              {
                number7 = Library.ReadInteger("Number 7");
                if (number7 != 0)
                {
                  number8 = Library.ReadInteger("Number 8");
                  if (number8 != 0)
                  {
                    number9 = Library.ReadInteger("Number 9");
                    if (number9 != 0)
                    {
                      number10 = Library.ReadInteger("Number 10");
                    }
                  }
                }
              }
            }
          }
        }
      }
    }
    // Priting
    if (number1 != 0)
    {
      Console.WriteLine($"Number 1: {number1}");
    }
    if (number2 != 0)
    {
      Console.WriteLine($"Number 2: {number2}");
    }
    if (number3 != 0)
    {
      Console.WriteLine($"Number 3: {number3}");
    }
    if (number4 != 0)
    {
      Console.WriteLine($"Number 4: {number4}");
    }
    if (number5 != 0)
    {
      Console.WriteLine($"Number 5: {number5}");
    }
    if (number6 != 0)
    {
      Console.WriteLine($"Number 6: {number6}");
    }
    if (number7 != 0)
    {
      Console.WriteLine($"Number 7: {number7}");
    }
    if (number8 != 0)
    {
      Console.WriteLine($"Number 8: {number8}");
    }
    if (number9 != 0)
    {
      Console.WriteLine($"Number 9: {number9}");
    }
    if (number10 != 0)
    {
      Console.WriteLine($"Number 10: {number10}");
    }
  }

  public static void Solution1WithArray()
  {
    int[] numbers = new int[10];
    // reading
    for (int i = 0; i < numbers.Length; i++)
    {
      numbers[i] = Library.ReadInteger($"Number {i + 1}");
    }
    // Writing
    for (int i = 0; i < numbers.Length; i++)
    {
      Console.WriteLine($"Number {i + 1}: {numbers[i]}");
    }
  }

  public static void Solution2WithArray()
  {
    int[] numbers = new int[10];
    // reading
    for (int i = 0; i < numbers.Length; i++)
    {
      numbers[i] = Library.ReadInteger($"Number {i + 1}");
      if (numbers[i] == 0)
      {
        break;
      }
    }
    // Writing
    for (int i = 0; i < numbers.Length; i++)
    {
      if (numbers[i] == 0)
      {
        break;
      }
      Console.WriteLine($"Number {i + 1}: {numbers[i]}");
    }
  }
}