using System;
/*
 * https://learn.microsoft.com/en-us/dotnet/csharp/language-reference/statements/iteration-statements
 * https://learn.microsoft.com/en-us/dotnet/csharp/language-reference/statements/iteration-statements#the-do-statement

   do
   {
       // Statments
   } while (LOGICAL_EXPRESSION);
 */
class doWhileCommand
{
  public static void Main(string[] args)
  {
    int i = 1;
    do
    {
      Console.Write($"{i}, ");
      i++;
    } while (i <= 10);
  }
}