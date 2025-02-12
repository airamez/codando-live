// https://learn.microsoft.com/en-us/dotnet/api/system.text.stringbuilder?view=net-9.0

using System;
using System.Diagnostics;
using System.Text;

namespace DotNetAPI;

public class StringBuilderApp
{
  public static void Main(string[] args)
  {
    Stopwatch stopwatch = new Stopwatch();

    const int LENGTH = 100_000;
    Console.WriteLine($"Length = {LENGTH:N0}");

    DemoString(stopwatch, LENGTH);

    DemoStringBuilder(stopwatch, LENGTH);
  }

  private static void DemoString(Stopwatch stopwatch, int LENGTH)
  {
    stopwatch.Restart();
    long memoryBefore = GC.GetTotalMemory(true);
    Console.WriteLine($"Memory before: {memoryBefore / (1024 * 1024):N0} MB");

    string myString = "";
    for (int i = 0; i < LENGTH; i++)
    {
      myString += $"{i} ";
    }

    stopwatch.Stop();
    Console.WriteLine($"Elapsed Time = {stopwatch.Elapsed}");
    Console.WriteLine($"GC memory: {GC.GetTotalMemory(true) / (1024 * 1024):N0} MB");
  }

  private static void DemoStringBuilder(Stopwatch stopwatch, int LENGTH)
  {
    stopwatch.Restart();
    long memoryBefore = GC.GetTotalMemory(true);
    Console.WriteLine($"Memory before: {memoryBefore / (1024 * 1024):N0} MB");

    var sb = new StringBuilder();
    for (int i = 0; i < LENGTH; i++)
    {
      sb.Append($"{i} ");
    }
    stopwatch.Stop();
    Console.WriteLine($"Elapsed Time = {stopwatch.Elapsed}");
    Console.WriteLine($"GC memory: {GC.GetTotalMemory(true) / (1024 * 1024):N0} MB");
  }
}