/*
03. Read 3 integers and print the highest value. 
 */
using System;
class SelectionQuestion03
{
  public static void Main(string[] args)
  {
    Console.Write("Number 1: ");
    int number1 = Convert.ToInt32(Console.ReadLine());
    Console.Write("Number 2: ");
    int number2 = Convert.ToInt32(Console.ReadLine());
    Console.Write("Number 3: ");
    int number3 = Convert.ToInt32(Console.ReadLine());

    // if (number1 >= number2 && number1 >= number3) {
    //     Console.WriteLine(number1);
    // } else if (number2 >= number1 && number2 >= number3) {
    //     Console.WriteLine(number2);
    // } else {
    //    Console.WriteLine(number3);
    // }

    Console.WriteLine(Math.Max(number1, Math.Max(number2, number3)));
  }
}