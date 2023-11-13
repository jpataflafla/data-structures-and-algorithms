using System;
using System.Collections.Generic;

public class EmptyQueueException : Exception
{
  public EmptyQueueException() : base("The queue is empty.") { }
}

public class Node<T>
{
  public T? Value { get; private set; }
  public Node<T>? Next { get; set; }
  public Node(T value)
  {
    this.Value = value;
    this.Next = null;
  }
}

public class MyQueue<T>
{
  public Node<T>? First { get; set; }
  public Node<T>? Last { get; set; }
  public int Length { get; set; }

  public MyQueue()
  {
    this.First = null;
    this.Last = null;
    this.Length = 0;
  }

  public bool IsEmpty() => this.Length == 0;

  public T? Peek() => this.First.Value; /*If this.First is not null, it accesses  the Value property of the object and returns it.
  If this.First is null, it short-circuits the expression and returns null.*/

  public T? Dequeue()
  {
    if (IsEmpty())
    {
      throw new EmptyQueueException();
      //return null;
    }

    var element = this.First;
    this.First = this.First.Next;
    this.Length--;
    if (IsEmpty())
    {
      this.Last = null;
    }
    return element.Value;
  }

  public T Enqueue(T Value)
  {
    var newElement = new Node<T>(Value);
    if (IsEmpty())
    {
      this.First = newElement;
    }
    else
    {
      this.Last.Next = newElement;
    }

    this.Last = newElement;
    this.Length++;

    return newElement.Value;
  }

  public void PrintQueue()
  {
    Node<T> currentNode = this.First;
    Console.WriteLine("____");
    Console.WriteLine("length: " + this.Length);
    if (IsEmpty())
    {
      Console.WriteLine("empty queue");
      return;
    }
    Console.WriteLine("first value: " + (this.First != null ? this.First.Value.ToString() : "null"));
    Console.WriteLine("last value: " + (this.Last != null ? this.Last.Value.ToString() : "null"));

    Console.WriteLine("QUEUE:");
    int counter = 0;
    while (currentNode != null)
    {
      Console.WriteLine(counter + ": " + currentNode.Value);
      currentNode = currentNode.Next; // Move to the next node
      if (currentNode == null)
      {
        Console.WriteLine("____");
      }
      counter++;
    }
  }

}

public class Program
{
  public static void Main(string[] args)
  {
    var myQueue = new MyQueue<string>();

    myQueue.Enqueue("google");
    myQueue.Enqueue("fb");
    myQueue.Enqueue("youtube");

    Console.WriteLine(myQueue);
    Console.WriteLine("peek: " + myQueue.Peek());
    myQueue.PrintQueue();

    Console.WriteLine("dequeue: " + myQueue.Dequeue());
    Console.WriteLine("peek: " + myQueue.Peek());

    myQueue.PrintQueue();

    Console.WriteLine("peek: " + myQueue.Peek());
    myQueue.PrintQueue();

    Console.WriteLine("dequeue: " + myQueue.Dequeue());
    myQueue.PrintQueue();

    Console.WriteLine("dequeue: " + myQueue.Dequeue());

    myQueue.PrintQueue();
  }
}