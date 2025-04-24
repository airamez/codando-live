using System;

/*
- The char type
  - Represent a single Unicode UTF-16 character
    - ASCII: American Standard Code for Information Interchange
      - https://www.ascii-code.com/
    - Unicode: Universal Coded Character Set
      - https://home.unicode.org/
  - The default value is \\0
  - The delimiter is single quote 'a' "a"

 */

public class _01_Char
{
  public static void Main(string[] args)
  {
    // Setting the Console to use UTF
    Console.OutputEncoding = System.Text.Encoding.UTF8;

    char myChar = 'Z';
    Console.WriteLine(myChar);
    string myString = myChar.ToString();
    Console.WriteLine(myString);
    // Operations
    Console.WriteLine($"char.IsLetter('a'): {char.IsLetter('a')}");
    Console.WriteLine($"char.IsLetter('0'): {char.IsLetter('0')}");
    Console.WriteLine($"char.IsLetterOrDigit('5'): {char.IsLetterOrDigit('5')}");
    Console.WriteLine($"char.IsLetterOrDigit('A'): {char.IsLetterOrDigit('A')}");
    Console.WriteLine($"char.IsLetterOrDigit('+'): {char.IsLetterOrDigit('+')}");
    Console.WriteLine($"char.IsLower('a'): {char.IsLower('a')}");
    Console.WriteLine($"char.IsLower('A'): {char.IsLower('A')}");
    Console.WriteLine($"char.ToUpper('a'): {char.ToUpper('a')}");
    Console.WriteLine($"char.ToLower('A'): {char.ToLower('A')}");
    Console.WriteLine($"char.IsBetween('d', 'a', 'f'): {char.IsBetween('d', 'a', 'f')}");
    Console.WriteLine($"char.IsBetween('k', 'a', 'f'): {char.IsBetween('k', 'a', 'f')}");
    Console.WriteLine($"char.IsDigit('9'): {char.IsDigit('9')}");
    Console.WriteLine($"char.IsDigit('Z'): {char.IsDigit('Z')}");
    Console.WriteLine($"char.IsPunctuation('.'): {char.IsPunctuation('.')}");
    Console.WriteLine($"char.IsPunctuation(','): {char.IsPunctuation(',')}");
    Console.WriteLine($"char.IsPunctuation('A'): {char.IsPunctuation('A')}");
    Console.WriteLine($"char.MinValue: {char.MinValue}");
    Console.WriteLine($"char.MaxValue): {char.MaxValue}");

    char fiveChar = char.Parse("5");
    Console.WriteLine(fiveChar);
    int fiveCharAsInt = fiveChar; // Danger not the value 5 but the code for 5
    Console.WriteLine(fiveCharAsInt);
    int fiveCharAsIntCorrect = int.Parse(fiveChar.ToString());
    Console.WriteLine(fiveCharAsIntCorrect);

    // Special Characters
    char tab = '\t';
    Console.WriteLine($"Tab: {tab} = {char.IsControl(tab)}");
    char newLine = '\n';
    Console.WriteLine($"New line: {newLine} = {char.IsControl(newLine)}");
    char quotes = '\"';
    Console.WriteLine($"Quotes: {quotes} = {char.IsControl(quotes)}");
    char SingleQuotes = '\'';
    Console.WriteLine($"Single Quotes: {SingleQuotes} - {char.IsControl(SingleQuotes)}");

    PrintAllChars();
  }

  public static void PrintAllChars()
  {
    int charCount = 0;
    for (char c = char.MinValue; c < char.MaxValue; c++)
    {
      if (!char.IsControl(c))
      {
        Console.Write(c);
      }
      charCount++;
    }
    Console.WriteLine($"\nChar count: {charCount}");
  }
}