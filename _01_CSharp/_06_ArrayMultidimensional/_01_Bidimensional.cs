using System;

public class _01_Bidimensonal
{
  public static void Main(string[] args)
  {
    int[,] Bidimensional = {
            {10, 11, 12, 13, 14},
            {15, 16, 17, 19, 19},
            {20, 21, 22, 23, 24},
            {25, 26, 27, 28, 29},
        };
    Print(Bidimensional);

    int[,] matrix = new int[3, 4];
    for (int i = 0; i < matrix.GetLength(0); i++)
    {
      for (int j = 0; j < matrix.GetLength(1); j++)
      {
        Console.Write($"matrix[{i},{j}]=");
        matrix[i, j] = Convert.ToInt32(Console.ReadLine());
      }
    }
    Print(matrix);
  }

  public static void Print(int[,] matrix)
  {
    Console.WriteLine($"Rank/Dimensions = {matrix.Rank}");
    Console.WriteLine($"Length = {matrix.Length}");
    Console.WriteLine($"Rows = {matrix.GetLength(0)}");
    Console.WriteLine($"Columns = {matrix.GetLength(1)}");
    for (int i = 0; i < matrix.GetLength(0); i++)
    {
      for (int j = 0; j < matrix.GetLength(1); j++)
      {
        Console.Write($"{matrix[i, j]} ");
      }
      Console.WriteLine();
    }
    Console.WriteLine();
  }
}