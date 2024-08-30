using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Pattern_Searching_Algorithms
{
    public class NativeSearch_alogorithem
    {

        public static void NativeSearch(string text, string pattern)
        {
            int n = text.Length;
            int m = pattern.Length;

            for (int i = 0; i <= n - m; i++)
            {
                int j;
                for (j = 0; j < m; j++)
                {
                    if (text[i + j] != pattern[j])
                    {
                        break; 
                    }
                }

              
                if (j == m)
                {
                    Console.WriteLine($"Pattern found at index of {i}");
                }
            }
        }
    }
}
