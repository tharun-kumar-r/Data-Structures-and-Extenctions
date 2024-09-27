using System.ComponentModel.DataAnnotations;

namespace Employee_Management.Models
{
    public class Employee
    {
        
            [Key]
            public int Id { get; set; }

            [StringLength(50)]
            public string FirstName { get; set; }

            [StringLength(50)]
            public string MiddleName { get; set; }

            [StringLength(50)]
            public string LastName { get; set; }

            public double? Salary { get; set; }

            [StringLength(100)]
            [EmailAddress]
            public string Email { get; set; }

            public long? PhoneNumber { get; set; }

            [StringLength(255)]
            public string Address { get; set; }

            [StringLength(50)]
            public string Country { get; set; }

            public int? Age { get; set; }

            [DataType(DataType.Date)]
            public DateTime? DateOfBirth { get; set; }
        }
}
