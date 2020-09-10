using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AHelpingHand.Models
{
    public class HelpCreate
    {
        [Required]
        [Display(Name = "Name:")]
        public string Name { get; set; }
        [Display(Name = "Company Name:")]
        public string Company { get; set; }
        [Required]
        [EmailAddress]
        [Display(Name = "Email Address:")]
        public string Email { get; set; }
        [Required]
        [MaxLength(10), MinLength(7)]
        [Display(Name = "Phone:")]
        public string Phone { get; set; }
        [Required]
        [Display(Name = "Service:")]
        public string Category { get; set; }
        [Required]
        [Display(Name = "Specialty:")]
        public string Subcategory { get; set; }
        [Required]
        [Display(Name = "Experience (years):")]
        public int Experience { get; set; }
        [Required]
        [Display(Name = "Rate For Service:")]
        public string Rate { get; set; }
        [Required]
        [Display(Name = "Accepting New Clients?")]
        public bool NewClients { get; set; }
    }
}