using System;
using System.Collections.Generic;

namespace DataStructures.Graph.Weighted;

public class WeightedGraphApp
{
    public static void Main(string[] args)
    {
        MyWeightedGraph graph = new MyWeightedGraph();
        graph.Add("A");
        graph.Add("B");
        graph.Add("C");
        graph.Add("D");
        graph.Add("E");
        graph.Add("F");
        graph.Connect("A", "B", 10);
        graph.Connect("A", "C", 8);
        graph.Connect("A", "D", 15);
        graph.Connect("B", "D", 7);
        graph.Connect("C", "D", 5);
        graph.Connect("C", "E", 10);
        graph.Connect("D", "E", 1);
        graph.Connect("D", "F", 4);
        graph.Connect("E", "F", 2);
        graph.Print();

        // PrintShortestPath(graph, "A", "B");
        // PrintShortestPath(graph, "A", "C");
        // PrintShortestPath(graph, "A", "D");
        // PrintShortestPath(graph, "A", "E");
        PrintShortestPath(graph, "A", "F");

        // PrintShortestPath(graph, "B", "B");
        // PrintShortestPath(graph, "B", "D");
        // PrintShortestPath(graph, "B", "E");
        // PrintShortestPath(graph, "B", "F");

        // PrintShortestPath(graph, "D", "E");
        // PrintShortestPath(graph, "D", "F");

        // try
        // {
        //     Console.WriteLine($"[F=>A]: {graph.GetShortetsPath("F", "A")}");
        // }
        // catch (Exception ex)
        // {
        //     Console.WriteLine(ex.Message);
        // }
    }

    public static void PrintShortestPath(
        MyWeightedGraph graph,
        string source,
        string target)
    {
        Console.Write($"[{source}=>{target}]: ");
        graph.GetShortetsPath(source, target)
            .ForEach(n => Console.Write($"{n.node.Data}({n.Weight}) "));
        Console.WriteLine();
    }
}

public class Edge
{
    public int Weight { set; get; }
    public Node Adjacent { set; get; }

    public Edge(Node adjacent, int weight)
    {
        Weight = weight;
        Adjacent = adjacent;
    }
}

public class Node : IComparable
{
    public string Data { set; get; }
    public List<Edge> Edges { private set; get; }

    public Node(string data)
    {
        Data = data;
        Edges = new List<Edge>();
    }

    public int CompareTo(object obj)
    {
        var other = obj as Node;
        if (other == null)
        {
            return -1;
        }
        else
        {
            return Data.CompareTo(other.Data);
        }
    }
}

public class DijkstraTableEntry
{
    public int Weight { set; get; }
    public Node Previous { set; get; }

    public DijkstraTableEntry(int weight, Node previous)
    {
        Weight = weight;
        Previous = previous;
    }
}

public class MyWeightedGraph
{
    public Dictionary<string, Node> Nodes;

    public MyWeightedGraph()
    {
        Nodes = new Dictionary<string, Node>();
    }

    public void Add(string value)
    {
        if (Nodes.ContainsKey(value))
        {
            throw new Exception($"Value already exist in the grap: {value}");
        }
        Nodes[value] = new Node(value);
    }

    public void Connect(
        string sourceValue,
        string targetValue,
        int weight)
    {
        var source = GetNode(sourceValue);
        var target = GetNode(targetValue);
        source.Edges.Add(new Edge(target, weight));
    }

    private Node GetNode(string value)
    {
        var node = Nodes[value];
        if (node == null)
        {
            throw new Exception($"No node found with the data: {value}");
        }
        return node;
    }

    public void Print()
    {
        foreach (var node in Nodes.Values)
        {
            Console.Write($"{node.Data}: ");
            foreach (var edge in node.Edges)
            {
                Console.Write($"[{edge.Weight}=>{edge.Adjacent.Data}] ");
            }
            Console.WriteLine();
        }
    }

    public List<(Node node, int Weight)> GetShortetsPath(
        string sourceValue,
        string targetValue)
    {
        var visited = new HashSet<Node>();
        var source = GetNode(sourceValue);
        var target = GetNode(targetValue);
        var dijkstraTable = new Dictionary<Node, DijkstraTableEntry>();
        foreach (var node in Nodes.Values)
        {
            dijkstraTable[node] = new DijkstraTableEntry(int.MaxValue, null);
        }
        dijkstraTable[source].Weight = 0;
        var toVisit = new PriorityQueue<Node, int>();
        toVisit.Enqueue(source, 0);
        while (toVisit.Count > 0)
        {
            var current = toVisit.Dequeue();
            if (visited.Contains(current))
            {
                continue;
            }
            visited.Add(current);
            var currentWeight = dijkstraTable[current].Weight;
            foreach (var edge in current.Edges)
            {
                int weightFromTable = dijkstraTable[edge.Adjacent].Weight;
                int candidateWeight = currentWeight + edge.Weight;
                if (candidateWeight < weightFromTable)
                {
                    dijkstraTable[edge.Adjacent].Weight = candidateWeight;
                    dijkstraTable[edge.Adjacent].Previous = current;
                }
                if (!visited.Contains(edge.Adjacent))
                {
                    toVisit.Enqueue(edge.Adjacent, dijkstraTable[edge.Adjacent].Weight);
                }
            }
        }
        if (dijkstraTable[target].Equals(int.MaxValue))
        {
            string msg = $"Node ({targetValue}) is not reachable from Source ({sourceValue})";
            throw new Exception(msg);
        }
        return GetShortestPath(target, dijkstraTable);
    }

    private List<(Node node, int Weight)> GetShortestPath(
        Node target,
        Dictionary<Node, DijkstraTableEntry> dijkstraTable)
    {
        var path = new List<(Node node, int Weight)>();
        Node runner = target;
        while (runner != null)
        {
            path.Insert(0, (runner, dijkstraTable[runner].Weight));
            runner = dijkstraTable[runner].Previous;
        }
        return path;
    }
}