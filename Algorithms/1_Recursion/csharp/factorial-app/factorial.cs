//Write two functions that find the factorial of any number.
//One should use a recursive algorithm,
//and the second one should use a loop (iterative algorithm).

using System;

public class Factorial
{
  public static int CalculateFactorialRecursive(int number)//O(n) - time complexity
  {
    if (number < 0)
    {
      throw new ArgumentException("Input must be a non-negative integer", nameof(number));
    }


    if (number == 0 || number == 1)
    {
      return 1;
    }

    return number * CalculateFactorialRecursive(number - 1);

  }

  // c# DOESN'T support Tail Call Optimization (TCO) so all methods in this class are just O(n) - space complexity
  public static int CalculateFactorialLikeTailRecursive(int number, int accumulator = 1)// O(n) - time complexity
  {
    if (number < 0)
    {
      throw new ArgumentException("Input must be a non-negative integer", nameof(number));
    }


    if (number == 0 || number == 1)
    {
      return accumulator;
    }

    return CalculateFactorialLikeTailRecursive(number - 1, number * accumulator);

  }

  public static int CalculateFactorialIterative(int number)//O(n) - time complexity
  {
    if (number < 0)
    {
      throw new ArgumentException("Input must be a non-negative integer", nameof(number));
    }


    int result = 1;
    while (number > 1)// not 0 or 1
    {
      result *= number--;
    }
    return result;
  }

  public static int CalculateFactorialIterative2(int number)//O(n) - time complexity
  {
    if (number < 0)
    {
      throw new ArgumentException("Input must be a non-negative integer", nameof(number));
    }


    int result = 1;
    for (int i = 1; i <= number; i++)
    {
      result *= i;
    }

    return result;
  }

  public static void Main(string[] args)
  {
    // Example usage
    int number = 5;

    var recursiveResult = CalculateFactorialRecursive(number);
    Console.WriteLine("Recursive: " + recursiveResult);

    var recursiveResult2 = CalculateFactorialLikeTailRecursive(number);
    Console.WriteLine("Recursive - like tail optimization (but not supported by C#): " + recursiveResult2);

    var iterativeResult = CalculateFactorialIterative(number);
    Console.WriteLine("Iterative: " + iterativeResult);

    var iterativeResult2 = CalculateFactorialIterative2(number);
    Console.WriteLine("Iterative2: " + iterativeResult2);
  }
}