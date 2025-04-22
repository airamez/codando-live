/*
Definition of VARIABLE

Curiosity:
- How a computer stores data:
  - A number
    - Binary numbers
  - A letter/character
      - ASCII
      - Unicode
  - What about all different types of information?
    - Image
    - Sound
    - Video

Types
 Built-in or Primitive Types:
 - https://learn.microsoft.com/en-us/dotnet/csharp/language-reference/builtin-types/built-in-types
 - int
 - double
 - char
 - bool

 String:
 - https://learn.microsoft.com/en-us/dotnet/csharp/programming-guide/strings/
 - It is a class (Reference type)
 - It is immutable
 - Most used type

 Variable Declaration
   TYPE NAME

 Assignment
   NAME = VALUE or EXPRESSION

 */

using System;
class VariablesAndTypes
{
  public static void Main(string[] args)
  {
    int age = 50;
    Console.WriteLine(age);

    bool approved = true;
    Console.WriteLine(approved);

    double height = 1.95;
    Console.WriteLine(height);

    char c = 'Z';
    Console.WriteLine(c);

    string name = "Jose Maria";
    Console.WriteLine(name);
  }
}