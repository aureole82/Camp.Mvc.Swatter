using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace Camp.Mvc.Swatter.Models
{
    public class Pot
    {
        public int Id { get; set; }

        [Required]
        [Display(Name = "Code")]
        public string Abbreviation { get; set; }

        [Required]
        public string Name { get; set; }

        public string Description { get; set; }

        [EmailAddress]
        [Display(Name = "Contact")]
        public string Chief { get; set; }

        [Display(Name = "Swatting Targets")]
        public List<Fly> Flies { get; set; } = new List<Fly>();
    }
}