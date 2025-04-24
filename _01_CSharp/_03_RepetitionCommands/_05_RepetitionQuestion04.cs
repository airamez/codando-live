/*
 * Read integer numbers (flag = empty) and print the average.
 */
using System;
class RepetitionQuestion04
{
  public static void Main(string[] args)
  {
    int sum = 0;
    int count = 0;
    while (true)
    {
      Console.Write("Number = ");
      string numAsString = Console.ReadLine();
      if (numAsString == "")
      {
        break;
      }
      int number = Convert.ToInt32(numAsString);
      sum += number;
      count++;
    }
    if (count == 0)
    {
      Console.WriteLine("No numbers entered!");
    }
    else
    {
      double average = sum / (double)count;
      Console.WriteLine($"Average = {average}");
    }
  }
}