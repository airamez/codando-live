/*
18. Read an integer number H and print a Christmas Tree with height H.
    e.g.
    Height = 7
      *
     ...
    .....
   .......
  .........
 ...........
.............
      |
      |
      |
*/
using System;
class RepetitionQuestion18
{
  public static void Main(string[] args)
  {
    const char SPACE = ' ';
    const char STAR = '*';
    const char LEAF = '.';

    Console.Write("Height: ");
    int height = Convert.ToInt32(Console.ReadLine());

    int spaces = height - 1;
    int leafs = 1;

    // Printing the leafs
    for (int level = 1; level <= height; level++)
    {
      for (int i = 1; i <= spaces; i++)
      {
        Console.Write(SPACE);
      }
      // First level is the star (*)
      if (level == 1)
      {
        Console.WriteLine(STAR);
      }
      else
      { // starting on second level, leafs (.)
        for (int i = 1; i <= leafs; i++)
        {
          Console.Write(LEAF);
        }
        Console.WriteLine();
      }
      spaces--;
      leafs += 2;
    }

    // Printing the truck
    for (int trunkCount = 1; trunkCount <= height / 2; trunkCount++)
    {
      for (int i = 1; i <= height - 1; i++)
      {
        Console.Write(SPACE);
      }
      Console.WriteLine("|");
    }
  }
}