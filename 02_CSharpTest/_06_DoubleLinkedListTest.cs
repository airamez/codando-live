using NUnit.Framework;
using DataStructures.DoubleLinkedList;

namespace Tests;

public class DoubleLinkedListTests
{
  [Test]
  public void AddAtHeadTest()
  {
    var list = new MyDoubleLinkedList();
    Assert.That(list.Count, Is.EqualTo(0));
    Assert.That(list.Head, Is.Null);
    Assert.That(list.Tail, Is.Null);

    string NodeZeroValue = "Node 0";
    list.AddAtHead(NodeZeroValue);
    Assert.That(list.Count, Is.EqualTo(1));
    Assert.That(list.Head.Data, Is.EqualTo(NodeZeroValue));
    Assert.That(list.Tail.Data, Is.EqualTo(NodeZeroValue));

    string NodeOneValue = "Node 1";
    list.AddAtHead(NodeOneValue);
    Assert.That(list.Count, Is.EqualTo(2));
    Assert.That(list.Head.Data, Is.EqualTo(NodeOneValue));
    Assert.That(list.Tail.Data, Is.EqualTo(NodeZeroValue));

    string NodeTwoValue = "Node 2";
    list.AddAtHead(NodeTwoValue);
    Assert.That(list.Count, Is.EqualTo(3));
    Assert.That(list.Head.Data, Is.EqualTo(NodeTwoValue));
    Assert.That(list.Tail.Data, Is.EqualTo(NodeZeroValue));
    Assert.That(list.Head.Next.Data, Is.EqualTo(NodeOneValue));

    string NodeThreeValue = "Node 3";
    list.AddAtHead(NodeThreeValue);
    Assert.That(list.Count, Is.EqualTo(4));
    Assert.That(list.Head.Data, Is.EqualTo(NodeThreeValue));
    Assert.That(list.Head.Next.Data, Is.EqualTo(NodeTwoValue));
    Assert.That(list.Head.Next.Next.Data, Is.EqualTo(NodeOneValue));
  }

  [Test]
  public void AddAtTailtest()
  {
    var list = new MyDoubleLinkedList();
    Assert.That(list.Count, Is.EqualTo(0));
    Assert.That(list.Head, Is.Null);
    Assert.That(list.Tail, Is.Null);

    string nodeZeroValue = "Node 0";
    string nodeOneValue = "Node 1";
    string nodeTwoValue = "Node 2";
    string nodeThreeValue = "Node 3";

    list.AddAtTail(nodeZeroValue);
    Assert.That(list.Count, Is.EqualTo(1));
    Assert.That(list.Head.Data, Is.EqualTo(nodeZeroValue));
    Assert.That(list.Tail.Data, Is.EqualTo(nodeZeroValue));
    Assert.That(list.Head, Is.SameAs(list.Tail));

    list.AddAtTail(nodeOneValue);
    Assert.That(list.Count, Is.EqualTo(2));
    Assert.That(list.Head.Data, Is.EqualTo(nodeZeroValue));
    Assert.That(list.Tail.Data, Is.EqualTo(nodeOneValue));
    Assert.That(list.Tail.Previous.Data, Is.EqualTo(nodeZeroValue));
    Assert.That(list.Tail.Previous, Is.SameAs(list.Head));

    list.AddAtTail(nodeTwoValue);
    Assert.That(list.Count, Is.EqualTo(3));
    Assert.That(list.Head.Data, Is.EqualTo(nodeZeroValue));
    Assert.That(list.Tail.Data, Is.EqualTo(nodeTwoValue));
    Assert.That(list.Tail.Previous.Data, Is.EqualTo(nodeOneValue));

    list.AddAtTail(nodeThreeValue);
    Assert.That(list.Count, Is.EqualTo(4));
    Assert.That(list.Head.Data, Is.EqualTo(nodeZeroValue));
    Assert.That(list.Tail.Data, Is.EqualTo(nodeThreeValue));
    Assert.That(list.Tail.Previous.Data, Is.EqualTo(nodeTwoValue));
  }

