using System;

namespace OurCompany.LearnCoding.OOP.PropertyDemo
{

  public class PropertyApp
  {
    public static void Main(string[] args)
    {
      var car1 = new Car();
      car1.VIN = "123ABC";
      car1.Maker = "Toyota";
      car1.Model = "Rav4";
      car1.Year = 2023;
      Console.WriteLine($"VIN: {car1.VIN}; Maker; {car1.Maker}; Model: {car1.Model}; Year: {car1.Year}");

      var car2 = new Car
      {
        VIN = "456EFG",
        Maker = "Toyota",
        Model = "Trundra",
        Year = 2021
      };
      Console.WriteLine($"VIN: {car2.VIN}; Maker; {car2.Maker}; Model: {car2.Model}; Year: {car2.Year}");
    }
  }

  public class Car
  {
    public string VIN { set; get; }
    public string Maker { set; get; }
    public string Model { set; get; }
    public int Year { set; get; }
  }
}