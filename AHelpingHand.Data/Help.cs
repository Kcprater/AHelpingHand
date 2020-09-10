using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AHelpingHand.Data
{
    public class Help
    {
        [Key]
        [Display(Name = "Help ID")]
        public int HelpID { get; set; }
        [Required]
        [Display(Name = "User ID")]
        public Guid OwnerId { get; set; }
        [Required]
        [Display(Name = "Category")]
        public string Category { get; set; }
        [Required]
        [Display(Name = "Subcategory")]
        public string Subcategory { get; set; }
        [Required]
        [Display(Name = "Experience")]
        public int Experience { get; set; }
        [Required]
        [Display(Name = "Rate Charged")]
        public string Rate { get; set; }
        [Required]
        [Display(Name = "Accepting New Clients")]
        public bool NewClients { get; set; }
        public virtual ICollection<Provider> Providers { get; set; }
        public virtual Provider Provider { get; set; }
    }
}
