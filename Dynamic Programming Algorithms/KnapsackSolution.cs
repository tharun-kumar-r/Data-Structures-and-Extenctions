using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Dynamic_Programming_Algorithms
{
    public class KnapsackSolution
    {

        public static void KnapsackSolutions(int[] weights, int n, int capacity)
        {
            int[,] dp = new int[n + 1, capacity + 1];
            bool[,] keep = new bool[n + 1, capacity + 1];

            for (int i = 1; i <= n; i++)
            {
                for (int w = 1; w <= capacity; w++)
                {
                    if (weights[i - 1] <= w)
                    {
                        if (dp[i - 1, w] > dp[i - 1, w - weights[i - 1]] + weights[i - 1])
                        {
                            dp[i, w] = dp[i - 1, w];
                            keep[i, w] = false;
                        }
                        else
                        {
                            dp[i, w] = dp[i - 1, w - weights[i - 1]] + weights[i - 1];
                            keep[i, w] = true;
                        }
                    }
                    else
                    {
                        dp[i, w] = dp[i - 1, w];
                    }
                }
            }

            Console.WriteLine("Maximum weight achievable: " + dp[n, capacity]);

            Console.Write("Items included: ");
            int remainingCapacity = capacity;
            for (int i = n; i > 0; i--)
            {
                if (keep[i, remainingCapacity])
                {
                    Console.Write(weights[i - 1] + " ");
                    remainingCapacity -= weights[i - 1];
                }
            }
            Console.WriteLine();

           
        }

    }
}
