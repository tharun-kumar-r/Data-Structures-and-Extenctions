using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Tree_Data_Structures
{
    public class Graph  
    {

        private readonly Dictionary<int, List<int>> _adjacencyList;

        public Graph()
        {
            _adjacencyList = new Dictionary<int, List<int>>();
        }

   
        public void AddNode(int node)
        {
            if (!_adjacencyList.ContainsKey(node))
            {
                _adjacencyList[node] = new List<int>();
            }
        }

      
        public void AddEdge(int node1, int node2)
        {
            if (!_adjacencyList.ContainsKey(node1))
                AddNode(node1);
            if (!_adjacencyList.ContainsKey(node2))
                AddNode(node2);

            _adjacencyList[node1].Add(node2);
            _adjacencyList[node2].Add(node1); 
        }

        public void BFS(int startNode)
        {
            if (!_adjacencyList.ContainsKey(startNode))
            {
                Console.WriteLine("Start node not in the graph.");
                return;
            }

            var visited = new HashSet<int>();
            var queue = new Queue<int>();

           
            visited.Add(startNode);
            queue.Enqueue(startNode);

            while (queue.Count > 0)
            {
                int node = queue.Dequeue();
                Console.Write(node + " \n"); 

                foreach (var neighbor in _adjacencyList[node])
                {
                    if (!visited.Contains(neighbor))
                    {
                        visited.Add(neighbor);
                        queue.Enqueue(neighbor);
                    }
                }
            }
        }
    }
}
