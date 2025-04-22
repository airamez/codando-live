using System;
using System.Linq;
using OurCompany;

/*
 * Array: https://learn.microsoft.com/en-us/dotnet/api/system.array?view=net-7.0
 */

public class ArrayOperations
{
  public static void Main(string[] args)
  {
    int[] myArray = { 9, 2, 1, 8, 6, 5, 4, 3, 0, 7 };
    Library.PrintIntArray(myArray, "myArray");

    // Length
    Console.WriteLine($"Length = {myArray.Length}");

    // First Element: [0]
    int first = myArray.First();
    Console.WriteLine($"First: {first}");

    // Last Element: [a.Length - 1]
    int last = myArray.Last();
    Console.WriteLine($"Last: {last}");

    // Min
    int min = myArray.Min();
    Console.WriteLine($"Min: {min}");

    // Max
    int max = myArray.Max();
    Console.WriteLine($"Max: {max}");

    // Sum
    int sum = myArray.Sum();
    Console.WriteLine($"Sum: {sum}");

    // Average
    double average = myArray.Average();
    Console.WriteLine($"Average: {average}");

    // Clone
    int[] myArrayClone = (int[])myArray.Clone();

    // Sort
    Array.Sort(myArray);
    Library.PrintIntArray(myArray, "My Array Sorted");

    // Clear
    Library.PrintIntArray(myArrayClone, "My Array Cloned");
    Array.Clear(myArrayClone);
    Library.PrintIntArray(myArrayClone, "My Array Cloned Cleared");

    // Copy
    int[] myArrayCopy = new int[myArray.Length];
    Library.PrintIntArray(myArrayCopy, "Before copy");
    Array.Copy(myArray, myArrayCopy, myArray.Length);
    Library.PrintIntArray(myArrayCopy, "After copy");

    // Copy range
    Array.Clear(myArrayCopy);
    Library.PrintIntArray(myArrayCopy, "Before copy");
    Array.Copy(myArray, 2, myArrayCopy, 3, 5);
    Library.PrintIntArray(myArrayCopy, "After copy");

    // Contains
    bool contains7 = myArray.Contains(7);
    Console.WriteLine($"Contains(7): {contains7}");
    Console.WriteLine($"Contains(13): {myArray.Contains(13)}"); ;

    // IndexOf
    int indexOf4 = Array.IndexOf(myArrayCopy, 4);
    Console.WriteLine($"IndexOf 4: {indexOf4}");

    // LastIndexOf
    int lastIndexOf0 = Array.LastIndexOf(myArrayCopy, 0);
    Console.WriteLine($"IndexOf 0: {lastIndexOf0}");

    // Reverse
    Library.PrintIntArray(myArray);
    Array.Reverse(myArray);
    Library.PrintIntArray(myArray, "myArray Reversed");

    // Fill
    Array.Fill(myArray, 5);
    Library.PrintIntArray(myArray);
    Array.Fill(myArray, 3, 5, 4);
    Library.PrintIntArray(myArray);

    // Distinct
    int[] myNewArray = { 0, 1, 2, 0, 1, 2, 3, 3, 3, 2, 2, 2, 1, 1, 1, 0, 0, 0 };
    int[] myNewArrayDistinct = myNewArray.Distinct().ToArray();
    Library.PrintIntArray(myNewArray);
    Library.PrintIntArray(myNewArrayDistinct);


    int[] myArray2 = { 9, 2, 1, 8, 6, 5, 4, 3, 0, 7 };

    // Count
    int evenCount = myArray2.Count(e => e % 2 == 0);
    Console.WriteLine($"Even count: {evenCount}");

    // Generating new array based on condition
    int[] greaterThan5 = myArray2.Where(e => e > 5).ToArray();
    Library.PrintIntArray(greaterThan5, "Greater than 5");
    Library.PrintIntArray(myArray2, "myArray2");

  }
}