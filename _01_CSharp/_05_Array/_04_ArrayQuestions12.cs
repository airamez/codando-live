using System;
using System.Linq;
using System.Reflection;
using OurCompany;

/*
 * 12. Implement a routine to return an array with all elements 
       that are duplicated from an array of integers
 */
public class ArrayQuestion12
{
  public static void Main(string[] args)
  {
    int[] array = { 3, 1, 5, 1, 7, 3, 3, 9, 5, 6, 4, 3 };
    MyArray.Print(array);
    int[] duplicated = GetDuplicated(array);
    MyArray.Print(duplicated);

    int[] array2 = { 0, 0, 1, 3, 1, 5, 9, 2, 6, 2 };
    MyArray.Print(array2);
    int[] duplicated2 = GetDuplicated(array2);
    MyArray.Print(duplicated2);
  }

  public static int[] GetDuplicated(int[] array)
  {
    int[] duplicated = new int[array.Length];
    int iDuplicated = 0;
    for (int i = 0; i < array.Length; i++)
    {
      for (int j = i + 1; j < array.Length; j++)
      {
        if (array[i] == array[j])
        {
          duplicated[iDuplicated] = array[i];
          iDuplicated++;
          break;
        }
      }
    }
    // Creating a new array with just values we found as duplicated
    int[] dupFinal = new int[iDuplicated];
    Array.Copy(duplicated, 0, dupFinal, 0, iDuplicated);
    return dupFinal.Distinct().ToArray();
  }
}
