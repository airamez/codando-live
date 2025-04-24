using System;
using System.Collections.Generic;
using System.Diagnostics;

namespace BigO;

public class BigO_2App
{
    // Remember to open the System Monitor
    public static void Main(string[] args)
    {
        var rnd = new Random();

        Console.WriteLine("Checking O(N)");
        for (int i = 0; i < 10; i++)
        {
            Check_O_N((int)Math.Pow(10, i), rnd);
        }
        Console.WriteLine("O(N) completed");

        Console.WriteLine("Checking O(N²)");
        for (int i = 0; i < 6; i++)
        {
            Check_O_N2((int)Math.Pow(10, i), rnd);
        }
        Console.WriteLine("O(N²) completed");

        // What is the Big O Notation?
        // Attention, it is a trick question
        var stopwatch = new Stopwatch();
        stopwatch.Start();
        long sum = 0;
        for (int i = 0; i < 1000; i++) // O(1) because all loops have a constant
        {
            for (int j = 0; j < 1000; j++)
            {
                for (int k = 0; k < 1000; k++)
                {
                    sum += i + j + k;
                }
            }
        }
        Console.WriteLine($"Sum: {sum}");
        stopwatch.Stop();
        Console.WriteLine($"Elapsed: {stopwatch.Elapsed}");
    }

    private static void Check_O_N(int N, Random rnd)
    {
        var stopwatch = new Stopwatch();
        Console.Write($"Elapsed time with {N:N0} operations:");
        var list = new List<int>();
        stopwatch.Start();
        for (int i = 0; i < N; i++)
        {
            list.Add(rnd.Next(N));
        }
        stopwatch.Stop();
        Console.WriteLine($"{stopwatch.Elapsed}");
    }

    private static void Check_O_N2(long N, Random rnd)
    {
        var stopwatch = new Stopwatch();
        Console.Write($"Elapsed time with {N:N0} operations:");
        var list = new List<long>();
        stopwatch.Start();
        for (int i = 0; i < N; i++)
        {
            list.Add(rnd.NextInt64(N));
        }
        // "Print" the sum from each index to the end of the list
        for (int i = 0; i < N; i++)
        {
            long sum = 0;
            for (int j = i; j < N; j++)
            {
                sum += list[j];
            }
            //Console.WriteLine($"{i} = {sum}");
        }
        stopwatch.Stop();
        Console.WriteLine($"{stopwatch.Elapsed}");
    }
}