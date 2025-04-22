using System;
using System.Diagnostics;
using DataStructures.Heap;

namespace Sorting;

public class SortingApp
{
    const int LENGTH = 1000000;
    const int MIN = 0;
    const int MAX = 10000000;

    public static void Main(string[] args)
    {
        Console.WriteLine($"Lenght: {LENGTH}");

        var stopwatch = new Stopwatch();

        var input = GeneratedSortedArray(LENGTH, MIN, MAX);
        //var input = GetDemoArray();
        Console.WriteLine($"Is Sorted Input: {IsSorted(input)}");
        //PrintArray(input);

        // Console.WriteLine("Bubble Sort");
        // var bubbleArray = (int[])input.Clone();
        // stopwatch.Start();
        // BubbleSort(bubbleArray);
        // Console.WriteLine($"Execution time: {stopwatch.Elapsed}");
        // Console.WriteLine($"Is Sorted: {IsSorted(bubbleArray)}");
        // //PrintArray(bubbleArray);

        // Console.WriteLine("Selection Sort");
        // var selectionArray = (int[])input.Clone();
        // stopwatch.Restart();
        // SelecionSort((int[])input.Clone());
        // Console.WriteLine($"Execution time: {stopwatch.Elapsed}");
        // Console.WriteLine($"Is Sorted: {IsSorted(selectionArray)}");
        // // //PrintArray(selectionArray);

        // Console.WriteLine("Insertion Sort");
        // var insertionArray = (int[])input.Clone();
        // stopwatch.Restart();
        // InsertionSort(insertionArray);
        // Console.WriteLine($"Execution time: {stopwatch.Elapsed}");
        // Console.WriteLine($"Is Sorted: {IsSorted(insertionArray)}");
        // //PrintArray(insertionArray);

        Console.WriteLine("Quick Sort");
        var quickArray = (int[])input.Clone();
        stopwatch.Restart();
        QuickSort(quickArray);
        Console.WriteLine($"Execution time: {stopwatch.Elapsed}");
        Console.WriteLine($"Is Sorted: {IsSorted(quickArray)}");
        //PrintArray(quickArray);

        Console.WriteLine("Merge Sort");
        var mergeArray = (int[])input.Clone();
        stopwatch.Restart();
        MergeSort(mergeArray);
        Console.WriteLine($"Execution time: {stopwatch.Elapsed}");
        Console.WriteLine($"Is Sorted: {IsSorted(mergeArray)}");
        //PrintArray(mergeArray);

        Console.WriteLine("Heap Sort");
        var heapArray = (int[])input.Clone();
        stopwatch.Restart();
        HeapSortCoPilot(heapArray);
        Console.WriteLine($"Execution time: {stopwatch.Elapsed}");
        Console.WriteLine($"Is Sorted: {IsSorted(heapArray)}");
        //PrintArray(heapArray);
    }

    private static int[] GetDemoArray()
    {
        return [
            95, 35, 15, 49, 12,
            99, 65,  2,  7, 19,
            10, 99,  1,  2,  7,
            52, 37, 16, 81, 59,
            44, 61, 12,  3,  0,
            33

        ];
    }

    public static void BubbleSort(int[] array)
    {
        int limit = array.Length - 1;
        while (true)
        {
            bool swapped = false;
            for (int i = 0; i < limit; i++)
            {
                if (array[i] > array[i + 1])
                {
                    Swap(array, i, i + 1);
                    swapped = true;
                }
            }
            limit--;
            if (!swapped)
            {
                break;
            }
        }
    }

    public static void SelecionSort(int[] array)
    {
        for (int i = 0; i < array.Length; i++)
        {
            int minIndex = i;
            for (int j = i + 1; j < array.Length; j++)
            {
                if (array[j] < array[minIndex])
                    minIndex = j;
            }
            Swap(array, i, minIndex);
        }
    }

    public static void InsertionSort(int[] array)
    {
        for (int i = 1; i < array.Length; i++)
        {
            int current = array[i];
            int j = i - 1;
            while (j >= 0 && current < array[j])
            {
                array[j + 1] = array[j];
                j--;
            }
            array[j + 1] = current;
        }
    }

    public static void QuickSort(int[] array)
    {
        Quick_Sort(array, 0, array.Length - 1);
    }

    private static void Quick_Sort(int[] array, int left, int right)
    {
        if (left < right)
        {
            int pivot = Partition(array, left, right);
            Quick_Sort(array, left, pivot - 1);
            Quick_Sort(array, pivot + 1, right);
        }
    }

