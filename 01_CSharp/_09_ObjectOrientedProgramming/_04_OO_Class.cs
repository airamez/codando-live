using System;

/*
 * Customer
   Attributes
   * First Name
   * Last Name
   * Phone Number
   * Email
   * Username
   * Password
   * Address
     * Street #
     * Street Name
     * Apt #
     * Postalcode
     * State
     * Country
   * Driver's License #
   * Dependents
   * ...
   Operations
   * Registration
   * Send Email
   * Charge Payment
   * Send Invoice
   * ... 
 */

/*
 * Customer
   Attributes
   * First Name
   * Last Name
   * Phone Number
   * Email
   * Username
   * Password
 */

public class Customer
{
  private string firstName;
  private string lastName;

  public Customer(string firstName, string lastName)
  {
    SetFirstName(firstName);
    SetLastName(lastName);
  }

  public void SetFirstName(string firstName)
  {
    if (string.IsNullOrEmpty(firstName))
    {
      throw new Exception("First Name is required");
    }
    this.firstName = firstName;
  }

  public string GetFirstName()
  {
    return firstName;
  }

  public void SetLastName(string lastName)
  {
    if (string.IsNullOrEmpty(lastName))
    {
      throw new Exception("Last Name is required");
    }
    this.lastName = lastName;
  }

  public string GetLastName()
  {
    return lastName;
  }

  public string GetFullname()
  {
    return $"{GetFirstName()} {GetLastName()}";
  }
}

public class _04_OO_Class_App
{
  public static void Main(string[] args)
  {
    Customer customerA = new Customer("Jose", "Santos");
    Console.WriteLine($"Fullname: {customerA.GetFullname()}");

    //        Customer customerB = new Customer("", null);
  }
}
