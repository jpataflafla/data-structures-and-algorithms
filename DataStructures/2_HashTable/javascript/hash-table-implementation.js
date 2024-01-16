class HashTable {
  constructor(size) {
    this.data = new Array(size);
    // this will store buckets like an array inside an array [['grapes', 10000], ]
  }

  _hash(key) {
    // we are just looping over key, not whole collection so it is considered O(1) - constant time complexity
    // _ is to inform others that it should be treated as a private method
    // hash function
    let hash = 0;
    for (let i = 0; i < key.length; i++) {
      // Iterate over the key and add the character code (UTF-16 code) for the ith character to the hash value and multiply that value by i (to be more sure this will be unique). Then use modulo to take the remainder of dividing the calculated value by the length of the hash table.
      hash = (hash + key.charCodeAt(i) * i) % this.data.length;
    }
    return hash;
  }

  set(key, value) {
    // just adding/pushing data O(1)
    let address = this._hash(key);
    // if (!this.data[address]) {
    //   // if there is nothing at this address then add the element
    //   this.data[address] = [];
    //   this.data[address].push([key, value]);
    //   console.log(this.data);
    // } else {
    //   // if a collision occurs, don't create an array inside the main array, just add a second array [key, value] in the next place
    //   this.data[address].push([key, value]);
    // }

    // cleaner version - no else statement

    if (!this.data[address]) {
      // if there is nothing at this address then add the element (nested array for [key, value] arrays)
      this.data[address] = [];
    }

    this.data[address].push([key, value]); // this is simple hash collision handling - usually linked list is better to avoid shifting elements in this arrays and have fast insertion deletion
    console.log("data: ");
    console.log(this.data);
  }

  get(key) {
    //if there is no collisions O(1), but sometimes in case of the worst case scenario (collision with all elements) it may become O(n)
    let address = this._hash(key);
    const currentBucket = this.data[address];
    console.log("current bucket: " + currentBucket);
    if (currentBucket) {
      // if something exists at this address then ..

      for (let i = 0; i < currentBucket.length; i++) {
        if (currentBucket[i][0] === key) {
          //if the current bucket have value with key === key return the value
          return currentBucket[i][1];
        }
      }
    }

    return undefined; // nothing exists at this address
  }

  keys() {
    //by looping over the elements to get the keys -> O(n), and we also lose the order of the elements - it may be different from the insertion order
    if (!this.data.length) {
      return undefined;
    }
    let result = [];
    // loop through all the elements
    for (let i = 0; i < this.data.length; i++) {
      // if it's not an empty memory cell/ bucket
      if (this.data[i] && this.data[i].length) {
        // but also loop through all the potential collisions
        if (this.data.length > 1) {
          for (let j = 0; j < this.data[i].length; j++) {
            result.push(this.data[i][j][0]);
          }
        } else {
          result.push(this.data[i][0]);
        }
      }
    }
    return result;
  }
}

const myHashTable = new HashTable(50);
myHashTable.set("grapes", 10000);
myHashTable.set("apples", 40);

console.log(myHashTable.get("grapes"));
console.log(myHashTable.get("apples"));

console.log();
