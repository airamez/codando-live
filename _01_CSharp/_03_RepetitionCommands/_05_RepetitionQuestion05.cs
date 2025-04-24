/*
 * Read integer numbers (flag = empty) and 
   print the highest value.
 */
using System;
class RepetitionQuestion05
{
	public static void Main(string[] args)
	{
		string numberStr;
		int number;
		int highest = int.MinValue;
		bool numberEntered = false;
		do
		{
			Console.Write("Number: ");
			numberStr = Console.ReadLine();
			// string.Empty == ""
			if (numberStr != string.Empty)
			{
				numberEntered = true;
				number = Convert.ToInt32(numberStr);
				highest = Math.Max(highest, number); // Same effect as the next 3 lines
																						 // if (number > highest) {
																						 //     highest = number;
																						 // }
			}
		} while (numberStr != string.Empty);
		if (numberEntered)
		{
			Console.WriteLine($"Highest number is: {highest}");
		}
		else
		{
			Console.WriteLine("No numbers entered");
		}
	}
}