function mergeSortedArrays(array1, array2) {
  // Check for edge cases where one or both arrays are empty
  if (array1.length === 0 && array2.length !== 0) {
    return array2; // Return the non-empty array
  }
  if (array2.length === 0 && array1.length !== 0) {
    return array1; // Return the non-empty array
  }
  // if (array1.length === 0 && array2.length === 0) {
  //   return []; // Both arrays are empty, return an empty array - This is not needed - one of if statements above will return empty array
  // }

  const mergedArray = [];

  let i = 0; // Pointer for array1
  let j = 0; // Pointer for array2
  let array1Item = array1[i]; // Current element from array1
  let array2Item = array2[j]; // Current element from array2

  while (array1Item || array2Item) {
    // Continue loop until both arrays are fully processed

    if (!array2Item || array1Item < array2Item) {
      // If array2Item is undefined (empty), or array1Item is smaller
      mergedArray.push(array1Item);
      i++;
      array1Item = array1[i]; // Move pointer in array1
    } else {
      mergedArray.push(array2Item);
      j++;
      array2Item = array2[j]; // Move pointer in array2
    }
  }

  return mergedArray; // Return the sorted merged array
}

console.log(mergeSortedArrays([0, 3, 4, 31], [4, 6, 30, 34, 67, 77]));
// If your solution works - explain how you wold clean this code - make smaller methods etc.
