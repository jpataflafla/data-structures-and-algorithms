using System;

public class Stack<T>
{
  private T[] data; // Use an array to store the elements in the stack

  public Stack()
  {
    data = new T[0]; // Initialize with an empty array
  }

  // Property to get the length of the stack
  public int Length
  {
    get { return data.Length; } // Keeps track of the number of elements in the stack
  }

  // Property to get the top element of the stack
  public T Top
  {
    get { return Length == 0 ? default : data[Length - 1]; }
  }

  // Property to get the bottom element of the stack
  public T Bottom
  {
    get { return Length == 0 ? default : data[0]; }
  }

  // Method to peek at the top element without removing it
  public T Peek()
  {
    return Top; // Returns the value of the top node without removing it
  }

  // Method to pop the top element from the stack
  public T Pop()
  {
    if (Length == 0)
    {
      return default; // Return default value for type if stack is empty
    }

    T topElement = data[Length - 1];
    Array.Resize(ref data, Length - 1); // Remove the last element
    return topElement;
  }

  // Method to push a new element onto the stack
  public void Push(T value)
  {
    Array.Resize(ref data, Length + 1); // Increase the array size by 1
    data[Length - 1] = value; // Add the new value to the top
  }

  // Method to check if the stack is empty
  public bool IsEmpty()
  {
    return Length == 0;
  }

  // Method to print the stack
  public void PrintStack()
  {
    Console.WriteLine("____");
    Console.WriteLine("length: " + Length);

    if (IsEmpty())
    {
      Console.WriteLine("empty stack");
      return;
    }

    Console.WriteLine("top value: " + Top);
    Console.WriteLine("bottom value: " + Bottom);

    Console.WriteLine("STACK:");

    for (int i = Length - 1; i >= 0; i--)
    {
      Console.WriteLine(data[i]);

      if (i != 0)
      {
        Console.WriteLine("|");
      }
      else
      {
        Console.WriteLine("____");
      }
    }
  }
}

class Program
{
  static void Main()
  {
    Stack<string> stringStack = new Stack<string>();

    stringStack.Push("google");
    stringStack.Push("fb");
    stringStack.Push("youtube");

    Console.WriteLine(stringStack.Length);
    stringStack.PrintStack();

    Console.WriteLine("pop: " + stringStack.Pop());
    stringStack.PrintStack();

    Console.WriteLine("peek: " + stringStack.Peek());
    stringStack.PrintStack();

    Console.WriteLine("pop: " + stringStack.Pop());
    stringStack.PrintStack();

    Console.WriteLine("pop: " + stringStack.Pop());

    stringStack.PrintStack();

    Stack<int> intStack = new Stack<int>();

    intStack.Push(10);
    intStack.Push(20);
    intStack.Push(30);

    Console.WriteLine(intStack.Length);
    intStack.PrintStack();

    Console.WriteLine("pop: " + intStack.Pop());
    intStack.PrintStack();

    Console.WriteLine("peek: " + intStack.Peek());
    intStack.PrintStack();

    Console.WriteLine("pop: " + intStack.Pop());
    intStack.PrintStack();

    Console.WriteLine("pop: " + intStack.Pop());

    intStack.PrintStack();
  }
}
