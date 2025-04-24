using NUnit.Framework;
using DataStructures.LinkedList;

namespace Tests;

public class LinkedListTests
{
    [Test]
    public void AddAtHeadTest()
    {
        LinkedList linkedList = new LinkedList();
        linkedList.AddAtHead("Node 1");
        Assert.That(linkedList.Head.Data, Is.EqualTo("Node 1"));
        linkedList.AddAtHead("Node 2");
        Assert.That(linkedList.Head.Data, Is.EqualTo("Node 2"));
        linkedList.AddAtHead("Node 3");
        Assert.That(linkedList.Head.Data, Is.EqualTo("Node 3"));

        Node first = linkedList.Head;
        Node second = first.Next;
        Node third = second.Next;
        Assert.That(first.Data, Is.EqualTo("Node 3"));
        Assert.That(second.Data, Is.EqualTo("Node 2"));
        Assert.That(third.Data, Is.EqualTo("Node 1"));
    }

    [Test]
    public void CountTest()
    {
        LinkedList linkedList = new LinkedList();
        Assert.That(linkedList.Count, Is.EqualTo(0));
        linkedList.AddAtHead("Node 1");
        Assert.That(linkedList.Count, Is.EqualTo(1));
        linkedList.AddAtHead("Node 2");
        Assert.That(linkedList.Count, Is.EqualTo(2));
        linkedList.AddAtHead("Node 3");
        Assert.That(linkedList.Count, Is.EqualTo(3));
    }

    [Test]
    public void AddAtTailTest()
    {
        LinkedList linkedList = new LinkedList();
        linkedList.AddAtTail("Node 1");
        Assert.That(linkedList.Tail.Data, Is.EqualTo("Node 1"));
        linkedList.AddAtTail("Node 2");
        Assert.That(linkedList.Tail.Data, Is.EqualTo("Node 2"));
        linkedList.AddAtTail("Node 3");
        Assert.That(linkedList.Tail.Data, Is.EqualTo("Node 3"));
    }

    [Test]
    public void GetTestInvalidIndexes()
    {
        LinkedList linkedList = new LinkedList();
        linkedList.AddAtTail("Node 0");
        linkedList.AddAtTail("Node 1");
        linkedList.AddAtTail("Node 2");
        linkedList.AddAtTail("Node 3");
        linkedList.AddAtTail("Node 4");
        Assert.Throws<IndexOutOfRangeException>(() => linkedList.Get(-5));
        Assert.Throws<IndexOutOfRangeException>(() => linkedList.Get(linkedList.Count));
        Assert.Throws<IndexOutOfRangeException>(() => linkedList.Get(5));
        Assert.Throws<IndexOutOfRangeException>(() => linkedList.Get(10));
    }

    [Test]
    public void GetTestHead()
    {
        LinkedList linkedList = new LinkedList();
        linkedList.AddAtTail("Node 0");
        linkedList.AddAtTail("Node 1");
        linkedList.AddAtTail("Node 2");
        linkedList.AddAtTail("Node 3");
        linkedList.AddAtTail("Node 4");
        Assert.That(linkedList.Get(0).Data, Is.EqualTo("Node 0"));
    }

    [Test]
    public void GetTestTail()
    {
        LinkedList linkedList = new LinkedList();
        linkedList.AddAtTail("Node 0");
        linkedList.AddAtTail("Node 1");
        linkedList.AddAtTail("Node 2");
        linkedList.AddAtTail("Node 3");
        linkedList.AddAtTail("Node 4");
        Assert.That(linkedList.Get(linkedList.Count - 1).Data, Is.EqualTo("Node 4"));
    }

    [Test]
    public void GetTestMiddle()
    {
        LinkedList linkedList = new LinkedList();
        linkedList.AddAtTail("Node 0");
        linkedList.AddAtTail("Node 1");
        linkedList.AddAtTail("Node 2");
        linkedList.AddAtTail("Node 3");
        linkedList.AddAtTail("Node 4");
        Assert.That(linkedList.Get(1).Data, Is.EqualTo("Node 1"));
        Assert.That(linkedList.Get(2).Data, Is.EqualTo("Node 2"));
        Assert.That(linkedList.Get(3).Data, Is.EqualTo("Node 3"));
    }

