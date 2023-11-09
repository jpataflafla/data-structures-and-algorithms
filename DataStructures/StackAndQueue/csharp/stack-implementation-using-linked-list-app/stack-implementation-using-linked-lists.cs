using System;

class Node
{
  public string Value { get; private set; } // Value of the node
  public Node Next { get; set; } // Pointer to the next node in the stack

  public Node(string value)
  {
    Value = value;
    Next = null;
  }
}

class Stack
{
  private Node _top; // Points to the top node of the stack
  private Node _bottom; // Points to the bottom node of the stack (not necessary in most cases)
  private int _length; // Keeps track of the number of elements in the stack

  public string Peek()
  {
    return _top != null ? _top.Value : null; // Returns the value of the top node without removing it
  }

  public string Pop()
  {
    if (_top == null)
    {
      return null; // If the stack is empty, return null
    }

    Node topElement = _top; // Store the top node in a variable
    _top = topElement.Next; // Move the top pointer to the next node
    topElement.Next = null; // Remove the reference to the next node (prevents memory leaks)
    _length--; // Decrease the length of the stack

    if (_length == 0)
    {
      _bottom = null; // If the stack is now empty, also update the bottom pointer
    }

    return topElement.Value; // Return the value of the popped node
  }

  public void Push(string value)
  {
    Node newNode = new Node(value); // Create a new node with the provided value
    newNode.Next = _top; // Set the new node's next pointer to the current top node
    _top = newNode; // Set the new node as the new top of the stack

    if (_length == 0)
    {
      _bottom = newNode; // If it's the first node, also update the bottom pointer
    }

    _length++; // Increase the length of the stack
  }

  public bool IsEmpty()
  {
    return _length == 0; // If length is 0, the stack is empty
  }

  public void PrintStack()
  {
    Node currentNode = _top; // Start from the top of the stack

    Console.WriteLine("____");
    Console.WriteLine("length: " + _length);

    if (_length == 0 && _top == null)
    {
      Console.WriteLine("empty stack"); // If both top and length indicate an empty stack
      return;
    }

    Console.WriteLine("top value: " + _top.Value);
    Console.WriteLine("bottom value: " + _bottom.Value);

    Console.WriteLine("STACK:");

    while (currentNode != null)
    {
      Console.WriteLine(currentNode.Value);

      currentNode = currentNode.Next; // Move to the next node

      if (currentNode != null)
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
    Stack myStack = new Stack(); // Create a new instance of the Stack

    // Push some values onto the stack
    myStack.Push("google");
    myStack.Push("fb");
    myStack.Push("youtube");

    // Print the current state of the stack
    Console.WriteLine(myStack.Peek());
    myStack.PrintStack();

    // Pop a value from the stack and print the updated state
    Console.WriteLine("pop: " + myStack.Pop());
    myStack.PrintStack();

    // Peek at the top value without popping it and print the state
    Console.WriteLine("peek: " + myStack.Peek());
    myStack.PrintStack();

    // Pop another value and print the updated state
    Console.WriteLine("pop: " + myStack.Pop());
    myStack.PrintStack();

    // Try to pop from an empty stack (returns null)
    Console.WriteLine("pop: " + myStack.Pop());

    // Print the final state of the stack
    myStack.PrintStack();
  }
}
