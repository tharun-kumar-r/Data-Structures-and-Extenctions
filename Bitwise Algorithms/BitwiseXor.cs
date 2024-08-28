using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Bitwise_Algorithms
{
    public class BitwiseXor
    {

       public static void FindTwoNonRepeatingElements(int[] arr)
        {
           
            int xor = 0;
            foreach (int num in arr)
            {
                xor ^= num;
            }

           
            int setBit = xor & ~(xor - 1);

          
            int num1 = 0, num2 = 0;
            foreach (int num in arr)
            {
                if ((num & setBit) != 0)
                {
                    num1 ^= num;  
                }
                else
                {
                    num2 ^= num; 
                }
            }

            Console.WriteLine("The two non-repeating elements are: " + num1 + " and " + num2);
        }
    }
}
