/*
- https://learn.microsoft.com/en-us/dotnet/csharp/linq/
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

namespace Advanced;

public class LINQApp
{
  public static void Main(string[] args)
  {
    List<int> numbers = new List<int> { 1, 5, 2, 4, 3, 3, 4, 2, 5, 1 };

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

    // LINQ Sintaxe
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
    resultMethod.ToList().ForEach(name => Console.Write(name + " "));
    Console.WriteLine();

    // Removing duplicates
    var uniqueNumbers = numbers.Distinct();
    Console.WriteLine(string.Join(", ", uniqueNumbers));

    // ForEach
    var doubles = numbers.Select(n => n * 2);
    Console.Write("Doubles: ");
    doubles.ToList().ForEach(n => Console.Write(n + " "));
    Console.WriteLine();

    // FirstOrDefault
    var artur = names.FirstOrDefault(name => name.ToUpper() == "ARTUR");
    Console.WriteLine(artur);
    var jose = names.FirstOrDefault(name => name.ToUpper().Equals("JOSE"));
    Console.WriteLine(jose);

    // Sorting
    var sortedNames = names.OrderBy(name => name).ToList();
    sortedNames.ForEach(name => Console.Write(name + " "));
    Console.WriteLine();
    sortedNames = names.OrderByDescending(name => name).ToList();
    sortedNames.ForEach(name => Console.Write(name + " "));
    Console.WriteLine();

    // Grouping
    var employees = new List<Employee>
    {
        new Employee { Id = 1, Name = "Alice", Department = "HR" },
        new Employee { Id = 2, Name = "Bob", Department = "IT" },
        new Employee { Id = 3, Name = "Charlie", Department = "HR" },
        new Employee { Id = 4, Name = "TOM", Department = "HR" },
        new Employee { Id = 5, Name = "Jerry", Department = "IT" },
        new Employee { Id = 6, Name = "Benjas", Department = "IT" },
        new Employee { Id = 7, Name = "Leiloca", Department = "HR" },
    };
    var groups = employees.GroupBy(e => e.Department);
    foreach (var group in groups)
    {
      Console.WriteLine($"Department: {group.Key}");
      foreach (var employee in group)
      {
        Console.WriteLine($" - {employee.Name}");
      }
    }

    // Select
    var justNames = employees.Select(e => e.Name).ToList();
    Console.Write("Names: ");
    justNames.ForEach(name => Console.Write(name + " "));
    Console.WriteLine();

    var justDepartments = employees.Select(e => e.Department).Distinct().ToList();
    Console.Write("Departments: ");
    justDepartments.ForEach(Console.WriteLine); // Explain this compared to the previous ForEach

    // ToDictionary (Convert Collection to Dictionary)
    var peopleDict = employees.ToDictionary(p => p.Id);
    foreach (var employee in peopleDict)
    {
      Console.WriteLine($"{employee.Key}: {employee.Value}");
    }

    // Union, Intersect, Except (Set Operations)
    var list1 = new List<int> { 0, 1, 2, 3, 4, 5, 9 };
    var list2 = new List<int> { 5, 6, 7, 8, 9, 0, 1 };

    var union = list1.Union(list2);
    var intersect = list1.Intersect(list2);
    var except = list1.Except(list2);

    Console.WriteLine($"Union: {string.Join(", ", union)}");
    Console.WriteLine($"Intersect: {string.Join(", ", intersect)}");
    Console.WriteLine($"Except: {string.Join(", ", except)}");

    // Zip (Combine Two Sequences)
    var ages = new List<int> { 25, 30, 35, 40, 15, 29, 21 };
    var combined = names.Zip(ages, (name, age) => $"{name} is {age} years old");
    foreach (var item in combined)
    {
      Console.WriteLine(item);
    }
  }
}

public class Employee
{
  public int Id { get; set; }
  public string Name { get; set; }
  public string Department { get; set; }

  public override string ToString()
  {
    return $"[Id:{Id}; Name:{Name}; Department:{Department}]";
  }
}