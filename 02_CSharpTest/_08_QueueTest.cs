using DataStructures.Queue;
using NuGet.Frameworks;

namespace Tests.Queue;

public class QueueTests
{

  [Test]
  public void QueueWitoutCapacityTest()
  {
    var queue = new MyQueue();
    Assert.That(queue.IsEmpty, Is.True);
    Assert.That(queue.Capacity, Is.EqualTo(int.MaxValue));
    Assert.That(queue.Length, Is.EqualTo(0));
    Assert.That(queue.IsFull, Is.False);
    Assert.Throws<InvalidOperationException>(() => { string s = queue.Peek; });
    Assert.Throws<InvalidOperationException>(() => { string s = queue.Dequeue(); });

    queue.Enqueue("a");
    Assert.That(queue.IsEmpty, Is.False);
    Assert.That(queue.Capacity, Is.EqualTo(int.MaxValue));
    Assert.That(queue.Length, Is.EqualTo(1));
    Assert.That(queue.IsFull, Is.False);

    Assert.That(queue.Peek, Is.EqualTo("a"));
    Assert.That(queue.IsEmpty, Is.False);
    Assert.That(queue.Length, Is.EqualTo(1));

    Assert.That(queue.Dequeue(), Is.EqualTo("a"));
    Assert.That(queue.IsEmpty, Is.True);
    Assert.That(queue.Length, Is.EqualTo(0));
    Assert.Throws<InvalidOperationException>(() => { string s = queue.Peek; });
    Assert.Throws<InvalidOperationException>(() => { string s = queue.Dequeue(); });

    queue.Enqueue("a");
    queue.Enqueue("b");
    queue.Enqueue("c");
    Assert.That(queue.Peek, Is.EqualTo("a"));
    Assert.That(queue.IsEmpty, Is.False);
    Assert.That(queue.Length, Is.EqualTo(3));

    Assert.That(queue.Dequeue(), Is.EqualTo("a"));
    Assert.That(queue.IsEmpty, Is.False);
    Assert.That(queue.Length, Is.EqualTo(2));

    Assert.That(queue.Peek, Is.EqualTo("b"));
    Assert.That(queue.Length, Is.EqualTo(2));
    Assert.That(queue.Dequeue(), Is.EqualTo("b"));
    Assert.That(queue.IsEmpty, Is.False);
    Assert.That(queue.Length, Is.EqualTo(1));

    Assert.That(queue.Peek, Is.EqualTo("c"));
    Assert.That(queue.Length, Is.EqualTo(1));
    Assert.That(queue.Dequeue(), Is.EqualTo("c"));
    Assert.That(queue.IsEmpty, Is.True);
    Assert.That(queue.Length, Is.EqualTo(0));

    Assert.Throws<InvalidOperationException>(() => { string s = queue.Peek; });
    Assert.Throws<InvalidOperationException>(() => { string s = queue.Dequeue(); });

    queue = new MyQueue();
    for (int i = 1; i <= 100; i++)
    {
      queue.Enqueue($"Item_{i}");
      Assert.That(queue.Length, Is.EqualTo(i));
      Assert.That(queue.IsEmpty, Is.False);
    }
    Assert.That(queue.Length, Is.EqualTo(100));
    for (int i = 1; i <= 100; i++)
    {
      string value = queue.Dequeue();
      Assert.That(value, Is.EqualTo($"Item_{i}"));
      Assert.That(queue.Length, Is.EqualTo(100 - i));
    }
    Assert.That(queue.IsEmpty, Is.True);
    Assert.That(queue.Length, Is.EqualTo(0));

  }

  [Test]
  public void QueueWithCapacityTest()
  {
    var queue = new MyQueue(10);
    for (int i = 0; i < 10; i++)
    {
      queue.Enqueue($"Item_{i}");
    }
    Assert.That(queue.IsFull, Is.True);
    Assert.Throws<InvalidOperationException>(() => queue.Enqueue("XXX"));
  }
}