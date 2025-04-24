/*
 * Read an age and print "Minor" if the age is smaller than 18
 */
using System;
class SelectionQuestion07
{
    public static void Main(string[] args)
    {
        Console.Write("Age: ");
        int age = Convert.ToInt32(Console.ReadLine());
        if (age < 18)
        {
            Console.WriteLine("Minor");
        }
    }
}