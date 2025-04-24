using System;

namespace MyBankTest;

public class BankAccount
{
  private decimal balance;
  private string id;
  public string CustomerName { get; set; }

  public string ID
  {
    get
    {
      return id;
    }
  }

  public decimal Balance
  {
    get
    {
      return balance;
    }
  }

  public BankAccount(string id, decimal initialBalance)
  {
    balance = initialBalance;
  }

  public void Deposit(decimal ammount)
  {
    if (ammount <= 0)
    {
      throw new Exception("Amount has to be a positive value");
    }
    balance += ammount;
  }

  public void Withdraw(decimal amount)
  {
    if (amount <= 0)
    {
      throw new Exception("Amount has to be a positive value");
    }
    if (amount > balance)
    {
      throw new Exception("Amount has to be less or equal than balance");
    }
    balance -= amount;
  }
}