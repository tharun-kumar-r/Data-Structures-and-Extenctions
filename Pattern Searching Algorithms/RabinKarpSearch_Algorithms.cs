using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Pattern_Searching_Algorithms
{
    public class RabinKarpSearch_Algorithms
    {
        public static void RabinKarpSearch(string text, string pattern, int prime)
        {
            int n = text.Length;
            int m = pattern.Length;
            int d = 256; 
            int patternHash = 0;
            int textHash = 0;
            int h = 1;

            for (int i = 0; i < m - 1; i++)
                h = (h * d) % prime;

            
            for (int i = 0; i < m; i++)
            {
                patternHash = (d * patternHash + pattern[i]) % prime;
                textHash = (d * textHash + text[i]) % prime;
            }

            Console.WriteLine($"Pattern Hash: {patternHash}");

            
            for (int i = 0; i <= n - m; i++)
            {
               
                Console.WriteLine($"Hash Index: {i}, Text Hash: {textHash}");

         
                if (patternHash == textHash)
                {
                  
                    int j;
                    for (j = 0; j < m; j++)
                    {
                        if (text[i + j] != pattern[j])
                            break;
                    }

                    if (j == m)
                        Console.WriteLine($"Pattern found at index {i}");
                }

              
                if (i < n - m)
                {
                    textHash = (d * (textHash - text[i] * h) + text[i + m]) % prime;

                    if (textHash < 0)
                        textHash = (textHash + prime);
                }
            }
        }
    }
}