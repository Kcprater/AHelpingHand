using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AHelpingHand.Models
{
    public class ProviderListItem
    {
        [Display(Name="Provider ID")]
        public int ProviderID { get; set; }
        [Display(Name = "Name")]
        public string Name { get; set; }
        [Display(Name = "Company Name")]
        public string Company { get; set; }
        [Display(Name = "Email")]
        public string Email { get; set; }
        [Display(Name = "Phone")]
        public string Phone { get; set; }
        public int HelpID { get; set; }
    }
}