/*

NOTE: Show the power of modularization by refactoring the program below:

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
using OurCompany;

class ModularizationIntro3
{
  public static void Main(string[] args)
  {
    const char SPACE = ' ';
    const char STAR = '*';
    const char LEAF = '.';

    int height = Library.ReadInteger("Height: ", "=");

    int spaces = height - 1;
    int leafs = 1;

    // Printing the leafs
    for (int level = 1; level <= height; level++)
    {
      Library.RepeatChar(SPACE, spaces);
      // First level is the star (*)
      if (level == 1)
      {
        Console.WriteLine(STAR);
      }
      else
      { // starting on second level, leafs (.)
        Library.RepeatChar(LEAF, leafs);
        Console.WriteLine();
      }
      spaces--;
      leafs += 2;
    }

    // Printing the truck
    for (int trunkCount = 1; trunkCount <= height / 2; trunkCount++)
    {
      Library.RepeatChar(SPACE, height - 1);
      Console.WriteLine("|");
    }
  }
}