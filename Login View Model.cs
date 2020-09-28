using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using WebApplication2.Models;

namespace WebApplication2.ViewModels
{
    public class LoginViewModel
    {
        [Display(Name = "Member Id")]
        [Required(ErrorMessage = "Member Id is required")]
        public string UserId { get; set; }
        [Required]
        [DataType(DataType.Password)]
        public string Password { get; set; }

        [Required(ErrorMessage = "Please select an User Role")]
        
        [Display(Name = "User Role")]
        public int UserRole { get; set; }
        
    }
}
