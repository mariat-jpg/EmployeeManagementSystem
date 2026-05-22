using System;
using Employee;
using System.ComponentModel.DataAnnotations;

namespace Employee.Models
{
    public class Login
    {
        //public string type_user { get; set; }

        [Required(ErrorMessage="Username is required")]
        public string username { get; set; }

        [Required(ErrorMessage = "Password is required")]
        [DataType(DataType.Password)]
        [MinLength(8,ErrorMessage = "Password must contain atleast 8 characters")]
        [RegularExpression(@"^(?=.*[A-Za-z])(?=.*\d)(?=.*[!@#$%^&*])[A-Za-z\d!@#$%^&*]+$",ErrorMessage="Password must contain alphanumeric values and special charcaters")]
        public string password { get; set; }
    }
}
