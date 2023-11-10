class Node {
  constructor(value) {
    this.left = null;
    this.right = null;
    this.value = value;
  }
}

class BinarySearchTree {
  constructor() {
    this.root = null;
  }

  insert(value) {
    // Step 1: Create a new node with the given value
    const newNode = new Node(value);

    // Step 2: Check if the tree is empty
    if (this.root === null) {
      this.root = newNode; // Set the new node as the root if the tree is empty
      return; // Insertion is complete
    }

    // Step 3: Traverse the tree to find the right position
    let currentNode = this.root;
    while (true) {
      // Step 4: Compare and move left or right
      if (value < currentNode.value) {
        // Move to the left subtree
        if (currentNode.left === null) {
          currentNode.left = newNode; // Insert the new node on the left if the spot is empty
          break; // Insertion is complete
        }
        currentNode = currentNode.left; // Move to the left child and continue the loop
        continue;
      }

      if (value > currentNode.value) {
        // Move to the right subtree
        if (currentNode.right === null) {
          currentNode.right = newNode; // Insert the new node on the right if the spot is empty
          break; // Insertion is complete
        }
        currentNode = currentNode.right; // Move to the right child and continue the loop
        continue;
      }

      // Step 5: Handle the case where the value already exists
      // (you may choose to ignore or update, in this example, we break without doing anything)
      break;
    }
  }

  lookup(value) {
    if (this.root === null) {
      return null;
    }

    let currentNode = this.root;
    while (currentNode !== null) {
      if (currentNode.value === value) {
        return currentNode;
      }

      if (value < currentNode.value) {
        currentNode = currentNode.left;
        continue;
      }

      if (value > currentNode.value) {
        currentNode = currentNode.right;
        continue;
      }

      if (currentNode.value === null) {
        return null;
      }
    }
    return currentNode;
  }

  remove(value) {
    if (this.root === null) {
      // Tree is empty, nothing to remove
      return null;
    }

    let currentNode = this.root;
    let parentNode = null;

    // Step 1: Find the Node to Remove and its Parent
    while (currentNode !== null) {
      if (value === currentNode.value) {
        // Node to remove found
        break;
      }

      parentNode = currentNode;

      if (value < currentNode.value) {
        currentNode = currentNode.left;
        continue;
      }

      if (value > currentNode.value) {
        currentNode = currentNode.right;
        continue;
      }
    }

    if (currentNode === null) {
      // Node with the given value not found
      return null;
    }

    // Step 2: Case 1 - Node has no Children (Leaf Node)
    if (currentNode.left === null && currentNode.right === null) {
      if (parentNode === null) {
        // Node to remove is the root with no children
        this.root = null;
        return;
      }
      // Node to remove is a leaf, update parent's reference
      if (parentNode.left === currentNode) {
        parentNode.left = null;
      } else {
        parentNode.right = null;
      }
      return;
    }

    // Step 3: Case 2 - Node has One Child
    if (currentNode.left === null || currentNode.right === null) {
      const childNode = currentNode.left || currentNode.right;
      //this is the same as above=> const childNode = currentNode.left !== null ? currentNode.left : currentNode.right;

      if (parentNode === null) {
        // Node to remove is the root with one child
        this.root = childNode;
        return;
      }
      // Node to remove has one child, update parent's reference
      if (parentNode.left === currentNode) {
        parentNode.left = childNode;
      } else {
        parentNode.right = childNode;
      }

      return;
    }

    // Step 4: Case 3 - Node has Two Children
    // Find the successor (smallest value in the right subtree)
    let successor = currentNode.right;
    let successorParent = currentNode;

    while (successor.left !== null) {
      successorParent = successor;
      successor = successor.left;
    }

    // Replace the value of the node to remove with the successor value
    currentNode.value = successor.value;

    // Remove the successor (which is guaranteed to have at most one child)
    /*The successor, being the leftmost node in the right subtree, is guaranteed to have at most one child (at most a right child). This is because if the successor had a left child, it would not be the leftmost node*/
    if (successorParent.left === successor) {
      successorParent.left = successor.right; // right can be null value
    } else {
      successorParent.right = successor.right;
    }
  }
}

const tree = new BinarySearchTree();
//      9
//   4      20
// 1   6   15   170
tree.insert(9);
tree.insert(4);
tree.insert(6);
tree.insert(20);
tree.insert(15);
tree.insert(170);
tree.insert(1);

// console.log(JSON.stringify(traverse(tree.root)));
// function traverse(node) {
//   const tree = { value: node.value };
//   tree.left = node.left === null ? null : traverse(node.left);
//   tree.right = node.right === null ? null : traverse(node.right);
//   return tree;
// }

function printTree(node, level = 0, prefix = "Root: ") {
  if (node === null) {
    return "";
  }

  let treeStr = " ".repeat(level * 4) + prefix + node.value + "\n";
  treeStr += printTree(node.left, level + 1, "L: ");
  treeStr += printTree(node.right, level + 1, "R: ");

  return treeStr;
}
console.log(printTree(tree.root));

console.log(tree.lookup(171));
console.log(tree.lookup(4).value);
console.log(tree.lookup(6).value);

tree.remove(4);
console.log(printTree(tree.root));
