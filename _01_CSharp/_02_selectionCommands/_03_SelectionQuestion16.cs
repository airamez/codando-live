/*
 Read the 3 scores (grades) of a student and calculate the weighted 
 average using the weights: 30, 30 and 40.
    Print if the student is "PASS" or "FAIL".
    - The score (grade) is a real number from 0 to 10
    - The approval average is 7.5
*/
using System;
class SelectionQuestion16
{
  public static void Main(string[] args)
  {
    Console.Write("Score 1: ");
    double score1 = Convert.ToDouble(Console.ReadLine());
    Console.Write("Score 2: ");
    double score2 = Convert.ToDouble(Console.ReadLine());
    Console.Write("Score 3: ");
    double score3 = Convert.ToDouble(Console.ReadLine());

    double weightedAverage = (score1 * 30 + score2 * 30 + score3 * 40) / 100;

    Console.WriteLine($"Weighted Average = {weightedAverage}");
    if (weightedAverage >= 7.5)
    {
      Console.WriteLine("PASS");
    }
    else
    {
      Console.WriteLine("FAIL");
    }
  }
}