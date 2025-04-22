using System;
using System.ComponentModel;
using System.Linq;
using System.Net;
using System.Reflection;
using OurCompany;

/*
 * 25. Implement a routine to given an array of N non-negative integers 
       representing an elevation map where the width of each bar is 1,
       compute how much water it is able to trap after raining.
 */
public class ArrayQuestion25
{
  public static void Main(string[] args)
  {
    int[] elevations = {
            2, 1, 3, 0, 1, 3, 2, 0, 1, 2, 0, 1, 4, 1, 5, 0, 2, 1, 3, 0, 0, 2
        };
    int trappedWater = GetTrappedWater(elevations);
    Console.WriteLine($"Total trapped water = {trappedWater}");
  }

  private static int GetTrappedWater(int[] elevations)
  {
    int[] maxLeft = GetMaxElevationsOnLeft(elevations);
    int[] maxRight = GetMaxElevationsFromRight(elevations);
    return GetTotalTrappedWater(elevations, maxLeft, maxRight);
  }

  private static int GetTotalTrappedWater(int[] elevations,
                                          int[] maxLeft,
                                          int[] maxRight)
  {
    int totaltrappedWater = 0;
    for (int i = 0; i < elevations.Length; i++)
    {
      int max = Math.Min(maxLeft[i], maxRight[i]);
      int trappedWaterLocal = max - elevations[i];
      if (trappedWaterLocal > 0)
      {
        totaltrappedWater += trappedWaterLocal;
      }
    }

    return totaltrappedWater;
  }

  private static int[] GetMaxElevationsFromRight(int[] elevations)
  {
    int[] maxRight = new int[elevations.Length];
    int maxElevationRight = 0;
    for (int i = elevations.Length - 2; i >= 0; i--)
    {
      maxElevationRight = Math.Max(maxElevationRight, elevations[i + 1]);
      maxRight[i] = maxElevationRight;
    }
    return maxRight;
  }

  private static int[] GetMaxElevationsOnLeft(int[] elevations)
  {
    int[] maxLeft = new int[elevations.Length];
    int maxElevationLeft = 0;
    for (int i = 1; i < elevations.Length; i++)
    {
      maxElevationLeft = Math.Max(maxElevationLeft, elevations[i - 1]);
      maxLeft[i] = maxElevationLeft;
    }
    return maxLeft;
  }
}