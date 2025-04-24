/*
Read the values of the side of a triangle and print the type of the triangle
- Isosceles: Only two sides are equals
- Scalene: All sides are different
- Equilateral : All sides are equals
 */
using System;
class SelectionQuestion19
{
  public static void Main(string[] args)
  {
    Console.Write("Size A: ");
    double a = Convert.ToDouble(Console.ReadLine());
    Console.Write("Size B: ");
    double b = Convert.ToDouble(Console.ReadLine());
    Console.Write("Size C: ");
    double c = Convert.ToDouble(Console.ReadLine());

    if (a == b && a == c)
    {
      Console.WriteLine("Equilateral");
    }
    else if (a != b && a != c && b != c)
    {
      Console.WriteLine("Scalene");
    }
    else
    {
      Console.WriteLine("Isosceles");
    }
  }
}