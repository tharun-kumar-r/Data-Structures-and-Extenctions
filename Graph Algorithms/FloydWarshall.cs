using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Graph_Algorithms
{
   
    class FloydWarshall
    {
        static readonly int INF = 99999;

      
        public static void FloydWarshallAlgorithm(int[,] graph, int V)
        {
           
            int[,] dist = new int[V, V];

         
            for (int i = 0; i < V; i++)
            {
                for (int j = 0; j < V; j++)
                {
                    dist[i, j] = graph[i, j];
                }
            }

          
            for (int k = 0; k < V; k++)
            {
                for (int i = 0; i < V; i++)
                {
                    for (int j = 0; j < V; j++)
                    {
                       
                        if (dist[i, k] + dist[k, j] < dist[i, j])
                        {
                            dist[i, j] = dist[i, k] + dist[k, j];
                        }
                    }
                }
            }

      
            PrintSolution(dist, V);
        }

      
        static void PrintSolution(int[,] dist, int V)
        {
            Console.WriteLine("The following matrix shows the shortest distances between every pair of vertices:");
            for (int i = 0; i < V; i++)
            {
                for (int j = 0; j < V; j++)
                {
                    if (dist[i, j] == INF)
                    {
                        Console.Write("INF".PadLeft(7));
                    }
                    else
                    {
                        Console.Write(dist[i, j].ToString().PadLeft(7));
                    }
                }
                Console.WriteLine();
            }
        }

       
        static void Main()
        {
            int V = 4;
            int[,] graph = {
            { 0, 3, INF, 7 },
            { 8, 0, 2, INF },
            { 5, INF, 0, 1 },
            { 2, INF, INF, 0 }
        };

            FloydWarshallAlgorithm(graph, V);
        }
    }

}
