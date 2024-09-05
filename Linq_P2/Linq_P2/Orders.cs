using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Linq_P2
{
    class Orders
    {
        public int Cid { get; set; }
        public int Oid { get; set; }
        public string Address { get; set; }
        public string Datetime { get; set; }


        static List<Orders> Ord = new List<Orders>
        {
            new Orders { Cid = 1, Oid = 1213, Address="Bnagalore", Datetime=DateTime.Now.ToLocalTime().ToString()},
            new Orders { Cid = 3, Oid = 3534, Address="Kolar", Datetime=DateTime.Now.ToLocalTime().ToString()},
            new Orders { Cid = 4, Oid = 3534, Address="Andra", Datetime=DateTime.Now.ToLocalTime().ToString()},
            new Orders { Cid = 1, Oid = 6744, Address="Delhi", Datetime=DateTime.Now.ToLocalTime().ToString()},
            new Orders { Cid = 21, Oid = 5465, Address="Karnataka", Datetime=DateTime.Now.ToLocalTime().ToString()}
        };

        public static List<Orders> ShowOrders()
        {
            return Ord;
        }

    }
}
