using DataStructures.Set;

namespace Tests.Set;

public class SetTests
{

  [Test]
  public void SetTest()
  {
    var mySet = new MySet(100);

    Assert.That(mySet.Size, Is.EqualTo(0));

    mySet.Add(5);
    Assert.That(mySet.Size, Is.EqualTo(1));
    mySet.Add(5);
    Assert.That(mySet.Size, Is.EqualTo(1));
    mySet.Remove(5);
    Assert.That(mySet.Size, Is.EqualTo(0));
    mySet.Remove(5);
    Assert.That(mySet.Size, Is.EqualTo(0));

    mySet.Add(1);
    Assert.That(mySet.Size, Is.EqualTo(1));
    mySet.Add(3);
    Assert.That(mySet.Size, Is.EqualTo(2));
    mySet.Add(5);
    Assert.That(mySet.Size, Is.EqualTo(3));
    mySet.Add(7);
    Assert.That(mySet.Size, Is.EqualTo(4));

    Assert.That(mySet.Contains(1), Is.True);
    Assert.That(mySet.Contains(2), Is.False);
    Assert.That(mySet.Contains(3), Is.True);
    Assert.That(mySet.Contains(4), Is.False);
    Assert.That(mySet.Contains(5), Is.True);
    Assert.That(mySet.Contains(6), Is.False);
    Assert.That(mySet.Contains(7), Is.True);
    Assert.That(mySet.Contains(8), Is.False);

    Assert.Throws<InvalidOperationException>(() => mySet.Add(100));
    Assert.Throws<InvalidOperationException>(() => mySet.Add(101));
    Assert.Throws<InvalidOperationException>(() => mySet.Add(500));
    Assert.Throws<InvalidOperationException>(() => mySet.Add(-1));
  }
}