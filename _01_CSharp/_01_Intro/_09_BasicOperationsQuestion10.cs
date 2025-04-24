/*
10. Read the name, salary and salary increase percentage and 
    print the name and the new salary.
 */
using System;
class _006_BasicOperationsQuestions10
{
  public static void Main(string[] args)
  {
    Console.Write("Name: ");
    string name = Console.ReadLine();
    Console.Write("Salary: ");
    double salary = Convert.ToDouble(Console.ReadLine());
    Console.Write("Salary Increase %: ");
    double salaryIncreasePercentage = Convert.ToDouble(Console.ReadLine());

    double salaryIncrease = salary * (salaryIncreasePercentage / 100);
    double newSalary = salary + salaryIncrease;

    Console.WriteLine($"Name: {name}; New Salary: {newSalary}; Salary Increase: {salaryIncrease}");
  }
}