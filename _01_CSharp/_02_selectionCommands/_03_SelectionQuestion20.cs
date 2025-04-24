/*
20. Read the name and salary of a employee and calculate the new salary
    based on the rules below:
    Salary               Raising %
     0 to 50,000           20%
     50,001 to 100,000     15%
     100,001 to 150,000    10%
     150,000 +              5%
     Print the name, raising % and the new Salary
 */
using System;
class SelectionQuestion20
{
  public static void Main(string[] args)
  {
    Console.Write("Name: ");
    string name = Console.ReadLine();
    Console.Write("Salary: ");
    double salary = Convert.ToDouble(Console.ReadLine());

    int raisingPercentual = 0;
    if (salary <= 50000)
    {
      raisingPercentual = 20;
    }
    else if (salary <= 100000)
    {
      raisingPercentual = 15;
    }
    else if (salary <= 150000)
    {
      raisingPercentual = 10;
    }
    else
    {
      raisingPercentual = 5;
    }
    double salaryIncrease = salary * (raisingPercentual / 100.00);
    double newSalary = salary + salaryIncrease;

    Console.WriteLine($"Name: {name}; Salary: {newSalary}; Increase: {salaryIncrease}");
  }
}