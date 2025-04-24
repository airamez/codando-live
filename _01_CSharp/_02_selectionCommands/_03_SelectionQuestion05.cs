/*
 * Read 3 integers and print them in ascending order. (non descending)
 */
using System;
class SelectionQuestion05
{
  public static void Main(string[] args)
  {
    // Console.Write("Number 1: ");
    // int n1 = Convert.ToInt32(Console.ReadLine());
    // Console.Write("Number 2: ");
    // int n2 = Convert.ToInt32(Console.ReadLine());
    // Console.Write("Number 3: ");
    // int n3 = Convert.ToInt32(Console.ReadLine());

    // if (n1 <= n2 && n2 <= n3) {
    //     Console.WriteLine($"{n1}, {n2}, {n3}");
    // } else if (n1 <= n3 && n3 <= n2) {
    //     Console.WriteLine($"{n1}, {n3}, {n2}");
    // } else if (n2 <= n1 && n1 <= n3) {
    //     Console.WriteLine($"{n2}, {n1}, {n3}");
    // } else if (n2 <= n3 && n3 <= n1) {
    //     Console.WriteLine($"{n2}, {n3}, {n1}");
    // } else if (n3 <= n1 && n1 <= n2) {
    //     Console.WriteLine($"{n3}, {n1}, {n2}");
    // } else {
    //     Console.WriteLine($"{n3}, {n2}, {n1}");
    // }

    // Forcing n1 and n2 to ascending order
    // if (n1 > n2) {
    //     int aux = n1;
    //     n1 = n2;
    //     n2 = aux;
    // }

    // if (n3 < n1) {
    //     Console.WriteLine($"{n3}, {n1}, {n2}");
    // } else if (n3 < n2) {
    //     Console.WriteLine($"{n1}, {n3}, {n2}");
    // } else {
    //     Console.WriteLine($"{n1}, {n2}, {n3}");
    // }

    int[] numbers = new int[3];

    Console.Write("Number 1: ");
    numbers[0] = Convert.ToInt32(Console.ReadLine());
    Console.Write("Number 2: ");
    numbers[1] = Convert.ToInt32(Console.ReadLine());
    Console.Write("Number 3: ");
    numbers[2] = Convert.ToInt32(Console.ReadLine());

    Array.Sort(numbers);

    Console.WriteLine($"{numbers[0]}, {numbers[1]}, {numbers[2]}");
  }
}