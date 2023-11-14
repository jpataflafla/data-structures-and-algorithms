// Write two functions that find the factorial of any number.
//One should use a recursive algorithm,
//and the second one should use a loop (iterative algorithm).

function calculateFactorialRecursive(number) {
  // O(n)
  if (number < 0) {
    throw new Error("Input must be a non-negative integer");
  }

  if (number === 0 || number === 1) {
    //0! = 1 and 1! = 1
    return 1;
  }

  console.log(number + "  a");
  return number * calculateFactorialRecursive(number - 1);
}

function calculateFactorialTailRecursive(number, accumulator = 1) {
  // O(n) time complexity
  // O(n) - space complexity
  if (number < 0) {
    throw new Error("Input must be a non-negative integer");
  }

  if (number === 0 || number === 1) {
    // Base cases: 0! = 1 and 1! = 1
    return accumulator;
  }

  return calculateFactorialTailRecursive(number - 1, number * accumulator);
}
/*In both versions, the maximum depth of the call stack is determined by the value of "number." The space complexity is proportional to the depth of the recursion, making it O(n). Tail call optimization, if supported by the JavaScript engine, could potentially reduce the space complexity to O(1) by reusing the same stack frame for each recursive call, but in 2022, not all JavaScript engines implement this optimization. It should be checked for specific environment */

function calculateFactorialIterative(number) {
  // O(n)
  if (number < 0) {
    throw new Error("Input must be a non-negative integer");
  }

  let answer = 1;
  while (number !== 0 && number !== 1) {
    answer *= number;
    number--;
  }
  return answer;
}

//or using  for loop
//Iterative function to find the factorial
function calculateFactorialIterative2(number) {
  // O(n)
  if (number < 0) {
    throw new Error("Input must be a non-negative integer");
  }

  let result = 1;
  for (let i = 1; i <= number; i++) {
    result *= i;
  }
  return result;
}

// Example usage
const number = 5;

let recursiveResult = calculateFactorialRecursive(number);
console.log("Recursive: " + recursiveResult);

let recursiveResult2 = calculateFactorialTailRecursive(number);
console.log("Recursive - tail optimization: " + recursiveResult2);

let iterativeResult = calculateFactorialIterative(number);
console.log("Iterative: " + iterativeResult);

let iterativeResult2 = calculateFactorialIterative2(number);
console.log("Iterative2: " + iterativeResult2);
