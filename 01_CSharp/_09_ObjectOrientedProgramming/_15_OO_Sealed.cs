using System;

/*
# The sealed keyword is used to prevent a class from being inherited
  by other classes or a method/property to be overriden.
# That means a sealed class cannot have a sub/derived class.
# You can also use the sealed modifier on a method or property that 
  overrides a virtual method or property from a base class. 
# When you define new methods or properties in a class, you can prevent
  deriving classes from overriding them by not declaring them as virtual.
# It is an error to use the abstract modifier with a sealed class, because
  an abstract class must be inherited by a class that provides an 
  implementation of the abstract methods or properties.

# Class Content
  # Create an example to show it:
    - MyBaseClass
    - MySubClass
    - MySubSubClass
    - Defines a method to PrintID
    - Show the SubClass as sealed
    - Show without virtual/override
    - Show with virtual/override
    - Show the PrintID as sealed
  # 

 */
namespace OurCompany.LearnCoding.OOP.Sealed;

public class SealedApp
{
  public static void Main(string[] args)
  {
    MyBaseClass myBaseObject = new MyBaseClass
    {
      ID = "MYid 001",
      Name = "Name 1"
    };
    myBaseObject.PrintID();

    MySubClass mySubObject = new MySubClass
    {
      ID = "MYSUB 001",
      Name = "My Sub Name",
      Specialization = "My Sub Spec 1"
    };
    mySubObject.PrintID();

    MyBaseClass mySubObjectCopy = mySubObject;
    mySubObjectCopy.PrintID();

    MySubSubclass mySubSubObject = new MySubSubclass
    {
      ID = "MYsubSuB 001",
      Name = "My SubSUB Name",
      Specialization = "My Sub Sub Spec 1",
      Location = "Brazil"
    };
    mySubSubObject.PrintID();
  }
}

public class MyBaseClass
{
  public string ID { get; set; }
  public string Name { get; set; }
  public virtual void PrintID()
  {
    Console.WriteLine($"ID: {ID.ToUpper()}");
  }
}

public class MySubClass : MyBaseClass
{
  public string Specialization { get; set; }
  public override sealed void PrintID()
  {
    Console.WriteLine($"ID: {ID.ToLower()}");
  }
}

public class MySubSubclass : MySubClass
{
  public string Location { get; set; }

  // public override void PrintID() {
  //   Console.WriteLine($"ID: {ID}");
  // }
}
