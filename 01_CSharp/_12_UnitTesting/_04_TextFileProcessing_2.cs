using System;
using System.IO;
using System.Collections.Generic;

namespace UnitTesting2;

public class TextFileProcessing_2
{
  public static void Main(string[] args)
  {
    string filePath = "CSharp/_12_UnitTesting/InputFile.txt";
    TextFileProcessor processor = new TextFileProcessor(filePath);
    //List<string> lines = processor.ProduceLines();
    processor.Run();
  }
}

public class TextFileProcessor
{
  public string FilePath { get; private set; }

  public TextFileProcessor(string filePath)
  {
    FilePath = filePath;
  }

  public void Run()
  {
    List<string> lines = ProduceLines();
    foreach (string line in lines)
    {
      Console.WriteLine(line);
    }
  }

  public List<string> ProduceLines()
  {
    List<string> lines = new List<string>();
    StreamReader reader = null;
    try
    {
      int number;
      int sum = 0;
      int count = 0;
      reader = new StreamReader(FilePath);
      while (!reader.EndOfStream)
      {
        try
        {
          number = Convert.ToInt32(reader.ReadLine());
          count++;
          sum += number;
          lines.Add($"{count}: {number}");
        }
        catch (FormatException ex)
        {
          lines.Add("Invalid number!");
        }
      }
      decimal average = sum / (decimal)count;
      lines.Add($"Sum: {sum}");
      lines.Add($"Average: {average}");
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
    return lines;
  }
}