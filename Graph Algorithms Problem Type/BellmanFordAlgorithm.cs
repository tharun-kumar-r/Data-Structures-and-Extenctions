using System;
using System.Collections.Generic;
using Graph_Algorithms_Problem_Type;

namespace Graph_Algorithms_Problem_Type
{
    public class Edges
    {
        public int Source { get; set; }
        public int Destination { get; set; }
        public int Weight { get; set; }

        public Edges(int source, int destination, int weight)
        {
            Source = source;
            Destination = destination;
            Weight = weight;
        }
    }

    public class BellmanFordAlgorithm
    {
        public static void FindShortestPaths(int numberOfVertices, List<Edges> edges, int source)
        {
            int[] distances = new int[numberOfVertices];

            for (int i = 0; i < numberOfVertices; i++)
            {
                distances[i] = int.MaxValue;
            }
            distances[source] = 0;

            for (int i = 1; i < numberOfVertices; i++)
            {
                foreach (var edge in edges)
                {
                    if (distances[edge.Source] != int.MaxValue &&
                        distances[edge.Source] + edge.Weight < distances[edge.Destination])
                    {
                        distances[edge.Destination] = distances[edge.Source] + edge.Weight;
                    }
                }
            }

            foreach (var edge in edges)
            {
                if (distances[edge.Source] != int.MaxValue &&
                    distances[edge.Source] + edge.Weight < distances[edge.Destination])
                {
                    Console.WriteLine("Graph contains negative weight cycle");
                    return;
                }
            }

            Console.WriteLine("Vertex Distance from Source");
            for (int i = 0; i < numberOfVertices; i++)
            {
                Console.WriteLine($"{i}\t\t{(distances[i] == int.MaxValue ? "INF" : distances[i].ToString())}");
            }
        }
    }
}
