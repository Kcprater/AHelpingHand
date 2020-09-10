using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AHelpingHand.Data
{
    public class Provider
    {
        [Key]
        [Display(Name = "Provider ID")]
        public int ProviderID { get; set; }
        [Required]
        [Display(Name = "Provider Name")]
        public string Name { get; set; }
        [Display(Name = "Company Name")]
        public string Company { get; set; }
        [Required]
        [EmailAddress]
        [Display(Name = "Email Address")]
        public string Email { get; set; }
        [Required]
        [Display(Name = "Phone Number")]
        public string Phone { get; set; }
        public int HelpID { get; set; }
        public virtual Help Help { get; set; }
        public virtual ICollection<Help> Helps { get; set; }
    }
}