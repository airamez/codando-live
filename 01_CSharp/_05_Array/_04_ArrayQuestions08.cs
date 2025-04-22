using System;
using OurCompany;

/*
 *  8. Implement a routine to generate an integer array with randon numbers from a provided interval: int[] GenerateRandomArray(length, minValue, maxValue)
 */
public class ArrayQuestion08
{
  public static void Main(string[] args)
  {
    int[] randomArray1 = GenerateRandomArray(10, 0, 9);
    MyArray.Print(randomArray1);

    int[] randomArray2 = GenerateRandomArray(30, 5, 15);
    MyArray.Print(randomArray2);

    int[] randomArray3 = GenerateRandomArray(30, 10, 5);
    MyArray.Print(randomArray3);

    int[] randomArray4 = GenerateRandomArray(30, 10, 10);
    MyArray.Print(randomArray4);

    int[] randomArray5 = GenerateRandomArray(30, -5, 5);
    MyArray.Print(randomArray5);
  }

  public static int[] GenerateRandomArray(int length, int minValue, int maxValue)
  {
    int[] array = new int[length];
    if (minValue > maxValue)
    {
      int aux = minValue;
      minValue = maxValue;
      maxValue = aux;
    }
    Random random = new Random();
    for (int i = 0; i < array.Length; i++)
    {
      array[i] = random.Next(minValue, maxValue + 1);
    }
    return array;
  }
}