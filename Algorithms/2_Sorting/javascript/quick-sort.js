const numbers = [99, 44, 6, 2, 1, 5, 63, 87, 283, 4, 0];

// Function to perform QuickSort
function quickSort(array, left, right) {
  // Check if there are more than one element in the array
  if (left < right) {
    // Find the partition index, elements smaller than pivot on the left, larger on the right
    const partitionIndex = partition(array, left, right);

    // Recursively sort the subarrays on the left and right of the partition
    quickSort(array, left, partitionIndex - 1);
    quickSort(array, partitionIndex + 1, right);
  }

  // Return the sorted array
  return array;
}

// Function to partition the array and return the index of the pivot element
function partition(array, left, right) {
  // Choose the rightmost element as the pivot
  const pivot = array[right];
  // Initialize the index of the smaller element
  let i = left - 1;

  // Iterate through the array and rearrange elements based on their relation to the pivot
  for (let j = left; j < right; j++) {
    if (array[j] < pivot) {
      // Swap elements if they are smaller than the pivot
      i++;
      swap(array, i, j);
    }
  }

  // Swap the pivot element to its correct position
  swap(array, i + 1, right);

  // Return the index of the pivot element after partitioning
  return i + 1;
}

// Function to swap two elements in the array
function swap(array, i, j) {
  const temp = array[i];
  array[i] = array[j];
  array[j] = temp;
}

// Select first and last index as 2nd and 3rd parameters
const sortedNumbers = quickSort(numbers, 0, numbers.length - 1);

// Output the sorted array
console.log(sortedNumbers);
