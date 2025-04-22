/*
 * Object-oriented programming (OOP) is a programming paradigm that relies on the concept of classes and objects.
 * It is used to structure a software program into simple, reusable pieces of code blueprints (usually called classes),
   which are used to create individual instances of objects.
 * OOP is a popular programming paradigm used for software development.
 */

using System;

public class OO_Intro
{

  static double balance = 0;

  public static void Main(string[] args)
  {
    Console.WriteLine($"Balance: {balance}");
    Deposit(100);
    Console.WriteLine($"Balance: {balance}");
    Deposit(100);
    Console.WriteLine($"Balance: {balance}");
    Withdraw(75);
    Console.WriteLine($"Balance: {balance}");
    Withdraw(350);
    Console.WriteLine($"Balance: {balance}");
    balance = 1000000;
    Console.WriteLine($"Balance: {balance}");
  }

  public static void Deposit(double value)
  {
    balance += value;
  }

  public static void Withdraw(double value)
  {
    if (value < balance)
    {
      balance -= value;
    }
  }
}