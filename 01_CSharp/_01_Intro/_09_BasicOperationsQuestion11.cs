/*
11. Read the name, salary, years of experience and the 
     umbers of kids of a employee and print the name and 
     the new salary using the following formula: 
    - 0.5% per year of experience
    - 2% per kid
 */
using System;
class _006_BasicOperationsQuestions11
{
  public static void Main(string[] args)
  {
    Console.Write("Name: ");
    string name = Console.ReadLine();
    Console.Write("Salary: ");
    double salary = Convert.ToDouble(Console.ReadLine());
    Console.Write("Years of experience: ");
    int yearsOfExperience = Convert.ToInt32(Console.ReadLine());
    Console.Write("Number of Kids: ");
    int kids = Convert.ToInt32(Console.ReadLine());

    // salary += ((yearsOfExperience * 0.5 + kids * 2) / 100) * salary;
    // Console.WriteLine($"Name: {name}; New Salary: {salary}");

    double yearsIncrease = yearsOfExperience * 0.5;
    double kidsIncrease = kids * 2;
    double salaryIncreasePercentage = yearsIncrease + kidsIncrease;
    double salaryIncrease = salary * (salaryIncreasePercentage / 100);
    double newSalary = salary + salaryIncrease;

    Console.WriteLine($"Name: {name}; New Salary: {newSalary}; Salary Increase Percentage: {salaryIncreasePercentage}%; Salary Increase: {salaryIncrease}");
  }
}