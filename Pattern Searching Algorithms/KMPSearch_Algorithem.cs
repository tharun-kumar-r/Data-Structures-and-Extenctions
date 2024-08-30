using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Pattern_Searching_Algorithms
{
    public class KMPSearch_Algorithem
    {

        public static void KMPSearch(string pattern, string text)
        {
            int m = pattern.Length;
            int n = text.Length;

          
            int[] lps = new int[m];
            int j = 0; 

            ComputeLPSArray(pattern, m, lps);

            int i = 0; 
            while (i < n)
            {
                if (pattern[j] == text[i])
                {
                    j++;
                    i++;
                }

                if (j == m)
                {
                    Console.WriteLine($"Pattern found at index {i - j}");
                    j = lps[j - 1];
                }
            
                else if (i < n && pattern[j] != text[i])
                {
               
                    if (j != 0)
                        j = lps[j - 1];
                    else
                        i++;
                }
            }
        }

        public static void ComputeLPSArray(string pattern, int m, int[] lps)
        {
      
            int len = 0;
            int i = 1;
            lps[0] = 0; 

            while (i < m)
            {
                if (pattern[i] == pattern[len])
                {
                    len++;
                    lps[i] = len;
                    i++;
                }
                else
                {
                   
                    if (len != 0)
                    {
                        len = lps[len - 1];
                    }
                    else
                    {
                        lps[i] = 0;
                        i++;
                    }
                }
            }
        }
    }
}
