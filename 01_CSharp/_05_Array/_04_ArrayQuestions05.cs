using System;
using System.Linq;
using OurCompany;

/*
 *  5. Implement a routine to calculate the average of an array of 
    integers: double ArrayAverage(array)
 */
public class ArrayQuestion05
{
  public static void Main(string[] args)
  {
    int[] array = { 17, 33, 40, 85, 6, 8 };

    double average = ArrayAverage(array);
    Console.WriteLine($"Average = {average}");
    Console.WriteLine($"Test passed: {average == 31.5}");

    long sum = ArraySum(array);
    Console.WriteLine($"Sum = {sum}");
    Console.WriteLine($"Test passed: {sum == 189}");

    average = ArrayAverage2(array);
    Console.WriteLine($"Average = {average}");
    Console.WriteLine($"Test passed: {average == 31.5}");

  }

  public static double ArrayAverage(int[] array)
  {
    long sum = 0;
    for (int i = 0; i < array.Length; i++)
    {
      sum += array[i];
    }
    return sum / (double)array.Length;
  }

  public static double ArrayAverage2(int[] array)
  {
    long sum = ArraySum(array);
    return sum / (double)array.Length;
  }

  public static long ArraySum(int[] array)
  {
    long sum = 0;
    for (int i = 0; i < array.Length; i++)
    {
      sum += array[i];
    }
    return sum;
  }
}