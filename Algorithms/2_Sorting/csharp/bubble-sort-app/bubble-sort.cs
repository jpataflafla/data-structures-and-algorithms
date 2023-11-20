using System;

class Program
{
  static void BubbleSort(int[] arr)
  {
    int n = arr.Length;
    bool swapped;

    do
    {
      swapped = false;

      for (int i = 0; i < n - 1; i++)
      {
        if (arr[i] > arr[i + 1])
        {
          // Swap elements if they are in the wrong order
          int temp = arr[i];
          arr[i] = arr[i + 1];
          arr[i + 1] = temp;

          swapped = true;
        }
      }
    } while (swapped);
  }

  static void Main(string[] args)
  {
    int[] arrayToSort = { 64, 34, 25, 12, 22, 11, 90 };
    BubbleSort(arrayToSort);

    Console.WriteLine("Sorted array:");
    foreach (var element in arrayToSort)
    {
      Console.Write(element + " ");
    }
  }
}
