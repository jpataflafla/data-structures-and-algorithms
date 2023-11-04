using System;
using System.Collections.Generic; // Added this for List

public class HashTable<TKey, TValue>
{
  private List<(TKey, TValue)[]> data; // List to store the buckets

  public HashTable(int size)
  {
    data = new List<(TKey, TValue)[]>(size); // Initialize data as a list of arrays
    for (int i = 0; i < size; i++)
    {
      data.Add(null); // Initialize each element in the list as null
    }
  }

  private int Hash(TKey key)
  {
    int hash = 0;
    string keyString = key.ToString(); // Convert key to string for hash calculation

    for (int i = 0; i < keyString.Length; i++)
    {
      hash = (hash + (int)keyString[i] * i) % data.Count; // Calculate the hash value
    }

    return hash;
  }

  public void Set(TKey key, TValue value)
  {
    int address = Hash(key); // Get the address (index) for the key

    if (data[address] == null)
    {
      data[address] = new (TKey, TValue)[0]; // Create an empty array if the address is null
    }

    List<(TKey, TValue)> currentBucket = new List<(TKey, TValue)>(data[address]); // Get the current bucket

    currentBucket.Add((key, value)); // Add the key-value pair to the bucket
    data[address] = currentBucket.ToArray(); // Update the data with the modified bucket

    // Print the current state of the hash table
    Console.WriteLine("data: ");
    foreach (var bucket in data)
    {
      if (bucket != null)
      {
        foreach (var item in bucket)
        {
          Console.WriteLine($"{item.Item1}: {item.Item2}");
        }
      }
    }
  }

  public TValue Get(TKey key)
  {
    int address = Hash(key); // Get the address (index) for the key

    if (data[address] != null)
    {
      foreach (var item in data[address])
      {
        if (item.Item1.Equals(key))
        {
          return item.Item2; // Return the value if the key is found
        }
      }
    }

    throw new KeyNotFoundException("Key not found in hash table."); // Throw an exception if key not found
  }

  public List<TKey> Keys()
  {
    List<TKey> result = new List<TKey>(); // List to store the keys

    foreach (var bucket in data)
    {
      if (bucket != null)
      {
        foreach (var item in bucket)
        {
          result.Add(item.Item1); // Add keys to the result list
        }
      }
    }

    return result; // Return the list of keys
  }
}

class Program
{
  static void Main()
  {
    // Example usage of the HashTable class
    HashTable<string, int> myHashTable = new HashTable<string, int>(50);
    myHashTable.Set("grapes", 10000);
    myHashTable.Set("apples", 40);

    Console.WriteLine(myHashTable.Get("grapes")); // Output: 10000
    Console.WriteLine(myHashTable.Get("apples")); // Output: 40

    Console.WriteLine();

    HashTable<string, string> stringHashTable = new HashTable<string, string>(50);
    stringHashTable.Set("name", "John Doe");
    stringHashTable.Set("email", "john@example.com");

    Console.WriteLine(stringHashTable.Get("name")); // Output: John Doe
    Console.WriteLine(stringHashTable.Get("email")); // Output: john@example.com

    Console.WriteLine(String.Join(", ", myHashTable.Keys()));
    Console.WriteLine(String.Join(", ", stringHashTable.Keys()));
  }
}
