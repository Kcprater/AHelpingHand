using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AHelpingHand.Models
{
    public class ProviderCreate
    {
        [Required]
        public string Name { get; set; }
        public string Company { get; set; }
        [Required]
        public string Email { get; set; }
        [Required]
        [MaxLength(10), MinLength(7)]
        public string Phone { get; set; }
        public int HelpID { get; set; }
    }
}