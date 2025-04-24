/*
 * Logical expressions return a boolean value
   - https://learn.microsoft.com/en-us/dotnet/csharp/language-reference/operators/boolean-logical-operators
   - Check priority
 * Comparison and Logical expressions
 * Combination of comparison
 * And = &&
      True and True   = True
      True and False  = False
      False and True  = False
      False and False = False
 * Or = ||
      True and True   = True
      True and False  = True
      False and True  = True
      False and False = False
 * Not = !
      True = False
      False = True
 * XOR = ^
      True and True   = False
      True and False  = True
      False and True  = True
      False and False = False
 * Explain the Short circuit versions: & |
 * Examples using: Married, Salary, Has a job, is a manager
 * - Is married
 * - Is married and is a manager
 * - Married and has a job
 * - Salary greater than 150.000 and is a manager
 * - Is married, salary greater than 150.000 and is manager
 * - Not married and Salary greater than or equal to 150.000 or is not a manager
 */
using System;
class LogicalExpressions
{
  public static void Main(string[] args)
  {
    bool isMarried = true;
    int salary = 120000;
    bool isManager = false;

    Console.WriteLine($"isMarried = {isMarried}");
    Console.WriteLine($"Is married and is a manager = {isMarried && isManager}");
    Console.WriteLine($"Salary greater than 150.000 and is a manager = {salary > 150000 && isManager}");
    Console.WriteLine($"Is married, salary greater than 150.000 and is manager = {isMarried && salary > 150000 && isManager}");
    Console.Write("Not married and Salary greater than or equal to 150.000 or is not a manager = ");
    Console.WriteLine(((!isMarried) && salary >= 150000) || (!isManager));

  }
}