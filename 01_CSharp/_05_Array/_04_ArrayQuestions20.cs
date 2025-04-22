using System;
using System.Linq;
using System.Reflection;
using OurCompany;

/*
 * 20. Implement a routine to indicate if an array of integers has two values 
       that sum to a provided value: bool HasSum(array, sum)
 */
public class ArrayQuestion20
{
  public static void Main(string[] args)
  {
    int[] array = { 5, 3, 0, 2, 8, -7, 6, 4, 5, 10 };
    Console.WriteLine(HasSum(array, 8)); // true
    Console.WriteLine(HasSum(array, 5)); // true
    Console.WriteLine(HasSum(array, 1)); // true
    Console.WriteLine(HasSum(array, 18)); // true
    Console.WriteLine(HasSum(array, 6)); // true
    Console.WriteLine(HasSum(array, 0) == false); // true
    Console.WriteLine(HasSum(array, 100)); // true
    Console.WriteLine(HasSum(array, -6) == false); // false
    Console.WriteLine(HasSum(array, 20) == false); // false
  }

  public static bool HasSum(int[] array, int sum)
  {
    for (int i = 0; i < array.Length; i++)
    {
      for (int j = i + 1; j < array.Length; j++)
      {
        if (array[i] + array[j] == sum)
        {
          return true;
        }
      }
    }
    return false;
  }
}
