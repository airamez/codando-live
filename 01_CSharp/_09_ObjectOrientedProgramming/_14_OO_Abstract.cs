using System;
/*
# An abstract class is a class that cannot be instantiated.
  It can only be used as a base class for other classes.
# An abstract class can contain abstract methods (methods without a body)
  and non-abstract methods (methods with a body).
# When a non-abstract class inherits an abstract class, it should 
  provide an implementation of the abstract methods.
# An abstract method can only be present inside an abstract class.
# The abstract keyword is used to create an abstract class or method.
# An abstract class:
  # Can have access modifiers like public, private, protected, etc.
  # Can have fields, properties, constructors, events, indexers,
    operators, finalizers, and static constructors.
  # Can inherit from another abstract class or a non-abstract class.
  # Can implement an interface.
  # Can NOT be sealed.

# Class Content
  # Use example Inheritance2
    # Instatianed the Shap class
    # Make the Shap class abstract
    # Try to instantiated the Shap class
    # Define a new abstract method

# Homework:
  Implement the GetArea methods for Circle and Square
 */

namespace OurCompany.LearnCoding.OOP.Abstract;

public class AbstractApp
{
  public static void Main(string[] args)
  {
    // Shape shap = new Shape ("Blue","Red", 5);
    Triangle triangle = new Triangle("Blue", "Red", 5,
    new Point(2, 4),
    new Point(3, -6),
    new Point(7, 8)
    );
    Circle circle = new Circle("Blue", "Red", 5, new Point(5, 15), 50);
    Square square = new Square("Blue", "Red", 5, new Point(30, 50), new Point(70, 85));
    Rectangle rectangle = new Rectangle("Blue", "Red", 5,
    new Point(0, 0),
    new Point(0, 5),
    new Point(10, 5),
    new Point(10, 0));

    Console.WriteLine($"Triagle Area: {triangle.GetArea()}");
    Console.WriteLine($"Rectangle Area: {rectangle.GetArea()}");
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
public abstract class Shape
{
  public string BackgroundColor { set; get; }
  public string BorderColor { get; set; }
  public int BorderWitdh { get; set; }

  public abstract double GetArea();

  public Shape(string backgroundColor, string borderColor, int borderWidth)
  {
    BackgroundColor = backgroundColor;
    BorderColor = borderColor;
    BorderWitdh = borderWidth;
  }
}

public class Triangle : Shape
{
  public Point Point1 { set; get; }
  public Point Point2 { get; set; }
  public Point Point3 { get; set; }
  public Triangle(string backgroundColor, string borderColor, int borderWidth,
                  Point point1, Point point2, Point point3)
    : base(backgroundColor, borderColor, borderWidth)
  {
    Point1 = point1;
    Point2 = point2;
    Point3 = point3;
  }

  public override double GetArea()
  {
    double sum = Point1.X * (Point2.Y - Point3.Y) +
                 Point2.X * (Point3.Y - Point1.Y) +
                 Point3.X * (Point1.Y - Point2.Y);
    sum = Math.Abs(sum);
    double area = 0.5 * sum;
    return area;
  }
}

public class Square : Shape
{
  public Point Point1 { set; get; }
  public Point Point2 { get; set; }

  public Square(string backgroundColor, string borderColor, int borderWidth,
                Point point1, Point point2)
    : base(backgroundColor, borderColor, borderWidth)
  {
    Point1 = point1;
    Point2 = point2;
  }

  public override double GetArea()
  {
    Console.WriteLine("Square Area");
    return 250;
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
    : base(backgroundColor, borderColor, borderWidth)
  {
    Point1 = point1;
    Point2 = point2;
    Point3 = point3;
    Point4 = point4;
  }

  public override double GetArea()
  {
    double length = Math.Sqrt(Math.Pow(Point1.X - Point2.X, 2) +
                    Math.Pow(Point1.Y - Point2.Y, 2));
    double width = Math.Sqrt(Math.Pow(Point2.X - Point3.X, 2) +
                    Math.Pow(Point2.Y - Point3.Y, 2));
    return length * width;
  }
}

public class Circle : Shape
{
  public Point Center { get; set; }
  public int Radius { set; get; }

  public Circle(string backgroundColor, string borderColor, int borderWidth,
                Point center, int radius)
      : base(backgroundColor, borderColor, borderWidth)
  {
    Center = center;
    Radius = radius;
  }

  public override double GetArea()
  {
    Console.WriteLine("Circle Area");
    return 500;
  }
}