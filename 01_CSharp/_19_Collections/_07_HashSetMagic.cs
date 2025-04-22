using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using Exceptions;

namespace Collections;

public class HashSetMagicApp
{
    public static void Main()
    {
        const int ENTRY_COUNT = 10_000_000;
        const int LOOKUP_COUNT = 10_000;
        const int RANDOM_STRING_LENGTH = 10;
        var random = new Random();

        // Generate random strings
        var entries = new List<string>();
        for (int i = 0; i < ENTRY_COUNT; i++)
        {
            entries.Add(RandomString(random, RANDOM_STRING_LENGTH));
        }

        // Add entries to List
        var list = new List<string>(entries);

        // Add to HAshSet
        var hashSet = new HashSet<string>(entries);

        // Randomly pick strings to search for
        var lookupStrings = new List<string>();
        for (int i = 0; i < LOOKUP_COUNT; i++)
        {
            lookupStrings.Add(entries[random.Next(ENTRY_COUNT)]);
        }

        // Searching in the List
        var stopwatch = Stopwatch.StartNew();
        int listContainsCounter = 0;
        foreach (var item in lookupStrings)
        {
            if (list.Contains(item))
            {
                listContainsCounter++;
            }
        }
        stopwatch.Stop();
        Console.WriteLine($"List: Count = {listContainsCounter}; time: {stopwatch.ElapsedMilliseconds} ms");

        // Searching in the HashSet
        stopwatch.Restart();
        int hashCountainsCount = 0;
        foreach (var item in lookupStrings)
        {
            if (hashSet.Contains(item))
            {
                hashCountainsCount++;
            }
        }
        stopwatch.Stop();
        Console.WriteLine($"HashSet: Count = {hashCountainsCount}; time: {stopwatch.ElapsedMilliseconds} ms");
    }

    static string RandomString(Random random, int length)
    {
        const string chars = "ABCDEFGHIJKLMNOPQRSTUVWXYZabcdefghijklmnopqrstuvwxyz0123456789";
        return new string(Enumerable.Repeat(chars, length).Select(s => s[random.Next(s.Length)]).ToArray());
    }
}
