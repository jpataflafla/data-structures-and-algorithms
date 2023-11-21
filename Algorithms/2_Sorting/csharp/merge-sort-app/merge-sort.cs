using System;

class Program
{
  // Recursive function to perform Merge Sort
  static int[] MergeSort(int[] array)
  {
    // Base case: If the array has only one element, it is already sorted
    if (array.Length <= 1)
      return array;

    // Split the array into two halves
    int middle = array.Length / 2;
    int[] left = new int[middle];
    int[] right = new int[array.Length - middle];

    // Copy elements to left and right arrays
    Array.Copy(array, 0, left, 0, middle);
    Array.Copy(array, middle, right, 0, array.Length - middle);

    // Recursively sort both halves and merge them
    return Merge(MergeSort(left), MergeSort(right));
  }

  // Merge two sorted arrays into a single sorted array
  static int[] Merge(int[] left, int[] right)
  {
    int leftIndex = 0;
    int rightIndex = 0;
    int resultIndex = 0;
    int[] result = new int[left.Length + right.Length];

    // Compare elements from both arrays and merge them in sorted order
    while (leftIndex < left.Length && rightIndex < right.Length)
    {
      // Ternary operator to determine which element is smaller
      result[resultIndex++] = (left[leftIndex] < right[rightIndex]) ? left[leftIndex++] : right[rightIndex++];
    }

    // Add any remaining elements from the left array
    while (leftIndex < left.Length)
      result[resultIndex++] = left[leftIndex++];

    // Add any remaining elements from the right array
    while (rightIndex < right.Length)
      result[resultIndex++] = right[rightIndex++];

    return result;
  }

  static void Main()
  {
    int[] numbers = { 99, 44, 6, 2, 1, 5, 63, 87, 283, 4, 0, 1 };
    numbers = MergeSort(numbers);

    Console.WriteLine("Sorted array:");
    foreach (var number in numbers)
    {
      Console.Write(number + " ");
    }
  }

}
