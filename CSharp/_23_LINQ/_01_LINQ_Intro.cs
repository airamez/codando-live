/*
- What is LINQ?
  - LINQ (Language-Integrated Query) is a feature in C# that allows querying collections
    (like arrays, lists, and databases) using a readable, SQL-like syntax.
  - It provides a unified way to access data from different sources 
    (e.g., databases, collections, CSS, XML, JSON files, etc).
  - Most C# collections provice LINQ capabilities
    - The System.Linq library has to be imported
- Why Use LINQ?
  - Concise & Readable: Simplifies complex queries.
  - Type Safety: Errors are caught at compile time.
  - Performance Optimization: LINQ queries are optimized for execution.
  - Consistent Syntax: Same query syntax for different data sources (Collections, SQL, XML).

- LINQ Syntax
  - There are two main styles of LINQ:
  - Query Syntax (SQL-like)
  - Method Syntax (Lambda expressions)

- Common LINQ methods
  --------------------------------------------------------------------
  Method	                Description
  --------------------------------------------------------------------
  Where                   Filters elements based on a condition
  Select                  Projects each element into a new form
  OrderBy	                Sorts elements in ascending order
  OrderByDescending       Sorts elements in descending order
  GroupBy                 Groups elements based on a key
  Join                    Joins two sequences based on a condition
  First / FirstOrDefault	Returns the first element
  Any                     Checks if any elements satisfy a condition
  Count                   Returns the number of elements
*/

using System;
using System.Collections.Generic;
using System.Linq;

namespace LINQ;

public class LINQApp
{
  public static void Main(string[] args)
  {
    List<int> numbers = new List<int> { 1, 2, 3, 4, 5, 6, 7, 8, 9, 10 };

    // Traditional approach
    List<int> evenNumbers = new List<int>();
    foreach (var num in numbers)
    {
      if (num % 2 == 0)
        evenNumbers.Add(num);
    }
    foreach (var num in evenNumbers)
    {
      Console.Write(num + " ");
    }
    Console.WriteLine();

    // Using LINQ
    var evenNumbersLINQ = numbers.Where(n => n % 2 == 0).ToList();
    evenNumbersLINQ.ForEach(n => Console.Write(n + " "));
    Console.WriteLine();

    // Linq Sintaxe
    var names = new List<string> { "Alice", "Bob", "Albert", "Charlie", "Alfred", "David", "Artur" };

    // Query
    var resultQuery = from name in names
                      where name.StartsWith("A")
                      select name;

    foreach (var name in resultQuery)
    {
      Console.Write(name + " ");
    }
    Console.WriteLine();

    // Method
    var resultMethod = names.Where(name => name.StartsWith("A"));
    foreach (var name in resultMethod)
    {
      Console.Write(name + " ");
    }
    Console.WriteLine();

    // Sorting
    var sortedNames = names.OrderBy(name => name).ToList();
    sortedNames.ForEach(name => Console.Write(name + " "));
    Console.WriteLine();

    // Grouping
    var employees = new List<Employee>
    {
        new Employee { Name = "Alice", Department = "HR" },
        new Employee { Name = "Bob", Department = "IT" },
        new Employee { Name = "Charlie", Department = "HR" },
        new Employee { Name = "TOM", Department = "HR" },
        new Employee { Name = "Jerry", Department = "IT" },
        new Employee { Name = "Benjas", Department = "IT" },
        new Employee { Name = "Leiloca", Department = "HR" },
    };
    var groups = employees.GroupBy(e => e.Department);
    foreach (var group in groups)
    {
      Console.WriteLine($"Department: {group.Key}");
      foreach (var emp in group)
      {
        Console.WriteLine($" - {emp.Name}");
      }
    }
  }
}

public class Employee
{
  public string Name { get; set; }
  public string Department { get; set; }
}