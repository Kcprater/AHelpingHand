using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AHelpingHand.Models
{
    public class ProviderEdit
    {
        public int ProviderID { get; set; }
        [Display(Name = "Name:")]
        public string Name { get; set; }
        [Display(Name = "Company Name:")]
        public string Company { get; set; }
        [Display(Name = "Email:")]
        public string Email { get; set; }
        [Display(Name = "Phone Number:")]
        public string Phone { get; set; }
    }
}