// https://leetcode.com/problems/two-sum

using System;
using System.Collections.Generic;
using System.Diagnostics;

namespace CodingQuestions;

public class LeetCode_01
{
  public static void Main(string[] args)
  {
    const int LENGTH = 1_000_000_000;
    Random rnd = new Random();

    var app = new LeetCode_01();

    int[] input = app.GenerateArray(rnd, LENGTH);
    int target = rnd.Next(2 * LENGTH);
    Console.WriteLine($"Target = {target}");

    Stopwatch stopwatch = new Stopwatch();

    stopwatch.Start();
    int[] ouput1 = app.TwoSumSlow(input, target);
    stopwatch.Stop();
    Console.WriteLine($"{stopwatch.ElapsedMilliseconds} ms");

    stopwatch.Restart();
    int[] ouput2 = app.TwoSumFast(input, target);
    stopwatch.Stop();
    Console.WriteLine($"{stopwatch.ElapsedMilliseconds} ms");

    if (ouput1 == null)
    {
      Console.WriteLine($"The sum {target} not found ");
    }
    else
    {
      Console.WriteLine($"The sum was found {ouput1[0]}:{ouput1[1]}");
    }
    if (ouput2 == null)
    {
      Console.WriteLine($"The sum {target} not found ");
    }
    else
    {
      Console.WriteLine($"The sum was found {ouput2[0]}:{ouput2[1]}");
    }
  }

  public int[] GenerateArray(Random rnd, int length)
  {
    var input = new int[length];
    for (int i = 0; i < length; i++)
    {
      input[i] = rnd.Next(length);
    }
    return input;
  }

  public int[] TwoSumFast(int[] nums, int target)
  {
    var dict = new Dictionary<int, int>();
    for (int i = 0; i < nums.Length; i++)
    {
      var expectedValue = target - nums[i];
      if (dict.ContainsKey(expectedValue))
      {
        return new int[] { dict[expectedValue], i };
      }
      dict[nums[i]] = i;
    }
    return null;
  }

  public int[] TwoSumSlow(int[] nums, int target)
  {
    for (int i = 0; i < nums.Length; i++)
    {
      for (int j = i + 1; j < nums.Length; j++)
      {
        if (nums[i] + nums[j] == target)
        {
          return new int[] { i, j };
        }
      }
    }
    return null;
  }
}