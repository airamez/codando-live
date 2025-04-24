/*
Read an letter and print if it is a consonant or vowel
 */
using System;
class SelectionQuestion13
{
  public static void Main(string[] args)
  {
    Console.Write("Letter: ");
    string letter = Console.ReadLine();

    // Solution 1 (Junior) :)
    if (letter == "a" ||
        letter == "e" ||
        letter == "i" ||
        letter == "o" ||
        letter == "u" ||
        letter == "A" ||
        letter == "E" ||
        letter == "I" ||
        letter == "O" ||
        letter == "U")
    {
      Console.WriteLine("Vowel");
    }
    else
    {
      Console.WriteLine("Consonant");
    }

    // Solution 2 (Senior) :)
    string letterLower = letter.ToLower();
    if (letterLower == "a" ||
        letterLower == "e" ||
        letterLower == "i" ||
        letterLower == "o" ||
        letterLower == "u")
    {
      Console.WriteLine($"{letter} is a Vowel");
    }
    else
    {
      Console.WriteLine($"{letter} is a Consonant");
    }

    // Solution 3 (Principal) :)
    if ("aeiou".IndexOf(letterLower) != -1)
    {
      Console.WriteLine($"{letter} is a Vowel");
    }
    else
    {
      Console.WriteLine($"{letter} is a Consonant");
    }
  }
}