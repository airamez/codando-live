using System;
using System.Linq;
using System.Reflection;
using OurCompany;

/*
 * 10. Implement a routine to check if an array of integer is palindrome
 */
public class ArrayQuestion10
{
  public static void Main(string[] args)
  {
    int[] arr1 = { 4, 7, 9, 0, 9, 7, 4 };
    Console.WriteLine(IsPalindrome2(arr1));

    int[] arr2 = { 1, 2, 3, 4, 4, 3, 2, 1 };
    Console.WriteLine(IsPalindrome2(arr2));

    int[] arr3 = { 5 };
    Console.WriteLine(IsPalindrome2(arr3));

    int[] arr4 = { 1, 3, 5, 7, 8, 5, 3, 1 };
    Console.WriteLine(IsPalindrome2(arr4));

    int[] arr5 = { 4, 7, 9, 0, 9, 7, 4, 5 };
    Console.WriteLine(IsPalindrome2(arr5));

    Console.WriteLine($"Test1 Pass = {IsPalindrome2(arr1)}");
    Console.WriteLine($"Test2 Pass = {IsPalindrome2(arr2)}");
    Console.WriteLine($"Test3 Pass = {IsPalindrome2(arr3)}");
    Console.WriteLine($"Test4 Pass = {IsPalindrome2(arr4) == false}");
    Console.WriteLine($"Test5 Pass = {IsPalindrome2(arr5) == false}");
  }

  public static bool IsPalindrome1(int[] array)
  {
    int[] clonned = (int[])array.Clone();
    Array.Reverse(clonned);
    return ArrayQuestion09.ArrayEquals(array, clonned);
  }
  public static bool IsPalindrome2(int[] array)
  {
    int left = 0;
    int right = array.Length - 1;
    while (left < right)
    {
      if (array[left] != array[right])
      {
        return false;
      }
      left++;
      right--;
    }
    return true;
  }

}