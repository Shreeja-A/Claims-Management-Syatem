using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace WebApplication2.Models
{
    public class Claim
    {

        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }

        [ForeignKey("user")]
        [Display(Name ="Member/Agent Id")]
        public string UserId { get; set; }

        [Key]
        [Required]
        [Display(Name ="Claim Id")]
        public string ClaimId { get; set; }

        [Required]
        [Display(Name ="Type Of Claim")]
        public string ClaimType { get; set; }

        [Required]
        [Display(Name ="Policy Id")]
        public string PolicyId { get; set; }

        [Required]
        [Range(0.01, 999999999, ErrorMessage = "Ammount must be greater than 0")]
        [Display(Name = "Amount to be claimed")]
        public decimal Amount { get; set; }

        [Display(Name ="Status")]
        public int ClaimStatus { get; set; }

        public User user { get; set; }

        public string Comments{ get; set; }
    }
}
