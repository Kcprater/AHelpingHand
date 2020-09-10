using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AHelpingHand.Models
{
    public class HelpEdit
    {
        public int HelpID { get; set; }
        [Display(Name = "Service:")]
        public string Category { get; set; }
        [Display(Name = "Specialty:")]
        public string Subcategory { get; set; }
        [Display(Name = "Experience:")]
        public int Experience { get; set; }
        [Display(Name = "Rate For Service:")]
        public string Rate { get; set; }
        [Display(Name = "Accepting New Clients?")]
        public bool NewClients { get; set; }
    }
}