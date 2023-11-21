using System;

public class Program
{
  public static void InsertionSort(int[] array)
  {
    for (int i = 1; i < array.Length; i++)
    {
      var currentElement = array[i];
      var lastElementIndex = i - 1;

      while (lastElementIndex >= 0
      && currentElement < array[lastElementIndex])
      {
        array[lastElementIndex + 1] = array[lastElementIndex];
        lastElementIndex--;
      }

      array[lastElementIndex + 1] = currentElement;

    }
  }

  public static void Main(string[] args)
  {
    int[] numbers = new int[] { 1, 5, 324, 12, 2345, 12, 3, 4, 2, 3 };
    InsertionSort(numbers);
    Console.WriteLine(string.Join(" ", numbers));
  }
}