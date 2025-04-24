//https://learn.microsoft.com/en-us/dotnet/api/system.collections.generic.dictionary-2?view=net-9.0

using System;
using System.Collections.Generic;

namespace Collections;

public class DictionaryApp
{
  public static void Main(string[] args)
  {
    Dictionary<int, string> numbers = new Dictionary<int, string>();
    numbers.Add(0, "Zero");
    numbers.Add(1, "One");
    numbers.Add(2, "Two");
    numbers.Add(3, "Three");
    numbers.Add(4, "Four");
    numbers[9] = "Nine"; // The most common way to Add :)

    Console.WriteLine(numbers.ContainsKey(1));
    Console.WriteLine(numbers.ContainsKey(5));

    try
    {
      numbers.Add(0, "Zero..."); // Exception if key already exists
      // When using Add, maybe necessary to check if key exists fist
    }
    catch (Exception ex)
    {
      Console.WriteLine(ex.Message);
    }

    numbers[0] = "Zero.."; // No exception, works as replace

    string two = numbers[2];
    Console.WriteLine($"two = {two}");

    try
    {
      string five = numbers[5]; // Exception when key doesn't exist
    }
    catch (Exception ex)
    {
      Console.WriteLine(ex.Message);
    }

    string six = numbers.GetValueOrDefault(6); // No exception if does not exist, return the default value
    Console.WriteLine($"Six = {six}");


    for (int i = 0; i <= 4; i++)
    {
      Console.Write($"{numbers[i]} ");
    }
    Console.WriteLine();

    foreach (int key in numbers.Keys)
    {
      Console.WriteLine($"{key} = {numbers[key]}");
    }

    numbers.Remove(9);
    foreach (int key in numbers.Keys)
    {
      Console.WriteLine($"{key} = {numbers[key]}");
    }

    numbers.Remove(9); // Does not raise exception if does not exist
  }
}