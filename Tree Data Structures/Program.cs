using System;
using Tree_Data_Structures;



class Program
{
    static void Main(string[] args)
    {
        BinaryTree tree = new BinaryTree();

        tree.Insert(10);
        tree.Insert(5);
        tree.Insert(15);
        tree.Insert(2);
        tree.Insert(7);
        tree.Insert(12);
        tree.Insert(18);
        tree.Insert(1);
        tree.Insert(3);
        tree.Insert(20);

        tree.PrintInOrder(tree.Root);
        Console.WriteLine( tree.IsBalanced() ? "\nThe tree is balanced." : "\nThe tree is not balanced.");

    

        BinaryTree btree = new BinaryTree();
        btree.Insert(1);
        btree.Insert(2);
        btree.Insert(3);
        btree.Insert(4);
        btree.Insert(5);
        btree.Insert(7);
        btree.Insert(8);
        btree.Insert(10);
        btree.Insert(13);
        btree.Insert(20);

        btree.PrintInOrder(btree.Root);
        Console.WriteLine(btree.IsBalanced() ? "\nThe tree is balanced.\n" : "\nThe tree is not balanced.\n");


        Graph graph = new Graph();

       
        graph.AddEdge(1, 2);
        graph.AddEdge(1, 3);
        graph.AddEdge(2, 4);
        graph.AddEdge(2, 5);
        graph.AddEdge(3, 6);
        graph.AddEdge(3, 7);

     
        Console.WriteLine("BFS traversal starting from node 5:");
        graph.BFS(5);

    }
}
