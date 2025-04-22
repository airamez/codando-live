using System;

public class OO_Demo
{
  public static void Main(string[] args)
  {
    Account account1 = new Account("ACC001");
    account1.Deposit(500);
    account1.Withdraw(200);
    Console.WriteLine($"Account #: {account1.GetNumber()}");
    Console.WriteLine($"Balance: {account1.GetBalance()}");

    Account account2 = new Account("ACC02", 1500);
    Console.WriteLine($"Account #: {account2.GetNumber()}");
    Console.WriteLine($"Balance: {account2.GetBalance()}");

    Account[] accounts = new Account[10];
    Random random = new Random();
    for (int i = 0; i < accounts.Length; i++)
    {
      accounts[i] = new Account($"ACC{i}", random.Next(1000, 2001));
      accounts[i].Print();
    }

    Account account3 = new Account(null);
    account3.Deposit(2000);
  }
}

public class Account
{
  private double balance;
  private string number;

  public Account(string number)
  {
    if (string.IsNullOrWhiteSpace(number))
    {
      throw new Exception("Invalide Account Number");
    }
    SetNumber(number);
  }

  public Account(string number, double initialDeposit)
  {
    SetNumber(number);
    Deposit(initialDeposit);
  }

  public double GetBalance()
  {
    return balance;
  }

  public void SetNumber(string newNumber)
  {
    number = newNumber;
  }

  public string GetNumber()
  {
    return number;
  }

  public void Deposit(double value)
  {
    balance += value;
  }

  public void Withdraw(double value)
  {
    if (value < balance)
    {
      balance -= value;
    }
  }

  public void Print()
  {
    Console.WriteLine($"Account #: {GetNumber()}");
    Console.WriteLine($"Balance: {GetBalance()}");
  }
}