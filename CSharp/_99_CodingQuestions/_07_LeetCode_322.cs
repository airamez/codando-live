
// https://leetcode.com/problems/coin-change/description
using System;
using System.Linq;

public class LeetCode_322
{
  public static void Main(string[] args)
  {
    int[] coins = [2, 3, 4, 5];
    Console.WriteLine(GetCoins(coins, 7));
    Console.WriteLine(GetCoins(coins, 3));
    Console.WriteLine(GetCoins(coins, 4));
    Console.WriteLine(GetCoins(coins, 5));
    Console.WriteLine(GetCoins(coins, 6));
    Console.WriteLine(GetCoins(coins, 15));
    Console.WriteLine(GetCoins(coins, 8));
    Console.WriteLine(GetCoins(coins, 11));
    Console.WriteLine(GetCoins(coins, 45));
    Console.WriteLine(GetCoins(coins, 46));
    Console.WriteLine(GetCoins(coins, 48));
    Console.WriteLine(GetCoins(coins, 46));
    Console.WriteLine(GetCoins(coins, 1));

  }

  private static int GetCoins(int[] coins, int amount)
  {
    /*
     * Array to store the min coins of all values from 0 to amount
     * Each position of the array has the min amount of coins for that amount
     * The index represents the partial amount and the value represents the min number of coins
     * If the amount is 11, the array will have 12 positions representing the values from 0 to 11
     */
    int[] amounts = new int[amount + 1];
    amounts[0] = 0; // For the value zero, 0 coins is needed
    for (int partialAmount = 1; partialAmount < amounts.Length; partialAmount++)
    {
      // Set the amount of coins for the current partial amount to 'infinite'
      amounts[partialAmount] = int.MaxValue;
      // Checks which coin
      foreach (int coin in coins)
      {
        // difference from the partial amount and the current coin
        int diff = partialAmount - coin;
        // Ignoring if the coind is greater than the partial amount or
        // there is no possible amount of coins for the difference
        if (coin <= partialAmount && amounts[diff] != int.MaxValue)
        {
          /*
           * Set the partial amount to the min
           * This is the heart of the DP because there are two cases
           * 1: The current array position already has the min amount of coins
           * 2: The minimal amount of coins is from diff amount + 1,
           *    where the + 1 means the current coin
           * In the first interaction dp[partialAmount] is alwats infinite      
           */
          amounts[partialAmount] = Math.Min(amounts[partialAmount], amounts[diff] + 1);
        }
      }
    }
    if (amounts.Last() == int.MaxValue)
    {
      return -1;
    }
    return amounts.Last();
  }
}