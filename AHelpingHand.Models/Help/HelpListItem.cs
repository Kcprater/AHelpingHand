using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AHelpingHand.Models
{
    public class HelpListItem
    {
        [Display(Name = "Help ID")]
        public int HelpID { get; set; }
        [Display(Name = "Category")]
        public string Category { get; set; }
        [Display(Name = "Speciality")]
        public string Subcategory { get; set; }
        [Display(Name = "Experience")]
        public int Experience { get; set; }
        [Display(Name = "Rate Charged")]
        public string Rate { get; set; }
        [Display(Name = "Accepting New Clients")]
        public bool NewClients { get; set; }
    }
}