  [Test]
  public void GetAtIndexOutOfRangeTest()
  {
    var list = new MyDoubleLinkedList();
    Assert.Throws<IndexOutOfRangeException>(() => list.GetAtIndex(-1));
    Assert.Throws<IndexOutOfRangeException>(() => list.GetAtIndex(7));
    Assert.Throws<IndexOutOfRangeException>(() => list.GetAtIndex(8));
  }

  [Test]
  public void GetAtIndexHeadTest()
  {
    var list = new MyDoubleLinkedList();
    for (int i = 0; i < 7; i++)
    {
      list.AddAtTail($"Node {i}");
    }
    Assert.That(list.GetAtIndex(0).Data, Is.EqualTo($"Node 0"));
  }

  [Test]
  public void GetAtIndexTailTest()
  {
    var list = new MyDoubleLinkedList();
    for (int i = 0; i < 7; i++)
    {
      list.AddAtTail($"Node {i}");
    }
    Assert.That(list.GetAtIndex(list.Count - 1).Data, Is.EqualTo($"Node 6"));
  }

  [Test]
  public void GetAtIndexTest()
  {
    var list = new MyDoubleLinkedList();
    for (int i = 0; i < 100; i++)
    {
      list.AddAtTail($"Node {i}");
    }
    for (int i = 0; i < 100; i++)
    {
      Assert.That(list.GetAtIndex(i).Data, Is.EqualTo($"Node {i}"));
    }
  }

  [Test]
  public void GetAtIndexTestCornerCaseWithTwoNodes()
  {
    var list = new MyDoubleLinkedList();
    list.AddAtTail("A");
    list.AddAtTail("B");
    list.AddAtTail("C");

    Assert.That(list.GetAtIndex(0).Data, Is.EqualTo("A"));
    Assert.That(list.GetAtIndex(1).Data, Is.EqualTo("B"));
    Assert.That(list.GetAtIndex(2).Data, Is.EqualTo("C"));
  }

  [Test]
  public void AdddAtIndexTest()
  {
    // 0     1       2      3
    // A <-> A2 <->  B0 <-> B

    var list = new MyDoubleLinkedList();

    list.AddAtIndex(0, "B");
    Assert.That(list.Count, Is.EqualTo(1));
    Assert.That(list.Head.Data, Is.EqualTo("B"));
    Assert.That(list.Tail.Data, Is.EqualTo("B"));

    list.AddAtIndex(0, "A");
    Assert.That(list.Count, Is.EqualTo(2));
    Assert.That(list.Head.Data, Is.EqualTo("A"));
    Assert.That(list.Tail.Data, Is.EqualTo("B"));
    Assert.That(list.Head.Next, Is.EqualTo(list.Tail));
    Assert.That(list.Tail.Previous, Is.EqualTo(list.Head));

    list.AddAtIndex(1, "A2");
    Assert.That(list.Count, Is.EqualTo(3));
    Assert.That(list.Head.Data, Is.EqualTo("A"));
    Assert.That(list.Tail.Data, Is.EqualTo("B"));
    Assert.That(list.GetAtIndex(1).Data, Is.EqualTo("A2"));

    list.AddAtIndex(2, "B0");
    Assert.That(list.Count, Is.EqualTo(4));
    Assert.That(list.Head.Data, Is.EqualTo("A"));
    Assert.That(list.Tail.Data, Is.EqualTo("B"));
    Assert.That(list.GetAtIndex(1).Data, Is.EqualTo("A2"));
    Assert.That(list.GetAtIndex(2).Data, Is.EqualTo("B0"));

    Assert.Throws<IndexOutOfRangeException>(() => list.AddAtIndex(-1, "XXX"));
    Assert.Throws<IndexOutOfRangeException>(() => list.AddAtIndex(20, "XXX"));
  }

  [Test]
  public void RemoveAtHeadTest()
  {
    var list = new MyDoubleLinkedList();
    Assert.Throws<InvalidOperationException>(() => list.RemoveAtHead());

    const int LIST_SIZE = 10;
    for (int i = 0; i < LIST_SIZE; i++)
    {
      list.AddAtTail($"Node {i}");
    }

    for (int i = 0; i < LIST_SIZE; i++)
    {
      list.RemoveAtHead();
      Assert.That(list.Count, Is.EqualTo(LIST_SIZE - (i + 1)));
      if (i < LIST_SIZE - 1)
      {
        Assert.That(list.Head.Data, Is.EqualTo($"Node {i + 1}"));
      }
      else
      {
        Assert.That(list.Head, Is.Null);
      }
    }
  }

