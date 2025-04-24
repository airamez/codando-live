using System;
using OurCompany;

public class ParameterOutput
{

  public static void Main(string[] args)
  {
    int dividend = Library.ReadInteger("Dividend");
    int divisor = Library.ReadInteger("Divisor");
    int quocient;
    int remainder;
    Library.IntDivision(dividend, divisor, out quocient, out remainder);
    // We could about declaring the out variable by providing the type on the
    // routine call
    //  Library.IntDivision(dividend, divisor, out int quocient, out int remainder);
    Console.Write($"{dividend}/{divisor} => ");
    Console.WriteLine($"Quocient = {quocient}; Remainder = {remainder} ");
  }
}