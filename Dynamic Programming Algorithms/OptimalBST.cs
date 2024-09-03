using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Dynamic_Programming_Algorithms
{
    public class OptimalBST
    {


        public static int Sum(int[] freq, int i, int j)
        {
            int sum = 0;
            for (int k = i; k <= j; k++)
                sum += freq[k];
            return sum;
        }


        public static int OptimalBSTCost(int[] keys, int[] freq, int n, int[,] root)
        {

            int[,] cost = new int[n, n];

            for (int i = 0; i < n; i++)
            {
                cost[i, i] = freq[i];
                root[i, i] = i;
            }


            for (int length = 2; length <= n; length++)
            {
                for (int i = 0; i <= n - length; i++)
                {
                    int j = i + length - 1;
                    cost[i, j] = int.MaxValue;


                    for (int r = i; r <= j; r++)
                    {

                        int c = ((r > i) ? cost[i, r - 1] : 0) +
                                ((r < j) ? cost[r + 1, j] : 0) +
                                Sum(freq, i, j);


                        if (c < cost[i, j])
                        {
                            cost[i, j] = c;
                            root[i, j] = r;
                        }
                    }
                }
            }


            return cost[0, n - 1];
        }

    }
}
