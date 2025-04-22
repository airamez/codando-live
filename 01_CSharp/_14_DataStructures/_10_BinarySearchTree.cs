/*
# Binary Search Tree (BST)
  # Definition:
    * A Binary Search Tree is a binary tree data structure where for all nodes: 
      * The left subtree’s keys are less than the node’s key, and
      * The right subtree’s keys are greater than the node’s key.
      * These properties apply recursively for all nodes in the tree.
  # Usage: 
    * BSTs are commonly used in computer science for efficient searching and sorting of data.
      They allow for fast lookup, addition, and removal of items, and can be used to implement
      dynamic sets and lookup tables.
    * OBS: A BST can be unbalanced and provide poor performance like a list
*/
using System;
using System.Collections.Generic;
using System.Linq;
namespace DataStructures.BinarySearchTree;

public class BinarySearchTreeApp
{
  public static void Main(string[] args)
  {
    Console.Clear();

    var testData = new List<int> { 50, 25, 12, 35, 75, 65, 90, 85, 100, 47, 5, 6, 40, 49, 4, 89 };
    var bst = InitBST(testData);

    bst.Print();

    Console.WriteLine($"\nRemoving: 500");
    bst.RemoveRecursive(500);
    bst.Print();

    Console.WriteLine($"\nRemoving: 4");
    bst.RemoveRecursive(4);
    bst.Print();

    Console.WriteLine($"\nRemoving: 49");
    bst = InitBST(testData);
    bst.RemoveRecursive(49);
    bst.Print();

    Console.WriteLine($"\nRemoving: 12");
    bst = InitBST(testData);
    bst.RemoveRecursive(12);
    bst.Print();

    Console.WriteLine($"\nRemoving: 25");
    bst = InitBST(testData);
    bst.RemoveRecursive(25);
    bst.Print();

    Console.WriteLine($"\nRemoving: 50");
    bst = InitBST(testData);
    bst.RemoveRecursive(50);
    bst.Print();

    // Not initing any more

    Console.WriteLine($"\nRemoving: 12");
    bst.RemoveRecursive(12);
    bst.Print();

    Console.WriteLine($"\nRemoving: 89");
    bst.RemoveRecursive(89);
    bst.Print();

    Console.WriteLine($"\nRemoving: 5");
    bst.RemoveRecursive(5);
    bst.Print();

    Console.WriteLine($"\nRemoving: 35");
    bst.RemoveRecursive(35);
    bst.Print();

    Console.WriteLine($"\nRemoving: 75");
    bst.RemoveRecursive(75);
    bst.Print();

    Console.WriteLine($"\nRemoving: 100");
    bst.RemoveRecursive(100);
    bst.Print();

    Console.WriteLine($"\nRemoving: 65");
    bst.RemoveRecursive(65);
    bst.Print();

    Console.WriteLine($"\nRemoving: 85");
    bst.RemoveRecursive(85);
    bst.Print();

    Console.WriteLine($"\nRemoving: 25");
    bst.RemoveRecursive(25);
    bst.Print();

    foreach (var value in testData)
    {
      Console.WriteLine($"\nRemoving: {value}");
      bst.RemoveRecursive(value);
      bst.Print();
    }
  }

  private static BST InitBST(List<int> data)
  {
    var bst = new BST();
    foreach (var value in data)
    {
      bst.Add(value);
    }
    return bst;
  }

  private static void PrintByLevel(BST bst)
  {
    var allLevels = bst.TraversePerLevel();
    Console.WriteLine("".PadLeft(50, '-'));
    Console.WriteLine($"Count: {bst.Count}");
    for (int level = 0; level < allLevels.Count; level++)
    {
      Console.Write($"Level {level}: ");
      foreach (var value in allLevels[level])
      {
        Console.Write($"{value} ");
      }
      Console.WriteLine();
    }
  }
}

public class BST
{
  Node root { set; get; }

  public int Count { private set; get; }

  public BST()
  {
    Count = 0;
    root = null;
  }

  public void Add(int value)
  {
    if (root == null)
    {
      root = new Node(value);
      Count = 1;
    }
    else
    {
      Add(root, value);
    }
  }

  private void Add(Node node, int value)
  {
    if (node.Data != value)
    {
      if (value < node.Data)
      {
        if (node.Left == null)
        {
          node.Left = new Node(value);
          Count++;
        }
        else
        {
          Add(node.Left, value);
        }
      }
      else
      {
        if (node.Right == null)
        {
          node.Right = new Node(value);
          Count++;
        }
        else
        {
          Add(node.Right, value);
        }
      }
    }
  }

  public bool Exists(int value)
  {
    return Exists(root, value);
  }

  private bool Exists(Node node, int value)
  {
    if (node == null)
    {
      return false;
    }

    if (node.Data == value)
    {
      return true;
    }

    if (value < node.Data)
    {
      return Exists(node.Left, value);
    }
    else
    {
      return Exists(node.Right, value);
    }
  }

  public List<int> TraverseInOrder()
  {
    var result = new List<int>();
    TraverseInOrder(root, result);
    return result;
  }

  private void TraverseInOrder(Node node, List<int> result)
  {
    if (node != null)
    {
      TraverseInOrder(node.Left, result);
      result.Add(node.Data);
      TraverseInOrder(node.Right, result);
    }
  }

  public List<int> TraversePreOrder()
  {
    var result = new List<int>();
    TraversePreOrder(root, result);
    return result;
  }

  private void TraversePreOrder(Node node, List<int> result)
  {
    if (node != null)
    {
      result.Add(node.Data);
      TraversePreOrder(node.Left, result);
      TraversePreOrder(node.Right, result);
    }
  }

  public List<int> TraversePostOrder()
  {
    var result = new List<int>();
    TraversePostOrder(root, result);
    return result;

  }

