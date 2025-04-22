/*
# Relationship is a way to describe how one class is connected to another class.
# Consequently, how object are connected as well.
# There are several types of relationships between classes:
  # Direct reference: In this type of relationship, one class has a direct 
    reference to another class. 
  # Association: This is a more general relationship between classes.
    # It simply means that two classes are related in some way. 
    # The association can be:
      # One to One: 1:1
      # One to Many: 1:N
      # Many to Many: N:N
  # Aggregation: This is a type of association where one class is a part of 
    another class. For example, if you have a Person class and an Address class,
    you might say that a Person has an aggregation relationship with an Address.
  # Composition: This is a stronger form of aggregation where one class is composed
    of one or more other classes. For example, if you have a Car class and classes 
    Wheel, Engine and Transmission, you might say that a Car has a composition
    relationship with these classes.

# Class Content:
  # Show examples using Visio digrams
  # Show some implementations
  # Quick overview about the class List
  # Show constructor using just new(params)
*/


using System;
using System.Collections.Generic;

namespace UniversityX.ProjextA.DomainB;

public class RelationshipApp
{

  public static void Main(string[] args)
  {
    Building mainBuilding = new("Main BLD", "Street A, San Diego, California, 923456");
    Console.WriteLine(mainBuilding);

    Department computerScience = new("Computer Science", mainBuilding);
    Department history = new("History", mainBuilding);
    Department medicine = new("Medicine", mainBuilding);
    Department Biology = new("Biology", mainBuilding);

    mainBuilding.PrintDepartments();
  }
}

public class Building
{
  public string Name { get; set; }
  public string Address { get; set; }
  List<Department> Departments;

  public Building(string name, string address)
  {
    Name = name;
    Address = address;
    Departments = new List<Department>();
  }

  public void AddDepartment(Department department)
  {
    Departments.Add(department);
  }

  public override string ToString()
  {
    return $"Building: {Name}; Address: {Address}";
  }

  public void PrintDepartments()
  {
    foreach (Department department in Departments)
    {
      Console.WriteLine(department);
    }
  }
}

public class Department
{
  public string Name { get; set; }
  public Building Building { get; set; }

  public Department(string name, Building building)
  {
    Name = name;
    Building = building;
    building.AddDepartment(this);
  }

  public override string ToString()
  {
    return $"Departament: {Name}; {Building}";
  }
}