    [Test]
    public void AddAtIndex0()
    {
        LinkedList linkedList = new LinkedList();
        linkedList.AddAt("Node 1", 0);
        Assert.That(linkedList.Head.Data, Is.EqualTo("Node 1"));
        Assert.That(linkedList.Count, Is.EqualTo(1));
        linkedList.AddAt("Node 0", 0);
        Assert.That(linkedList.Head.Data, Is.EqualTo("Node 0"));
        Assert.That(linkedList.Count, Is.EqualTo(2));
        Assert.That(linkedList.Tail.Data, Is.EqualTo("Node 1"));
    }

    [Test]
    public void AddAtNegativeIndex()
    {
        LinkedList linkedList = new LinkedList();
        Assert.Throws<IndexOutOfRangeException>(() => linkedList.AddAt("Node -1", -1));
    }

    [Test]
    public void AddAtOutOfIndex()
    {
        LinkedList linkedList = new LinkedList();
        Assert.Throws<IndexOutOfRangeException>(() => linkedList.AddAt("Node 0", 1));
        linkedList.AddAt("Node 0", 0);
        Assert.That(linkedList.Head.Data, Is.EqualTo("Node 0"));
        Assert.Throws<IndexOutOfRangeException>(() => linkedList.AddAt("Node 0", 2));
        Assert.Throws<IndexOutOfRangeException>(() => linkedList.AddAt("Node 5", 5));
    }

    [Test]
    public void AddAtLength()
    {
        LinkedList linkedList = new LinkedList();
        linkedList.AddAt("Node 0", 0);
        Assert.That(linkedList.Head.Data, Is.EqualTo("Node 0"));
        linkedList.AddAt("Node 1", 1);
        Assert.That(linkedList.Get(1).Data, Is.EqualTo("Node 1"));
        linkedList.AddAt("Node 2", 2);
        Assert.That(linkedList.Tail.Data, Is.EqualTo("Node 2"));
        linkedList.AddAt("Node 3", 3);
        Assert.That(linkedList.Get(3).Data, Is.EqualTo("Node 3"));
    }

    [Test]
    public void AddAtMiddle()
    {
        LinkedList linkedList = new LinkedList();
        linkedList.AddAtTail("Node 0");
        linkedList.AddAtTail("Node 1");
        linkedList.AddAtTail("Node 3");
        linkedList.AddAtTail("Node 5");
        linkedList.AddAtTail("Node 7");
        linkedList.AddAt("Node 2", 2);
        Assert.That(linkedList.Get(2).Data, Is.EqualTo("Node 2"));
        Assert.That(linkedList.Count, Is.EqualTo(6));
        linkedList.AddAt("Node 4", 4);
        Assert.That(linkedList.Get(4).Data, Is.EqualTo("Node 4"));
        Assert.That(linkedList.Count, Is.EqualTo(7));
        linkedList.AddAt("Node 6", 6);
        Assert.That(linkedList.Get(6).Data, Is.EqualTo("Node 6"));
        Assert.That(linkedList.Count, Is.EqualTo(8));
    }

    [Test]
    public void DeleteAtHeadTest()
    {
        LinkedList linkedList = new LinkedList();
        Assert.Throws<InvalidOperationException>(() =>
            linkedList.DeleteAtHead());
        linkedList.AddAtTail("Node 0");
        linkedList.AddAtTail("Node 1");
        linkedList.AddAtTail("Node 2");
        // Indixes : 0 1 2
        // Elements: 
        Assert.That(linkedList.Count, Is.EqualTo(3));
        linkedList.DeleteAtHead();
        Assert.That(linkedList.Count, Is.EqualTo(2));
        Assert.That(linkedList.Head.Data, Is.EqualTo("Node 1"));
        linkedList.DeleteAtHead();
        Assert.That(linkedList.Count, Is.EqualTo(1));
        Assert.That(linkedList.Head.Data, Is.EqualTo("Node 2"));
        Assert.That(linkedList.Tail.Data, Is.EqualTo("Node 2"));
        linkedList.DeleteAtHead();
        Assert.That(linkedList.Count, Is.EqualTo(0));
        Assert.That(linkedList.Head, Is.Null);
        Assert.That(linkedList.Tail, Is.Null);
        Assert.Throws<InvalidOperationException>(() =>
            linkedList.DeleteAtHead());
    }

