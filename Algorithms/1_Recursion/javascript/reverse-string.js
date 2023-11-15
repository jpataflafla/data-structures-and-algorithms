//Implement a function that reverses a string using iteration and a function that uses recursion

function reverseStringIterative(str) {
  //O(n) - time complexity
  //O(n) space complexity -> result array is proportional to the input
  let reversed = [];
  let input = [...str];
  for (let i = 0; i < str.length; i++) {
    reversed.push(input.pop()); //[input.length - 1 - i]);
  }
  return reversed.join("");
}

function reverseStringIterative2(str) {
  //O(n) - time complexity
  //O(n) space complexity -> reversed string is proportional to the input
  let reversed = "";
  for (let i = str.length - 1; i >= 0; i--) {
    reversed += str[i];
  }
  return reversed;
}

//reverse string in place could help to achieve O(1) space complexity - BUT it is not done here because let strArray = str.split(""); is O(n) so it makes function O(n);
//JS strings are immutable
function reverseStringIterative3(str) {
  //O(n) - time complexity
  // Convert the string to an array since strings are immutable
  let strArray = str.split("");

  // Use two pointers approach to swap characters from the beginning and end
  let start = 0;
  let end = strArray.length - 1;

  while (start < end) {
    //swap characters at start/end indices
    let temp = strArray[start];
    strArray[start] = strArray[end];
    strArray[end] = temp;

    //move pointers towards each other
    end--;
    start++;
  }
  return strArray.join("");
}

function reverseStringRecursive(str) {
  // O(n)
  // Base case: if the string is empty or has only one character, it is already reversed
  if (str.length <= 1) {
    return str;
  }
  return reverseStringRecursive(str.substring(1)) + str.charAt(0);
  /*reverseStringRecursive("hello")
   reverseStringRecursive("ello") + "h"
      reverseStringRecursive("llo") + "e"
         reverseStringRecursive("lo") + "l"
            reverseStringRecursive("o") + "l"
               "o"
            Backtrack: "o" + "l" = "ol"
         Backtrack: "ol" + "l" = "oll"
      Backtrack: "oll" + "e" = "olle"
   Backtrack: "olle" + "h" = "olleh"
*/
}

console.log(reverseStringIterative("doog si azzip"));
console.log(reverseStringIterative2("doog si azzip"));
console.log(reverseStringIterative3("doog si azzip"));
console.log(reverseStringRecursive("doog si azzip"));
//should return: 'pizza is good'
