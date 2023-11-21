const numbers = [99, 44, 6, 2, 1, 5, 63, 87, 283, 4, 0, 1];

function mergeSort(array) {
  // Base case: If the array has only one element, it is already sorted
  if (array.length === 1) {
    return array;
  }

  // Split the array into two halves
  const middle = Math.floor(array.length / 2);
  const left = array.slice(0, middle);
  const right = array.slice(middle);

  // Recursively sort both halves
  return merge(mergeSort(left), mergeSort(right));
}

function merge(left, right) {
  let result = [];
  let leftIndex = 0;
  let rightIndex = 0;

  // Compare elements from both arrays and merge them in sorted order
  while (leftIndex < left.length && rightIndex < right.length) {
    if (left[leftIndex] < right[rightIndex]) {
      // If the element from the left array is smaller, add it to the result
      result.push(left[leftIndex]);
      leftIndex++;
    } else {
      // If the element from the right array is smaller, add it to the result
      result.push(right[rightIndex]);
      rightIndex++;
    }
  }

  // Add any remaining elements from the left and right arrays
  return result.concat(left.slice(leftIndex), right.slice(rightIndex));
}

// Example usage:
const answer = mergeSort(numbers);
console.log(answer);
