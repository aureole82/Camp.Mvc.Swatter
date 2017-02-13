using System.ComponentModel.DataAnnotations;
using Camp.Mvc.Swatter.Models;

namespace Camp.Mvc.Swatter.Aggregates.Flies
{
    public class FlyDetailsAggregate
    {
        public Fly Fly { get; set; }

        [Display(Name = "Home Pot")]
        public string PotCode { get; set; }

        [Display(Name = "Pot Name")]
        public string PotName { get; set; }
    }
}