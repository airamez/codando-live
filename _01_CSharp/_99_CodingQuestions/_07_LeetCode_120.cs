
// https://leetcode.com/problems/triangle/
using System;
using System.Collections.Generic;
using System.Linq;

namespace CodingQuestions;

public class LeetCode_120
{
  public static void Main(string[] args)
  {
    var input = new List<IList<int>>
    {
      new List<int>(      [2]      ),
      new List<int>(    [3 , 4]    ),
      new List<int>(  [6 , 5 , 7]  ),
      new List<int>([4 , 1 , 8 , 3])
    };

    var app = new LeetCode_120();
    Console.WriteLine(app.MinimumTotal(input));
  }

  public int MinimumTotal(IList<IList<int>> triangle)
  {
    var dp = new List<List<int?>>();
    for (int i = 0; i < triangle.Count; i++)
    {
      dp.Add(new List<int?>());
      for (int j = 0; j < triangle[i].Count; j++)
      {
        dp.Last().Add(null);
      }
    }
    dp[0][0] = triangle[0][0];
    for (int row = 0; row < triangle.Count - 1; row++)
    {
      for (int rowIndex = 0; rowIndex < triangle[row].Count; rowIndex++)
      {
        int leftSum = dp[row][rowIndex].Value + triangle[row + 1][rowIndex];
        int rightSum = dp[row][rowIndex].Value + triangle[row + 1][rowIndex + 1];
        if (dp[row + 1][rowIndex] == null)
        {
          dp[row + 1][rowIndex] = leftSum;
        }
        else
        {
          dp[row + 1][rowIndex] = Math.Min(dp[row + 1][rowIndex].Value, leftSum);
        }
        if (dp[row + 1][rowIndex + 1] == null)
        {
          dp[row + 1][rowIndex + 1] = rightSum;
        }
        else
        {
          dp[row + 1][rowIndex + 1] = Math.Min(dp[row + 1][rowIndex].Value, rightSum);
        }
      }
    }
    int result = int.MaxValue;
    foreach (var sum in dp.Last())
    {
      result = Math.Min(result, sum.Value);
    }
    return result;
  }
}