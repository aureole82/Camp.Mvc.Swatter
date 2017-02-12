using System;
using System.ComponentModel.DataAnnotations;

namespace Camp.Mvc.Swatter.Models
{
    public class Fly
    {
        public int Id { get; set; }

        [Display(Name = "Title")]
        public string Head { get; set; }

        [Display(Name = "Description")]
        public string Body { get; set; }

        [Display(Name = "Author")]
        [DisplayFormat(NullDisplayText= "(unknown)")]
        public string Creator { get; set; }

        [Display(Name = "Created at")]
        [DisplayFormat(DataFormatString = "{0:F}")]
        public DateTime Born { get; set; } = DateTime.Now;

        [Display(Name = "Updated at")]
        [DisplayFormat(DataFormatString = "{0:d}")]
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