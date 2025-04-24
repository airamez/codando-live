using System;
using OurCompany;

public class ParameterNamed
{

  public static void Main(string[] args)
  {
    int integer_1 = 1;
    int integer_2 = 2;
    string string_1 = "I am string 1";
    string string_2 = "I am string 2";
    MyRoutine(integer_1, integer_2, string_1, string_2);
    MyRoutine(integer_2, integer_1, string_2, string_1);
    MyRoutine(str1: string_1,
              str2: string_2,
              int1: integer_1,
              int2: integer_2);
    MyRoutine(str2: string_2,
              str1: string_1,
              int2: integer_2,
              int1: integer_1);
    MyRoutine(str1: "STR 1", int1: 1,
              str2: "STR 2", int2: 2);
    MyRoutine(int1: 1, str1: "STR 1",
              int2: 2, str2: "STR 2");
    // Not recommended partial use
    MyRoutine(1, 2,
              str1: "STR 1",
              str2: "STR 2");
    MyRoutine(1, str1: "STR 1",
              int2: 2, str2: "STR 2");
    MyRoutine(1, 2,
              str2: "STR 2",
              str1: "STR 1");
    MyRoutine(int1: 1, 2,
              "STR 1",
              str2: "STR 2");
  }

  public static void MyRoutine(int int1, int int2, string str1, string str2)
  {
    Console.WriteLine($"[{int1}: {str1}; {int2}: {str2}]");
  }
}