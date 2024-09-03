using Dynamic_Programming_Algorithms;
using System;

class Program
{
    public static void Main()
    {
        obst();

        Console.WriteLine("\n\n***************Task 2***************");
        KnapsackSolutions_Subset();

        Console.WriteLine("\n\n***************N Queen***************");
        n_queen.SolveNQueens();
    }



    public static void KnapsackSolutions_Subset()
    {
        int[] weights = { 5, 10, 12, 13, 15, 18 };
        int n = weights.Length;
        int capacity = 30;

        KnapsackSolution.KnapsackSolutions(weights, n, capacity);
    }

    public static void obst()
    {
        int[] keys = { 10, 20, 30, 40 };
        int[] freq = { 4, 2, 6, 3 };
        int n = keys.Length;


        Console.WriteLine("Keys: ");
        for (int i = 0; i < n; i++)
        {
            Console.Write(keys[i] + " ");
        }

        Console.WriteLine("\nFrequencies: ");
        for (int i = 0; i < n; i++)
        {
            Console.Write(freq[i] + " ");
        }

        Console.WriteLine();


        int[,] root = new int[n, n];


        int result = OptimalBST.OptimalBSTCost(keys, freq, n, root);
        Console.WriteLine("Cost of the optimal BST is: " + result);


        Console.WriteLine("Subsets and their roots:");
        PrintSubset.PrintSubsets(keys, root, 0, n - 1);
    }
}
