using System;

class LCS
{
       static string LongestCommonSubsequence(string A, string B)
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

        int index = dp[m, n];
        char[] lcs = new char[index]; 
              
        int aIndex = m, bIndex = n;
        while (aIndex > 0 && bIndex > 0)
        {
           
            if (A[aIndex - 1] == B[bIndex - 1])
            {
                lcs[index - 1] = A[aIndex - 1]; 
                aIndex--;
                bIndex--;
                index--;
            }
           
            else if (dp[aIndex - 1, bIndex] > dp[aIndex, bIndex - 1])
                aIndex--;
            else
                bIndex--;
        }
               
        return new string(lcs);
    }
        static void Main()
    {
        string A = "aabcdefghij";
        string B = "ecdgi";
        string lcsString = LongestCommonSubsequence(A, B);
        Console.WriteLine("Longest Common Subsequence: " + lcsString);
    }
}
