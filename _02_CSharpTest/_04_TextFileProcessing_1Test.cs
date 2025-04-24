using System;
using System.IO;
using NUnit.Framework;
using UnitTesting1;

[TestFixture]
public class TextFileProcessing_1Test
{
  [Test]
  public void TestMainMethod()
  {
    // Arrange
    string expectedOutput = "1: 10" + System.Environment.NewLine +
                            "2: 20" + System.Environment.NewLine +
                            "3: 30" + System.Environment.NewLine +
                            "Invalid value" + System.Environment.NewLine +
                            "4: 40" + System.Environment.NewLine +
                            "Sum: 100" + System.Environment.NewLine +
                            "Average: 25";
    // Act
    string actualOutput;
    using (StringWriter writer = new StringWriter())
    {
      Console.SetOut(writer);
      TextFileProcessing_1.Main(null);
      actualOutput = writer.ToString().Trim();
    }
    // Assert
    Assert.That(actualOutput, Is.EqualTo(expectedOutput));
  }
}