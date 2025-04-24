using System;
using OurCompany;

/*
 * Array is a reference type
 */
public class ArrayAssignment
{
	public static void Main(string[] args)
	{
		int number = 10;
		int numberCopy = number;
		Console.WriteLine($"Number: {number}, NumberCopy: {numberCopy}");

		numberCopy = 20;
		Console.WriteLine($"Number: {number}, NumberCopy: {numberCopy}");

		Console.WriteLine("Printing 'both' arrays");
		int[] numbers = { 1, 2, 3 };
		int[] numbersCopy = numbers;
		Library.PrintIntArray(numbers, "numbers", true);
		Library.PrintIntArray(numbersCopy, "numbersCopy", true);

		numbers[0] = 3;
		numbers[2] = 1;
		Console.WriteLine("Printing 'both' arrays, after changing the numbers array");
		Library.PrintIntArray(numbers, "numbers", true);
		Library.PrintIntArray(numbersCopy, "numbersCopy", true);

		Console.WriteLine("Cloning the array and changing the cloned one");
		numbersCopy = (int[])numbers.Clone(); // Using the Clone method from the array
		numbersCopy[0] = 1;
		numbersCopy[2] = 3;
		Library.PrintIntArray(numbers, "numbers", true);
		Library.PrintIntArray(numbersCopy, "numbersCopy", true);
	}
}