// https://learn.microsoft.com/en-us/dotnet/framework/data/adonet/local-transactions
using System;
using Microsoft.Data.SqlClient;

namespace ADO.NET.DataAcces;

public class TransactionApp
{
  public static void Main(string[] args)
  {
    BankAccountService bankService = new BankAccountService();
    while (true)
    {
      // Note: Remember to show how a hacker could create money using this design

      try
      {
        Console.Write("From Account ID: ");
        int sourceId = int.Parse(Console.ReadLine());
        if (sourceId == 0) break;

        Console.Write("To Account ID: ");
        int targetId = int.Parse(Console.ReadLine());

        Console.Write("Amount: ");
        decimal amount = decimal.Parse(Console.ReadLine());

        bankService.Transfer(sourceId, targetId, amount);
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
  public BankAccountService()
  {
  }

  public void Debit(int accountId, decimal amount,
                    SqlConnection connection,
                    SqlTransaction transaction)
  {
    string sql = "UPDATE Account SET amount = amount - @Amount WHERE id = @AccountId";
    using (SqlCommand command = new SqlCommand(sql, connection, transaction))
    {
      command.Parameters.AddWithValue("@Amount", amount);
      command.Parameters.AddWithValue("@AccountId", accountId);
      command.ExecuteNonQuery();
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
      command.ExecuteNonQuery();
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

          // Simulating a connection issue
          Random random = new Random();
          if (random.Next(4) == 3)
          {
            throw new Exception("Connection Lost");
          }

          Credit(targetId, amount, connection, transaction);
          transaction.Commit();
          Console.WriteLine("Transfer completed");
        }
        catch (Exception ex)
        {
          Console.WriteLine(ex.Message);
          transaction.Rollback();
        }
      }
    }
  }
}
