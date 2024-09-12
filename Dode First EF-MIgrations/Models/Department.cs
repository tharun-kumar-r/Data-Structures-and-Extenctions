using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Dode_First_EF_MIgrations.Models
{
    public class Department
    {
        [Key]
        public int DId { get; set; } 
        public string DName { get; set; }

        public int Sts { get; set; }
        public virtual ICollection<Employee> Employees { get; set; }

    }
}
