/*
 Create a multiplication table game following the specification below:
    - The game must ask multiplication questions using random numbers from 0 to 9.
      e.g 3 x 9 = ?
          7 x 8 = ?
          0 x 2 = ?
          ...
    - The game ends when the user type an empty value or if the user get 5 incorrect answers;
    - At the end of the game prints the score showing the number of correct and and incorrect answers;
*/
using System;
class RepetitionQuestion10
{
  public static void Main(string[] args)
  {
    Random rnd = new Random();
    int corrects = 0;
    int incorrects = 0;
    int number1 = 0;
    int number2 = 0;
    int result = 0;
    string guessStr;
    int guess = 0;

    while (true)
    {
      number1 = rnd.Next(10);
      number2 = rnd.Next(10);
      result = number1 * number2;
      Console.Write($"{number1} x {number2} = ");
      guessStr = Console.ReadLine();
      if (guessStr == string.Empty)
      {
        break;
      }
      guess = Convert.ToInt32(guessStr);
      if (guess == result)
      {
        corrects++;
      }
      else
      {
        incorrects++;
      }
      if (incorrects == 5)
      {
        break;
      }
    }
    Console.WriteLine($"Correct answers = {corrects}");
    Console.WriteLine($"Incorrect answers = {incorrects}");
  }
}