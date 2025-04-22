using System;
/*
# It is possible to create custom exception to improve
  the "communication" with our API users
# The custom Exception need to extend Exception or
  a sub-class
# Usually implements the contructor receiving the message
  and invoke the same constructor from the base class
# The keywork throw raise an Exception: throw new Exception(msg)
# It is a good practic to document the possible exception:
  /// <summary>
  /// Method description.
  /// </summary>
  /// <param name="PARAM_1_NAME">Param 1 description</param>
  /// <param name="PARAM_2_NAME">Param 2 description</param>
  /// <returns>Return description</returns>
  /// <exception cref="EXCEPTION_CLASS">Exception description</exception>

# Class content:
  # Demo using an BankAccount class with Deposit and Withdraw operation
  # Create a InsuficientBalanceException
  # Raise a custom exception with insuficient funds on a Withdraw operation
  # Demo how to use it
 */

namespace Exceptions;

public class CustomExceptionApp
{
  public static void Main(string[] args)
  {
    try
    {
      BankAccount account1 = new BankAccount("ID001", 100);
      Console.WriteLine(account1);

      account1.Deposit(500);
      Console.WriteLine(account1);

      account1.Withdraw(300);
      Console.WriteLine(account1);

      try
      {
        account1.Withdraw(5000);
      }
      catch (InsuficientBalanceException ex)
      {
        Console.WriteLine(ex);
      }
      finally
      {
        Console.WriteLine(account1);
      }

      account1.Withdraw(50);
      Console.WriteLine(account1);

      account1.Withdraw(150);
      Console.WriteLine(account1);
    }
    catch (Exception ex)
    {
      Console.WriteLine(ex.Message);
    }
  }
}

public class BankAccount
{
  public string ID { get; set; }
  private double balance;
  public double Balance
  {
    get
    {
      return balance;
    }
  }

  public BankAccount(string id, double initialBalance = 0)
  {
    ID = id;
    balance = initialBalance;
  }

  public void Deposit(double amount)
  {
    balance += amount;
  }

  /// <summary>
  /// Withdraw the amount from the account balance
  /// </summary>
  /// <param name="amount">Withdraw amount</param>
  /// <exception cref="InsuficientBalanceException">Exception rasied if insuficient balance</exception>

  public void Withdraw(double amount)
  {

    if (amount > balance)
    {
      throw new InsuficientBalanceException($"Insuficient balance: Balance = {balance}; amount = {amount}");
    }
    balance -= amount;
  }

  public override string ToString()
  {
    return $"Account[ID: {ID}; Balance:{Balance}]";
  }
}

public class InsuficientBalanceException : Exception
{
  public InsuficientBalanceException(string message) : base(message)
  {
  }
}