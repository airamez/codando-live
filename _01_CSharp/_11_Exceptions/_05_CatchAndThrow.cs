using System;
/*
 */

namespace Exceptions;

public class CatchAndThrowApp
{
  public static void Main(string[] args)
  {
    try
    {
      MyMethod1();
    }
    catch (Exception ex)
    {
      Console.WriteLine(ex);
      Console.WriteLine("".PadLeft(150, '='));
    }
    try
    {
      MyMethod2();
    }
    catch (Exception ex)
    {
      Console.WriteLine(ex);
      Console.WriteLine("".PadLeft(150, '='));
    }
  }

  public static void MyMethod1()
  {
    try
    {
      MyMethodWithException();
    }
    catch (Exception ex)
    {
      Console.WriteLine($"Metyhod 1: {ex}");
      Console.WriteLine("".PadLeft(150, '='));
      throw;
    }
  }

  public static void MyMethod2()
  {
    try
    {
      MyMethodWithException();
    }
    catch (Exception ex)
    {
      Console.WriteLine($"Metyhod 2: {ex}");
      Console.WriteLine("".PadLeft(150, '='));
      throw new Exception(ex.Message);
    }
  }

  public static void MyMethodWithException()
  {
    throw new Exception("My Method with Exception");
  }
}