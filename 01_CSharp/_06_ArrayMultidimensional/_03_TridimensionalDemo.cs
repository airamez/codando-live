using System;

public class _03_TridimensionalDemo
{

    static void Main(string[] args)
    {
        demo1();
        demo2();
    }

    private static void demo1()
    {
        string[] months = { "January", "February", "March", "April", "May", "June", "July", "August", "September", "Octorber", "Nocvember", "December" };
        int[] preciptationPerMonth = { 5, 3, 6, 2, 1, 0, 0, 8, 10, 5, 3, 6 };

        // Printing precipitation per month
        for (int i = 0; i < preciptationPerMonth.Length; i++)
        {
            Console.WriteLine($"{months[i]}= {preciptationPerMonth[i]}");
        }

        string[] states = { "California", "Florida", "Nevada", "Texas" };
        int[,] preciptationPerMonthPerState =
        {
            {11, 13, 16, 15, 10, 10, 15, 18, 10, 15, 10, 12},
            {19, 21, 25, 22, 31, 35, 50, 38, 20, 45, 25, 24},
            {10, 11, 12, 12, 15, 20, 11, 12, 15, 17, 15, 18},
            {11, 11, 13, 11, 21, 13, 10, 15, 14, 13, 15, 27},
        };

        Console.WriteLine("Precipitation Per State/Month report:");
        for (int i = 0; i < states.Length; i++)
        {
            Console.WriteLine($"State: {states[i]}");
            for (int j = 0; j < months.Length; j++)
            {
                Console.WriteLine($"  {months[j]}= {preciptationPerMonthPerState[i, j]}");
            }
        }
    }

    private static void demo2()
    {
        string[] months = { "January", "February", "March", "April", "May", "June", "July", "August", "September", "Octorber", "November", "December" };
        int[] preciptationPerMonth = { 5, 3, 6, 2, 1, 0, 0, 8, 10, 5, 3, 6 };

        // Printing precipitation per month
        for (int i = 0; i < preciptationPerMonth.Length; i++)
        {
            Console.WriteLine($"{months[i]}= {preciptationPerMonth[i]}");
        }

        string[] states = { "California", "Florida", "Nevada", "Texas" };
        int[][] preciptationPerMonthPerState =
        {
            new int[] {11, 13, 16, 15, 10, 10, 15, 18, 10, 15, 10, 12},
            new int[] {19, 21, 25, 22, 31, 35, 50, 38, 20, 45, 25, 24},
            new int[] {10, 11, 12, 12, 15, 20, 11, 12, 15, 17, 15, 18},
            new int[] {11, 11, 13, 11, 21, 13, 10, 15, 14, 13, 15, 27},
        };

        Console.WriteLine("Precipitation Per State/Month report:");
        for (int i = 0; i < states.Length; i++)
        {
            Console.WriteLine($"State: {states[i]}");
            for (int j = 0; j < preciptationPerMonthPerState[i].Length; j++)
            {
                Console.WriteLine($"  {months[j]}= {preciptationPerMonthPerState[i][j]}");
            }
        }
    }
}
