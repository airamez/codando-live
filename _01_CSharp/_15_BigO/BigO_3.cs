using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;

namespace BigO;

/*
    Question: Implement a method to receive an array as input and return an array
              with the sum of all elements from each index to the end of the array.
*/

public class BigO_3App
{
    public static void Main(string[] args)
    {
        int[] input = { 0, 1, 2, 3, 4, 5, 6, 7, 8, 9 };
        foreach (var sum in GetAcummulatedSumON2(input))
        {
            Console.Write($"{sum} ");
        }
        Console.WriteLine();
        foreach (var sum in GetAcummulatedSumON(input))
        {
            Console.Write($"{sum} ");
        }
        Console.WriteLine();
        foreach (var sum in GetAcummulatedSumONImproved(input))
        {
            Console.Write($"{sum} ");
        }
    }

    public static long[] GetAcummulatedSumON2(int[] input)
    {
        long[] output = new long[input.Length];
        for (int i = 0; i < input.Length; i++)
        {
            long sum = 0;
            for (int j = i; j < input.Length; j++)
            {
                sum += input[j];
            }
            output[i] = sum;
        }
        return output;
    }

    public static long[] GetAcummulatedSumON(int[] input)
    {
        long[] output = new long[input.Length];
        long sum = input.Sum(); // N
        output[0] = sum;
        for (int i = 1; i < input.Length; i++) // N
        {
            output[i] = output[i - 1] - input[i - 1];
        }
        return output;
    }

    public static long[] GetAcummulatedSumONImproved(int[] input)
    {
        long[] output = new long[input.Length];
        output[output.Length - 1] = input[input.Length - 1];
        for (int i = input.Length - 2; i >= 0; i--) // N
        {
            output[i] = output[i + 1] + input[i];
        }
        return output;
    }
}