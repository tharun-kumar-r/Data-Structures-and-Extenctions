using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Code_First_Approach.Models
{
    public class Department
    {
        [Required]
        public int Id { get; set; }
        public string Dname { get; set; }
        public List<Employee> Did { get; set; }
    }
}
