using System;

/*
String is the most common data type in Information System
Documentation: https://learn.microsoft.com/en-us/dotnet/api/system.string?view=net-8.0
C# Strings:
 - Read-only (immutable) collection of sequential Char objects
 - The length of the string is stored in the property Length
 - All methods "modifying" a string, return a new string
 - We can access elements of a string as an array: myString[index]
*/

public class _02_String
{
  public static void Main(string[] args)
  {
    // Creating an alias for print
    Action<string> print = Console.WriteLine;

    /*
     * Special Characters
     * \t = tab
     * \n = new line
     * \" = "
     * \\ = \
     */
    string specialChars = "I\tlove\tCoding\nThis is a double quotes: \"\nThis is a backslash: \\";
    print(specialChars);

    string myString = "  I love to code  ";
    print($"myString[2]: {myString[2]}");
    print($"myString[4]: {myString[4]}");

    print($"Length: {myString.Length}");
    print($"ToUpper: {myString.ToUpper()}");
    print($"ToLower: {myString.ToLower()}");
    print($"Substring(2, 6): {myString.Substring(2, 6)}");
    print($"Substring(9): {myString.Substring(9)}");
    print($"Replace('o', '0'): {myString.Replace('o', '0')}");
    print($"Replace(\"love\", \"enjoy\"): {myString.Replace("love", "enjoy")}");
    print($"IndexOf('o'): {myString.IndexOf('o')}");
    print($"IndexOf('x'): {myString.IndexOf('x')}");
    print($"LastIndexOf('o'): {myString.LastIndexOf('o')}");
    print($"Contains('love'): {myString.Contains("love")}");
    print($"StartsWith('I'): {myString.StartsWith("  I")}");
    print($"EndsWith('code'): {myString.EndsWith("code  ")}");
    print($"Trim(): {myString.Trim()}");
    print($"TrimStart('I'): {myString.TrimStart(' ')}");
    print($"TrimEnd('e'): {myString.TrimEnd(' ')}");
    print($"PadLeft(20, '-'): {myString.PadLeft(30, '-')}");
    print($"PadRight(20, '-'): {myString.PadRight(30, '-')}");
    print($"\"\".PadLeft(20,'-'): {"".PadLeft(20, '-')}");
    print($"IsNullOrEmpty(null): {string.IsNullOrEmpty(null)}");
    print($"IsNullOrEmpty(\"\"): {string.IsNullOrEmpty("")}");
    print($"IsNullOrEmpty(\" \"): {string.IsNullOrEmpty(" ")}");
    print($"IsNullOrWhiteSpace(null): {string.IsNullOrWhiteSpace(null)}");
    print($"IsNullOrWhiteSpace(\"\"): {string.IsNullOrWhiteSpace("")}");
    print($"IsNullOrWhiteSpace(\" \"): {string.IsNullOrWhiteSpace(" ")}");
    print($"Insert(4, \"do \"): {myString.Insert(4, "do ")}");
    print($"Remove(3, 8): {myString.Remove(3, 8)}");
    print($"Clone(): {myString.Clone()}");

    // Empty String
    string myEmptyString = string.Empty;
    print($"string.Empty: {myEmptyString}");

    // To Array
    char[] charArray = myString.ToCharArray();
    print($"ToCharArray()");
    for (int i = 0; i < charArray.Length; i++)
    {
      print($"charArray[{i}]: {charArray[i]}");
    }
    print($"ToCharArray(2, 10): {string.Join("\n", myString.ToCharArray(2, 10))}");

    string str1 = "I";
    string str2 = "love";
    string str3 = "to";
    string str4 = "code";

    // Concat
    myString = string.Concat(str1, " ", str2, " ", str3, " ", str4);
    print($"string.Concat(str1, \" \", str2, \" \", str3, \" \", str4)): {myString}");

    // Join
    myString = string.Join('_', str1, str2, str3, str4);
    print($"string.Join('_', str1, str2, str3, str4)): {myString}");

    // Split
    string[] words = myString.Split('_');
    for (int i = 0; i < words.Length; i++)
    {
      print($"words[{i}]: {words[i]}");
    }

    // Comparing strings
    str1 = "Microsoft";
    str2 = "Microsoft";
    print($"str1: {str1}");
    print($"str2: {str2}");
    print($"str1 == str2: {str1 == str2}");
    print($"str1.Equals(str2): {str1.Equals(str2)}");

    // Differences between Lower/Upper case
    str2 = "microsoft";
    print($"str1: {str1}");
    print($"str2: {str2}");
    print($"str1 == str2: {str1 == str2}");
    print($"str1.Equals(str2): {str1.Equals(str2)}");

    // Comparing ignoring the case
    print($"str1.Equals(str2): {str1.Equals(str2, StringComparison.InvariantCultureIgnoreCase)}");

    // PLESSE, DON'T DO THIS:
    print($"str1.ToLower() == str2.ToLower(): {str1.ToLower() == str2.ToLower()}");

    // Multiline String
    string multiLineString = @"This is the first line
This is the second line
This is the third line";
    print(multiLineString);

    // Interpolation
    string firstName = "Jose";
    string lastName = "Santos";
    string email = "jose.santos@email.com";
    string phone = "+1(999)999-9999";
    string content = $"FullName: {firstName} {lastName}; Email: {email}; Phone: {phone} ";
    print(content);

    // Multiline + Interpolation
    content = $@"Full Name: {firstName} {lastName}
Email: {email}
Phone: {phone}";
    print(content);
  }
}