using Graph_Algorithms;

class Program
{
    static void Main(string[] args)
    {
        int verticesCount = 6;
        Dijkstras_algorithm graph = new Dijkstras_algorithm(verticesCount);

       
        graph.AddEdge(0, 1, 4);
        graph.AddEdge(0, 2, 2);
        graph.AddEdge(1, 2, 5);
        graph.AddEdge(1, 3, 10);
        graph.AddEdge(2, 4, 3);
        graph.AddEdge(4, 3, 4);
        graph.AddEdge(3, 5, 11);

        int startNode = 0;
        graph.Dijkstra(startNode);
    }
}