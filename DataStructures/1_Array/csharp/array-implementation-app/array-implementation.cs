using System;

class MyArray
{
    private int _length;
    public int Length => _length;

    private Object[] _data;

    public MyArray()
    {
        this._length = 0;
        this._data = new Object[1]; //just new array with 1 element
        //in c# array like this is static; List is dynamic collection in c#
    }

    public Object Get(int index)
    {
        return _data[index];
    }

    //add element
    // public Object[] Push(Object item)
    // {
    //     // Check if the array is full
    //     if (this._data.Length == this._length)
    //     {
    //         // Create a temporary array and copy existing data
    //         Object[] temp = new Object[this._length];
    //         Array.Copy(this._data, temp, this._length);

    //         // Increase size of the main array
    //         this._data = new Object[_length + 1]; //increases size of temp array

    //         // Copy back the data from the temporary array to the main array
    //         Array.Copy(temp, this._data, this._length);
    //     }

    //     // Insert the new item into the last index
    //     this._data[this._length] = item;

    //     // Increment the length
    //     this._length++;

    //     // Return the modified array
    //     return this._data;
    // }

    public Object[] Push(Object item)
    {
        if (this._data.Length == this._length)
        {
            Array.Resize(ref this._data, this._length * 2); // Double the length of the array - common strategy
            /*Doubling the size of the array when it needs to be resized is a common strategy in dynamic array implementations. This strategy is used to achieve amortized constant time complexity for appending elements to the array.

            When you double the size of the array, you ensure that the number of times you need to resize the array is relatively small compared to the number of elements you can store. This means that, on average, each append operation takes constant time.

            If you were to increase the size by a fixed amount (e.g., adding one extra element each time), you would end up with a worst-case scenario of O(n) time complexity for appending elements, where n is the number of elements in the array. This is because you would have to resize the array every time you reach its current capacity.

            By doubling the size, you reduce the frequency of resizing operations, leading to better overall performance. Keep in mind that this is a common strategy, and the exact factor by which the array is resized can vary depending on the specific requirements of the application.*/

            /*Doubling is actually not so much related to performance but to simplicity. It is mostly used in textbooks. Real-world implementations use different factors, e.g. Microsoft's implementation of the C++ STL uses 1.5x, as does .NET. For dictionaries, .NET uses 1.5x rounded up to the next prime number. Oracle's implementation of ArrayList[T] uses 1.25x. YARV uses 1.25x. Python uses 1.125x + 3 for smaller x and 1.125x + 6 for large x. 1.5x has some performance advantages over 2x. For a specific definition of "optimal" and an infinitely large array, the optimal value is actually the golden ratio. */
        }
        this._data[this._length++] = item; // Insert item into last index and increment length
        return this._data;
    }

    public Object Pop()
    {
        // Get the last item from the array
        Object popped = _data[this._length - 1];

        // Clear the last item by setting it to null (or you could use default(Object) for reference types)
        _data[this._length - 1] = default(Object);//null;

        // Decrease the length by 1 to reflect the removal of the last item
        this._length--;

        // Return the removed item
        return popped;
    }

    public Object Delete(int index)
    {
        // Get the item to delete
        Object itemToDelete = _data[index];

        // Shift items after the deleted index
        ShiftItems(index);

        return itemToDelete;
    }

    private void ShiftItems(int index)
    {
        // Shift items after the specified index one position to the left
        for (int i = index; i < _length - 1; i++)
        {
            _data[i] = _data[i + 1];
        }

        // Set the last item to null (or default(Object) for reference types)
        //_data[_length - 1] = null; //this is not removing item and can make memory leak, so ..
        // Object[] newData = new Object[_length - 1];
        // for (int i = 0; i < newData.Length; i++)
        // {
        //     newData[i] = _data[i];
        // }
        // _data = newData;
        //or just
        if (_length > 1)
        {
            Object[] newData = new Object[_length - 1];
            Array.Copy(_data, 0, newData, 0, _length - 1);

            _data = newData;
        }
        else
        {
            // Handle the case when the original array has only one element or is empty.
            // You may want to assign an empty array or null to _data, depending on your requirements.
            _data = new Object[1]; // or _data = null;
        }


        // Decrease the length to reflect the removal of an item
        _length--;
    }
}

static class Program
{
    private static void PrintAll(MyArray myArray)
    {
        for (int i = 0; i < myArray.Length; i++)
        {
            Console.WriteLine(myArray.Get(i));
        }
        Console.WriteLine("___\n");
    }
    static void Main(string[] args)
    {
        MyArray myArray = new MyArray();

        myArray.Push("Hello");
        myArray.Push("World");
        myArray.Push("!");

        PrintAll(myArray);
        myArray.Pop();
        PrintAll(myArray);

        myArray.Delete(1);
        PrintAll(myArray);
    }

}
