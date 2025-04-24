// https://leetcode.com/problems/word-break/
using System;
using System.Collections.Generic;
using System.Text;

namespace CodingQuestions;
public class LeetCode_139
{
    static void Main(string[] args)
    {
        string s = "leetcode";
        List<string> wordDict = ["leet", "code"];
        var app = new LeetCode_139();
        Console.WriteLine(app.WordBreak(s, wordDict));

        s = "catsandog";
        wordDict = ["cats", "dog", "sand", "and", "cat"];
        Console.WriteLine(app.WordBreak(s, wordDict));
    }

    public bool WordBreak(string s, IList<string> wordDict)
    {
        var wordSet = new HashSet<string>(wordDict);
        int maxLength = 0;
        foreach (var word in wordDict)
        {
            maxLength = Math.Max(maxLength, word.Length);
        }
        bool[] dp = new bool[s.Length + 1];
        dp[0] = true;
        for (int i = 0; i < s.Length; i++)
        {
            StringBuilder currentWord = new StringBuilder();
            int index = i;
            while (index >= 0 && i - index < maxLength)
            {
                currentWord.Insert(0, s[index]);
                if (wordDict.Contains(currentWord.ToString()))
                {
                    dp[i + 1] = dp[index];
                }
                index--;
            }
        }
        return dp[dp.Length - 1];
    }
}
