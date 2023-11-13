class QueueWithStacks {
  constructor() {
    this.stackDequeue = []; //just js array with pop and push so no operations on indexes will be used to treat this as Stack
    this.stackEnqueue = [];
  }

  isEmpty() {
    return this.stackDequeue.length === 0 && this.stackEnqueue.length === 0;
  }

  enqueue(value) {
    this.stackEnqueue.push(value);
  }

  dequeue() {
    if (this.stackDequeue.length === 0) {
      if (this.stackEnqueue.length === 0) {
        return null;
      }

      while (this.stackEnqueue.length > 0) {
        this.stackDequeue.push(this.stackEnqueue.pop());
      }
    }

    return this.stackDequeue.pop();
  }

  peek() {
    if (this.stackDequeue.length === 0) {
      if (this.stackEnqueue.length === 0) {
        return null;
      }

      while (this.stackEnqueue.length > 0) {
        this.stackDequeue.push(this.stackEnqueue.pop());
      }
    }
    //similar like dequeue but we want only reference, without pop
    //return this.stackDequeue[this.stackDequeue.length - 1]; //but this solution uses array index - and there is another way to do this using only stack operations
    let topElement = this.stackDequeue.pop();
    this.stackDequeue.push(topElement);
    return topElement;
  }

  printQueue() {
    if (this.isEmpty()) {
      console.log("empty queue");
      return;
    }

    console.log("QUEUE:");
    let counter = 0;

    // Create a copy of the dequeue stack for iteration without altering the original
    let tempStackDequeue = [...this.stackDequeue];
    let tempStackEnqueue = [...this.stackEnqueue];
    /*Both slice() and the spread operator (...) can be used to create a shallow copy of an array or stack in JavaScript. They serve the same purpose in this context.*/
    // let tempStackDequeue = this.stackDequeue.slice();
    // let tempStackEnqueue = this.stackEnqueue.slice();

    console.log("length: " + tempStackDequeue.length);

    while (tempStackDequeue.length > 0) {
      let element = tempStackDequeue.pop();
      console.log(counter + ": " + element);
      counter++;
    }
    while (tempStackEnqueue.length > 0) {
      let element = tempStackEnqueue.pop();
      console.log(counter + ": " + element);
      counter++;
    }

    console.log("____");
  }
}

const myQueue = new QueueWithStacks();

myQueue.enqueue("a");
myQueue.enqueue("b");
myQueue.enqueue("c");
myQueue.printQueue();

myQueue.enqueue("d");
myQueue.printQueue();

console.log(myQueue.dequeue());
myQueue.printQueue();

myQueue.enqueue("e");
myQueue.printQueue();

console.log(myQueue.peek());
myQueue.printQueue();
