using System;

class Program
{
  static void SelectionSort(int[] array)
  {
    int len = array.Length;

    for (int i = 0; i < len - 1; i++)
    {
      int minIndex = i;

      // Find the index of the minimum element in the remaining unsorted array
      for (int j = i + 1; j < len; j++)
      {
        if (array[j] < array[minIndex])
        {
          minIndex = j;
        }
      }

      // Swap the found minimum element with the element at index i
      if (minIndex != i)
      {
        int temp = array[i];
        array[i] = array[minIndex];
        array[minIndex] = temp;
      }
    }
  }

  static void Main()
  {
    int[] numbers = { 99, 44, 6, 2, 1, 5, 63, 87, 283, 4, 0 };
    SelectionSort(numbers);

    Console.Write("Sorted array: ");
    foreach (var number in numbers)
    {
      Console.Write(number + " ");
    }
  }
}
