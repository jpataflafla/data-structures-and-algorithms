class Stack {
  constructor() {
    this.data = []; // Use an array to store the elements in the stack
  }

  // Use a getter for length
  get length() {
    return this.data.length; // Keeps track of the number of elements in the stack
  }

  get top() {
    return this.length === 0 ? null : this.data[this.length - 1];
  }

  get bottom() {
    return this.length === 0 ? null : this.data[0];
  }

  peek() {
    return this.top; // Returns the value of the top node without removing it
  }

  pop() {
    return this.data.pop(); // Use pop without arguments to remove the last element
  }

  push(value) {
    this.data.push(value);
  }

  isEmpty() {
    return this.length === 0; // If length is 0, the stack is empty
  }

  printStack() {
    console.log("____");
    console.log("length: " + this.length);
    if (this.isEmpty()) {
      console.log("empty stack");
      return;
    }
    console.log("top value: " + this.top);
    console.log("bottom value: " + this.bottom);

    console.log("STACK:");
    for (let i = this.length - 1; i >= 0; i--) {
      console.log(this.data[i]);

      if (i !== 0) {
        console.log("|");
      } else {
        console.log("____");
      }
    }
  }
}

const myStack = new Stack();

myStack.push("google");
myStack.push("fb");
myStack.push("youtube");

console.log(myStack);
myStack.printStack();

console.log("pop: " + myStack.pop());
myStack.printStack();

console.log("peek: " + myStack.peek());
myStack.printStack();

console.log("pop: " + myStack.pop());
myStack.printStack();

console.log("pop: " + myStack.pop());

myStack.printStack();
