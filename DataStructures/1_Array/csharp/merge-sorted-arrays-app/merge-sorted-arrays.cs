//Given two sorted arrays, can you combine them into one large one that is still sorted?

using System;

class Program
{
  static int[] MergeSortedArrays(int[] array1, int[] array2)
  {
    // Check for edge cases where one or both arrays are empty
    if (array1.Length == 0)
    {
      return array2; // Return the non-empty array
    }

    if (array2.Length == 0)
    {
      return array1; // Return the non-empty array
    }

    // Initialize the merged array with enough space to hold all elements
    int[] mergedArray = new int[array1.Length + array2.Length];

    int i = 0; // Pointer for array1
    int j = 0; // Pointer for array2
    int k = 0; // Pointer for mergedArray

    // Merge the arrays while they both have elements
    while (i < array1.Length && j < array2.Length)
    {
      if (array1[i] < array2[j])
        mergedArray[k++] = array1[i++];
      else
        mergedArray[k++] = array2[j++];
    }

    // If there are remaining elements in array1, copy them to mergedArray
    while (i < array1.Length)
      mergedArray[k++] = array1[i++];

    // If there are remaining elements in arr2ay, copy them to mergedArray
    while (j < array2.Length)
      mergedArray[k++] = array2[j++];

    return mergedArray; // Return the sorted merged array
  }

  static void Main()
  {
    int[] merged = MergeSortedArrays(new int[] { 0, 3, 4, 31 }, new int[] { 4, 6, 30, 34, 67, 77 });
    Console.WriteLine(String.Join(" ", merged));
    // foreach (int item in merged)
    // {
    //   Console.Write(item + " ");
    // }
  }
}
