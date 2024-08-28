using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Bitwise_Algorithms
{
    public class SwapBit
    {

       public static int SwapBits(int number, int bit1, int bit2)
        {
            
            int bitVal1 = (number >> bit1) & 1;
            int bitVal2 = (number >> bit2) & 1;
                      
            if (bitVal1 == bitVal2)
            {
                return number;
            }
                   
            number ^= (1 << bit1);
            number ^= (1 << bit2);

            return number;
        }
    }

}