    [Test]
    public void DeleteAtTailTest()
    {
        LinkedList linkedList = new LinkedList();
        Assert.Throws<InvalidOperationException>(() =>
            linkedList.DeleteAtTail());
        linkedList.AddAtTail("Node 0");
        linkedList.AddAtTail("Node 1");
        linkedList.AddAtTail("Node 2");
        Assert.That(linkedList.Count, Is.EqualTo(3));
        linkedList.DeleteAtTail();
        Assert.That(linkedList.Count, Is.EqualTo(2));
        Assert.That(linkedList.Tail.Data, Is.EqualTo("Node 1"));
        linkedList.DeleteAtTail();
        Assert.That(linkedList.Count, Is.EqualTo(1));
        Assert.That(linkedList.Tail.Data, Is.EqualTo("Node 0"));
        linkedList.DeleteAtTail();
        Assert.That(linkedList.Count, Is.EqualTo(0));
        Assert.That(linkedList.Head, Is.Null);
        Assert.That(linkedList.Tail, Is.Null);
        Assert.Throws<InvalidOperationException>(() =>
            linkedList.DeleteAtTail());
    }

    [Test]
    public void DeleteAtIndexTest()
    {
        LinkedList linkedList = new LinkedList();
        Assert.Throws<IndexOutOfRangeException>(() => linkedList.DeleteAt(-1));
        Assert.Throws<IndexOutOfRangeException>(() => linkedList.DeleteAt(0));
        Assert.Throws<IndexOutOfRangeException>(() => linkedList.DeleteAt(1));
        linkedList.AddAtTail("Node 0");
        linkedList.AddAtTail("Node 1");
        linkedList.AddAtTail("Node 2");
        linkedList.AddAtTail("Node 3");
        linkedList.AddAtTail("Node 4");
        Assert.Throws<IndexOutOfRangeException>(() => linkedList.DeleteAt(5));
        Assert.Throws<IndexOutOfRangeException>(() => linkedList.DeleteAt(10));
        Assert.That(linkedList.Count, Is.EqualTo(5));
        linkedList.DeleteAt(2);
        Assert.That(linkedList.Count, Is.EqualTo(4));
        Assert.That(linkedList.Get(2).Data, Is.EqualTo("Node 3"));
        linkedList.DeleteAt(0);
        Assert.That(linkedList.Count, Is.EqualTo(3));
        Assert.That(linkedList.Head.Data, Is.EqualTo("Node 1"));
        Assert.That(linkedList.Get(0).Data, Is.EqualTo("Node 1"));
        linkedList.DeleteAt(2);
        Assert.That(linkedList.Count, Is.EqualTo(2));
        Assert.That(linkedList.Head.Data, Is.EqualTo("Node 1"));
        Assert.That(linkedList.Tail.Data, Is.EqualTo("Node 3"));
        linkedList.DeleteAt(1);
        Assert.That(linkedList.Count, Is.EqualTo(1));
        Assert.That(linkedList.Tail.Data, Is.EqualTo("Node 1"));
        Assert.That(linkedList.Head.Data, Is.EqualTo("Node 1"));
        Assert.That(linkedList.Get(0).Data, Is.EqualTo("Node 1"));
        linkedList.DeleteAt(0);
        Assert.That(linkedList.Count, Is.EqualTo(0));
        Assert.That(linkedList.Head, Is.Null);
        Assert.That(linkedList.Tail, Is.Null);
    }
}
