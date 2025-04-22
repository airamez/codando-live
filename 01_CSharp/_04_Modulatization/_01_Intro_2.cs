using System;

//namespace company.domain.project.module;
public class ModularizationIntro2
{
  /*
   * Module, sub-routine,
   * - Functions
   * - Procedures
   */
  public static void Main(string[] args)
  {
    // Console.Write("Number 1: ");
    // int n1 = Convert.ToInt32(Console.ReadLine());
    // Console.Write("Number 2: ");
    // int n2 = Convert.ToInt32(Console.ReadLine());
    // Console.Write("Number 3: ");
    // int n3 = Convert.ToInt32(Console.ReadLine());

    int n1 = ReadInteger("Number 1", ":");
    int n2 = ReadInteger("Number 2", "=");
    int n3 = ReadInteger("Number 3", "=>");

    double avg = Average(n1, n2, n3);
    Console.WriteLine($"The average of {n1}, {n2}, {n3} = {avg}");

    Console.WriteLine(Average(7, 3, 15));
    Console.WriteLine(Average(1, 9, 45));
  }

  public static int ReadInteger(string prompt, string signal)
  {
    Console.Write($"{prompt} {signal} ");
    return Convert.ToInt32(Console.ReadLine());
  }

  public static double Average(int number1, int number2, int number3)
  {
    int sum = number1 * 3 + number2 * 3 + number3 * 4;
    double avg = (sum) / (double)10;
    return avg;
  }
}