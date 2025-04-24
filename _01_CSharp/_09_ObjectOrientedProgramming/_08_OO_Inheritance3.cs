using System;

namespace OurCompany.LearnCoding.OOP.Inheritance3;

public class HospitalApp
{
  public static void Main(string[] args)
  {
    Person person1 = new Person
    {
      FirstName = "Jose",
      LastName = "Santos",
      Email = "josesantos@email.com",
      Phone = "(999)666-1234"
    };
    person1.Print();

    Patient patient1 = new Patient
    {
      FirstName = "João",
      LastName = "Apolinário",
      Email = "japolinario@noemail.com",
      Phone = "(123)456-7890",
      PatientID = "P1",
      Symptoms = "Fever"
    };
    patient1.Print();

    Nurse nurse1 = new Nurse
    {
      FirstName = "Maria",
      LastName = "Karmelita",
      Email = "mkarmelita@email.com",
      Phone = "(666)666-1234",
      EmployeeID = "Emp1",
      BankAccount = "Bank x1 Acc 1234",
      StartDate = "2020-03-17",
      NurseID = "N01",
      Shift = "Morning"
    };
    nurse1.Print();
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

  public void Print()
  {
    Console.WriteLine("Person");
    Console.WriteLine($"FullName: {FullName}");
    Console.WriteLine($"Email: {Email}");
    Console.WriteLine($"Phone: {Phone}");
  }
}

public class Patient : Person
{
  public string PatientID { get; set; }
  public string Symptoms { get; set; }

  public void Print()
  {
    base.Print();
    Console.WriteLine("Patient");
    Console.WriteLine($"PatientId: {PatientID}");
    Console.WriteLine($"Symptoms: {Symptoms}");
  }
}

public class Employee : Person
{
  public string EmployeeID { get; set; }
  public string BankAccount { get; set; }
  public string StartDate { get; set; }
  public void Print()
  {
    base.Print();
    Console.WriteLine("Employee");
    Console.WriteLine($"EmployeeID: {EmployeeID}");
    Console.WriteLine($"BankAccount: {BankAccount}");
    Console.WriteLine($"StartDate: {StartDate}");
  }
}

public class Nurse : Employee
{
  public string NurseID { get; set; }
  public string Shift { get; set; }

  public void Print()
  {
    base.Print();
    Console.WriteLine("Nurse");
    Console.WriteLine($"NurseID: {NurseID}");
    Console.WriteLine($"Shift: {Shift}");
  }
}

// Homework: Create the Doctor class