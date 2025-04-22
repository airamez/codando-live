using System;
namespace OurCompany.LearnCoding.OOP.TheObjectClass;
/*
# The object class is the root of the C# class hierarchy.
  It is the base class for all types in C#, including 
  value types and reference types.
# The object class is defined in the System namespace.
# It provides a set of methods and properties that are 
  common to all objects.
# It defines the following methods which can be overridden by subclasses:
  # Equals
  # GetHashCode
  # ToString
# It also defines the GetType method, which returns the type
  of the current instance.
# Class Content:
  # Explain the code
  # Run the code and review the results
  # Uncomment the override methods from MyClass
  # Run the code and review the results
*/
public class ThObjectClassApp
{
  public static void Main(string[] args)
  {
    object[] objects = new object[10];

    objects[0] = new object();
    objects[1] = "Jose Santos";
    objects[2] = 5;
    objects[3] = 10.45;
    objects[4] = true;
    objects[5] = new MyClass("Leila", "Rodrigues");
    objects[6] = '#';
    objects[7] = new MyClass("Jose", "Santos");
    objects[8] = "Jose Santos";
    objects[9] = new MyClass("Jose", "Santos");

    for (int i = 0; i < objects.Length; i++)
    {
      Console.Write($"Type:{objects[i].GetType()}; ");
      Console.Write($"ToString(): {objects[i]}; ");
      //      string stringRepresentation = objects[i].ToString();
      Console.WriteLine($"HashCode: {objects[i].GetHashCode()}");
    }

    Console.WriteLine($"[1] == [2]: {objects[1] == objects[2]}");
    Console.WriteLine($"[1] == [8]: {objects[1] == objects[8]}");
    Console.WriteLine($"[5] == [9]: {objects[5] == objects[9]}");
    Console.WriteLine($"[7] == [9]: {objects[7] == objects[9]}");

    Console.WriteLine($"[1].Equals([2]): {objects[1].Equals(objects[2])}");
    Console.WriteLine($"[1].Equals([8]): {objects[1].Equals(objects[8])}");
    Console.WriteLine($"[5].Equals([9]): {objects[5].Equals(objects[9])}");
    Console.WriteLine($"[7].Equals([9]): {objects[7].Equals(objects[9])}");
    Console.WriteLine($"[7].Equals([9]): {objects[7].Equals(objects[8])}");
  }
}


public class MyClass
{
  public string FirstName { get; set; }
  public string LastName { get; set; }
  public string FullName { get => $"{FirstName} {LastName}"; }

  public MyClass(string firstName, string lastName)
  {
    FirstName = firstName;
    LastName = lastName;
  }

  public override string ToString()
  {
    return $"[First Name: {FirstName}; Last Name :{LastName}]";
  }

  public override bool Equals(object otherObject)
  {
    if (otherObject is not MyClass)
    {
      return false;
    }
    MyClass other = (MyClass)otherObject;
    return FullName.Equals(other.FullName);
  }

  public override int GetHashCode()
  {
    return FullName.GetHashCode();
  }
}
