// implemented with linked lists
class Node {
  constructor(value) {
    this.value = value;
    this.next = null;
  }
}

class Queue {
  constructor(value) {
    this.first = null;
    this.last = null;
    this.length = 0;
  }

  peek() {
    return this.first === null ? null : this.first.value;
  }

  enqueue(value) {
    const newElement = new Node(value);

    if (this.last === null) {
      this.first = newElement;
    } else {
      this.last.next = newElement;
    }
    this.last = newElement;
    this.length++;
  }

  dequeue() {
    if (this.first === null) {
      return null;
    }

    const element = this.first;
    this.first = element.next;
    element.next = null;
    this.length--;
    if (this.isEmpty) {
      this.last = null;
    }
    return element.value;
  }

  isEmpty() {
    return this.length === 0;
  }

  printQueue() {
    let currentNode = this.first;
    console.log("____");
    console.log("length: " + this.length);
    if (this.isEmpty()) {
      console.log("empty queue");
      return;
    }
    console.log("first value: " + this.first?.value);
    console.log("last value: " + this.last?.value);

    console.log("QUEUE:");
    let counter = 0;
    while (currentNode != null) {
      console.log(counter + ": " + currentNode.value);
      currentNode = currentNode.next; // Move to the next node
      if (currentNode === null) {
        console.log("____");
      }
      counter++;
    }
  }
}

const myQueue = new Queue();

myQueue.enqueue("google");
myQueue.enqueue("fb");
myQueue.enqueue("youtube");

console.log(myQueue);
console.log("peek: " + myQueue.peek());
myQueue.printQueue();

console.log("dequeue: " + myQueue.dequeue());
console.log("peek: " + myQueue.peek());

myQueue.printQueue();

console.log("peek: " + myQueue.peek());
myQueue.printQueue();

console.log("dequeue: " + myQueue.dequeue());
myQueue.printQueue();

console.log("dequeue: " + myQueue.dequeue());

myQueue.printQueue();
