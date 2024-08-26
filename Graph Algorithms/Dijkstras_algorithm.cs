using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Graph_Algorithms
{
    public class Dijkstras_algorithm
    {


        private int verticesCount;
        private List<Tuple<int, int>>[] adjacencyList;

        public Dijkstras_algorithm(int verticesCount)
        {
            this.verticesCount = verticesCount;
            adjacencyList = new List<Tuple<int, int>>[verticesCount];

            for (int i = 0; i < verticesCount; i++)
            {
                adjacencyList[i] = new List<Tuple<int, int>>();
            }
        }

        public void AddEdge(int source, int destination, int weight)
        {
            adjacencyList[source].Add(Tuple.Create(destination, weight));
            adjacencyList[destination].Add(Tuple.Create(source, weight));
        }

        public void Dijkstra(int startNode)
        {
       
            int[] distances = new int[verticesCount];
            for (int i = 0; i < verticesCount; i++)
            {
                distances[i] = int.MaxValue;
            }
            distances[startNode] = 0;

        
            SortedSet<Tuple<int, int>> priorityQueue = new SortedSet<Tuple<int, int>>();
            priorityQueue.Add(Tuple.Create(0, startNode));

            while (priorityQueue.Count > 0)
            {
              
                Tuple<int, int> current = priorityQueue.Min;
                priorityQueue.Remove(current);

                int currentDistance = current.Item1;
                int currentNode = current.Item2;

                foreach (var neighbor in adjacencyList[currentNode])
                {
                    int neighborNode = neighbor.Item1;
                    int edgeWeight = neighbor.Item2;

                    int newDist = currentDistance + edgeWeight;
                    if (newDist < distances[neighborNode])
                    {
                        distances[neighborNode] = newDist;

                     
                        priorityQueue.Add(Tuple.Create(newDist, neighborNode));
                    }
                }
            }

         
            Console.WriteLine("Shortest distances from node {0}:", startNode);
            for (int i = 0; i < verticesCount; i++)
            {
                Console.WriteLine("Node {0} -> Distance: {1}", i, distances[i]);
            }

        }
}
}
