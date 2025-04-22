/*
18. Read the Name, Height and Gender (M = Male; F = Female) of a person
    and calculate the ideal weight using the rules below:
    - Male  : Ideal weight = (72.7 x Height) - 58
    - Female: Ideal weight = (62.1 x Height) - 44.7
    The height is in meters and the weight in kilograms
 */
using System;
class SelectionQuestion18
{
  public static void Main(string[] args)
  {
    Console.Write("Name: ");
    string name = Console.ReadLine();
    Console.Write("Height: ");
    double height = Convert.ToDouble(Console.ReadLine());
    Console.Write("Gender: ");
    string gender = Console.ReadLine();

    gender = gender.ToUpper(); // Make sure gender is Upper Case

    double idealWeight = 0;
    if (gender != "M" && gender != "F")
    {
      Console.WriteLine("I don't have a formula for the given gender");
    }
    else
    {
      if (gender == "M")
      {
        idealWeight = (72.7 * height) - 58;
      }
      else
      {
        idealWeight = (62.1 * height) - 44.7;
      }
      Console.WriteLine($"The weight is {idealWeight} Kilograms");
    }

    // #Homework, create a new program to provide if the person
    // needs to gain or lose weight and how much.
  }
}