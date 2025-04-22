using System;
/*
 * https://learn.microsoft.com/en-us/dotnet/csharp/language-reference/statements/iteration-statements
 * https://learn.microsoft.com/en-us/dotnet/csharp/language-reference/language-specification/statements#1392-the-while-statement

   while (LOGICAL_EXPRESSION)
   {
    // Statements
   }
 */
class whileCommand
{
  public static void Main(string[] args)
  {
    // int i = 0;
    // while (i < 3) {
    //     Console.Write(i);
    //     i++;
    // }

    // Read number until the user gives the number 0
    // int number = -1;
    // while (number != 0) {
    //     Console.Write("Number: ");
    //     number = Convert.ToInt32(Console.ReadLine());
    //     Console.WriteLine($"Number = {number}");
    // }

    // read integer number until the user provides 0
    // and prints the sum of all number
    int number;
    int sum = 0;
    Console.Write("Number: ");
    number = Convert.ToInt32(Console.ReadLine());
    while (number != 0)
    {
      sum += number; // sum = sum + number
      Console.Write("Number: ");
      number = Convert.ToInt32(Console.ReadLine());
    }
    Console.WriteLine($"The sum of all numbers is {sum}");
  }
}