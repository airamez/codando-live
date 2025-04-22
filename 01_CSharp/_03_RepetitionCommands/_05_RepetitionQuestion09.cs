/*
  Print the multiplication table for numbers from 0 to 9.
    .e.g
    0 x 0 = 0
    0 x 1 = 0
    0 x 2 = 0
    ...
    0 x 9 = 0
    1 x 0 = 0
    1 x 1 = 1
    1 x 2 = 2
    ...
    1 x 9 = 9
    2 x 0 = 0
    2 x 1 = 2
    2 x 2 = 4
    ...
    9 x 9 = 81
*/
using System;
class RepetitionQuestion09
{
  public static void Main(string[] args)
  {
    for (int i = 0; i <= 9; i++)
    {
      for (int j = 0; j <= 9; j++)
      {
        Console.WriteLine($"{i} x {j} = {i * j}");
      }
    }
  }
}