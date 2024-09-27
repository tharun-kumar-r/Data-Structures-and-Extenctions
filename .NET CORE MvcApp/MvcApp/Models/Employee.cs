using System;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace MvcApp.Models
{
    public class Employee
    {
        [DisplayName("Employee Id")]
        public int Id { get; set; }

        [Required(ErrorMessage = "Please Enter the First Name")]
        public string FirstName { get; set; }

        [Required(ErrorMessage = "Please Enter the Middle Name")]
        public string MiddleName { get; set; }

        [Required(ErrorMessage = "Please Enter the Last Name")]
        public string LastName { get; set; }

        [Range(0, double.MaxValue, ErrorMessage = "Please Enter a Valid Salary")]
        public float Salary { get; set; }

        [Required(ErrorMessage = "Please Enter the Email")]
        [EmailAddress(ErrorMessage = "Invalid Email Address")]
        public string Email { get; set; }

        [Required(ErrorMessage = "Please Enter the Phone Number")]
     
        public long PhoneNumber { get; set; }

        [Required(ErrorMessage = "Please Enter the Address")]
        [StringLength(100, ErrorMessage = "Address cannot be more than 100 characters")] 
        public string Address { get; set; }

        [Required(ErrorMessage = "Please Select the Country")]
        public string Country { get; set; }

        [Range(18, 65, ErrorMessage = "Age must be between 18 and 65")]
        public int Age { get; set; }

        [Required(ErrorMessage = "Please Select the Date of Birth")]
        public string DateOfBirth { get; set; } // Changed from string to DateTime
    }
}
