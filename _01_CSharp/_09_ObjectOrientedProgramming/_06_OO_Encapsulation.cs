using System;

/*
# Encapsulation is the wrapping up of data and information inside a class,
  and offer methods/properties to access them.
# It is achieved by declaring attributes (and some methods) as private and using 
  methods/properties to access them.
# There are four access modifiers that can be used to control the visibility:
   public: Anywhere
   private: Only inside the class
   protected: Only inside the class and sub-classes
   internal: Only inside the same Assembly (EXE, DLL or Project)
# Class Content:
  # 1. Review Namespace
  # 2. Create a new class Car
 */

namespace OurCompany.LearnCoding.OOP.Encapsulation;

public class Car
{
  private string vin;
  private string maker;
  private string model;

  public Car(string vin, string maker, string model)
  {
    SetVIN(vin);
    SetMaker(maker);
    SetModel(model);
  }

  private void SetVIN(string vin)
  {
    if (string.IsNullOrEmpty(vin))
    {
      throw new Exception("VIN is required");
    }
    this.vin = vin;
  }

  public string GetVIN()
  {
    return vin;
  }

  public void SetMaker(string maker)
  {
    if (string.IsNullOrEmpty(maker))
    {
      throw new Exception("Maker is required");
    }
    this.maker = maker;
  }

  public string GetMaker()
  {
    return maker;
  }

  public void SetModel(string model)
  {
    if (string.IsNullOrEmpty(model))
    {
      throw new Exception("Model is required");
    }
    this.model = model;
  }

  public string GetModel()
  {
    return model;
  }
}

public class CarApp
{
  public static void Main(string[] args)
  {
    Car car1 = new Car("1234ABC", "Toyota", "Rav4");
    Console.WriteLine($"VIN: {car1.GetVIN()}; Maker: {car1.GetMaker()}; Model: {car1.GetModel()}");
    //car1.SetVin() // Not accessible


    //Car car2 = new Car("345BCD", "", null);
  }
}