using System;
using System.Collections.Generic;
using System.Linq;

namespace DataStructures.Heap;

public class MyHeapApp
{
    public static void Main(string[] args)
    {
        int[] data = { 11, 7, 2, 81, 4, 80, 5, 93, 15, 90, 28, 75, 30, 84, 85 };
        var myHeap = new MyHeap(data);
        myHeap.Print();

        myHeap.Add(70);
        myHeap.Print();

        myHeap.Add(99);
        myHeap.Print();

        int max = myHeap.Pop();
        Console.WriteLine($"Max: {max}");
        myHeap.Print();

        while (myHeap.Count > 0)
        {
            Console.WriteLine();
            myHeap.Print();
            Console.WriteLine($"Max: {myHeap.Pop()}");
        }
    }
}

public class MyHeap
{
    private List<int> Data;

    public int Count => Data.Count;

    public MyHeap(int[] data = null)
    {
        if (data == null)
        {
            Data = new List<int>();
        }
        else
        {
            Data = data.ToList();
            Heapify();
        }
    }

    private void Heapify()
    {
        /*
            Heapify up each node
            On every swap heapify down        
        */
        for (int i = Data.Count / 2; i >= 0; i--)
        {
            Heapify(i);
        }
    }

    private void Heapify(int index)
    {
        var childrenIndexes = GetChildrenIndexes(index);
        int greaterIndex = index;
        if (childrenIndexes.Left < Data.Count && Data[childrenIndexes.Left] > Data[greaterIndex])
        {
            greaterIndex = childrenIndexes.Left;
        }
        if (childrenIndexes.Right < Data.Count && Data[childrenIndexes.Right] > Data[greaterIndex])
        {
            greaterIndex = childrenIndexes.Right;
        }
        if (index != greaterIndex) // We found a greater chield value
        {
            Swap(index, greaterIndex);
            Heapify(greaterIndex);
        }
    }

    private void Swap(int left, int right)
    {
        int aux = Data[left];
        Data[left] = Data[right];
        Data[right] = aux;
    }

    private (int Left, int Right) GetChildrenIndexes(int index)
    {
        return (index * 2 + 1, index * 2 + 2);
    }

    public void Add(int value)
    {
        /*
            Add leaf and check-heap up
        */
        Data.Add(value);
        int index = Data.Count - 1;
        int parentIndex = GetParentIndex(index);
        while (Data[index] > Data[parentIndex])
        {
            Swap(parentIndex, index);
            index = parentIndex;
            parentIndex = GetParentIndex(index);
        }
    }

    private int GetParentIndex(int index)
    {
        return (index - 1) / 2;
    }

    public int Pop()
    {
        /*
            Save root value to return
            Set root to -infinite
            Heapify down
            Remove the node with -infinite
          */
        if (Data.Count == 0)
        {
            throw new Exception("The heap is empty");
        }
        int max = Data[0];
        Data[0] = Data[Data.Count - 1];
        Data.RemoveAt(Data.Count - 1);
        Heapify(0);
        return max;
    }

    public void Print()
    {
        Console.WriteLine();
        foreach (int value in Data)
        {
            Console.Write($"{value} ");
        }
        Console.WriteLine();
    }
}