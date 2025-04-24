/*
Read the current hour (military time: 0 to 23) and print the appropriate salutation:
    Good morning
    Good Afternoon
    Good evening
    Good night
 */
using System;
class SelectionQuestion11
{
  public static void Main(string[] args)
  {
    Console.Write("Hour = ");
    int hour = Convert.ToInt32(Console.ReadLine());

    if (hour < 0 || hour > 23)
    {
      Console.WriteLine("Invalid hour!");
    }
    else
    {
      string salutation;
      if (hour < 12)
      {
        salutation = "Morning";
      }
      else if (hour < 16)
      {
        salutation = "Afternoon";
      }
      else if (hour < 20)
      {
        salutation = "Evening";
      }
      else
      {
        salutation = "Night";
      }
      Console.WriteLine($"Good {salutation}!!");
    }
  }
}