  private void TraversePostOrder(Node node, List<int> result)
  {
    if (node != null)
    {
      TraversePostOrder(node.Left, result);
      TraversePostOrder(node.Right, result);
      result.Add(node.Data);
    }
  }

  public List<List<int>> TraversePerLevel()
  {
    var result = new List<List<int>>();
    TraversePerLevel(root, result);
    return result;
  }

  public void TraversePerLevel(Node root, List<List<int>> result)
  {
    if (root == null)
    {
      return;
    }
    result.Add(new List<int>());
    var currentLevel = new Queue<Node>();
    var nextLevel = new Queue<Node>();
    currentLevel.Enqueue(root);
    while (currentLevel.Count > 0)
    {
      var node = currentLevel.Dequeue();
      result.Last().Add(node.Data);
      if (node.Left != null)
      {
        nextLevel.Enqueue(node.Left);
      }
      if (node.Right != null)
      {
        nextLevel.Enqueue(node.Right);
      }
      if (currentLevel.Count == 0 && nextLevel.Count > 0)
      {
        result.Add(new List<int>());
        currentLevel = nextLevel;
        nextLevel = new Queue<Node>();
      }
    }
  }

  private bool _nodeRemoved;
  public void RemoveRecursive(int value)
  {
    _nodeRemoved = false;
    root = RemoveRecursive(root, value);
    if (_nodeRemoved)
    {
      Count--;
    }
  }

  private Node RemoveRecursive(Node node, int value)
  {
    if (node == null) // not found
    {
      return null;
    }
    if (value < node.Data)
    {
      node.Left = RemoveRecursive(node.Left, value);
    }
    else if (value > node.Data)
    {
      node.Right = RemoveRecursive(node.Right, value);
    }
    else
    {
      _nodeRemoved = true;
      // Leaf
      if (node.Left == null && node.Right == null)
      {
        return null;
      }
      // Only right child
      if (node.Left == null)
      {
        return node.Right;
      }
      // Only left child
      if (node.Right == null) // Only left child
      {
        return node.Left;
      }
      // Both children
      node.Data = GetValueAndAdjustSuccessor(node);
    }
    return node;
  }

  public void RemoveNonRecursive(int value)
  {
    RemoveNonRecursive(root, value);
  }

  private void RemoveNonRecursive(Node root, int value)
  {
    if (root == null)
    {
      return;
    }

    Node target = root;
    Node parent = root;
    bool isTargetLeftChild = true; // flag to indicate if the target is on left o right

    while (target.Data != value)
    {
      parent = target; // set parent to current because we will move current one level down
      if (value < target.Data)  // Move left
      {
        target = target.Left;
        isTargetLeftChild = true;
      }
      else // Move right
      {
        target = target.Right;
        isTargetLeftChild = false;
      }
      if (target == null) // Value not found
        return;
    }
    Count--; // value found, decrement Count
    // Case 1: leaf = Left and Right equal to null
    if (target.Left == null && target.Right == null)
    {
      if (target == this.root) // Checking removing root
        this.root = null;
      else if (isTargetLeftChild) // Set the parent left to null
        parent.Left = null;
      else // set the parent right to null
        parent.Right = null;
    }
    // Case 3: Has two children = Left and Right not null
    else if (target.Left != null && target.Right != null)
    {
      // var successor = GetSuccessor(target); // Find the node to replace the target one
      // RemoveNonRecursive(target, successor);
      // target.Data = successor;
      target.Data = GetValueAndAdjustSuccessor(target);
    }
    else if (target.Left != null) // Has a subtree on Left
    {
      if (target == this.root) // If removing root
        this.root = target.Left;
      else if (isTargetLeftChild) // If the target node is on left of its parent
        parent.Left = target.Left;
      else // If the target node is on the right of its parent
        parent.Right = target.Left;
    }
    else // Has a subtree on Right
    {
      if (target == this.root) // If removing root
        this.root = target.Right;
      else if (isTargetLeftChild) // If the target node is on the left of its parent
        parent.Left = target.Right;
      else // If rarget node is on the right of its parent
        parent.Right = target.Right;
    }
  }

  // Return the successor value and adjust the successor parent left reference
  private int GetValueAndAdjustSuccessor(Node target)
  {
    Node successor = target.Right;
    Node parent = target;
    while (successor.Left != null)
    {
      parent = successor;
      successor = successor.Left;
    }
    // Corner case, if the successor is the right node of target
    if (parent == target)
    {
      parent.Right = successor.Right;
    }
    else
    {
      parent.Left = successor.Right;
    }
    return successor.Data;
  }

  private int GetSuccessor(Node target)
  {
    Node successor = target;
    Node current = target.Right; // runner
    while (current != null)
    {
      successor = current;
      current = current.Left; // move left
    }
    return successor.Data;
  }

  public void Print()
  {
    Console.WriteLine($"Count: {Count}");
    PrintPretty(root, "", true, "Root");
  }

  public void PrintPretty(Node node, string indent, bool last, string indicator)
  {
    if (node != null)
    {
      Console.Write(indent);
      if (last)
      {
        Console.Write("└─");
        indent += "  ";
      }
      else
      {
        Console.Write("├─");
        indent += "│ ";
      }
      Console.WriteLine($"{indicator}:{node.Data}");
      if (node.Left != null)
      {
        PrintPretty(node.Left, indent, node.Right == null, "L");
      }
      if (node.Right != null)
      {
        PrintPretty(node.Right, indent, true, "R");
      }
    }
  }
}

public class Node
{
  public int Data { set; get; }
  public Node Left { set; get; }
  public Node Right { set; get; }

  public Node(int data)
  {
    Data = data;
    Left = null;
    Right = null;
  }
}