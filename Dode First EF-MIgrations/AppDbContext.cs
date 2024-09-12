using Dode_First_EF_MIgrations.Models;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Dode_First_EF_MIgrations
{
    public class AppDbContext : DbContext
    {

        public   DbSet<Employee> employees { get; set; }
        public DbSet<Department> departments { get; set; }  
    }
}
