using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Dynamic_Programming
{
    internal class longest_common
    {

                static int LongestCommonSubsequence(string A, string B)
        {
            int m = A.Length;
            int n = B.Length;

      
            int[,] dp = new int[m + 1, n + 1];

           
            for (int i = 0; i <= m; i++)
            {
                for (int j = 0; j <= n; j++)
                {
                    if (i == 0 || j == 0)
                        dp[i, j] = 0;
                    else if (A[i - 1] == B[j - 1])
                        dp[i, j] = dp[i - 1, j - 1] + 1;
                    else
                        dp[i, j] = Math.Max(dp[i - 1, j], dp[i, j - 1]);
                }
            }

      
            return dp[m, n];
        }

        static void Main()
        {
            string A = "aabcdefghij";
            string B = "ecdgi";

            int lcsLength = LongestCommonSubsequence(A, B);
            Console.WriteLine("Length of Longest Common Subsequence: " + lcsLength);
        }
    }

}

