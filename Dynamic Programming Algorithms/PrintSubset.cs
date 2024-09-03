using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Dynamic_Programming_Algorithms
{
    public class PrintSubset
    {


        public static void PrintSubsets(int[] keys, int[,] root, int i, int j)
        {
            if (i > j)
                return;

            int r = root[i, j];
            Console.WriteLine("Root of keys from index " + i + " to " + j + " is: " + keys[r]);


            PrintSubsets(keys, root, i, r - 1);
            PrintSubsets(keys, root, r + 1, j);
        }

    }
}
