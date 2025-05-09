using System;
using System.Data;
using Newtonsoft.Json;

namespace ADO.NET.DataAccess;

public class DataTableIntroApp
{
  public static void Main(string[] args)
  {
    DataTable students = new DataTable("Students");

    // Define columns
    students.Columns.Add("ID", typeof(int));
    students.Columns.Add("Name", typeof(string));
    students.Columns.Add("Age", typeof(int));

    // Add rows
    students.Rows.Add(1, "Alice", 22);
    students.Rows.Add(2, "Bob", 25);
    students.Rows.Add(3, "Charlie", 21);
    students.Rows.Add(4, "David", 24);
    students.Rows.Add(5, "Emma", 23);
    students.Rows.Add(6, "Frank", 26);
    students.Rows.Add(7, "Grace", 22);
    students.Rows.Add(8, "Hannah", 27);
    students.Rows.Add(9, "Ian", 20);
    students.Rows.Add(10, "Julia", 29);
    students.Rows.Add(11, "Kevin", 22);
    students.Rows.Add(12, "Laura", 25);
    students.Rows.Add(13, "Mike", 21);
    students.Rows.Add(14, "Nancy", 24);
    students.Rows.Add(15, "Oliver", 23);

    // Traversing
    foreach (DataRow student in students.Rows)
    {
      Console.WriteLine($"{student["ID"]}, {student["Name"]}, {student["Age"]}");
    }

    // Filtering and sorting
    Console.WriteLine("Age greater than 24 and sorted by Name in ascending order");
    foreach (DataRow student in students.Select("Age > 24", "Name ASC"))
    {
      Console.WriteLine($"{student["ID"]}, {student["Name"]}, {student["Age"]}");
    }

    // Updating
    Console.WriteLine($"table.Rows[0][\"Name\"] = {students.Rows[0]["Name"]}");
    students.Rows[0]["Name"] = "Jose";
    Console.WriteLine($"table.Rows[0][\"Name\"] = {students.Rows[0]["Name"]}");

    // Deleting
    students.Rows[1].Delete();
    students.AcceptChanges();
    foreach (DataRow student in students.Rows)
    {
      Console.WriteLine($"{student["ID"]}, {student["Name"]}, {student["Age"]}");
    }

    // Converting to JSON
    string json = JsonConvert.SerializeObject(students, Formatting.Indented);
    Console.WriteLine(json);

    // Loading from JSON
    // Note: All columns come as strings
    DataTable studentsFromJson = JsonConvert.DeserializeObject<DataTable>(json);

    foreach (DataRow row in studentsFromJson.Rows)
    {
      Console.WriteLine($"{row["ID"]}, {row["Name"]}, {row["Age"]}");
    }
  }
}