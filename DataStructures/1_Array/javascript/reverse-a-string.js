// create a function that reverses a string
// "Hi John" -> "nhoJ iH"

function reverseString(str) {
  // 1. check of our input
  if (!str || str.length < 2 || typeof str !== "string") {
    // if string is undefined or just one letter or is is not type of string
    return "input is not correct"; // should probably return an error
  }
  // 2. convert string into an array (we could do it by str.split but in JS strings are treated like arrays)
  const backwards = [];
  for (let i = str.length - 1; i >= 0; i--) {
    backwards.push(str[i]);
  }
  // 3. return reversed string
  return backwards.join("");
}

function reverseString2(str) {
  //simplification
  // 1. check of our input
  if (!str || str.length < 2 || typeof str !== "string") {
    // if string is undefined or just one letter or is is not type of string
    return "input is not correct"; // should probably return an error
  }
  // 2. convert string into an array (we could do it by str.split but in JS strings are treated like arrays)
  // 3. return reversed string
  return str.split("").reverse().join("");
}

// new ES6 syntax
const reverseString3 = (str) => str.split("").reverse().join("");

// fancy, using destructuring operator
const reverseString4 = (str) => [...str].reverse().join("");

console.log(reverseString("nhoJ iH"));
console.log(reverseString2("nhoJ iH"));
console.log(reverseString3("nhoJ iH"));
console.log(reverseString4("nhoJ iH"));