    private static int Partition(int[] array, int left, int right)
    {
        int pivot = array[right];
        int smaller = left - 1;
        for (int greater = left; greater < right; greater++)
        {
            if (array[greater] < pivot)
            {
                smaller++;
                Swap(array, smaller, greater);
            }
        }
        Swap(array, smaller + 1, right);
        return smaller + 1;
    }

    private static int PartitionB(int[] array, int left, int right)
    {
        int mid = left + (right - left) / 2;
        int pivot = array[mid];
        while (true)
        {
            while (array[right] > pivot)
            {
                right--;
            }
            while (array[left] < pivot)
            {
                left++;
            }
            if (left >= right)
            {
                return right;
            }
            Swap(array, left, right);
            left++;
            right--;
        }
    }

    public static void MergeSort(int[] array)
    {
        MergeSort(array, 0, array.Length - 1);
    }

    private static void MergeSort(int[] array, int left, int right)
    {
        if (left < right)
        {
            int middle = (left + right) / 2;
            MergeSort(array, left, middle);
            MergeSort(array, middle + 1, right);
            Merge(array, left, middle, right);
        }
    }

    public static void Merge(int[] array, int left, int middle, int right)
    {
        int leftArrayLength = middle - left + 1;
        int rightArrayLenght = right - middle;

        int[] leftArray = new int[leftArrayLength];
        int[] rightArray = new int[rightArrayLenght];

        Array.Copy(array, left, leftArray, 0, leftArrayLength);
        Array.Copy(array, middle + 1, rightArray, 0, rightArrayLenght);

        int leftIndex = 0;
        int rightIndex = 0;
        int mergedIndex = left;

        while (leftIndex < leftArrayLength && rightIndex < rightArrayLenght)
        {
            if (leftArray[leftIndex] <= rightArray[rightIndex])
            {
                array[mergedIndex] = leftArray[leftIndex];
                leftIndex++;
            }
            else
            {
                array[mergedIndex] = rightArray[rightIndex];
                rightIndex++;
            }
            mergedIndex++;
        }
        while (leftIndex < leftArrayLength)
        {
            array[mergedIndex++] = leftArray[leftIndex++];
        }
        while (rightIndex < rightArrayLenght)
        {
            array[mergedIndex++] = rightArray[rightIndex++];
        }
    }

    public static void HeapSort(int[] array)
    {
        MyHeap myHeap = new MyHeap(array);
        int i = array.Length - 1;
        while (myHeap.Count > 0)
        {
            array[i] = myHeap.Pop();
            i--;
        }
    }

    public static void HeapSortCoPilot(int[] array)
    {
        int length = array.Length;
        // Build the max heap
        for (int i = length / 2 - 1; i >= 0; i--)
        {
            Heapify(array, length, i);
        }
        // Extract elements from the heap and sort
        for (int i = length - 1; i >= 0; i--)
        {
            Swap(array, 0, i);
            Heapify(array, i, 0);
        }
    }

    private static void Heapify(int[] array, int length, int root)
    {
        int largest = root;
        int left = 2 * root + 1;
        int right = 2 * root + 2;
        if (left < length && array[left] > array[largest])
        {
            largest = left;
        }
        if (right < length && array[right] > array[largest])
        {
            largest = right;
        }
        if (largest != root)
        {
            int temp = array[root];
            array[root] = array[largest];
            array[largest] = temp;

            Heapify(array, length, largest);
        }
    }

    public static void Swap(int[] array, int left, int right)
    {
        int aux = array[left];
        array[left] = array[right];
        array[right] = aux;
    }

    public static int[] GeneratedSortedArray(int length, int minValue, int maxValue)
    {
        Random random = new Random();
        var array = new int[length];
        for (int i = 0; i < array.Length; i++)
        {
            array[i] = random.Next(minValue, maxValue);
        }
        return array;
    }

    public static void PrintArray(int[] array)
    {
        Console.Write("[");
        for (int i = 0; i < array.Length - 1; i++)
        {
            Console.Write($"{array[i]},");
        }
        Console.WriteLine($"{array[array.Length - 1]}]");
    }

    public static bool IsSorted(int[] array)
    {
        for (int i = 0; i < array.Length - 1; i++)
        {
            if (array[i] > array[i + 1])
            {
                return false;
            }
        }
        return true;
    }
}