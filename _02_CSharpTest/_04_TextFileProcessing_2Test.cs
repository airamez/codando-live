using System;
using System.IO;
using System.Collections.Generic;
using NUnit.Framework;
using UnitTesting2;
using Moq;

[TestFixture]
public class TextFileProcessing_2Test
{
  [Test]
  public void TestProduceLines()
  {
    // Arrange
    TextFileProcessor processor = new TextFileProcessor("InputFile.txt");

    // Act
    List<string> lines = processor.ProduceLines();

    // Assert
    Assert.That(lines[0], Is.EqualTo("1: 50"));
    Assert.That(lines[1], Is.EqualTo("2: 60"));
    Assert.That(lines[2], Is.EqualTo("3: 70"));
    Assert.That(lines[3], Is.EqualTo("Invalid number!"));
    Assert.That(lines[4], Is.EqualTo("4: 80"));
    Assert.That(lines[5], Is.EqualTo("Sum: 260"));
    Assert.That(lines[6], Is.EqualTo("Average: 65"));
    Assert.That(lines.Count, Is.EqualTo(7));
  }
}