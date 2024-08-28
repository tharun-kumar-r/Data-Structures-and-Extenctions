using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Bitwise_Algorithms
{
     class IntToBinary
    {
       
      public  static string ConvertToBinary(int number)
        {
            if (number == 0)
                return "0";

            string binary = "";
            while (number > 0)
            {
                binary = (number % 2).ToString() + binary;
                number /= 2;
            }
            return binary;
        }

    }
}
