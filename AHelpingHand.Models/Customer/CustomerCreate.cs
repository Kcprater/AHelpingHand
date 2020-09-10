using AHelpingHand.Data;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AHelpingHand.Models
{
    public class CustomerCreate
    {
        [Required]
        [Display(Name = "Name:")]
        public string Name { get; set; }
        [Required]
        [Display(Name = "Email:")]
        public string Email { get; set; }
        [Required]
        [Display(Name = "Service:")]
        public string Category { get; set; }
        [Required]
        [Display(Name = "Specialty:")]
        public string Subcategory { get; set; }
        [Required]
        [Display(Name = "My Skill Level:")]
        public Skill Skill { get; set; }
    }
}
