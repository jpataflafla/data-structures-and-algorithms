// Fibonacci sequence using recursive and iterative approach
// 0 1 1 2 3 5 8 13

/*The Fibonacci sequence is defined such that each number is the sum of the two preceding ones. Therefore, when calculating the n-th Fibonacci number using recursion, we sum the result of the function for n-1 and n-2.*/
function fibonacciSequenceRecursive(n) {
  // O(2^n) - time complexity: The number of function calls grows exponentially with the input size 'n'.
  // O(n) - space complexity: The depth of the call stack is proportional to 'n', leading to linear space usage. Each level of the call stack requires O(1) space for function arguments and local variables. Since Fib(i-1) gets evaluated completely before Fib(i-2), there will never be more than i levels of recursion.
  //https://stackoverflow.com/questions/28756045/what-is-the-space-complexity-of-a-recursive-fibonacci-algorithm#:~:text=Space%20complexity%20of%20recursive%20fibonacci,together%20at%20the%20same%20time.

  if (n < 0) {
    throw new Error("Input should be non-negative integer");
  }

  if (n === 0 || n === 1) {
    // or n<2 or n<==1
    return n;
  }

  return fibonacciSequenceRecursive(n - 1) + fibonacciSequenceRecursive(n - 2);
}
/*The time complexity of the recursive Fibonacci algorithm is often expressed as O(2^n), where n is the input parameter. This is because, for each call to calculate a Fibonacci number, the algorithm makes two recursive calls, leading to an exponential growth in the number of function calls.

Let's break down the recursion for a better understanding:

For fibonacci(n), it makes two recursive calls: fibonacci(n - 1) and fibonacci(n - 2).
Each of those calls makes two more recursive calls, and so on.
In general, the number of function calls grows exponentially with the input size. More precisely, it's 2^n because, at each level of recursion, the number of calls doubles. This results in a binary tree structure where each node represents a function call, and the depth of the tree is proportional to n.

The time complexity is expressed in big O notation to describe the upper bound of an algorithm's growth rate. In the case of O(2^n) for the recursive Fibonacci algorithm, it indicates that the number of operations grows exponentially with the size of the input, making it highly inefficient for larger values of n.*/

function fibonacciSequenceIterative(n) {
  // Time complexity is O(n): More iterations are required for larger n, leading to linear time complexity.
  // Space complexity is also O(n): A larger array is constructed for larger n, resulting in linear space usage.

  if (n < 0) {
    throw new Error("Input should be non-negative integer");
  }

  if (n <= 1) {
    return n;
  }

  let fib = [0, 1]; // to have at least two elements and use n-1 and n-2 element

  for (let i = 2; i < n + 1; i++) {
    //i < n + 1 -> to use last and an element before
    fib.push(fib[i - 1] + fib[i - 2]);
  }

  return fib[n];
}

// Example: Print the first 10 Fibonacci numbers
for (let i = 0; i < 10; i++) {
  console.log(fibonacciSequenceRecursive(i));
}

for (let i = 0; i < 10; i++) {
  console.log(fibonacciSequenceIterative(i));
}
