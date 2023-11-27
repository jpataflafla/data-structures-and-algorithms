//0, 1, 1, 2, 3, 5, 8, 13, 21, 34

let calculationsCount = 0;
function fibonacci(n) {
  calculationsCount++;
  if (n < 2) {
    return n;
  }
  return fibonacci(n - 1) + fibonacci(n - 2);
}

fibonacci(7); //this will make 13 calculations with recursive function, 8 -> 21, 9->34 and so on etc. it grows fast -> it is O(2^n) every nested call has 2 nested calls

// how to make it more efficient with dynamic programming?
// it is possible to make it O(n) using memoization
// Function that returns a memoized Fibonacci function
let memoizedCalculationCalls = 0;
function fibonacciMemoization() {
  // Object to store previously computed Fibonacci values for reuse
  let cache = {};

  // Inner function representing the actual Fibonacci calculation with memoization
  return function fib(n) {
    memoizedCalculationCalls++;

    // Check if the Fibonacci value for 'n' is already in the cache
    if (n in cache) {
      // If yes, return the cached value to avoid redundant calculations
      return cache[n];
    }

    // Base case: if n is 0 or 1, return n as the Fibonacci value
    if (n < 2) {
      return n;
    }

    // Recursive case: calculate Fibonacci value for n using memoization
    cache[n] = fib(n - 1) + fib(n - 2);

    // Return the calculated value for n
    return cache[n];
  };
}

// Example usage:
// Create a memoized Fibonacci function
const memoizedFibonacci = fibonacciMemoization();
console.log(memoizedFibonacci(10));
console.log(memoizedCalculationCalls + " memoized calculations");
console.log(fibonacci(10));
console.log(calculationsCount + " classic recursive fibonacci calculations");
