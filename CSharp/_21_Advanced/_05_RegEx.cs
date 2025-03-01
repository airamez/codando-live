/*
- Regular Expressions (Regex) in C# are powerful tools for pattern matching and text processing. 
- They allow you to search, extract, and manipulate strings efficiently. 
- The System.Text.RegularExpressions namespace provides the Regex class to work with regular expressions.
- Common Regex Patterns
  \d    : Matches any digit (0-9)
  \w    : Matches any word character (a-z, A-Z, 0-9, _)
  \s    : Matches any whitespace character
  .     : Matches any character except newline
  ^     : Matches the start of a string
  $     : Matches the end of a string
  *     : Matches zero or more occurrences of the preceding element
  +     : Matches one or more occurrences
  ?     : Matches zero or one occurrence
  {n,m} : Matches at least n and at most m occurrences
  |     : OR operator
  ()    : Grouping
  []    : Character class
*/

using System;
using System.Text.RegularExpressions;

namespace Advanced;

public class RegExApp
{
  public static void Main(string[] args)
  {

    // Phone number pattern
    string phonePattern = @"\(\d{3}\)\d{3}-\d{4}";
    Match phoneMatch = Regex.Match("(123)456-7890", phonePattern);
    Console.WriteLine(phoneMatch.Success);
    phoneMatch = Regex.Match("(12A)457-7890", phonePattern);
    Console.WriteLine(phoneMatch.Success);

    // Validate Email
    string emailPattern = @"[a-zA-Z0-9._%+-]+@[a-zA-Z0-9.-]+\.[a-zA-Z]{2,}";
    string emailToValidate = "user@example.com";
    bool isValidEmail = Regex.IsMatch(emailToValidate, emailPattern);
    Console.WriteLine("Is valid email: " + isValidEmail);

    emailToValidate = "userexample.com";
    isValidEmail = Regex.IsMatch(emailToValidate, emailPattern);
    Console.WriteLine("Is valid email: " + isValidEmail);


    string input =
    @"My email is example@test.com and my phone is (123)456-7890.
      I know someone with the email jordan@nba.com and his phone us (023)0230-2323
      This is another email scotch.pipens@nba.com => (011)0110-1111
    ";

    // Match
    Match emailMatch = Regex.Match(input, emailPattern);
    if (emailMatch.Success)
    {
      Console.WriteLine("Email found: " + emailMatch.Value);
    }
    // Matches
    MatchCollection emailMatches = Regex.Matches(input, emailPattern);
    foreach (Match email in emailMatches)
    {
      Console.WriteLine(email);
    }
  }
}