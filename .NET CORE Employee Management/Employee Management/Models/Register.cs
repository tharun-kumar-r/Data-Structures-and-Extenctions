using Microsoft.AspNetCore.Mvc;
using System.ComponentModel.DataAnnotations;

namespace Employee_Management.Models
{
    public class Register
    {
        [Required(ErrorMessage = "Please enter the valid Email")]
        [EmailAddress(ErrorMessage = "Please enter the valid Email")]
        [Remote(action: "EmailCheck", controller: "Home", ErrorMessage = "Email is already registered.")]
        public string Email { get; set; }

        [Required(ErrorMessage = "Please Enter the Password")]
        [DataType(DataType.Password)]
        [Length(6, 10, ErrorMessage = "Please enter the valid Password")]
        public string Password { get; set; }

        [Required(ErrorMessage = "Please Enter the Password")]
       
        [DataType(DataType.Password)]
        [Compare("Password", ErrorMessage = "The password and confirmation password do not match.")]
        [Length(6, 10, ErrorMessage = "Please enter the valid Password")]
        public string ConfirmPassword { get; set; }
    }
}
