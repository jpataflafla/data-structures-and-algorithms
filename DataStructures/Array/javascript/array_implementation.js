class MyArray {
  constructor() {
    this.length = 0;
    this.data = {};
  }

  //provides data access
  get(index) {
    return this.data[index];
  }

  //provides method to add something to the array
  push(item) {
    this.data[this.length] = item;
    this.length++;
    return this.length; //typical push method in JS will return the length of an array
  }

  //to remove the last item from an array
  pop() {
    //TODO: prevent pop when length less than 1
    const lastItem = this.data[this.length - 1];
    delete this.data[this.length - 1];
    this.length--;
    return lastItem;
  }

  //to delete item
  delete(index) {
    const item = this.data[index];
    this.shiftItems(index); //single principle responsibility -> shift should be done in another method
  }

  //shift items when i.e. one item inside array was deleted
  shiftItems(index) {
    //start at the index where we want to remove the item and iterate to shift the indices from that index to the left by 1
    for (let i = index; i < this.length; i++) {
      // O(n)
      this.data[i] = this.data[i + 1];
    }
    delete this.data[this.length - 1];
    this.length--;
  }
}

// test it
const newArray = new MyArray();
console.log(newArray.push("hi"));
console.log(newArray.push("you"));
console.log(newArray.push("!"));

console.log(newArray.get(0));
console.log(newArray);
console.log(newArray.pop());
console.log(newArray);
console.log(newArray.delete(1));
console.log(newArray);
