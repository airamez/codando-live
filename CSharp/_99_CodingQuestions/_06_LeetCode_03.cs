// https://leetcode.com/problems/longest-substring-without-repeating-characters

using System;
using System.Collections.Generic;
using System.Diagnostics;

namespace CodingQuestions;

public class LeetCode_03
{
  public int LengthOfLongestSubstring(string s)
  {
    if (s == null || s.Length == 0)
    {
      return 0;
    }
    if (s.Length == 1)
    {
      return 1;
    }
    int i = 0;
    var dict = new Dictionary<char, int>();
    int maxLength = 0;
    while (i < s.Length)
    {
      char character = s[i];
      if (dict.ContainsKey(character))
      {
        i = dict[character] + 1;
        dict.Clear();
      }
      dict[s[i]] = i;
      maxLength = Math.Max(maxLength, dict.Count);
      i++;
    }
    return maxLength;
  }
}