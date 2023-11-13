using System;
using System.Collections.Generic;

public class QueueUsingStacks<T>
{
  private Stack<T> _enqueueStack;
  private Stack<T> _dequeueStack;

  public QueueUsingStacks()
  {
    this._enqueueStack = new Stack<T>();
    this._dequeueStack = new Stack<T>();
  }

  public bool IsEmpty => _dequeueStack.Count == 0 && _enqueueStack.Count == 0;

  public void Enqueue(T value)
  {
    _enqueueStack.Push(value);
  }

  public T Dequeue()
  {
    FillDequeueStack();
    return _dequeueStack.Pop();
  }

  public T Peek()
  {
    FillDequeueStack();

    return _dequeueStack.Peek();
  }

  public override string ToString()
  {
    List<T> elements = new List<T>();
    FillDequeueStack();

    // Create a temporary stack to store elements from _enqueueStack in reverse order
    Stack<T> tempStack = new Stack<T>();

    while (_enqueueStack.Count > 0)
    {
      tempStack.Push(_enqueueStack.Pop());
    }

    foreach (var item in _dequeueStack)
    {
      elements.Add(item);
    }

    foreach (var item in tempStack)
    {
      elements.Add(item);
      _enqueueStack.Push(item); // Add the elements back to _enqueueStack
    }

    return string.Join(", ", elements);
  }


  private void FillDequeueStack()
  {
    if (_dequeueStack.Count == 0)
    {
      if (_enqueueStack.Count == 0)
      {
        throw new Exception("Empty queue");
      }

      while (_enqueueStack.Count > 0)
      {
        _dequeueStack.Push(_enqueueStack.Pop());
      }
    }
  }
}

public class Program
{
  public static void Main()
  {
    QueueUsingStacks<string> myQueue = new QueueUsingStacks<string>();

    myQueue.Enqueue("a");
    Console.WriteLine("Enqueue(a)");

    myQueue.Enqueue("b");
    Console.WriteLine("Enqueue(b)");

    myQueue.Enqueue("c");
    Console.WriteLine("Enqueue(c)");

    Console.WriteLine(myQueue);

    myQueue.Enqueue("d");
    Console.WriteLine("Enqueue(d)");
    Console.WriteLine(myQueue);

    Console.WriteLine("Dequeue(): " + myQueue.Dequeue());

    Console.WriteLine(myQueue);

    myQueue.Enqueue("e");
    Console.WriteLine("Enqueue(e)");

    Console.WriteLine(myQueue);

    Console.WriteLine("Peek(): " + myQueue.Peek());

    Console.WriteLine(myQueue);
  }
}
