//Find the first recurring character - google question
// Given an array = [2, 5, 1, 2, 3, 5, 1, 2, 4]
// It should return 2
// Given an array = [2, 1, 1, 2, 3, 5, 1, 2, 4]
// It should return 1
// Given an array = [2, 5, 1, 3]
// It should return undefined

// function firstRecurringCharacter(input) {
//   for (let i = 0; i < input.length; i++) {
//     //O(n)
//     for (let j = i + 1; j < input.length; j++) {
//       //O(n)
//       if (input[i] === input[j]) {
//         return input[i];
//       }
//     }
//   }
//   return undefined;
//   //So this works, but there is a problem - there are nested loops - O(n^2) so it probably can be done with better time complexity
//   // nested loops? - try hash tables...
// }

function firstRecurringCharacterMap(input) {
  let hashTable = new Map();
  /* 
  A Map object is used here instead of a plain object. Maps offer advantages over plain objects, 
  including the ability to iterate elements in insertion order and support for any value as keys.
  
  Objects are similar to Maps in that both let you set keys to values, retrieve those values, delete keys, and detect whether something is stored at a key. Because of this, Objects have been used as Maps historically; however, there are important differences between Objects and Maps that make using a Map better.

  An Object has a prototype, so there are default keys in the map. However, this can be bypassed using map = Object.create(null). The keys of an Object are Strings, where they can be any value for a Map. You can get the size of a Map easily while you have to manually keep track of size for an Object.
  https://stackoverflow.com/questions/18541940/map-vs-object-in-javascript 
  */

  for (let i = 0; i < input.length; i++) {
    if (hashTable.has(input[i])) {
      // If the character is already in the Map, it's a recurring character
      return input[i]; // Return the recurring character
    }
    hashTable.set(input[i], input[i]); // Add the character to the Map
  }

  return undefined; // If no recurring character is found, return undefined
  // This function uses a Map to efficiently check for recurring characters in an array.
  // It has a time complexity of O(n) because it only loops through the input array once.
  // The use of a Map allows for efficient lookups to check if a character has been seen before.
}

function firstRecurringCharacterObjectAsHashTable(input) {
  let hashTable = {}; // Initialize a hash table (an object in JavaScript) to keep track of seen characters

  for (let i = 0; i < input.length; i++) {
    if (hashTable[input[i]] !== undefined) {
      // In JavaScript, when using an object as a key-value pair,
      // if a key is present but its corresponding value is 0, false, or null,
      // it can be incorrectly evaluated as a falsy value in a conditional check.
      // Therefore, to accurately determine if the key exists and has a defined value,
      // we use strict inequality comparison (!== undefined) to explicitly check if the value is not undefined.
      // This ensures that even if the value is 0, false, or null, the condition will evaluate to true.

      // If the character is already in the hash table, it's a recurring character
      return input[i]; // Return the recurring character
    }
    hashTable[input[i]] = input[i]; // Add the character to the hash table
  }

  return undefined; // If no recurring character is found, return undefined
}

function firstRecurringCharacterSet(input) {
  let hashTable = new Set();

  for (let i = 0; i < input.length; i++) {
    if (hashTable.has(input[i])) {
      // If the character is already in the hash table, it's a recurring character
      return input[i]; // Return the recurring character
    }
    hashTable.add(input[i]); // Add the character to the hash table
  }

  return undefined; // If no recurring character is found, return undefined
}

console.log(firstRecurringCharacterMap([2, 5, 1, 2, 3, 5, 1, 2, 4]));

console.log(
  firstRecurringCharacterObjectAsHashTable([2, 5, 1, 2, 3, 5, 1, 2, 4])
);

console.log(firstRecurringCharacterSet([2, 5, 1, 2, 3, 5, 1, 2, 4]));
