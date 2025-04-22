/*
16. Read an integer number H and print H lines composed of * characters start 
    with one character and adding one * for each new line.
    e.g.
    Height = 7
    *
    **
    ***
    ****
    *****
    ******
    *******
*/
using System;
class RepetitionQuestion16
{
  public static void Main(string[] args)
  {
    Console.Write("Height: ");
    int height = Convert.ToInt32(Console.ReadLine());

    // Option 1
    for (int row = 1; row <= height; row++)
    {
      for (int i = 1; i <= row; i++)
      {
        Console.Write("*");
      }
      Console.WriteLine();
    }

    // Option 2
    string asterics = "*";
    for (int row = 1; row <= height; row++)
    {
      Console.WriteLine(asterics);
      asterics += "*";
    }
  }
}