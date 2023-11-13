class Graph {
  constructor() {
    this.numberOfNodes = 0;
    this.adjacentNodesList = {}; // Object used as a hash table to store the adjacency list.
    // We could use arrays, but removing objects not in order is less efficient and less convenient.
  }

  // addVertex(node) {
  //   this.adjacentNodes[node] = [];
  //   this.numberOfNodes++;
  // }

  addVertex(node) {
    if (!this.adjacentNodesList.hasOwnProperty(node)) {
      this.adjacentNodesList[node] = [];
      this.numberOfNodes++;
    } else {
      console.log(`Node with key ${node} already exists.`);
      // You can throw an error, return a boolean indicating success, or handle it in some other way.
    }
  }

  // addEdge(node1, node2) {
  //   //UNDIRECTED GRAPH - so connections should be added both ways
  //   this.adjacentNodesList[node1].push(node2);
  //   this.adjacentNodesList[node2].push(node1);
  // }

  addEdge(node1, node2) {
    if (
      !this.adjacentNodesList.hasOwnProperty(node1) ||
      !this.adjacentNodesList.hasOwnProperty(node2)
    ) {
      console.log("Error: One or more nodes do not exist in the graph.");
      return;
    }

    if (
      this.adjacentNodesList[node1].includes(node2) ||
      this.adjacentNodesList[node2].includes(node1)
    ) {
      console.log(`Error: Edge between ${node1} and ${node2} already exists.`);
      return;
    }

    // UNDIRECTED GRAPH - so connections should be added both ways
    this.adjacentNodesList[node1].push(node2);
    this.adjacentNodesList[node2].push(node1);
  }

  showConnections() {
    const allNodes = Object.keys(this.adjacentNodesList);

    for (let node of allNodes) {
      let nodeConnections = this.adjacentNodesList[node];
      let connections = "";
      for (let vertex of nodeConnections) {
        connections += vertex + " ";
      }
      console.log(node + "--->" + connections);
    }
  }
}

const myGraph = new Graph();
myGraph.addVertex("0");
myGraph.addVertex("1");
myGraph.addVertex("2");
myGraph.addVertex("3");
myGraph.addVertex("4");
myGraph.addVertex("5");
myGraph.addVertex("6");
myGraph.addVertex("6");
myGraph.addEdge("3", "1");
myGraph.addEdge("3", "4");
myGraph.addEdge("4", "2");
myGraph.addEdge("4", "5");
myGraph.addEdge("5", "6");
myGraph.addEdge("1", "2");
myGraph.addEdge("1", "0");
myGraph.addEdge("2", "0");
myGraph.addEdge("2", "0");

myGraph.showConnections();
