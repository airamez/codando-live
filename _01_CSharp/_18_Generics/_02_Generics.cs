using System;
using System.Diagnostics.CodeAnalysis;


namespace Generics;

public class GenericsApp
{

    public static void Swap<T>(ref T a, ref T b)
    {
        T temp = a;
        a = b;
        b = temp;
    }

    public static void Main(string[] args)
    {
        var intCollection = new MyCollection(4);
        intCollection.Add(5);
        intCollection.Add(10);
        intCollection.Add(1);
        Console.WriteLine(intCollection.Get(0));
        Console.WriteLine(intCollection.Get(1));
        Console.WriteLine(intCollection.Get(2));

        int n0 = (int)intCollection.Get(0);
        Console.WriteLine(n0);
        intCollection.Add("Jose");
        string name = (string)intCollection.Get(3);
        //        int n3 = (int)myIntCollection.Get(3);
        Console.WriteLine(name);

        var intGenIntCollection = new MyGenericCollection<int>(3);
        intGenIntCollection.Add(5);
        intGenIntCollection.Add(10);
        intGenIntCollection.Add(1);
        int number = intGenIntCollection.Get(2);

        var strGenCollection = new MyGenericCollection<string>(3);
        strGenCollection.Add("Jose");
        strGenCollection.Add("Leila");
        strGenCollection.Add("Artur");

        var students = new MyGenericCollection<Student>(3);
        students.Add(new Student(1, "Jose"));
        students.Add(new Student(2, "Leila"));
        students.Add(new Student(3, "Artur"));
        var jose = students.Get(0);
        Console.WriteLine(jose);
        var leila = students.Get(1);
        Console.WriteLine(leila);
        Console.WriteLine(students.Get(2));

        int n1 = 1;
        int n2 = 2;
        Console.WriteLine($"n1 = {n1}; n2 = {n2}");
        Swap(ref n1, ref n2);
        Console.WriteLine($"n1 = {n1}; n2 = {n2}");

        string name1 = "Jose";
        string name2 = "Leila";
        Console.WriteLine($"name1 = {name1}; name2 = {name2}");
        Swap(ref name1, ref name2);
        Console.WriteLine($"name1 = {name1}; name2 = {name2}");
    }
}

public class MyCollection
{
    private object[] data;
    private int index;

    public MyCollection(int length)
    {
        data = new object[length];
        index = 0;
    }

    public void Add(object value)
    {
        data[index++] = value;
    }

    public object Get(int index)
    {
        return data[index];
    }
}

public class MyGenericCollection<T>
{
    private T[] data;
    private int index;

    public MyGenericCollection(int length)
    {
        data = new T[length];
        index = 0;
    }

    public void Add(T value)
    {
        data[index++] = value;
    }

    public T Get(int index)
    {
        return data[index];
    }
}

public class Student
{
    public int Id { get; set; }
    public string Name { get; set; }

    public Student(int id, string name)
    {
        Id = id;
        Name = name;
    }

    public override string ToString()
    {
        return $"[{Id}, {Name}]";
    }
}