using System;
using System.IO;
using System.Collections.Generic;

namespace UnitTesting3;

public class TextFileProcessing_3
{
  public static void Main(string[] args)
  {
    string filePath = "CSharp/_12_UnitTesting/InputFile.txt";
    TextFileProcessor processor =
      new TextFileProcessor(new StreamReaderWrapper(filePath));
    processor.Run();
  }
}

public interface IStreamReader
{
  string ReadLine();
  bool EndOfStream { get; }
  void Close();
}

public class StreamReaderWrapper : IStreamReader
{
  private readonly StreamReader _streamReader;

  public StreamReaderWrapper(string fileName)
  {
    _streamReader = new StreamReader(fileName);
  }

  public string ReadLine()
  {
    return _streamReader.ReadLine();
  }

  public bool EndOfStream
  {
    get { return _streamReader.EndOfStream; }
  }

  public void Close()
  {
    _streamReader.Close();
  }
}

public class TextFileProcessor
{
  public IStreamReader StreamReader { get; private set; }

  public TextFileProcessor(IStreamReader streamReader)
  {
    StreamReader = streamReader;
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
    try
    {
      int number;
      int sum = 0;
      int count = 0;
      while (!StreamReader.EndOfStream)
      {
        try
        {
          number = Convert.ToInt32(StreamReader.ReadLine());
          count++;
          sum += number;
          lines.Add($"{count}: {number}");
        }
        catch (FormatException ex)
        {
          lines.Add("Invalid value");
        }
      }
      decimal average = sum / (decimal)count;
      lines.Add($"Sum: {sum}");
      lines.Add($"Average: {average}");
    }
    catch (Exception ex)
    {
      string msg = $"An unexpected error occurred: {ex.Message}";
      throw new Exception(msg);
    }
    finally
    {
      if (StreamReader != null)
      {
        StreamReader.Close();
      }
    }
    return lines;
  }
}