  [Test]
  public void RemoveAtTailTest()
  {
    var list = new MyDoubleLinkedList();

    Assert.Throws<InvalidOperationException>(() => list.RemoveAtTail());

    Assert.That(list.IsEmpty, Is.True);
    list.AddAtHead("1");
    Assert.That(list.IsEmpty, Is.False);
    list.AddAtTail("2");
    list.AddAtTail("3");
    list.AddAtTail("4");
    list.AddAtTail("5");
    Assert.That(list.Count, Is.EqualTo(5));
    Assert.That(list.Head.Previous, Is.Null);

    list.RemoveAtTail();
    Assert.That(list.Count, Is.EqualTo(4));
    Assert.That(list.Tail.Data, Is.EqualTo("4"));
    Assert.That(list.Tail.Next, Is.Null);

    list.RemoveAtTail();
    Assert.That(list.Count, Is.EqualTo(3));
    Assert.That(list.Tail.Data, Is.EqualTo("3"));
    Assert.That(list.Tail.Next, Is.Null);

    list.RemoveAtTail();
    Assert.That(list.Count, Is.EqualTo(2));
    Assert.That(list.Tail.Data, Is.EqualTo("2"));
    Assert.That(list.Tail.Next, Is.Null);

    list.RemoveAtTail();
    Assert.That(list.Count, Is.EqualTo(1));
    Assert.That(list.Tail.Data, Is.EqualTo("1"));
    Assert.That(list.Tail.Next, Is.Null);
    Assert.That(list.Head.Previous, Is.Null);

    list.RemoveAtTail();
    Assert.Throws<InvalidOperationException>(() => list.RemoveAtTail());
    Assert.That(list.IsEmpty, Is.True);
    Assert.That(list.Count, Is.EqualTo(0));
  }

  [Test]
  public void RemoveAtIndexTest()
  {
    var list = new MyDoubleLinkedList();
    // Remove on an empty list
    Assert.Throws<IndexOutOfRangeException>(() => list.RemoveAtIndex(5));
    // Remove with an invalid index
    Assert.Throws<IndexOutOfRangeException>(() => list.RemoveAtIndex(-5));

    list.AddAtTail("Node 1");
    // Remove with an invalid index
    Assert.Throws<IndexOutOfRangeException>(() => list.RemoveAtIndex(1));
    // Remove with an invalid index
    Assert.Throws<IndexOutOfRangeException>(() => list.RemoveAtIndex(5));
    // Remove when there only one node / At Head
    list.RemoveAtIndex(0);
    Assert.That(list.Count, Is.EqualTo(0));
    Assert.That(list.Head, Is.Null);
    Assert.That(list.IsEmpty, Is.True);
    Assert.Throws<IndexOutOfRangeException>(() => list.RemoveAtIndex(0));

    list.AddAtTail("Node 1");
    list.AddAtTail("Node 2");
    list.AddAtTail("Node 3");
    list.AddAtTail("Node 4");
    list.AddAtTail("Node 5");

    // Remove at Head
    list.RemoveAtIndex(0);
    Assert.That(list.Head.Previous, Is.Null);
    Assert.That(list.Count, Is.EqualTo(4));
    Assert.That(list.IsEmpty, Is.False);
    Assert.That(list.Head.Data, Is.EqualTo("Node 2"));
    Assert.That(list.Tail.Data, Is.EqualTo("Node 5"));

    // Remove at At
    list.AddAtHead("Node 1");
    list.RemoveAtIndex(2);
    Assert.That(list.Count, Is.EqualTo(4));
    Assert.That(list.Head.Next.Next.Data, Is.EqualTo("Node 4"));

    // Remove at Tail
    list.RemoveAtIndex(list.Count - 1);
    Assert.That(list.Count, Is.EqualTo(3));
    Assert.That(list.Tail.Data, Is.EqualTo("Node 4"));
  }
}