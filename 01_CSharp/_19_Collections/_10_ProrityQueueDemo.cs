// https://leetcode.com/problems/kth-largest-element-in-an-array/description/
// 215. Kth Largest Element in an Array

using System;
using System.Collections.Generic;

namespace Collections;

public class PriorityQueueDemoApp
{
  public static void Main(string[] args)
  {
    /*
      Example 1:
      Input: nums = [3,2,1,5,6,4], k = 2
      Output: 5

      Example 2:
      Input: nums = [3,2,3,1,2,4,5,5,6], k = 4
      Output: 4
    */
    var app = new PriorityQueueDemoApp();
    Console.WriteLine(app.FindKthLargest([3, 2, 1, 5, 6, 4], 2));
    Console.WriteLine(app.FindKthLargest([3, 2, 3, 1, 2, 4, 5, 5, 6], 4));
  }

  public int FindKthLargest(int[] nums, int k)
  {
    var heap = new PriorityQueue<int, int>();
    foreach (var num in nums)
    {
      heap.Enqueue(num, num);
      if (heap.Count > k)
      {
        heap.Dequeue();
      }
    }
    return heap.Dequeue();
  }
}