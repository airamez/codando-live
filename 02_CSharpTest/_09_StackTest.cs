using DataStructures.Stack;

namespace Tests.Stack;

public class StackTests
{

  [Test]
  public void StackWitoutCapacityTest()
  {
    var queue = new MyStack();
    Assert.That(queue.IsEmpty, Is.True);
    Assert.That(queue.Capacity, Is.EqualTo(int.MaxValue));
    Assert.That(queue.Length, Is.EqualTo(0));
    Assert.That(queue.IsFull, Is.False);
    Assert.Throws<InvalidOperationException>(() => { string s = queue.Peek; });
    Assert.Throws<InvalidOperationException>(() => { string s = queue.Pop(); });

    queue.Push("a");
    Assert.That(queue.IsEmpty, Is.False);
    Assert.That(queue.Capacity, Is.EqualTo(int.MaxValue));
    Assert.That(queue.Length, Is.EqualTo(1));
    Assert.That(queue.IsFull, Is.False);
    Assert.That(queue.Peek, Is.EqualTo("a"));
    Assert.That(queue.IsEmpty, Is.False);
    Assert.That(queue.Length, Is.EqualTo(1));

    Assert.That(queue.Pop(), Is.EqualTo("a"));
    Assert.That(queue.IsEmpty, Is.True);
    Assert.That(queue.Length, Is.EqualTo(0));
    Assert.Throws<InvalidOperationException>(() => { string s = queue.Peek; });
    Assert.Throws<InvalidOperationException>(() => { string s = queue.Pop(); });

    // c
    queue.Push("c");
    queue.Push("b");
    queue.Push("a");
    Assert.That(queue.Peek, Is.EqualTo("a"));
    Assert.That(queue.IsEmpty, Is.False);
    Assert.That(queue.Length, Is.EqualTo(3));

    Assert.That(queue.Pop(), Is.EqualTo("a"));
    Assert.That(queue.IsEmpty, Is.False);
    Assert.That(queue.Length, Is.EqualTo(2));

    Assert.That(queue.Peek, Is.EqualTo("b"));
    Assert.That(queue.Length, Is.EqualTo(2));
    Assert.That(queue.Pop(), Is.EqualTo("b"));
    Assert.That(queue.IsEmpty, Is.False);
    Assert.That(queue.Length, Is.EqualTo(1));

    Assert.That(queue.Peek, Is.EqualTo("c"));
    Assert.That(queue.Length, Is.EqualTo(1));
    Assert.That(queue.Pop(), Is.EqualTo("c"));
    Assert.That(queue.IsEmpty, Is.True);
    Assert.That(queue.Length, Is.EqualTo(0));

    Assert.Throws<InvalidOperationException>(() => { string s = queue.Peek; });
    Assert.Throws<InvalidOperationException>(() => { string s = queue.Pop(); });

    queue = new MyStack();
    for (int i = 1; i <= 100; i++)
    {
      queue.Push($"Item_{i}");
      Assert.That(queue.Length, Is.EqualTo(i));
      Assert.That(queue.IsEmpty, Is.False);
    }
    Assert.That(queue.Length, Is.EqualTo(100));
    for (int i = 1; i <= 100; i++)
    {
      string value = queue.Pop();
      Assert.That(value, Is.EqualTo($"Item_{101 - i}"));
      Assert.That(queue.Length, Is.EqualTo(100 - i));
    }
    Assert.That(queue.IsEmpty, Is.True);
    Assert.That(queue.Length, Is.EqualTo(0));
  }

  [Test]
  public void StackWithCapacityTest()
  {
    var queue = new MyStack(10);
    for (int i = 0; i < 10; i++)
    {
      queue.Push($"Item_{i}");
    }
    Assert.That(queue.IsFull, Is.True);
    Assert.Throws<InvalidOperationException>(() => queue.Push("XXX"));
  }
}