using AHelpingHand.Data;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AHelpingHand.Models
{
    public class CustomerDetail
    {
        [Display(Name = "Customer ID")]
        public int CustomerID { get; set; }
        [Display(Name = "Name:")]
        public string Name { get; set; }
        [Display(Name = "Email:")]
        public string Email { get; set; }
        [Display(Name = "Service Needed:")]
        public string Category { get; set; }
        [Display(Name = "Specialty:")]
        public string Subcategory { get; set; }
        [Display(Name = "My Skill Level:")]
        public Skill Skill { get; set; }
    }
}
