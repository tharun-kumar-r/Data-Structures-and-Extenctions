using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Dode_First_EF_MIgrations.Models
{
    public class Employee
    {
        [Key]
        public int Id { get; set; }
        public string Name { get; set; }
        public int Age { get; set; }
        public int Gender { get; set; }

        public float Salary { get; set; }
        public int DId { get; set;}

        public virtual Department Department { get; set; }  

    }
}
