using AHelpingHand.Data;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AHelpingHand.Models
{
    public class HelpDetail
    {
        [Display(Name = "Help ID:")]
        public int HelpID { get; set; }
        [Display(Name = "Category:")]
        public string Category { get; set; }
        [Display(Name = "Subcategory:")]
        public string Subcategory { get; set; }
        [Display(Name = "Experience:")]
        public int Experience { get; set; }
        [Display(Name = "Rate Charged:")]
        public string Rate { get; set; }
        [Display(Name = "Accepting New Cleints")]
        public bool NewClients { get; set; }
        [Display(Name = "Provider Name:")]
        public string Name { get; set; }
        [Display(Name = "Provider Email:")]
        public string Email { get; set; }
        [Display(Name = "Provider Phone:")]
        public string Phone { get; set; }
        public List<Provider> Provider { get; set; }
    }
}
