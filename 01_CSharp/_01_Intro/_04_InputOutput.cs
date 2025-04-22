/*
- Console Class
  - https://learn.microsoft.com/en-us/dotnet/api/system.console?view=net-7.0
- Input/Read
- Output/Write
- Casting
  - https://learn.microsoft.com/en-us/dotnet/csharp/programming-guide/types/casting-and-type-conversions
- Convertion
  - https://learn.microsoft.com/en-us/dotnet/api/system.convert?view=net-7.0
- String interpolation
  - https://learn.microsoft.com/en-us/dotnet/csharp/language-reference/tokens/interpolated
 */
using System;
class IO
{
  public static void Main(string[] args)
  {
    Console.Write("Name: ");
    string userName = Console.ReadLine();
    Console.Write("Olá ");
    Console.WriteLine(userName);
    int i = 45675657;
    long l = Int64.MaxValue;
    i = (int)l;
    Console.Write("Name: ");
    string name = Console.ReadLine();
    Console.Write("Age: ");
    string ageAsString = Console.ReadLine();
    int age = Convert.ToInt16(ageAsString);
    //string message = "Hello " + name + " your age is " + age + ".";
    string message = $"Hello {name} your age is {age}.";
    Console.WriteLine(message);
  }
}