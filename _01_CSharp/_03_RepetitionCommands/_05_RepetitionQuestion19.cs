/*
19. Generated 10,000 random numbers from 1 to 5 and print how many times and 
    the percentage of each numbers.
    e.g.
    1 = 200 times (2%)
    2 = 5000 times (50%)
    3 = 800 times (8%)
    4 = 1000 times (10%)
    5 = 3000 times (30%)
*/
using System;
class RepetitionQuestion19
{
  public static void Main(string[] args)
  {
    // Declaring the counters
    int counter_1 = 0;
    int counter_2 = 0;
    int counter_3 = 0;
    int counter_4 = 0;
    int counter_5 = 0;

    // initializing the random component
    Random rnd = new Random();

    // Looping 10k times
    for (int i = 1; i <= 10000; i++)
    {
      // Generating a random number from 1 to 5 (inclusive)
      int newNumber = rnd.Next(1, 6);

      // Acumulating the correct counter
      if (newNumber == 1)
      {
        counter_1++;
      }
      else if (newNumber == 2)
      {
        counter_2++;
      }
      else if (newNumber == 3)
      {
        counter_3++;
      }
      else if (newNumber == 4)
      {
        counter_4++;
      }
      else
      {
        counter_5++;
      }
    }

    // Calculatig the percentages
    decimal percentage_1 = (100 * counter_1) / (decimal)10000;
    decimal percentage_2 = (100 * counter_2) / (decimal)10000;
    decimal percentage_3 = (100 * counter_3) / (decimal)10000;
    decimal percentage_4 = (100 * counter_4) / (decimal)10000;
    decimal percentage_5 = (100 * counter_5) / (decimal)10000;

    Console.WriteLine($"1 = {counter_1} times ({percentage_1}%)");
    Console.WriteLine($"2 = {counter_2} times ({percentage_2}%)");
    Console.WriteLine($"3 = {counter_3} times ({percentage_3}%)");
    Console.WriteLine($"4 = {counter_4} times ({percentage_4}%)");
    Console.WriteLine($"5 = {counter_5} times ({percentage_5}%)");
  }
}