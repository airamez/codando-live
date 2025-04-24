/*
    https://learn.microsoft.com/en-us/dotnet/csharp/language-reference/statements/selection-statements

    Syntax:
    switch(expression) 
    {
    case x:
        if x equals to expression
        break;
    case y:
        if y equals to expression
        break;
    case z:
        if z equals to expression
        break;
    default:
        if no match
        break;
    }
 */
using System;
class SWITCH
{
  public static void Main(string[] args)
  {
    /*
     * Get the Day of the week description from the number
     * 1 = Sunday
     * 2 = Monday
     * 3 = Tuesday
     * 4 = Wednesday
     * 5 = Thursday
     * 6 = Friday
     * 7 = Saturday
     * Obs: Print if it is an invalid number as well.
     */
    Console.Write("Day of the week number: ");
    int day = Convert.ToInt32(Console.ReadLine());
    string dayDescription;
    switch (day)
    {
      case 1:
        dayDescription = "Sunday";
        break;
      case 2:
        dayDescription = "Monday";
        break;
      case 3:
        dayDescription = "Tuesday";
        break;
      case 4:
        dayDescription = "Wednesday";
        break;
      case 5:
        dayDescription = "Thursday";
        break;
      case 6:
        dayDescription = "Friday";
        break;
      case 7:
        dayDescription = "Saturday";
        break;
      default:
        dayDescription = "Invalid day";
        break;
    }
    Console.WriteLine($"The day #{day} is {dayDescription}");
  }
}