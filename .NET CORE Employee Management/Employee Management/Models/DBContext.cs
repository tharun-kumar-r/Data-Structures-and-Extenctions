using Microsoft.EntityFrameworkCore;

namespace Employee_Management.Models
{
    public class DBContext :  DbContext
    {
        public DBContext(DbContextOptions options)  : base(options)
        {
            
        }

        public DbSet<Login> logins { get; set; }
        public DbSet<Employee> employees { get; set; }
    }
}
