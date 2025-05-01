// https://learn.microsoft.com/en-us/dotnet/framework/data/adonet/local-transactions
using System;
using System.Transactions;
using Microsoft.Data.SqlClient;

namespace ADO.NET.DataAcces;

public class TransactionWithScopeApp
{
  public static void Main(string[] args)
  {
    BankAccountServiceWithScope bankService = new BankAccountServiceWithScope();
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

        bankService.Transfer(sourceId, targetId, amount);
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
        connection.Open();
        try
        {
          Debit(sourceId, amount, connection);

          // Simulating a connection issue
          Random random = new Random();
          if (random.Next(4) == 3)
          {
            throw new Exception("Connection Lost");
          }

          Credit(targetId, amount, connection);
          transactionScope.Complete();
          Console.WriteLine("Transfer completed!");
        }
        catch (Exception ex)
        {
          Console.WriteLine(ex.Message);
        }
      }
    }
  }
  public void Debit(int accountId, decimal amount, SqlConnection connection)
  {
    string sql = "UPDATE Account SET amount = amount - @Amount WHERE id = @AccountId";
    using (SqlCommand command = new SqlCommand(sql, connection))
    {
      command.Parameters.AddWithValue("@Amount", amount);
      command.Parameters.AddWithValue("@AccountId", accountId);
      command.ExecuteNonQuery();
    }
  }

  public void Credit(int accountId, decimal amount, SqlConnection connection)
  {
    string sql = "UPDATE Account SET amount = amount + @Amount WHERE id = @AccountId";
    using (SqlCommand command = new SqlCommand(sql, connection))
    {
      command.Parameters.AddWithValue("@Amount", amount);
      command.Parameters.AddWithValue("@AccountId", accountId);
      command.ExecuteNonQuery();
    }
  }
}
