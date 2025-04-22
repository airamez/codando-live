/*
 https://learn.microsoft.com/en-us/dotnet/csharp/language-reference/statements/jump-statements
 */
using System;
class breakAndContinue
{
    public static void Main(string[] args)
    {
        for (int i = 0; i <= 9; i++)
        {
            if (i == 4)
            {
                break;
            }
            Console.Write($"{i}, ");
        }

        Console.WriteLine();

        for (int i = 0; i <= 9; i++)
        {
            if (i % 2 == 0)
            {
                continue;
            }
            Console.Write($"{i}, ");
        }
    }
}