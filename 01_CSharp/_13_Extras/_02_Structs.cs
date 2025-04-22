/*
# Structs (Strcutures) is a value type data structure in C#
# Unlike classes, structs are value types rather than reference types.
# It is similar to a class because it can contain constructors, methods, and fields
# It represents lightweight objects that encapsulate data
# Common use: Designing small, data-focused types.
# Sintaxe:
  struct <struct_name>
  {
      // Fields
      // Methods
  }
*/
using System;

namespace Extras;

public struct Coords
{
  public double X { set; get; }
  public double Y { set; get; }

  public Coords(double x, double y)
  {
    X = x;
    Y = y;
  }

  public override string ToString() => $"({X}, {Y})";
}

public class StructApp
{
  public static void Main()
  {
    Coords a = new Coords(3, 4);
    Console.WriteLine(a);
    Coords b = a; // Copy of a
    Console.WriteLine(b);
    a.X = 10;
    Console.WriteLine(a);
    Console.WriteLine(b);
  }
}