class Node {
  constructor(value) {
    this.value = value; // Value of the node
    this.next = null; // Pointer to the next node in the stack
  }
}

class Stack {
  constructor() {
    this.top = null; // Points to the top node of the stack
    this.bottom = null; // Points to the bottom node of the stack (not necessary in most cases)
    this.length = 0; // Keeps track of the number of elements in the stack
  }

  peek() {
    return this.top ? this.top.value : null; // Returns the value of the top node without removing it
  }

  pop() {
    if (this.top === null) {
      return null; // If the stack is empty, return null
    }
    const topElement = this.top; // Store the top node in a variable
    this.top = topElement.next; // Move the top pointer to the next node
    topElement.next = null; // Remove the reference to the next node (prevents memory leaks)
    this.length--; // Decrease the length of the stack
    if (this.length === 0) {
      this.bottom = null; // If the stack is now empty, also update the bottom pointer
    }
    return topElement.value; // Return the value of the popped node
  }

  push(value) {
    const newNode = new Node(value); // Create a new node with the provided value
    newNode.next = this.top; // Set the new node's next pointer to the current top node
    this.top = newNode; // Set the new node as the new top of the stack
    if (this.length === 0) {
      this.bottom = newNode; // If it's the first node, also update the bottom pointer
    }
    this.length++; // Increase the length of the stack
  }

  isEmpty() {
    return this.length === 0; // If length is 0, the stack is empty
  }

  printStack() {
    let currentNode = this.top; // Start from the top of the stack

    console.log("____");
    console.log("length: " + this.length);
    if (this.length === 0 && this.top === null) {
      console.log("empty stack"); // If both top and length indicate an empty stack
      return;
    }
    console.log("top value: " + this.top.value);
    console.log("bottom value: " + this.bottom.value);

    console.log("STACK:");
    while (currentNode != null) {
      console.log(currentNode.value);

      currentNode = currentNode.next; // Move to the next node
      if (currentNode !== null) {
        console.log("|");
      } else {
        console.log("____");
      }
    }
  }
}

const myStack = new Stack(); // Create a new instance of the Stack

// Push some values onto the stack
myStack.push("google");
myStack.push("fb");
myStack.push("youtube");

// Print the current state of the stack
console.log(myStack);
myStack.printStack();

// Pop a value from the stack and print the updated state
console.log("pop: " + myStack.pop());
myStack.printStack();

// Peek at the top value without popping it and print the state
console.log("peek: " + myStack.peek());
myStack.printStack();

// Pop another value and print the updated state
console.log("pop: " + myStack.pop());
myStack.printStack();

// Try to pop from an empty stack (returns null)
console.log("pop: " + myStack.pop());

// Print the final state of the stack
myStack.printStack();
