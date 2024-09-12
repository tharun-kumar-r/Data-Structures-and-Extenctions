using Code_First_Approach.Models;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Code_First_Approach
{
    public class AppDbInnit : DropCreateDatabaseIfModelChanges<AppDbContext>
    {
        protected override void Seed(AppDbContext context)
        {
            context.Employees.Add(new Employee { Id = 1, Name = "Tharun Kumar", did = 2, Age = 22,  Gender="Male", Salary=244234  });
            context.Employees.Add(new Employee { Id = 1, Name = " Kumar", did=1, Age = 22, Gender = "Male", Salary = 244234 });

           
            context.SaveChanges();

            base.Seed(context);
        }
    }
}
