using System;
using System.Collections.Generic;

class Program
{
  static int calculationsCount = 0;

  static int Fibonacci(int n)
  {
    calculationsCount++;

    if (n < 2)
    {
      return n;
    }

    return Fibonacci(n - 1) + Fibonacci(n - 2);
  }

  static void Main()
  {
    Fibonacci(7); // This will make 13 calculations with the recursive function

    Console.WriteLine($"Classic recursive Fibonacci calculations: {calculationsCount}");

    // How to make it more efficient with dynamic programming?
    // It is possible to make it O(n) using memoization.

    // Function that returns a memoized Fibonacci function
    int memoizedCalculationCalls = 0;
    Dictionary<int, int> cache = new Dictionary<int, int>();

    // Inner function representing the actual Fibonacci calculation with memoization
    Func<int, int> fib = null;
    fib = (n) =>
    {
      memoizedCalculationCalls++;

      // Check if the Fibonacci value for 'n' is already in the cache
      if (cache.ContainsKey(n))
      {
        // If yes, return the cached value to avoid redundant calculations
        return cache[n];
      }

      // Base case: if n is 0 or 1, return n as the Fibonacci value
      if (n < 2)
      {
        return n;
      }

      // Recursive case: calculate Fibonacci value for n using memoization
      cache[n] = fib(n - 1) + fib(n - 2);

      // Return the calculated value for n
      return cache[n];
    };

    // Example usage:
    // Create a memoized Fibonacci function
    Console.WriteLine($"Memoized Fibonacci value for n=10: {fib(10)}");
    Console.WriteLine($"Memoized Fibonacci calculations: {memoizedCalculationCalls}");

    // Test the classic recursive Fibonacci function with the same example
    calculationsCount = 0; // Reset the count for classic recursive Fibonacci
    Console.WriteLine($"Classic recursive Fibonacci value for n=10: {Fibonacci(10)}");
    Console.WriteLine($"Classic recursive Fibonacci calculations: {calculationsCount}");
  }
}
