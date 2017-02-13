using System.ComponentModel.DataAnnotations;
using Camp.Mvc.Swatter.Models;

namespace Camp.Mvc.Swatter.Aggregates.Flies
{
    public class FlyListAggregate
    {
        public Fly Fly { get; set; }

        [Display(Name = "Home Pot")]
        public string PotCode { get; set; }

        [Display(Name = "Code")]
        public string Code => $"{PotCode}-{Fly.Id}";

        public double DaysAlive { get; set; }
    }
}