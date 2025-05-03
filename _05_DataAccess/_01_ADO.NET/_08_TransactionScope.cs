// https://learn.microsoft.com/en-us/dotnet/api/system.transactions.transactionscope?view=net-9.0
using System;
using System.Transactions;
using Microsoft.Data.SqlClient;

namespace ADO.NET.DataAcces;

public class TransactionScopeApp
{
  public static void Main(string[] args)
  {
    BankAccountServiceWithScope accountService = new BankAccountServiceWithScope();

    // Calling Debit and Credit directly
    accountService.Credit(1, 100);
    accountService.Debit(2, 200);

    try
    {
      accountService.Credit(99, 200);
    }
    catch (Exception ex)
    {
      Console.WriteLine(ex.Message);
    }

    while (true)
    {
      try
      {
        Console.Write("From Account ID: ");
        int sourceId = int.Parse(Console.ReadLine());
        if (sourceId == 0) break;

        Console.Write("  To Account ID: ");
        int targetId = int.Parse(Console.ReadLine());

        Console.Write("         Amount: ");
        decimal amount = decimal.Parse(Console.ReadLine());

        accountService.Transfer(sourceId, targetId, amount);
      }
      catch (Exception ex)
      {
        Console.WriteLine($"Error: {ex.Message}");
      }
    }
  }
}

public class BankAccountServiceWithScope
{
  public void Transfer(int sourceId, int targetId, decimal amount)
  {
    using (var transactionScope = new TransactionScope())
    {
      using (var connection = new SqlConnection(ConnectionString.GetConnectionString()))
      {
        Debit(sourceId, amount, connection);

        // Simulating a connection issue
        Random random = new();
        if (random.Next(4) == 3)
        {
          throw new Exception("Connection Lost");
        }

        Credit(targetId, amount, connection);
        transactionScope.Complete();
        Console.WriteLine("Transfer completed!");
      }
    }
  }

  public void Debit(int accountId, decimal amount, SqlConnection connection = null)
  {
    bool shouldClose = CheckConnection(ref connection);
    try
    {
      string sql = "UPDATE Account SET amount = amount - @Amount WHERE id = @AccountId";
      using (SqlCommand command = new SqlCommand(sql, connection))
      {
        command.Parameters.AddWithValue("@Amount", amount);
        command.Parameters.AddWithValue("@AccountId", accountId);
        if (command.ExecuteNonQuery() == 0)
        {
          throw new Exception($"Account ID not found: {accountId}");
        }
      }
    }
    finally
    {
      if (shouldClose)
      {
        connection.Close();
      }
    }
  }

  public void Credit(int accountId, decimal amount, SqlConnection connection = null)
  {
    bool shouldClose = CheckConnection(ref connection);
    try
    {
      string sql = "UPDATE Account SET amount = amount + @Amount WHERE id = @AccountId";
      using (SqlCommand command = new SqlCommand(sql, connection))
      {
        command.Parameters.AddWithValue("@Amount", amount);
        command.Parameters.AddWithValue("@AccountId", accountId);
        if (command.ExecuteNonQuery() == 0)
        {
          throw new Exception($"Account ID not found: {accountId}");
        }
      }
    }
    finally
    {
      if (shouldClose)
      {
        connection.Close();
      }
    }
  }

  private static bool CheckConnection(ref SqlConnection connection)
  {
    if (connection == null)
    {
      connection = new SqlConnection(ConnectionString.GetConnectionString());
    }
    if (connection.State == System.Data.ConnectionState.Closed)
    {
      connection.Open();
      return true;
    }
    return false;
  }
}
