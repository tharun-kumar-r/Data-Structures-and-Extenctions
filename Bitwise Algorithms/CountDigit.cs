using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Bitwise_Algorithms
{
    public class CountDigit
    {

        public static int CountSetBits(int number)
        {
            int count = 0;
            while (number > 0)
            {
                
                if ((number & 1) == 1)
                {
                    count++;
                }
               
                number >>= 1;
            }
            return count;
        }
    }
}
