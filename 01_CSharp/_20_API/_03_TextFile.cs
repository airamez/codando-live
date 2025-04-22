// https://learn.microsoft.com/en-us/troubleshoot/developer/visualstudio/csharp/language-compilers/read-write-text-file
// https://learn.microsoft.com/en-us/dotnet/api/system.io.streamreader?view=net-9.0

using System;
using System.IO;
using System.Text;

namespace DotNetAPI;

public class TextFileApp
{
  public static void Main(string[] args)
  {
    string filePath = $"MyTextFile_{DateTime.Now.ToString("yyyy_MM_dd_HH_mm_ss")}.txt";
    Console.WriteLine($"File path: {filePath}");

    // Reading from Console and writing to a text file, line by line
    Console.WriteLine("Enter text to save (empty line to exit):");
    using (var writer = new StreamWriter(filePath, false, Encoding.UTF8))
    {
      int line = 1;
      while (true)
      {
        Console.Write($"Line[{line++}]: ");
        string input = Console.ReadLine();
        if (string.IsNullOrEmpty(input))
        {
          break;
        }
        writer.WriteLine(input);
      }
    }

    // Reading from file and printing in the console, line by line
    Console.WriteLine("Reading from file:");
    using (var reader = new StreamReader(filePath))
    {
      string line;
      while ((line = reader.ReadLine()) != null)
      {
        Console.WriteLine(line);
      }
    }

    // Reading the entire file content
    using (var reader = new StreamReader(filePath))
    {
      var fileContent = reader.ReadToEnd();
      Console.WriteLine(fileContent);
      // Writing the entire content to the file
      using (StreamWriter writer = new StreamWriter(filePath + ".bak"))
      {
        writer.Write(fileContent);
      }
    }
  }
}