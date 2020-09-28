using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using WebApplication2.Context;

namespace WebApplication2.Models
{
    public class User
    {

        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }


        [MinLength(4)]
        [MaxLength(50)]
        [Required(ErrorMessage = "Name should range between 4 and 50 letters")]
        [Display(Name = "First Name")]
        public string FirstName { get; set; }

        [MinLength(4)]
        [MaxLength(50)]
        [Required(ErrorMessage = "Name should range between 4 and 50 letters")]
        [Display(Name = "Last Name")]
        public string LastName { get; set; }

        [Required(ErrorMessage ="Minimum Age is 18 years")]
        [DisplayFormat(DataFormatString = "{0:dd/MM/yyyy}")]
        [DataType(DataType.Date)]
        [DateMinimumAge(18,ErrorMessage = "{0} must be someone at least {1} years of age")]
        [Display(Name = "Date Of Birth")]
        public DateTime DoB { get; set; }

        [Required]
        public string Gender { get; set; }

        [Required]
        [DataType(DataType.PhoneNumber)]
        [RegularExpression(@"^[789]\d{9}$", ErrorMessage = "Please enter a valid Contact Number")]
        [Display(Name = "Contact Number")]
        public string ContactNumber { get; set; }

        [Required]
        [DataType(DataType.Password)]
        [RegularExpression(@"^(?=.*\d)(?=.*[a-z])(?=.*[a-zA-Z]).{6,}$", ErrorMessage = "The Password should be of minimum 6 letters with special characters included")]
        public string Password { get; set; }

        [Required]
        [Display(Name = "Confirm Password")]
        [DataType(DataType.Password)]
        [System.ComponentModel.DataAnnotations.Compare("Password", ErrorMessage = "Password Not Matching")]
        public string ConfirmPassword { get; set; }

        [Key]
        [Required]
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        [Display(Name = "Member/Agent Id")]
        public string User_Id { get; set; }

        [ForeignKey("Role")]
        [Required(ErrorMessage = "Please select an User Role")]
        [Display(Name = "User Role")]
        public int UserRole { get; set; }
        public Role Role { get; set; }



    }
}





   


