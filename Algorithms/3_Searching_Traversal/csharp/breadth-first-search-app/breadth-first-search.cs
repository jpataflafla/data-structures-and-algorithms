using System;
//using System.Collections.Generic;
using System.Text; //string builder

namespace BinarySearchTreeImplementation;

public class Node
{
  public Node? Left { get; set; }
  public Node? Right { get; set; }
  public int Value { get; set; }

  public Node(int value)
  {
    Value = value;
    Left = null;
    Right = null;
  }
}
public class BinarySearchTree
{
  public Node? Root { get; set; }
  public BinarySearchTree()
  {
    this.Root = null;
  }

  public void Insert(int value)
  {
    var newNode = new Node(value);
    if (this.Root == null)
    {
      this.Root = newNode;
      return;
    }

    var currentNode = this.Root;

    while (currentNode != null)
    {
      //value already exists
      if (currentNode.Value == newNode.Value) { return; }

      if (newNode.Value > currentNode.Value)
      {
        // if (currentNode.Right == null)
        // {
        //   currentNode.Right = newNode;
        // }
        currentNode.Right ??= newNode;
        currentNode = currentNode.Right;
        continue;
      }

      if (newNode.Value < currentNode.Value)
      {
        if (currentNode.Left == null)
        {
          currentNode.Left = newNode;
        }
        currentNode = currentNode.Left;
        continue;
      }
    }
  }

  public Node? Lookup(int value)
  {
    var currentNode = this.Root;
    while (currentNode != null)
    {
      if (currentNode.Value == value)
      {
        return currentNode;
      }
      if (value > currentNode.Value)
      {
        currentNode = currentNode.Right;
        continue;
      }
      if (value < currentNode.Value)
      {
        currentNode = currentNode.Left;
        continue;
      }
    }
    //not found
    return null;

  }

  public void Remove(int value)
  {
    if (Root == null) return; //empty tree

    Node? currentNode = Root;
    Node? parentNode = null;

    while (currentNode != null)
    {
      if (value == currentNode.Value)
      {
        break; //current node is the node to remove
      }

      parentNode = currentNode;

      if (value < currentNode.Value)
      {
        currentNode = currentNode.Left;
        continue;
      }

      if (value > currentNode.Value)
      {
        currentNode = currentNode.Right;
        continue;
      }
    }

    if (currentNode == null) return;//node with given value not found

    //currentNode is the node to remove so:
    //Case 1 - Node has no children
    if (currentNode.Right == null && currentNode.Left == null)
    {
      if (parentNode == null)
      {
        //node to remove is the root node
        Root = null;
        return;
      }

      //node to remove is a leaf node, so update parent to remove it
      if (parentNode.Left == currentNode)
      {
        parentNode.Left = null;
      }
      else// if (parentNode.Right == currentNode)
      {
        parentNode.Right = null;
      }
      return;
    }

    //Case 2 - Node has one child
    if (currentNode.Left == null || currentNode.Right == null)
    {
      Node? childNode = currentNode.Left ?? currentNode.Right;

      if (parentNode == null)
      {
        //node to remove is the root node with one child
        this.Root = childNode;
        return;
      }

      // node to rm is not the root and has one child
      if (parentNode.Left == currentNode)
      {
        parentNode.Left = childNode;
      }
      else
      {
        parentNode.Right = childNode;
      }
      return;
    }

    //Case 3 - Node has two children
    // Find the successor (smallest value in the right subtree)
    Node? successor = currentNode.Right;
    Node? successorParent = currentNode;

    while (successor.Left != null)
    {
      successorParent = successor;
      successor = successor.Left;
    } //so now we know there is no more left child nodes

    // Replace the value of the node to remove with the successor value
    currentNode.Value = successor.Value;

    // Remove the successor (which is guaranteed to have at most one child)
    /*When removing a node that has two children (Case 3), it's necessary to find a suitable replacement value. This replacement value is typically taken from the leftmost node in the right subtree (the successor), ensuring that it is larger than all values in the left subtree but smaller than all values in the right subtree.
    */
    if (successorParent.Left == successor)
    {
      successorParent.Left = successor.Right;
    }
    else
    {
      successorParent.Right = successor.Right;
    }
  }


  public string PrintTree()
  {
    StringBuilder treeStr = new StringBuilder();
    PrintTree(Root, 0, "Root: ", treeStr);
    return treeStr.ToString();
  }

  private void PrintTree(Node? node, int level, string prefix, StringBuilder treeStr)
  {
    if (node is null)
    {
      return;
    }

    treeStr.Append($"{new string(' ', level * 4)}{prefix}{node.Value}\n");
    PrintTree(node.Left, level + 1, "L: ", treeStr);
    PrintTree(node.Right, level + 1, "R: ", treeStr);
  }

  //BFS
  public List<int> BreadthFirstSearchIterative()
  {
    List<int> list = new List<int>();
    if (Root == null)
      return list;

    Queue<Node> queue = new Queue<Node>();
    queue.Enqueue(Root);

    while (queue.Count > 0)
    {
      Node currentNode = queue.Dequeue();
      list.Add(currentNode.Value);

      if (currentNode.Left != null)
        queue.Enqueue(currentNode.Left);

      if (currentNode.Right != null)
        queue.Enqueue(currentNode.Right);
    }

    return list;
  }

  // BFS Recursive
  public List<int> BreadthFirstSearchRecursive()
  {
    List<int> list = new List<int>();
    Queue<Node> queue = new Queue<Node>();

    if (Root == null)
      return list;

    queue.Enqueue(Root);
    return BreadthFirstSearchRecursive(queue, list);
  }

  private List<int> BreadthFirstSearchRecursive(Queue<Node> queue, List<int> list)
  {
    if (queue.Count == 0)
      return list;

    Node currentNode = queue.Dequeue();
    list.Add(currentNode.Value);

    if (currentNode.Left != null)
      queue.Enqueue(currentNode.Left);

    if (currentNode.Right != null)
      queue.Enqueue(currentNode.Right);

    return BreadthFirstSearchRecursive(queue, list);
  }
}

public class Program
{
  public static void Main(string[] args)
  {
    BinarySearchTree tree = new BinarySearchTree();
    //      9
    //   4      20
    // 1   6   15   170
    tree.Insert(9);
    tree.Insert(4);
    tree.Insert(6);
    tree.Insert(20);
    tree.Insert(15);
    tree.Insert(170);
    tree.Insert(1);

    Console.WriteLine(string.Join(" ", tree.BreadthFirstSearchIterative()));
    Console.WriteLine(string.Join(" ", tree.BreadthFirstSearchRecursive()));

    Console.WriteLine(tree.PrintTree());

    Console.WriteLine(tree.Lookup(171)?.Value.ToString() ?? "null");
    Console.WriteLine(tree.Lookup(4)?.Value.ToString() ?? "null");
    Console.WriteLine(tree.Lookup(6)?.Value);

    tree.Remove(4);
    Console.WriteLine(tree.PrintTree());
  }
}