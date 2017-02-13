using System;
using System.ComponentModel.DataAnnotations;
using System.Linq;

namespace Camp.Mvc.Swatter.Models
{
    public class Fly
    {
        public int Id { get; set; }

        [Required]
        [MinLength(3, ErrorMessage = "Give {0} at least {1} characters")]
        [MaxLength(130, ErrorMessage = "{0} must not be longer than {1} characters")]
        //[StringLength(130, MinimumLength = 3)]
        [DontSwear]
        [Display(Name = "Title")]
        public string Head { get; set; }

        [DontSwear]
        [Display(Name = "Description")]
        [DataType(DataType.MultilineText)]
        public string Body { get; set; }

        [Required]
        [EmailAddress]
        [Display(Name = "Author")]
        [DisplayFormat(NullDisplayText = "(unknown)")]
        public string Creator { get; set; }

        [Display(Name = "Created at")]
        [DisplayFormat(DataFormatString = "{0:yyyy-MM-dd}", ApplyFormatInEditMode = true)]
        [DataType(DataType.Date)]
        public DateTime Born { get; set; } = DateTime.Now;

        [Display(Name = "Updated at")]
        [DisplayFormat(DataFormatString = "{0:yyyy-MM-dd}", ApplyFormatInEditMode = true)]
        [DataType(DataType.Date)]
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

    public class DontSwearAttribute : ValidationAttribute
    {
        private readonly string[] _forbidden = {"fuck", "bitch", "looser"};

        public DontSwearAttribute() : base("Don't swear on {0}!")
        {
        }

        protected override ValidationResult IsValid(object value, ValidationContext context)
        {
            var text = (value as string)?.ToLower();
            if (string.IsNullOrWhiteSpace(text)
                || !_forbidden.Any(swear => text.Contains(swear)))
                return ValidationResult.Success;

            var errorMessage = FormatErrorMessage(context.DisplayName);
            return new ValidationResult(errorMessage);
        }
    }
}