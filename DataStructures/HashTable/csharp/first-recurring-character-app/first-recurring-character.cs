//Find the first recurring character - google question
// Given an array = [2, 5, 1, 2, 3, 5, 1, 2, 4]
// It should return 2
// Given an array = [2, 1, 1, 2, 3, 5, 1, 2, 4]
// It should return 1
// Given an array = [2, 5, 1, 3]
// It should return undefined

using System;
using System.Collections.Generic;

public class Program
{
  // Method to find the first recurring character in an array of objects
  private static object? FindFirstRecurringCharacter(object[] input)
  {
    var hashSet = new HashSet<object>(); // HashSet to efficiently track seen objects

    for (int i = 0; i < input.Length; i++)
    {
      if (hashSet.Contains(input[i])) // Check if the object is already in the HashSet
      {
        return input[i]; // If found, return the recurring object
      }
      hashSet.Add(input[i]); // Otherwise, add the object to the HashSet
    }

    return null; // If no recurring object is found, return null
  }

  public static void Main()
  {
    var input1 = new object[] { 2, 5, 1, 2, 3, 5, 1, 2, 4 };
    var input2 = new object[] { 2, 'a', 1, 12, 'a', 2, 3, 5, 1, 2, 4 };
    var input3 = new object[] { 2, 5, 1, 3 };

    var result1 = FindFirstRecurringCharacter(input1);
    var result2 = FindFirstRecurringCharacter(input2);
    var result3 = FindFirstRecurringCharacter(input3);

    Console.WriteLine("it is: " + result1); // Output: 2
    Console.WriteLine("it is: " + result2); // Output: 1
    Console.WriteLine("it is: " + result3); // Output: null (no recurring character found)
  }
}

/*Comparison between HashSet, Hashtable, and Dictionary:

HashSet<T>:

Stores unique elements of type T.
Based on a hash table data structure.
Provides fast lookup times (O(1) on average) for Add, Remove, and Contains operations.
Does not maintain any particular order of elements.


Hashtable:

Stores key-value pairs (keys and values can be of any type).
Based on a hash table data structure.
Allows you to associate a value with a specific key.
Not type-safe and requires explicit casting when retrieving values.
Part of the System.Collections namespace.


Dictionary<TKey, TValue>:

A generic collection that stores key-value pairs with specified types for keys and values.
Based on a hash table data structure.
Provides fast lookup times (O(1) on average) for Add, Remove, and ContainsKey operations.
Is type-safe and does not require explicit casting when retrieving values.
Part of the System.Collections.Generic namespace.
In modern C# development, it is recommended to use generic collections like HashSet<T> and Dictionary<TKey, TValue> for type safety and better performance.*/