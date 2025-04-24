using System;
namespace OurCompany.LearnCoding.OOP.Polymorphism;
/*
# Polymorphism is a concept that allows objects of different classes
  to be treated as if they were objects of the same class.
# It is achieved through inheritance, where a subclass can inherit 
  properties and methods from its superclass and override them.
# Polymorphism allows you to write code that can work with objects
  of different classes in a uniform way, making your code more
  simple, flexible and reusable.

# Class Content
  # Recreate the example of Hospital Classes (Copy from _08_OO_Inheritance3.cs)
  # Use the method PrintBadge as vitual/override
  # Store objects in a Array of Person
  # Loop and call the method PrintBadge
  # Show how to check and cast to a specific object type using the operator: is
*/

public class PolymorphismApp
{
  public static void Main(string[] args)
  {
    Person[] personDB = new Person[10];
    personDB[0] = new Patient
    {
      FirstName = "Carlos",
      LastName = "Malta",
      Email = "cmalta@noemail.com",
      Phone = "999(111)2222",
      PatientID = "P001",
      Symptoms = "fever, headache"
    };
    personDB[1] = new Nurse
    {
      FirstName = "Marieta",
      LastName = "Silva",
      Email = "msilva@noemail.com",
      Phone = "999(333)4444",
      EmployeeID = "E001",
      BankAccount = "Bank X, Account 001",
      StartDate = "01/05/2022",
      NurseID = "N001",
      Shift = "Morning"
    };
    personDB[2] = new Doctor
    {
      FirstName = "Jose",
      LastName = "Maria",
      Email = "joseMaria@noemail.com",
      Phone = "999(555)8888",
      EmployeeID = "E002",
      BankAccount = "Bank A, Account 002",
      StartDate = "01/05/1965",
      DoctorID = "D0001",
      Specialization = "XRay"
    };
    personDB[3] = new Doctor
    {
      FirstName = "Zenilton",
      LastName = "Fonseca",
      Email = "zene@noemail.com",
      Phone = "999(555)2222",
      EmployeeID = "E003",
      BankAccount = "Bank X, Account 007",
      StartDate = "01/05/1995",
      DoctorID = "D0002",
      Specialization = "Images"
    };
    // Printing all badges
    for (int i = 0; i < 4; i++)
    {
      personDB[i].PrintBadge();
    }
    // Printing only Employee Badges
    for (int i = 0; i < 4; i++)
    {
      if (personDB[i] is Employee)
      {
        personDB[i].PrintBadge();
      }
    }
    // Printing Doctor Name and Specialization
    for (int i = 0; i < 4; i++)
    {
      if (personDB[i] is Doctor)
      {
        Doctor doctor = (Doctor)personDB[i];
        Console.WriteLine($"{doctor.FullName}:{doctor.Specialization}");
      }
    }
  }
}

public class Person
{
  public string FirstName { get; set; }
  public string LastName { get; set; }
  public string FullName
  {
    get
    {
      return $"{FirstName} {LastName}";
    }
  }
  public string Email { get; set; }
  public string Phone { get; set; }

  public virtual void PrintBadge()
  {
    Console.WriteLine($"FullName: {FullName}");
  }
}

public class Patient : Person
{
  public string PatientID { get; set; }
  public string Symptoms { get; set; }

  public override void PrintBadge()
  {
    Console.WriteLine("Patient");
    base.PrintBadge();
    Console.WriteLine($"PatientId: {PatientID}");
    Console.WriteLine($"Symptoms: {Symptoms}");
  }
}

public class Employee : Person
{
  public string EmployeeID { get; set; }
  public string BankAccount { get; set; }
  public string StartDate { get; set; }
  public override void PrintBadge()
  {
    Console.WriteLine("Employee");
    base.PrintBadge();
    Console.WriteLine($"EmployeeID: {EmployeeID}");
    Console.WriteLine($"StartDate: {StartDate}");
  }
}

public class Nurse : Employee
{
  public string NurseID { get; set; }
  public string Shift { get; set; }

  public override void PrintBadge()
  {
    Console.WriteLine("Nurse");
    base.PrintBadge();
    Console.WriteLine($"NurseID: {NurseID}");
    Console.WriteLine($"Shift: {Shift}");
  }
}

public class Doctor : Employee
{
  public string DoctorID { get; set; }
  public string Specialization { get; set; }

  public override void PrintBadge()
  {
    Console.WriteLine("Doctor");
    base.PrintBadge();
    Console.WriteLine($"Doctor ID: {DoctorID}");
    Console.WriteLine($"Specialization: {Specialization}");
  }
}
