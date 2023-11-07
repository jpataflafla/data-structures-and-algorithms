// 10 --> 5 --> 16
// example stupid simple implementation of this linked list:
// let myLinkedList = {
//   head: {
//     // first node
//     value: 10,
//     // reference to the next node
//     next: {
//       value: 5,
//       // this is tail
//       next: {
//         value: 16,
//         next: null, // end of the list
//       },
//     },
//   },
// };

// now implementation of singly linked list and use with the same example
class Node {
  constructor(value) {
    this.value = value;
    this.next = null;
  }
}

class LinkedList {
  constructor(value) {
    // this.head = {
    //   value: value,
    //   next: null,
    // };
    this.head = new Node(value);

    // in constructor we create only 1 node head and tail in the same time
    this.tail = this.head;
    this.length = 1;
  }

  append(value) {
    // O(1) - no iterations
    // const newNode = {
    //   value: value,
    //   next: null,
    // };
    const newNode = new Node(value);
    this.tail.next = newNode;
    this.tail = newNode;
    this.length++;

    return this;
  }

  prepend(value) {
    // O(1)
    const newNode = new Node(value);
    newNode.next = this.head;
    this.head = newNode;
    this.length++;

    return this;
  }

  traverseToIndex(index) {
    //check parameters
    if (index < 0 || index >= this.length) {
      throw new Error(
        "index must be more than zero and less that (length - 1)"
      );
    }

    let counter = 0;
    let currentNode = this.head;
    while (counter != index) {
      currentNode = currentNode.next;
      counter++;
    }
    return currentNode;
  }

  insert(index, value) {
    // O(n) - iteration is needed to get a reference of node at given index inside the list
    // Check if the index is valid (non-negative and within bounds)
    if (index < 0 || index >= this.length) {
      throw new Error("Invalid index");
    }

    if (index === 0) {
      this.prepend(value);
      // Return the updated list
      return this.printList();
    }
    if (index === this.length - 1) {
      this.append(value);
      // Return the updated list
      return this.printList();
    }

    const newNode = new Node(value);

    // Find the node before the desired index
    const previousNode = this.traverseToIndex(index - 1);

    // Save the reference to the node currently at the desired index
    const nodeAtIndex = previousNode.next;

    // Set the next pointer of the previous node to the new node
    previousNode.next = newNode;

    // Set the next pointer of the new node to the node previously at the index
    newNode.next = nodeAtIndex;

    // Increment the length of the list
    this.length++;

    // Return the updated list
    return this.printList();
  }

  remove(index) {
    // O(n) - iteration is needed
    // Check if the index is valid (non-negative and within bounds)
    if (index < 0 || index >= this.length) {
      throw new Error("Invalid index");
    }

    if (index === 0) {
      if (this.length === 1) {
        // If there's only one element in the list, set both head and tail to null
        this.head = null;
        this.tail = null;
      } else {
        // If there are more than one elements, update the head pointer
        this.head = this.head.next;
      }

      this.length--;
      return this.printList();
    }

    // Find the node before the desired index
    const previousNode = this.traverseToIndex(index - 1);

    // Get the reference to the node to be removed
    const nodeToRemove = previousNode.next;

    // Update the next pointer of the previous node to skip over the node to be removed
    previousNode.next = nodeToRemove.next;

    if (index === this.length - 1) {
      this.tail = previousNode; // If removing the last node, update Tail to be the previous node
    }

    // Decrement the length of the list
    this.length--;

    return this.printList();
  }

  printList() {
    const array = [];
    let currentNode = this.head;
    while (currentNode != null) {
      array.push(currentNode.value);
      currentNode = currentNode.next;
    }
    return array;
  }
}

const myLinkedList = new LinkedList(10);

myLinkedList.append(5);
myLinkedList.append(16);
myLinkedList.prepend(1);
console.log(myLinkedList.printList());
myLinkedList.insert(2, 123);
myLinkedList.insert(0, 123);
console.log(myLinkedList.printList());
myLinkedList.remove(2);
console.log(myLinkedList.printList());
myLinkedList.remove(myLinkedList.length - 1);
myLinkedList.remove(0);
console.log(myLinkedList.printList());
console.log(myLinkedList.length);
console.log(myLinkedList.head);
console.log(myLinkedList.tail);
