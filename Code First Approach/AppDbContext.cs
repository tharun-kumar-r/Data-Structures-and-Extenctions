using Code_First_Approach.Models;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Data.Entity.Migrations;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;

namespace Code_First_Approach
{
    public class AppDbContext : DbContext
    {
       
        public AppDbContext()
        {
            Database.SetInitializer(new AppDbInnit());
        }

        public DbSet<Employee> Employees { get; set; }
        public DbSet<Department> Departments { get; set; }


  
          

       
     

    }

}
