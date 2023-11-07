using System;
using System.Collections.Generic;

// Node class represents individual nodes in the linked list
public class Node
{
  public int Value; // Value of the node
  public Node Next; // Reference to the next node in the list

  // Constructor to initialize a node with a given value
  public Node(int value)
  {
    Value = value;
    Next = null; // By default, the next node is set to null
  }
}

// LinkedList class manages the linked list and its operations
public class LinkedList
{
  public Node Head; // Points to the first node in the list
  public Node Tail; // Points to the last node in the list
  public int Length; // Stores the length of the list

  // Constructor initializes the linked list with a single node
  public LinkedList(int value)
  {
    Node newNode = new Node(value); // Create a new node with the given value
    Head = newNode; // Set both Head and Tail to this node
    Tail = newNode;
    Length = 1; // Length is initially 1
  }

  // Append method adds a new node to the end of the list
  public void Append(int value)
  {
    Node newNode = new Node(value); // Create a new node with the given value
    Tail.Next = newNode; // Make the current Tail point to the new node
    Tail = newNode; // Update Tail to be the new node
    Length++; // Increase the length of the list
  }

  // Prepend method adds a new node to the beginning of the list
  public void Prepend(int value)
  {
    Node newNode = new Node(value); // Create a new node with the given value
    newNode.Next = Head; // Make the new node point to the current Head
    Head = newNode; // Update Head to be the new node
    Length++; // Increase the length of the list
  }

  // TraverseToIndex method finds the node at a specified index
  public Node TraverseToIndex(int index)
  {
    if (index < 0 || index >= Length)
    {
      throw new ArgumentException("Invalid index"); // Throw an error if index is out of bounds
    }

    int counter = 0;
    Node currentNode = Head; // Start from the Head node
    while (counter != index)
    {
      currentNode = currentNode.Next; // Move to the next node in the list
      counter++;
    }
    return currentNode; // Return the node at the specified index
  }

  // Insert method adds a new node at a specified index
  public void Insert(int index, int value)
  {
    if (index < 0 || index > Length)
    {
      throw new ArgumentException("Invalid index"); // Throw an error if index is out of bounds
    }

    Node newNode = new Node(value); // Create a new node with the given value

    if (index == 0)
    {
      newNode.Next = Head; // Insert at the beginning: Make new node point to current Head
      Head = newNode; // Update Head to be the new node
      if (Length == 0)
      {
        Tail = newNode; // If list was empty, also update Tail
      }
    }
    else if (index == Length)
    {
      Tail.Next = newNode; // Insert at the end: Make current Tail point to the new node
      Tail = newNode; // Update Tail to be the new node
    }
    else
    {
      Node previousNode = TraverseToIndex(index - 1); // Find the node before the specified index
      Node nodeAtIndex = previousNode.Next; // Get the node at the specified index

      previousNode.Next = newNode; // Make previous node point to the new node
      newNode.Next = nodeAtIndex; // Make new node point to the node at the specified index
    }

    Length++; // Increase the length of the list
  }

  // Remove method removes a node at a specified index
  public void Remove(int index)
  {
    if (index < 0 || index >= Length)
    {
      throw new ArgumentException("Invalid index"); // Throw an error if index is out of bounds
    }

    if (index == 0)
    {
      Head = Head.Next; // Remove the first node: Update Head to point to the next node
      if (Length == 1)
      {
        Tail = null; // If list only had one node, update Tail to null
      }
    }
    else
    {
      Node previousNode = TraverseToIndex(index - 1); // Find the node before the specified index
      Node nodeToRemove = previousNode.Next; // Get the node to be removed

      previousNode.Next = nodeToRemove.Next; // Make previous node skip over the node to be removed

      if (index == Length - 1)
      {
        Tail = previousNode; // If removing the last node, update Tail to be the previous node
      }
    }

    Length--; // Decrease the length of the list
  }

  // PrintList method returns a list of values in the linked list
  public List<int> PrintList()
  {
    List<int> listValues = new List<int>();
    Node currentNode = Head; // Start from the Head node
    while (currentNode != null)
    {
      listValues.Add(currentNode.Value); // Add value to the list
      currentNode = currentNode.Next; // Move to the next node
    }
    return listValues; // Return the list of values
  }
}

// Main program to demonstrate the linked list operations
class Program
{
  static void Main()
  {
    LinkedList myLinkedList = new LinkedList(10);

    myLinkedList.Append(5);
    myLinkedList.Append(16);
    myLinkedList.Prepend(1);

    Console.WriteLine(string.Join(" --> ", myLinkedList.PrintList()));

    myLinkedList.Insert(2, 123);
    Console.WriteLine(string.Join(" --> ", myLinkedList.PrintList()));

    myLinkedList.Remove(2);
    Console.WriteLine(string.Join(" --> ", myLinkedList.PrintList()));

    myLinkedList.Remove(myLinkedList.Length - 1);
    Console.WriteLine(string.Join(" --> ", myLinkedList.PrintList()));
  }
}
