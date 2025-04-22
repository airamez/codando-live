/*
 * Read integer numbers (flag = empty) and print the smallest value and it's frequency.
 */
using System;
class RepetitionQuestion07
{
  public static void Main(string[] args)
  {
    string numberStr;
    int number;
    int? lowest = null;
    int lowsestFrequency = 0;

    do
    {
      Console.Write("Number: ");
      numberStr = Console.ReadLine();
      if (numberStr != string.Empty)
      {
        number = Convert.ToInt32(numberStr);
        if ((!lowest.HasValue) ||
             number < lowest)
        {
          lowest = number;
          lowsestFrequency = 1;
        }
        else if (number == lowest)
        {
          lowsestFrequency++;
        }
      }
    } while (numberStr != string.Empty);
    if (lowest.HasValue)
    {
      Console.Write($"Lowest = {lowest}; Frequency = {lowsestFrequency}");
    }
    else
    {
      Console.Write("No values provided");
    }
  }
}