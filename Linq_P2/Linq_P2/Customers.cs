using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Linq_P2
{
    class Customers
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Gender { get; set; }
        public int Age { get; set; }
        public int Pincode { get; set; }

        static List<Customers> customer = new List<Customers>
        {
            new Customers { Id=1, Name="Tharun", Gender="Male", Age=27, Pincode=563113},
             new Customers { Id=2, Name="Kumar", Gender="Male", Age=23, Pincode=563113},
              new Customers { Id=3, Name="Ramya", Gender="Female", Age=20, Pincode=563113},
              new Customers { Id=4, Name="Jani", Gender="Male", Age=17, Pincode=563113},
              new Customers { Id=5, Name="Suma", Gender="Female", Age=57, Pincode=563113},
        };

        public static List<Customers> ShowCustomers()
        {
            return customer;
        }

    }
}
