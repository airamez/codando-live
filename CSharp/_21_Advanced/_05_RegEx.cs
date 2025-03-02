/*
- https://en.wikipedia.org/wiki/Regular_expression
- https://learn.microsoft.com/en-us/dotnet/api/system.text.regularexpressions.regex?view=net-9.0
- Regular Expressions (Regex) are powerful tools for pattern matching and text processing. 
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
    // Validate phone
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

    // Highlight Groups and Captures
    string datePattern = @"(\d{4})-(\d{2})-(\d{2})"; // yyyy-MM-dd format
    string dateInput = "Today's date is 2025-03-01.";
    Match dateMatch = Regex.Match(dateInput, datePattern);
    if (dateMatch.Success)
    {
      Console.WriteLine("Year: " + dateMatch.Groups[1].Value);
      Console.WriteLine("Month: " + dateMatch.Groups[2].Value);
      Console.WriteLine("Day: " + dateMatch.Groups[3].Value);
    }

    // Replace
    string inputText = "Contact: (123)456-7890, Email: user@example.com, Alternate: (987)654-3210, michael.scott@dundermifflin.com";
    // Mask phone numbers
    string maskedText = Regex.Replace(inputText, phonePattern, "***-***-****");
    // Mask email addresses
    maskedText = Regex.Replace(maskedText, emailPattern, "hidden@email.com");
    Console.WriteLine("Masked: " + maskedText);

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

    // Homework: extract all phone numbers witht the format (999)999-9999
  }

  private static string input = @"
    Contact: michael.scott@dundermifflin.com, Phone: (123)456-7890
    Email: pam.beesly@office.net
    Call me at (987)654-3210
    dwight.schrute@beetsandbears.org (555)123-4567
    Random text here, not a number or email!
    Email: stanley.hudson@workplace.com
    Numbers: 1010101010, (333)444-5555
    meredith.palmer@@oops-wrong-email-format
    (666)777-8888 creed.bratton@whoami.com
    Here’s a number: (999)888-7777 and an email: angela@catlover.com
    Call (444)555-6666 for details.
    oscar@accounting.net, (222)333-4444
    Note: This isn't relevant: [Insert some other content here].
    kelly.kapoor@dundermifflin.com, text (777)999-8888.
    Invalid email: notanemail@.com or missingnumberhere (78)870-234
    ";
}