using System;
using System.IO;
using System.Collections.Generic;
using NUnit.Framework;
using UnitTesting3;
using Moq;

[TestFixture]
public class TextFileProcessing_3Test
{
  [Test]
  public void TestProduceLines()
  {
    // Arrange
    var mockReader = new Mock<IStreamReader>();
    mockReader.SetupSequence(r => r.ReadLine())
        .Returns("50")
        .Returns("60")
        .Returns("70")
        .Returns("invalid number")
        .Returns("80");
    mockReader.SetupSequence(r => r.EndOfStream)
        .Returns(false)
        .Returns(false)
        .Returns(false)
        .Returns(false)
        .Returns(false)
        .Returns(true);

    // Act
    TextFileProcessor processor = new TextFileProcessor(mockReader.Object);
    List<string> lines = processor.ProduceLines();

    // Assert
    Assert.That(lines[0], Is.EqualTo("1: 50"));
    Assert.That(lines[1], Is.EqualTo("2: 60"));
    Assert.That(lines[2], Is.EqualTo("3: 70"));
    Assert.That(lines[3], Is.EqualTo("Invalid value"));
    Assert.That(lines[4], Is.EqualTo("4: 80"));
    Assert.That(lines[5], Is.EqualTo("Sum: 260"));
    Assert.That(lines[6], Is.EqualTo("Average: 65"));
    Assert.That(lines.Count, Is.EqualTo(7));
  }
}