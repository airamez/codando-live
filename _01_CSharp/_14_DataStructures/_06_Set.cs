/*
# Set
  # A Set is a collection of distinct elements.
  # Each element in a Set is unique.
  # The order of elements in a Set is not guaranteed.
  # Basic Operations
    # Add: Insert an element into the Set. 
      If the element already exists, the Set remains unchanged.
    # Remove: Remove an element from the Set.
      If the element does not exist, the Set remains unchanged.
    # Contains: Check if an element exists in the Set.
    # Size: Get the number of elements in the Set.
    # Iterate: Traverse through the elements in the Set.
  # Set operation
    # Intersection
    # Union
    # Difference
  # Use Cases
    # Sets are used when you want to avoid duplicate elements and 
      when you don’t care about the order of elements.
    # They are often used for operations like union, intersection,
      and set difference.
*/

using System;


namespace DataStructures.Set;

public class MySet
{
  private readonly bool[] values;


  public MySet(int capacity)
  {
    values = new bool[capacity];
    Size = 0;
  }

  public void Add(int value)
  {
    if (value < 0 || value >= values.Length)
    {
      throw new InvalidOperationException($"Value is out of bound: {value}");
    }
    if (!values[value])
    {
      Size++;
      values[value] = true;
    }
  }

  public void Remove(int value)
  {
    if (value < 0 || value >= values.Length)
    {
      throw new InvalidOperationException($"Value is out of bound: {value}");
    }
    if (values[value])
    {
      Size--;
      values[value] = false;
    }
  }

  public int Size { private set; get; }

  public bool Contains(int value)
  {
    return values[value];
  }
}

