using System;

public class _02_Tridimensonal
{

  public static void Main(string[] args)
  {
    int[,,] tridmensional = {
            {
                {10, 11, 12, 13, 14},
                {15, 16, 17, 19, 19},
            },
            {
                {20, 21, 22, 23, 24},
                {25, 26, 27, 28, 29},
            },
            {
                {30, 31, 32, 33, 34},
                {35, 36, 37, 39, 49},
            }
        };
    PrintArrayTridimensional(tridmensional);
  }

  public static void PrintArrayTridimensional(int[,,] tridimensional)
  {
    Console.WriteLine($"Rank/Dimensions = {tridimensional.Rank}");
    Console.WriteLine($"Length = {tridimensional.Length}");
    Console.WriteLine($"Dimensions 1 = {tridimensional.GetLength(0)}");
    Console.WriteLine($"Dimensions 2 = {tridimensional.GetLength(1)}");
    Console.WriteLine($"Dimensions 3 = {tridimensional.GetLength(2)}");
    for (int i = 0; i < tridimensional.GetLength(0); i++)
    {
      Console.WriteLine($"Matrix[{i}]");
      for (int j = 0; j < tridimensional.GetLength(1); j++)
      {
        for (int k = 0; k < tridimensional.GetLength(2); k++)
        {
          Console.Write($"{tridimensional[i, j, k]} ");
        }
        Console.WriteLine();
      }
    }
  }
}