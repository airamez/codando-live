using System;
using System.IO;

/*
# Sintaxe: Finally block
    try {
        // block of code
    } catch (Exception ex) {
        // Do something
    } finally {
        // Always executed.
        // Usually cleanup code
    }

*/

namespace Exceptions;

public class FinallyApp
{
  public static void Main(string[] args)
  {
    string filePath = "_11_Exceptions/InputFile.txt";
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
          Console.WriteLine(ex.Message);
        }
      }
      decimal average = sum / (decimal)count;
      Console.WriteLine($"Sum: {sum}");
      Console.WriteLine($"Average: {average}");
    }
    catch (FileNotFoundException ex)
    {
      Console.WriteLine($"{ex.Message}");
    }
    catch (IOException ex)
    {
      Console.WriteLine($"I/O Exception: {ex.Message}");
    }
    catch (Exception ex)
    {
      Console.WriteLine($"An unexpected error occurred: {ex.Message}");
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