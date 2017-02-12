using System;
using System.ComponentModel.DataAnnotations;

namespace Camp.Mvc.Swatter.Models
{
    public class Fly
    {
        public int Id { get; set; }

        [Required]
        [MinLength(3)]
        [MaxLength(130)]
        //[StringLength(130, MinimumLength = 3)]
        [Display(Name = "Title")]
        public string Head { get; set; }

        [Display(Name = "Description")]
        public string Body { get; set; }

        [Required]
        [EmailAddress]
        [Display(Name = "Author")]
        [DisplayFormat(NullDisplayText = "(unknown)")]
        public string Creator { get; set; }

        [Display(Name = "Created at")]
        [DisplayFormat(DataFormatString = "{0:F}")]
        public DateTime Born { get; set; } = DateTime.Now;

        [Display(Name = "Updated at")]
        [DisplayFormat(DataFormatString = "{0:F}")]
        public DateTime Updated { get; set; } = DateTime.Now;

        [Display(Name = "Severity")]
        public Weight Weight { get; set; } = Weight.Normal;
    }

    public enum Weight
    {
        Heavy,
        Normal,
        Light,
        Trivial
    }
}