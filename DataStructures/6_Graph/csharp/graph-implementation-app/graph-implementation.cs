using System;
using System.Collections.Generic;
using System.Text;


public class Graph<T> where T : notnull
{
  //hash table to store adjacency list
  private Dictionary<T, List<T>> _adjacencyList;
  private int _numberOfNodes;

  public Graph()
  {
    this._adjacencyList = new Dictionary<T, List<T>>();
    _numberOfNodes = 0;
  }

  public void AddVertex(T nodeKey)
  {
    if (_adjacencyList.ContainsKey(nodeKey))
    {
      Console.WriteLine("Key is already in the graph");
      // Throw an exception, return, or handle it in another way based on your requirements.
      return;
    }

    _adjacencyList.Add(nodeKey, new List<T>());
    _numberOfNodes++;

  }
  public void AddEdge(T node1Key, T node2Key)
  {
    if (!_adjacencyList.ContainsKey(node1Key)
    || !_adjacencyList.ContainsKey(node2Key))
    {
      Console.WriteLine("Error: One or more nodes do not exist in the graph.");
      return;
    }

    if (_adjacencyList[node1Key].Contains(node2Key)
    && _adjacencyList[node2Key].Contains(node1Key))
    {
      Console.WriteLine($"Error: Edge between {node1Key} and {node2Key} already exists.");
      return;
    }

    //undirected graph
    _adjacencyList[node1Key].Add(node2Key);
    _adjacencyList[node2Key].Add(node1Key);
  }

  public void ShowConnections()
  {
    foreach (var node in _adjacencyList)
    {
      var nodeConnections = node.Value;
      StringBuilder connections = new StringBuilder();
      connections.Append($"{node.Key} ---> ");
      foreach (var edge in nodeConnections)
      {
        connections.Append($"{edge}  ");
      }
      Console.WriteLine(connections);
    }
  }
}

public class Program
{
  public static void Main(string[] args)
  {
    var myGraph = new Graph<string>();
    myGraph.AddVertex("0");
    myGraph.AddVertex("1");
    myGraph.AddVertex("2");
    myGraph.AddVertex("3");
    myGraph.AddVertex("4");
    myGraph.AddVertex("5");
    myGraph.AddVertex("6");
    myGraph.AddVertex("6");
    myGraph.AddEdge("3", "1");
    myGraph.AddEdge("3", "4");
    myGraph.AddEdge("4", "2");
    myGraph.AddEdge("4", "5");
    myGraph.AddEdge("5", "6");
    myGraph.AddEdge("1", "2");
    myGraph.AddEdge("1", "0");
    myGraph.AddEdge("2", "0");
    myGraph.AddEdge("2", "0");

    myGraph.ShowConnections();
  }
}