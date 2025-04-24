/*
12. Create a guessing game following the specification below:
- Generate a random integer number from 1 to 100 (inclusive)
- Let the user try to guess the number until it get the right number
- For every guess the program should update the new interval
- At the end, print how many tries the player used
- e.g. Generated number = 35 (The player can't see this number)
- If only one number left in the interval the player lose the game
Try to guess a number from:
1 to 100 => 20
21 to 100 => 65
21 to 64 => 30
31 to 64 => 41
31 to 40 => 36
31 to 35 => 35
Congratulations you guessed the right number with 6 attempts!
*/
using System;
class RepetitionQuestion12
{
  public static void Main(string[] args)
  {
    Random rnd = new Random();
    int left = 1;
    int right = 100;
    int number = rnd.Next(1, right + 1); // Random number from 1 to 100 (inclusive)
                                         // int number = rnd.Next(right) + 1
    int attempts = 0;
    int guess;

    while (true)
    {
      Console.Write($"{left} to {right} => ");
      guess = Convert.ToInt32(Console.ReadLine());
      attempts++;
      // Checking if the guess is invalid
      if (guess < left || guess > right)
      {
        continue; // Skip to next guess
      }
      if (guess == number)
      {
        Console.WriteLine($"Congratulations you guessed the right number with {attempts} attempts !");
        break;
      }
      else if (guess < number)
      {
        left = guess + 1;
      }
      else
      {
        right = guess - 1;
      }
      if (left == right)
      {
        Console.WriteLine($"Your lost!!! With {attempts} attempts");
        break;
      }
    }
  }
}