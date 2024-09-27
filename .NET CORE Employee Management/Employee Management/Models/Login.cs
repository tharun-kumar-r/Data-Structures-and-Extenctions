using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace Employee_Management.Models
{
    public class Login
    {
        [Key]
        public int id { set; get; }

        [DisplayName("Email")]
        [Required(ErrorMessage ="Please Enter the Email")]
        [EmailAddress(ErrorMessage ="Please enter the valid Email")]
        public string email { set; get; }

        [DisplayName("Password")]
        [Required(ErrorMessage = "Please Enter the Password")]
        [StringLength(6, ErrorMessage = "Please enter the valid Password")]
        public string password { get; set; }

    }
}
