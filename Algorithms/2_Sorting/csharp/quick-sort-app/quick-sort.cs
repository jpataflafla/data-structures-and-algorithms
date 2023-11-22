using System;

class Program
{
  // Function to perform QuickSort
  static void QuickSort(int[] array, int left, int right)
  {
    // Check if there are more than one element in the array
    if (left < right)
    {
      // Find the partition index, elements smaller than pivot on the left, larger on the right
      int partitionIndex = Partition(array, left, right);

      // Recursively sort the subarrays on the left and right of the partition
      QuickSort(array, left, partitionIndex - 1);
      QuickSort(array, partitionIndex + 1, right);
    }
  }

  // Function to partition the array and return the index of the pivot element
  static int Partition(int[] array, int left, int right)
  {
    // Choose the rightmost element as the pivot
    int pivotIndex = right;
    int pivot = array[pivotIndex];
    // Initialize the index of the smaller element
    int i = left - 1;

    // Iterate through the array and rearrange elements based on their relation to the pivot
    for (int j = left; j < right; j++)
    {
      if (array[j] < pivot)
      {
        // Swap elements if they are smaller than the pivot
        i++;
        Swap(array, i, j);
      }
    }

    // Swap the pivot element to its correct position

    Swap(array, i + 1, pivotIndex);

    // Return the index of the pivot element after partitioning
    return i + 1;
  }

  // Function to swap two elements in the array
  static void Swap(int[] array, int i, int j)
  {
    int temp = array[i];
    array[i] = array[j];
    array[j] = temp;
  }

  static void Main()
  {
    int[] numbers = { 99, 44, 6, 2, 1, 5, 63, 87, 283, 4, 0 };

    // Select first and last index as 2nd and 3rd parameters
    QuickSort(numbers, 0, numbers.Length - 1);

    // Output the sorted array
    foreach (var number in numbers)
    {
      Console.Write(number + " ");
    }
  }
}
