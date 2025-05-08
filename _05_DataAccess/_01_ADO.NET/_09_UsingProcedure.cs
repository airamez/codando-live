// https://learn.microsoft.com/en-us/dotnet/api/system.transactions.transactionscope?view=net-9.0
using System;
using System.Data;
using Microsoft.Data.SqlClient;

namespace ADO.NET.DataAccess;

public class UsingProcedureApp
{
  public static void Main(string[] args)
  {
    BankAccountServiceWithProcedure accountService = new BankAccountServiceWithProcedure();

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
        Console.WriteLine("Transfer completed!");
      }
      catch (Exception ex)
      {
        Console.WriteLine($"Error: {ex.Message}");
      }
    }
  }
}

public class BankAccountServiceWithProcedure
{
  public void Transfer(int sourceId, int targetId, decimal amount)
  {
    using (var connection = new SqlConnection(ConnectionString.GetConnectionString()))
    {
      connection.Open();
      using (SqlCommand command = new SqlCommand("[dbo].[TransferAmount]", connection))
      {
        command.CommandType = CommandType.StoredProcedure;
        command.Parameters.AddWithValue("@SourceAccountId", sourceId);
        command.Parameters.AddWithValue("@TargetAccountId", targetId);
        command.Parameters.AddWithValue("@Amount", amount);
        command.ExecuteNonQuery();
      }
    }
  }
}
