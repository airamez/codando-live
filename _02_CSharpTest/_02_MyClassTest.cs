using NUnit.Framework;

[TestFixture]
public class MyClassTest
{
  [Test]
  public void TestDivision1()
  {
    // Arrange
    int dividend = 10;
    int divisor = 2;
    decimal expected = 5;

    // Act
    decimal result = MyClass.division(dividend, divisor);

    // Assert
    Assert.That(result, Is.EqualTo(expected));
  }

  [Test]
  public void TestDivision2()
  {
    Assert.That(MyClass.division(8, 2), Is.EqualTo(4));
  }

  [Test]
  public void TestDivision3()
  {
    Assert.That(MyClass.division(9, 3), Is.EqualTo(3));
  }

  [Test]
  public void TestDivision4()
  {
    Assert.That(MyClass.division(20, 2), Is.EqualTo(10));
  }

  [Test]
  public void TestDivision5()
  {
    Assert.That(MyClass.division(7, 2), Is.EqualTo(3.5));
  }

  [Test]
  public void TestDivision6()
  {
    Assert.That(MyClass.division(3, 2), Is.EqualTo(1.5));
  }
}