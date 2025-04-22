using System;
using OurCompany;

public class ParameterDefault
{

  public static void Main(string[] args)
  {
    int number1 = Library.ReadInteger("Number 1", ":");
    int number2 = Library.ReadInteger("Number 2", "=>");
    int number3 = Library.ReadInteger("Number 3", "=");
    int number4 = Library.ReadInteger("Number 4");
    int number5 = Library.ReadInteger("Number 5");
    int number6 = Library.ReadInteger();
  }
}