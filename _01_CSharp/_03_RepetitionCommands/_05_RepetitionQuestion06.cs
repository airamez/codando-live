/*
 * Read integer numbers (flag = empty) and print the two highest 
   unique values.
 */
using System;
class RepetitionQuestion06
{
  public static void Main(string[] args)
  {
    string numberStr;
    int number;
    int? highest1 = null;
    int? highest2 = null;

    do
    {
      Console.Write("Number = ");
      numberStr = Console.ReadLine();
      if (numberStr != string.Empty)
      {
        number = Convert.ToInt32(numberStr);
        if (!highest1.HasValue)
        { // if is null (does not have value)
          highest1 = number;
        }
        else if (number > highest1)
        {
          highest2 = highest1;
          highest1 = number;
        }
        else if (number != highest1 &&  // If number is different than highest1 and
                   ((!highest2.HasValue) || // If highest2 is null (meaning has no value yet) or
                   number > highest2) // If number is greater than highest 1
                  )
        {
          highest2 = number;
        }
      }
    } while (numberStr != string.Empty);

    if (highest1.HasValue)
    {
      Console.WriteLine($"Highest 1: {highest1}");
    }
    if (highest2.HasValue)
    {
      Console.WriteLine($"Highest 2: {highest2}");
    }
  }
}