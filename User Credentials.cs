using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.EnterpriseServices.Internal;
using System.Linq;
using System.Web;

namespace WebApplication2.Models
{
    public class UserCredential
    {
        
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }
        
        [ForeignKey("user")]
        [Required(ErrorMessage ="Member/Agent Id is required")]
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        [Display(Name = "Member/Agent Id")]
        public string UserId { get; set; }
        [Required]
        [DataType(DataType.Password)]
        public string Password { get; set; }

        public User user { get; set; }

        public int ApprovalStatus { get; set; }


    }
}
