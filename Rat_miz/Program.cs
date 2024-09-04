using System;

class RatInMaze
{

    static bool SolveMaze4x4(int[,] maze)
    {
        int N = 4;
        int[,] solution = new int[N, N];

        if (SolveMazeUtil(maze, 0, 0, solution, N) == false)
        {
            Console.WriteLine("No solution exists for the 4x4 maze");
            return false;
        }

        PrintSolution(solution, N);
        return true;
    }


    static bool SolveMaze8x8(int[,] maze)
    {
        int N = 8;
        int[,] solution = new int[N, N];

        if (SolveMazeUtil(maze, 0, 0, solution, N) == false)
        {
            Console.WriteLine("No solution exists for the 8x8 maze");
            return false;
        }

        PrintSolution(solution, N);
        return true;
    }

    
    static bool SolveMazeUtil(int[,] maze, int x, int y, int[,] solution, int N)
    {
       
        if (x == N - 1 && y == N - 1 && maze[x, y] == 1)
        {
            solution[x, y] = 1;
            return true;
        }

     
        if (IsSafe(maze, x, y, N))
        {
          
            solution[x, y] = 1;

           
            if (SolveMazeUtil(maze, x + 1, y, solution, N))
                return true;

            if (SolveMazeUtil(maze, x, y + 1, solution, N))
                return true;

            if (SolveMazeUtil(maze, x - 1, y, solution, N))
                return true;

            if (SolveMazeUtil(maze, x, y - 1, solution, N))
                return true;

            solution[x, y] = 0;
            return false;
        }

        return false;
    }

   
    static bool IsSafe(int[,] maze, int x, int y, int N)
    {
       
        return (x >= 0 && x < N && y >= 0 && y < N && maze[x, y] == 1);
    }

    
    static void PrintSolution(int[,] solution, int N)
    {
        for (int i = 0; i < N; i++)
        {
            for (int j = 0; j < N; j++)
                Console.Write(solution[i, j] + " ");
            Console.WriteLine();
        }
    }


    static void Main()
    {
   
        int[,] maze4x4 = {
            { 1, 0, 0, 0 },
            { 1, 1, 0, 1 },
            { 1, 1, 0, 0 },
            { 0, 1, 1, 1 }
        };

        Console.WriteLine("Solving 4x4 maze:");
        SolveMaze4x4(maze4x4);

 
        int[,] maze8x8 = {
            { 1, 0, 0, 0, 0, 0, 0, 0 },
            { 1, 1, 1, 0, 1, 1, 0, 0 },
            { 0, 0, 1, 0, 1, 0, 0, 0 },
            { 0, 0, 1, 1, 1, 0, 0, 0 },
            { 1, 1, 0, 0, 1, 1, 1, 0 },
            { 0, 1, 0, 0, 0, 0, 1, 0 },
            { 1, 1, 1, 1, 1, 1, 1, 0 },
            { 0, 0, 0, 0, 0, 0, 1, 1 }
        };

        Console.WriteLine("\nSolving 8x8 maze:");
        SolveMaze8x8(maze8x8);
    }
}
