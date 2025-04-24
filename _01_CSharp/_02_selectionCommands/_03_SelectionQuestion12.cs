/*
Read a single digit number and print the description (name).
 */
using System;
class SelectionQuestion12
{
  public static void Main(string[] args)
  {
    Console.Write("Digit = ");
    int digit = Convert.ToInt32(Console.ReadLine());
    string digitName;
    if (digit < 0 || digit > 9)
    {
      Console.WriteLine("Invalid digit!");
    }
    else
    {
      if (digit == 0)
      {
        digitName = "Zero";
      }
      else if (digit == 1)
      {
        digitName = "One";
      }
      else if (digit == 2)
      {
        digitName = "Two";
      }
      else if (digit == 3)
      {
        digitName = "Three";
      }
      else if (digit == 4)
      {
        digitName = "Four";
      }
      else if (digit == 5)
      {
        digitName = "Five";
      }
      else if (digit == 6)
      {
        digitName = "Six";
      }
      else if (digit == 7)
      {
        digitName = "Seven";
      }
      else if (digit == 8)
      {
        digitName = "Eight";
      }
      else
      {
        digitName = "Nine";
      }
      Console.WriteLine(digitName);
    }
  }
}