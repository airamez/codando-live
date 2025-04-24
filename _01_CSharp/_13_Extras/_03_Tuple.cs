/*
# Definition:
  # A tuple is a comma-separated list of elements enclosed in parentheses: (a, b, c, d, ...)
  # Tuples can contain 0 or more elements, including nested tuples: (a, b, c, d, (a,b), (a, (b,c)) ...)
# Tuple Types:
  # Tuples provide concise syntax to group multiple data elements in a lightweight data structure.
  # You can declare a tuple variable, initialize it, and access its data members.
# Value Semantics:
  # Tuples are value types; their elements are public fields.
  # Copies of tuple-type variables are made during assignment, method calls, and return values.
# Common Uses:
  # Method Return Types: Instead of defining out method parameters, group method results in a tuple return type.
  # Store Multiple Values: Use a tuple to store multiple values in a single data structure.
*/
using System;
using System.Collections.Generic;
using System.Linq;
using CsvHelper.Configuration.Attributes;

namespace Extras;

public class TupleApp
{
  public static void Main()
  {
    // Tuple
    var tuple = (1, "Hello", 3.14);
    Console.WriteLine(tuple);
    Console.WriteLine(tuple.Item1);
    Console.WriteLine(tuple.Item2);
    Console.WriteLine(tuple.Item3);
    tuple.Item1 = 10;
    tuple.Item2 = "World";
    tuple.Item3 = 3.1416;
    Console.WriteLine(tuple);
    Console.WriteLine(tuple.Item1);
    Console.WriteLine(tuple.Item2);
    Console.WriteLine(tuple.Item3);

    // Named Tuple
    var person = (Name: "John", Age: 30, City: "New York");
    Console.WriteLine(person);
    Console.WriteLine($"Name: {person.Name}, Age: {person.Age}, City: {person.City}");

    // Typed Tuple
    var typedTuple = new Tuple<int, string>(5, "Five");
    Console.WriteLine($"{typedTuple.Item1}: {typedTuple.Item2}");


    // Deconstructing Tuples
    var (min, max) = FindMindMax(8, 6, 1, 9, 3, 5, 0, 6);
    Console.WriteLine($"Min: {min}, Max: {max}");

    // Typed Tuple
    var dictionary = new Dictionary<int, (int ID, string Name)>();
    dictionary[0] = (ID: 1, Name: "Jose");

  }

  public static (int, int) FindMindMax(params int[] numbers)
  {
    return (numbers.Min(), numbers.Max());
  }
}