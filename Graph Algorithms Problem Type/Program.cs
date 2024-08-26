using Graph_Algorithms_Problem_Type;
using System;
using System.Collections.Generic;

class Program
{
    static void Main()
    {

        Console.WriteLine("============Kruskal Algorithm=============");
        KruskalAlgorithms();
        Console.WriteLine("============BellmanFord Algorithm=============");
        BellmanFordAlgorithms();
    }

    public static  void KruskalAlgorithms()
    {
        int numberOfVertices = 4;
        List<Edge> edges = new List<Edge>
        {
            new Edge(0, 1, 10),
            new Edge(0, 2, 6),
            new Edge(0, 3, 5),
            new Edge(1, 3, 15),
            new Edge(2, 3, 4)
        };

        List<Edge> mst = KruskalAlgorithm.FindMST(numberOfVertices, edges);

        Console.WriteLine("Edges in the Minimum Spanning Tree:");
        foreach (var edge in mst)
        {
            Console.WriteLine($"{edge.Source} - {edge.Destination}: {edge.Weight}");
        }
    }


    public static void BellmanFordAlgorithms()
    {
        int numberOfVertices = 5;
        List<Edges> edges = new List<Edges>
        {
            new Edges(0, 1, -1),
            new Edges(0, 2, 4),
            new Edges(1, 2, 3),
            new Edges(1, 3, 2),
            new Edges(1, 4, 2),
            new Edges(3, 2, 5),
            new Edges(3, 1, 1),
            new Edges(4, 3, -3)
        };

        int source = 0;
        BellmanFordAlgorithm.FindShortestPaths(numberOfVertices, edges, source);
    }
}
