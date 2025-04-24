// https://learn.microsoft.com/en-us/dotnet/api/system.text.stringbuilder?view=net-9.0

using System;
using System.Diagnostics;
using System.Text;

namespace DotNetAPI;

public class StringBuilderDemoApp
{
  public static void Main(string[] args)
  {
    string template = "[ID:{_ID_}; Description:{_DESC_}; Price:{_PRICE_}]";
    int id = 100;
    string description = "Product 1";
    int price = 500;

    var result = new StringBuilder(template);
    result.Replace("{_ID_}", id.ToString());
    result.Replace("{_DESC_}", description);
    result.Replace("{_PRICE_}", price.ToString());
    Console.WriteLine(result.ToString());

    var result2 = new StringBuilder(template);
    result2
      .Replace("{_ID_}", id.ToString())
      .Replace("{_DESC_}", description)
      .Replace("{_PRICE_}", price.ToString());
    Console.WriteLine(result2);

    StringBuilder names = new StringBuilder("Jose;Artur");
    names.Insert(5, "Leila;");
    Console.WriteLine(names);

    names.Remove(0, "Jose;".Length);
    Console.WriteLine(names);

    Console.WriteLine(names[0]);
    Console.WriteLine(names[1]);
    Console.WriteLine(names[2]);
    Console.WriteLine(names[3]);
    Console.WriteLine(names[4]);

    var bigOne = new StringBuilder(100);
    while (bigOne.Length < 100)
    {
      bigOne.Append("X");
    }
    Console.WriteLine(bigOne);
    bigOne.Clear();
    Console.WriteLine(bigOne);

    var namesAsString = names.ToString();
    Console.WriteLine(namesAsString);

  }
}