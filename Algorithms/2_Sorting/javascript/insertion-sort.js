const numbers = [99, 44, 6, 2, 1, 5, 63, 87, 283, 4, 0];

function insertionSort(array) {
  for (let i = 0; i < array.length; i++) {
    if (array[i] < array[0]) {
      //check if the current item should be the first item
      // array.splice(i, 1) removes the element at index i and returns an array containing that element
      // array.unshift(...) adds the element to the beginning of the array
      array.unshift(array.splice(i, 1)[0]); //move the number to the first position
    } else {
      //find when the number should go (int the left sorted part of array)
      for (let j = 0; j < i; j++) {
        if (array[i] > array[j - 1] && array[i] < array[j]) {
          // array.splice(i, 1) removes the element at index i and returns an array containing that element
          // array.splice(j, 0, ...) inserts the removed element at index j
          array.splice(j, 0, array.splice(i, 1)[0]);
          /* The splice() method of Array instances changes the contents of an array by removing or replacing existing elements and/or adding new elements in place */
        }
      }
    }
  }
}

function insertionSort2(array) {
  const len = array.length;

  for (let i = 1; i < len; i++) {
    let current = array[i];
    let j = i - 1;

    // Move elements greater than the current element to the right
    while (j >= 0 && array[j] > current) {
      array[j + 1] = array[j];
      j--;
    }

    // Place the current element at its correct position
    array[j + 1] = current;
  }
}

const insertionSort3 = (array) => {
  for (let i = 1; i < array.length; i++) {
    let currentElement = array[i];
    let lastIndex = i - 1;

    while (lastIndex >= 0 && array[lastIndex] > currentElement) {
      array[lastIndex + 1] = array[lastIndex];
      lastIndex--;
    }
    array[lastIndex + 1] = currentElement;
  }

  return array;
};

//insertionSort(numbers);
insertionSort2(numbers);
console.log(numbers);
