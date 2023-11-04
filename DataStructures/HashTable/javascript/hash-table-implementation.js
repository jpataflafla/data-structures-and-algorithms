class HashTable {
  constructor(size) {
    this.data = new Array(size);
    // this will store buckets like an array inside an array [['grapes', 10000], ]
  }

  _hash(key) {
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

    this.data[address].push([key, value]);
    console.log("data: ");
    console.log(this.data);
  }

  get(key) {
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
}

const myHashTable = new HashTable(50);
myHashTable.set("grapes", 10000);
myHashTable.set("apples", 40);

console.log(myHashTable.get("grapes"));
console.log(myHashTable.get("apples"));
