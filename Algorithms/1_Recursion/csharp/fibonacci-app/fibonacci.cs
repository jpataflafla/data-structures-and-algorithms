using System;

class Program
{
  static int FibonacciSequenceRecursive(int n)
  {
    // O(2^n) - time complexity
    // O(n) - space complexity - linear

    if (n < 0)
    {
      throw new ArgumentException("Input should be a non-negative integer");
    }

    if (n == 0 || n == 1)
    {
      return n;
    }

    return FibonacciSequenceRecursive(n - 1) + FibonacciSequenceRecursive(n - 2);
  }

  static int FibonacciSequenceIterative(int n)
  {
    // Time complexity is O(n)
    // Space complexity is O(n)

    if (n < 0)
    {
      throw new ArgumentException("Input should be a non-negative integer");
    }

    if (n <= 1)
    {
      return n;
    }

    int[] fib = new int[n + 1]; // n + 1 -> Elements are numbered starting from 0, so an array with (n + 1) elements is needed.

    // to have at least two elements and use n-1 and n-2 element
    fib[0] = 0;
    fib[1] = 1;

    for (int i = 2; i <= n; i++)
    {
      fib[i] = fib[i - 1] + fib[i - 2];
    }

    return fib[n];
  }

  static void Main()
  {
    // Example: Print the first 10 Fibonacci numbers using both recursive and iterative approaches
    for (int i = 0; i < 10; i++)
    {
      Console.WriteLine(FibonacciSequenceRecursive(i));
    }

    for (int i = 0; i < 10; i++)
    {
      Console.WriteLine(FibonacciSequenceIterative(i));
    }
  }
}
