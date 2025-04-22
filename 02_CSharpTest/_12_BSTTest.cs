using DataStructures.BinarySearchTree;

namespace Tests.BinarySearchTree;

public class BSTTest
{

  [Test]
  public void BstTest()
  {
    var bst = new BST();

    Assert.That(bst.Exists(50), Is.False);

    Assert.That(bst.Count, Is.EqualTo(0));
    bst.Add(50);
    Assert.That(bst.Count, Is.EqualTo(1));
    bst.Add(50);
    Assert.That(bst.Count, Is.EqualTo(1));
    bst.Add(25);
    Assert.That(bst.Count, Is.EqualTo(2));
    bst.Add(12);
    Assert.That(bst.Count, Is.EqualTo(3));
    bst.Add(35);
    Assert.That(bst.Count, Is.EqualTo(4));
    bst.Add(75);
    Assert.That(bst.Count, Is.EqualTo(5));
    bst.Add(65);
    Assert.That(bst.Count, Is.EqualTo(6));
    bst.Add(90);
    Assert.That(bst.Count, Is.EqualTo(7));
    bst.Add(85);
    Assert.That(bst.Count, Is.EqualTo(8));
    bst.Add(100);
    Assert.That(bst.Count, Is.EqualTo(9));
    bst.Add(35);
    Assert.That(bst.Count, Is.EqualTo(9));
    bst.Add(47);
    Assert.That(bst.Count, Is.EqualTo(10));
    bst.Add(5);
    Assert.That(bst.Count, Is.EqualTo(11));
    bst.Add(6);
    Assert.That(bst.Count, Is.EqualTo(12));

    var inOrder = bst.TraverseInOrder();
    var inOrderExpected = new List<int> { 5, 6, 12, 25, 35, 47, 50, 65, 75, 85, 90, 100 };
    Assert.That(inOrder, Is.EqualTo(inOrderExpected));

    var preOrder = bst.TraversePreOrder();
    var preOrderExpected = new List<int> { 50, 25, 12, 5, 6, 35, 47, 75, 65, 90, 85, 100 };
    Assert.That(preOrder, Is.EqualTo(preOrderExpected));

    var postOrder = bst.TraversePostOrder();
    var postOrderExpected = new List<int> { 6, 5, 12, 47, 35, 25, 65, 85, 100, 90, 75, 50 };
    Assert.That(postOrder, Is.EqualTo(postOrderExpected));

    Assert.That(bst.Exists(50), Is.True);
    Assert.That(bst.Exists(47), Is.True);
    Assert.That(bst.Exists(100), Is.True);
    Assert.That(bst.Exists(6), Is.True);
    Assert.That(bst.Exists(1), Is.False);
    Assert.That(bst.Exists(91), Is.False);
    Assert.That(bst.Exists(10), Is.False);

    foreach (var n in inOrderExpected)
    {
      Assert.That(bst.Exists(n), Is.True);
    }
  }
}