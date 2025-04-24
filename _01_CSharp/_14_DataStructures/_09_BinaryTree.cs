using System;
using System.Collections.Generic;
namespace DataStructures.BinaryTree;

public class BinaryTreeApp
{
  public static void Main(string[] args)
  {
    Node root = new Node("A");
    root.Left = new Node("B");
    root.Right = new Node("C");
    root.Left.Left = new Node("D");
    root.Left.Right = new Node("E");
    root.Right.Left = new Node("F");
    root.Right.Right = new Node("G");
    root.Left.Left.Left = new Node("H");
    root.Left.Left.Right = new Node("I");
    root.Left.Right.Left = new Node("J");
    root.Left.Right.Right = new Node("K");
    root.Right.Left.Left = new Node("L");
    root.Right.Left.Right = new Node("M");
    root.Right.Right.Left = new Node("N");
    root.Right.Right.Right = new Node("O");

    ByLevelWithRecursion(root);

    Console.WriteLine();

    ByLevelWithoutRecursion(root);

    // InOrder(root);

    // Console.WriteLine();
    // foreach (var data in InOrderAsList(root))
    // {
    //   Console.Write($"{data} ");
    // }

    // Console.WriteLine();
    // foreach (string data in InOrderEnumerable(root))
    // {
    //   Console.Write($"{data} ");
    // }

    // Console.WriteLine();
    // PreOrder(root);

    // Console.WriteLine();
    // foreach (var data in PreOrderAsList(root))
    // {
    //   Console.Write($"{data} ");
    // }

    // Console.WriteLine();
    // foreach (string data in PreOrderEnumerable(root))
    // {
    //   Console.Write($"{data} ");
    // }

    // Console.WriteLine();
    // PostOrder(root);

    // Console.WriteLine();
    // foreach (var data in PostOrderAsList(root))
    // {
    //   Console.Write($"{data} ");
    // }

    // Console.WriteLine();
    // foreach (string data in PostOrderEnumerable(root))
    // {
    //   Console.Write($"{data} ");
    // }

    // Console.WriteLine();
  }

  public static void InOrder(Node node)
  {
    if (node == null)
    {
      return;
    }
    InOrder(node.Left);
    Console.Write($"{node.Data} ");
    InOrder(node.Right);
  }

  public static void PreOrder(Node node)
  {
    if (node == null)
    {
      return;
    }
    Console.Write($"{node.Data} ");
    PreOrder(node.Left);
    PreOrder(node.Right);
  }

  public static void PostOrder(Node node)
  {
    if (node == null)
    {
      return;
    }
    PostOrder(node.Left);
    PostOrder(node.Right);
    Console.Write($"{node.Data} ");
  }

  public static List<string> InOrderAsList(Node root)
  {
    List<string> result = new List<string>();
    _InOrderAsList(root, result);
    return result;
  }

  private static void _InOrderAsList(Node node, List<string> result)
  {
    if (node == null)
    {
      return;
    }
    _InOrderAsList(node.Left, result);
    result.Add(node.Data);
    _InOrderAsList(node.Right, result);
  }

  public static List<string> PreOrderAsList(Node root)
  {
    List<string> result = new List<string>();
    _PreOrderAsList(root, result);
    return result;
  }

  private static void _PreOrderAsList(Node node, List<string> result)
  {
    if (node == null)
    {
      return;
    }
    result.Add(node.Data);
    _PreOrderAsList(node.Left, result);
    _PreOrderAsList(node.Right, result);
  }

  public static List<string> PostOrderAsList(Node root)
  {
    List<string> result = new List<string>();
    _PostOrderAsList(root, result);
    return result;
  }

  private static void _PostOrderAsList(Node node, List<string> result)
  {
    if (node == null)
    {
      return;
    }
    _PostOrderAsList(node.Left, result);
    _PostOrderAsList(node.Right, result);
    result.Add(node.Data);
  }

  public static IEnumerable<string> InOrderEnumerable(Node node)
  {
    if (node == null)
    {
      yield break;
    }
    foreach (var data in InOrderEnumerable(node.Left))
    {
      yield return data;
    }
    yield return node.Data;
    foreach (var data in InOrderEnumerable(node.Right))
    {
      yield return data;
    }
  }

  public static IEnumerable<string> PreOrderEnumerable(Node node)
  {
    if (node == null)
    {
      yield break;
    }
    yield return node.Data;
    foreach (var data in PreOrderEnumerable(node.Left))
    {
      yield return data;
    }
    foreach (var data in PreOrderEnumerable(node.Right))
    {
      yield return data;
    }
  }

  public static IEnumerable<string> PostOrderEnumerable(Node node)
  {
    if (node == null)
    {
      yield break;
    }
    foreach (var data in PostOrderEnumerable(node.Left))
    {
      yield return data;
    }
    foreach (var data in PostOrderEnumerable(node.Right))
    {
      yield return data;
    }
    yield return node.Data;
  }

  public static void ByLevelWithRecursion(Node node)
  {
    var dic = new Dictionary<int, List<string>>();
    ByLevel(dic, node, 0);
    for (int level = 0; level < dic.Count; level++)
    {
      Console.Write($"[{level}]: ");
      var listAtLevel = dic[level];
      foreach (var value in listAtLevel)
      {
        Console.Write($"{value}, ");
      }
      Console.WriteLine();
    }
  }

  private static void ByLevel(Dictionary<int, List<string>> dic, Node node, int level)
  {
    if (node == null)
    {
      return;
    }
    if (!dic.ContainsKey(level))
    {
      dic[level] = new List<string>();
    }
    dic[level].Add(node.Data);
    ByLevel(dic, node.Left, level + 1);
    ByLevel(dic, node.Right, level + 1);
  }
  public static void ByLevelWithoutRecursion(Node root)
  {
    var currentLevel = new Queue<Node>();
    var nextLevel = new Queue<Node>();
    currentLevel.Enqueue(root);
    var i = 0;
    Console.Write($"[{i}]:");
    while (currentLevel.Count > 0)
    {
      var currentNode = currentLevel.Dequeue();
      Console.Write($"{currentNode.Data}, ");
      if (currentNode.Left != null)
      {
        nextLevel.Enqueue(currentNode.Left);
      }
      if (currentNode.Right != null)
      {
        nextLevel.Enqueue(currentNode.Right);
      }
      if (currentLevel.Count == 0)
      {
        Console.WriteLine();
        if (nextLevel.Count != 0)
        {
          i++;
          Console.Write($"[{i}]:");
        }
        currentLevel = nextLevel;
        nextLevel = new Queue<Node>();
      }
    }
  }
}

public class Node
{
  public string Data { set; get; }
  public Node Left { set; get; }
  public Node Right { set; get; }

  public Node(string data)
  {
    Data = data;
    Left = null;
    Right = null;
  }
}