using System;
using System.ComponentModel;
using System.Linq;
using System.Net;
using System.Reflection;
using System.Runtime.Serialization.Formatters;
using System.Security.Cryptography.X509Certificates;
using OurCompany;

/*
 27. Implement a game of decoding a sequence of integer digits
    The game rules are:
    - Generate an array of random integer digits without duplication
    - Allow the player to provide 5 digits each turn
    - Show * for each digit that is in a correct position
    - Show + for each digit that is out position
    - Show - for each digit that is not part of the list
    - Keep the game until the player get all five
    Example:
    Secret: 02815
    Turn 1
    Input:  69234
    Output: --+--   
    Turn 2
    Input:  02784
    Ouput:  **-+-
    Turn 3
    Input:  02681
    Output: **-++
    Turn 4
    Input:  02851
    Output: ***++
    Turn 5
    Input:  02815
    Output: *****
    Congrats, You won!
 */
public class ArrayQuestion27
{
  public static void Main(string[] args)
  {
    int[] sequence = GetRandomSequence();
    int turn = 1;
    while (true)
    {
      Console.WriteLine($"Turn {turn}");
      Console.Write("Input:  ");
      string guess = Console.ReadLine();
      if (guess.Length != sequence.Length)
      {
        Console.WriteLine($"Please provide {sequence.Length} digits");
        continue;
      }
      Console.Write("Output: ");
      int correctDigitsCount = 0;
      for (int i = 0; i < sequence.Length; i++)
      {
        int guessDigit = Convert.ToInt32(guess[i].ToString());
        if (Array.IndexOf(sequence, guessDigit) == -1)
        {
          Console.Write("-");
        }
        else if (sequence[i] == guessDigit)
        {
          Console.Write("*");
          correctDigitsCount++;
        }
        else
        {
          Console.Write("+");
        }
      }
      Console.WriteLine();
      if (correctDigitsCount == sequence.Length)
      {
        Console.WriteLine($"Congrats, You won in {turn} turns!");
        break;
      }
      turn++;
    }
  }

  /// <summary>
  /// Return an array with 5 random integer digits, from 0 to 9
  /// </summary>
  /// <returns>Random array with 5 integers digits</returns>
  private static int[] GetRandomSequence()
  {
    int[] array = { 0, 1, 2, 3, 4, 5, 6, 7, 8, 9 };
    ArrayQuestion26.RandomizeArray(array);
    int[] sequence = new int[5];
    Array.Copy(array, sequence, sequence.Length);
    return sequence;
  }
}