// https://learn.microsoft.com/en-us/dotnet/framework/data/adonet/local-transactions
using System;
using Microsoft.Data.SqlClient;

namespace ADO.NET.DataAccess;

public class TransactionApp
{
  public static void Main(string[] args)
  {
    BankAccountService bankService = new BankAccountService();
    while (true)
    {
      /*
       * Note: Remember to show how a hacker could exploit using acccount IDs that don't exist
       */
      try
      {
        Console.Write("From Account ID: ");
        int sourceId = int.Parse(Console.ReadLine());
        if (sourceId == 0) break;

        Console.Write("  To Account ID: ");
        int targetId = int.Parse(Console.ReadLine());

        Console.Write("         Amount: ");
        decimal amount = decimal.Parse(Console.ReadLine());

        bankService.TransferFull(sourceId, targetId, amount);
        Console.WriteLine("Transfer completed");
      }
      catch (Exception ex)
      {
        Console.WriteLine($"Error: {ex.Message}");
      }
    }
  }
}

public class BankAccountService
{

  public void Debit(int accountId, decimal amount,
                    SqlConnection connection,
                    SqlTransaction transaction)
  {
    string sql = "UPDATE Account SET amount = amount - @Amount WHERE id = @AccountId";
    using (SqlCommand command = new SqlCommand(sql, connection, transaction))
    {
      command.Parameters.AddWithValue("@Amount", amount);
      command.Parameters.AddWithValue("@AccountId", accountId);
      // This fixes the security issue when account id does not exist
      if (command.ExecuteNonQuery() == 0)
      {
        throw new Exception($"Account ID not found: {accountId}");
      }
    }
  }

  public void Credit(int accountId, decimal amount,
                    SqlConnection connection,
                    SqlTransaction transaction)
  {
    string sql = "UPDATE Account SET amount = amount + @Amount WHERE id = @AccountId";
    using (SqlCommand command = new SqlCommand(sql, connection, transaction))
    {
      command.Parameters.AddWithValue("@Amount", amount);
      command.Parameters.AddWithValue("@AccountId", accountId);
      // This fixes the security issue when account id does not exist
      if (command.ExecuteNonQuery() == 0)
      {
        throw new Exception($"Account ID not found: {accountId}");
      }
    }
  }

  public void Transfer(int sourceId, int targetId, decimal amount)
  {
    using (var connection = new SqlConnection(ConnectionString.GetConnectionString()))
    {
      connection.Open();
      using (SqlTransaction transaction = connection.BeginTransaction())
      {
        try
        {
          Debit(sourceId, amount, connection, transaction);

          //Simulating a connection issue
          Random random = new Random();
          if (random.Next(4) == 3)
          {
            throw new Exception("Connection Lost");
          }

          Credit(targetId, amount, connection, transaction);
          transaction.Commit();
          Console.WriteLine("Transfer completed");
        }
        catch (Exception)
        {
          transaction.Rollback();
          throw;
        }
      }
    }
  }

  public void TransferFull(int sourceId, int targetId, decimal amount)
  {
    using (var connection = new SqlConnection(ConnectionString.GetConnectionString()))
    {
      connection.Open();
      using (SqlTransaction transaction = connection.BeginTransaction())
      {
        try
        {
          // Check Balance
          string balanceQuery = "SELECT Amount from Account WHERE id = @AccountId";
          using (SqlCommand balanceCommand = new SqlCommand(balanceQuery, connection, transaction))
          {
            balanceCommand.Parameters.AddWithValue("@AccountId", sourceId);
            var result = balanceCommand.ExecuteScalar();
            // Note: Explain this and show that amount is not null
            if (result == null || result == DBNull.Value)
            {
              throw new Exception($"Source Account ID not found: {sourceId}");
            }
            decimal balance = (decimal)result;
            if (amount > balance)
            {
              throw new Exception($"Insufficient balance in source account: Id={sourceId}; Balance={balance}; Amount={amount}");
            }
          }
          // Credit
          string sqlDebit = "UPDATE Account SET amount = amount - @Amount WHERE id = @AccountId";
          using (SqlCommand debitCommand = new SqlCommand(sqlDebit, connection, transaction))
          {
            debitCommand.Parameters.AddWithValue("@Amount", amount);
            debitCommand.Parameters.AddWithValue("@AccountId", sourceId);
            if (debitCommand.ExecuteNonQuery() == 0)
            {
              throw new Exception($"Source Account ID not found: {sourceId}");
            }
          }
          // Debit
          string sqlCredit = "UPDATE Account SET amount = amount + @Amount WHERE id = @AccountId";
          using (SqlCommand creditCommand = new SqlCommand(sqlCredit, connection, transaction))
          {
            creditCommand.Parameters.AddWithValue("@Amount", amount);
            creditCommand.Parameters.AddWithValue("@AccountId", targetId);
            if (creditCommand.ExecuteNonQuery() == 0)
            {
              throw new Exception($"Target Account ID not found: {targetId}");
            }
          }
          transaction.Commit();
        }
        catch (Exception)
        {
          transaction.Rollback();
          throw;
        }
      }
    }
  }
}
