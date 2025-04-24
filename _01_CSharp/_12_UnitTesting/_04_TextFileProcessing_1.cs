/*
Create a program to read a test file with a integer number per line
and produce the following output in the console:
1 - Each number with a line number
2 - The sum of all numbers
3 - The average of all numbers
4 - "Invalid value" for any line that is not a number
Example:
Input File:
----------------
10
20
30
invalid number
40
----------------
Output:
1: 10
2: 20
3: 30
Invalid value
4: 40
Sum: 100
Average: 25
*/
using System;
using System.IO;

namespace UnitTesting1;

public class TextFileProcessing_1
{
  public static void Main(string[] args)
  {
    string filePath = "_12_UnitTesting/InputFile.txt";
    StreamReader reader = null;
    try
    {
      int number;
      int sum = 0;
      int count = 0;
      reader = new StreamReader(filePath);
      while (!reader.EndOfStream)
      {
        try
        {
          number = Convert.ToInt32(reader.ReadLine());
          count++;
          sum += number;
          Console.WriteLine($"{count}: {number}");
        }
        catch (FormatException ex)
        {
          Console.WriteLine("Invalid value");
        }
      }
      decimal average = sum / (decimal)count;
      Console.WriteLine($"Sum: {sum}");
      Console.WriteLine($"Average: {average}");
    }
    catch (Exception ex)
    {
      throw new Exception($"An unexpected error occurred: {ex.Message}");
    }
    finally
    {
      if (reader != null)
      {
        reader.Close();
      }
    }
  }
}