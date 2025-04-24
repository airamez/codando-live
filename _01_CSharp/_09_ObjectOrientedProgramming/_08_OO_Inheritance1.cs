/*
# Inheritance is a feature that allows the definition of a base class
  that provides specific functionality and to define derived classes
  that either inherit or override that functionality.
# The class whose members are inherited is called the base/super class, and
  the class that inherits those members is called the derived/sub class.
# A derived class can have only one direct base class. However,
  inheritance is transitive, which allows you to define an inheritance
  hierarchy for a set of types.
# Constructos are not inherited by derived classes.
# To inherit from a class, use the : symbol
  e.g: public class Triagle : Shape {...}
# It is possible to reuse a Construtor from a base class by adding : base(params)
  on a sub-class constructor
# Class Content:
  # Overview using a diagram for Sharp:
    Triangle
    Square
    Rectangle
    Circle
  # Attributes:
    Common: BackgroundColor, BorderColor, BorderWidth
    Triangle: Points (3)
    Square: Points (2)
    Rectangle: Points(4)
    Circle: Point + Radius
 */
using System;

namespace OurCompany.LearnCoding.OOP.Inheritance1;

public class ShapeApp
{
  public static void Main(string[] args)
  {
    Triangle t1 = new Triangle(
      "Gold", "Pink", 5,
      new Point(1, 10),
      new Point(4, 9),
      new Point(15, 17));
    Console.WriteLine($"Triangle: {t1.BackgroundColor}; {t1.BorderColor}; {t1.BorderWitdh}");

    Square s1 = new Square(
      "LightBlue", "Yellow", 3,
      new Point(1, 10),
      new Point(4, 9));
    Console.WriteLine($"Square: {s1.BackgroundColor}; {s1.BorderColor}; {s1.BorderWitdh}");

    Rectangle r1 = new Rectangle(
      "Gray", "Green", 3,
      new Point(1, 10),
      new Point(5, 10),
      new Point(20, 21),
      new Point(15, 25));
    Console.WriteLine($"Rectangle: {r1.BackgroundColor}; {r1.BorderColor}; {r1.BorderWitdh}");

    Circle c1 = new Circle("Pink", "DarkBlue", 5, new Point(50, 50), 25);
    Console.WriteLine($"Rectangle: {c1.BackgroundColor}; {c1.BorderColor}; {c1.BorderWitdh}");
  }
}

public class Point
{
  public int X { get; set; }
  public int Y { get; set; }

  public Point(int x, int y)
  {
    X = x;
    Y = y;
  }
}
public class Shape
{
  public string BackgroundColor { set; get; }
  public string BorderColor { get; set; }
  public int BorderWitdh { get; set; }
}

public class Triangle : Shape
{
  public Point Point1 { set; get; }
  public Point Point2 { get; set; }
  public Point Point3 { get; set; }
  public Triangle(string backgroundColor, string borderColor, int borderWidth,
                  Point point1, Point point2, Point point3)
  {
    BackgroundColor = backgroundColor;
    BorderColor = borderColor;
    BorderWitdh = borderWidth;
    Point1 = point1;
    Point2 = point2;
    Point3 = point3;
  }
}

public class Square : Shape
{
  public Point Point1 { set; get; }
  public Point Point2 { get; set; }

  public Square(string backgroundColor, string borderColor, int borderWidth,
                Point point1, Point point2)
  {
    BackgroundColor = backgroundColor;
    BorderColor = borderColor;
    BorderWitdh = borderWidth;
    Point1 = point1;
    Point2 = point2;
  }
}

public class Rectangle : Shape
{
  public Point Point1 { set; get; }
  public Point Point2 { get; set; }
  public Point Point3 { get; set; }
  public Point Point4 { get; set; }

  public Rectangle(string backgroundColor, string borderColor, int borderWidth,
                   Point point1, Point point2, Point point3, Point point4)
  {
    BackgroundColor = backgroundColor;
    BorderColor = borderColor;
    BorderWitdh = borderWidth;
    Point1 = point1;
    Point2 = point2;
    Point3 = point3;
    Point4 = point4;
  }
}

public class Circle : Shape
{
  public Point Center { get; set; }
  public int Radius { set; get; }

  public Circle(string backgroundColor, string borderColor, int borderWidth,
                Point center, int radius)
  {
    BackgroundColor = backgroundColor;
    BorderColor = borderColor;
    BorderWitdh = borderWidth;
    Center = center;
    Radius = radius;
  }
}