using System;
using OurCompany;

/*
   https://learn.microsoft.com/en-us/dotnet/csharp/programming-guide/arrays/
   - Array is a data structure to store a collection of variable of the same type
   - Usually (C#, Java, C, C++) an Array has a fixed (static) type and length, define at declaration time
   - The elements of an array are accessed by an index, from 0 (first) to array length - 1 (last)
   - The declare an array we use:
     - TYPE[]
   - The length of an array is stored in the property Length
   - It is important to check if the index accesing an array element is a valid one
 */
public class ArrayIntro
{
    public static void Main(string[] args)
    {
        int[] numbers = {1, 2, 3, 4, 5, 6, 7, 8, 9};

        Console.WriteLine(numbers[5]);

        for (int i = 0; i < numbers.Length; i++) {
            Console.WriteLine(numbers[i]);
        }

        for (int i = 0; i < numbers.Length; i++) {
            numbers[i] = Library.ReadInteger($"number[{i}]");
        }
        for (int i = 0; i < numbers.Length; i++) {
            Console.WriteLine($"numbers[{i}] = {numbers[i]}");
        }

        string[] names = new string[5];
        names[0] = "José";
        names[1] = "Leila";
        names[2] = "Artur";
        Console.WriteLine(names[1]);
        Console.WriteLine(names[2]);
        Console.WriteLine(names[0]);
        Console.WriteLine(names[3]);
        Console.WriteLine(names[3] == null);

        // This will cause an error because there is no index 10
        Console.WriteLine(names[10]);
    }
}