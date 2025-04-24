using System;

/*
 # Method overriding is a feature that allows a subclass (derived or child class) 
   to provide a specific implementation of a method that is already provided
   by one of its superclasses or parent classes.
 # The implementation in the subclass overrides (replaces) the implementation 
   in the superclass by providing a method that has the same name, same parameters
   or signature, and same return type as the method in the parent class.
 # Method overriding is useful to implement polymorfism
 # In C# there are three keywords for overriding implementation:
   # virtual: used on the base class to indicate that overriding is possible
   # override: used in the subclass to indicate a method is being overriden
   # new: Used in the subclass to indicate the method is NOT being overriden

 # Class Content:
   # Demo with a base class with two methods and
     a Sub class using override and new for those methods.
   # Show the result of calling the methods using a reference
     for the base class  
 */

public class OverrideApp
{
  public static void Main(string[] args)
  {
    BaseClass baseObject = new BaseClass();
    baseObject.MethodA();
    baseObject.MethodB();

    SubClass subObject1 = new SubClass();
    subObject1.MethodA();
    subObject1.MethodB();

    BaseClass subObject2 = new SubClass();
    subObject2.MethodA();
    subObject2.MethodB();
  }
}

public class BaseClass
{
  public virtual void MethodA()
  {
    Console.WriteLine("BaseClass.MethodA()");
  }

  public virtual void MethodB()
  {
    Console.WriteLine("BaseClass.MethodB()");
  }
}

public class SubClass : BaseClass
{
  public override void MethodA()
  {
    Console.WriteLine("SubClass.MethodA()");
  }
  public new void MethodB()
  {
    Console.WriteLine("SubClass.MethodB()");
  }

  public void MethodC()
  {
    Console.WriteLine("SubClass.MethodC()");
  }
}
