using System;
using OurCompany;

/*
3. Implement a routine to print an integer array allowing the options to provide a label and print the array inline or multi-line.
   - Inline: all elements of the array in a single line, separated by commna "," and inside open/close brackets: e.g [1,2,3,4,5]
   - Multi: each element in a new line after the index, the index should be inside brackets.

   Array: 1 2 3 4 5

   Inline: [1,2,3,4,5]

   Multiline[0]: 1
   Multiline[1]: 2
   Multiline[2]: 3
   Multiline[3]: 4
   Multiline[4]: 5
*/
public class ArrayQuestion03
{
  public static void Main(string[] args)
  {
    int[] array = { 1, 2, 3, 4, 5, 6, 7, 8, 9 };

    MyArray.Print(array);
    MyArray.Print(array, "Inline", true);
    MyArray.Print(array, "My array", true);
    MyArray.Print(array, "Multiline", false);
    MyArray.Print(array, "My Array Multiline", false);
  }
}