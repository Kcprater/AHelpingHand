using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AHelpingHand.Data
{
    public enum Skill { Beginner, Novice, Intermediate, Advance, Expert, NA}
    public class Customer
    {
        [Key]
        [Display(Name = "Customer ID:")]
        public int CustomerID { get; set; }
        [Required]
        public Guid OwnerId { get; set; }
        [Required]
        [Display(Name = "Name")]
        public string Name { get; set; }
        [Required]
        [EmailAddress]
        [Display(Name = "Email Address")]
        public string Email { get; set; }
        [Required]
        [Display(Name = "Service")]
        public string Category { get; set; }
        [Required]
        [Display(Name = "Specialty")]
        public string Subcategory { get; set; }
        [Required]
        [Display(Name = "Skill Level")]
        public Skill Skill { get; set; }
        public virtual Help Help { get; set; }
    }
}