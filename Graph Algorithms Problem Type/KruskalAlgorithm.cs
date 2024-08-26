using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Graph_Algorithms_Problem_Type
{
    public class Edge : IComparable<Edge>
    {
        public int Source { get; set; }
        public int Destination { get; set; }
        public int Weight { get; set; }

        public Edge(int source, int destination, int weight)
        {
            Source = source;
            Destination = destination;
            Weight = weight;
        }

        public int CompareTo(Edge other)
        {
            return Weight.CompareTo(other.Weight);
        }
    }

    public class DisjointSet
    {
        private int[] parent;
        private int[] rank;

        public DisjointSet(int size)
        {
            parent = new int[size];
            rank = new int[size];
            for (int i = 0; i < size; i++)
            {
                parent[i] = i;
                rank[i] = 0;
            }
        }

        public int Find(int u)
        {
            if (parent[u] != u)
            {
                parent[u] = Find(parent[u]);
            }
            return parent[u];
        }

        public void Union(int u, int v)
        {
            int rootU = Find(u);
            int rootV = Find(v);

            if (rootU != rootV)
            {
                if (rank[rootU] > rank[rootV])
                {
                    parent[rootV] = rootU;
                }
                else if (rank[rootU] < rank[rootV])
                {
                    parent[rootU] = rootV;
                }
                else
                {
                    parent[rootV] = rootU;
                    rank[rootU]++;
                }
            }
        }
    }

    public class KruskalAlgorithm
    {
        public static List<Edge> FindMST(int numberOfVertices, List<Edge> edges)
        {
            List<Edge> result = new List<Edge>();
            DisjointSet ds = new DisjointSet(numberOfVertices);

            
            edges.Sort();

            foreach (var edge in edges)
            {
                int root1 = ds.Find(edge.Source);
                int root2 = ds.Find(edge.Destination);

                if (root1 != root2)
                {
                    result.Add(edge);
                    ds.Union(root1, root2);
                }
            }

            return result;
        }
    }

}
