using System;

namespace Camp.Mvc.Swatter.Models
{
    public class Fly
    {
        public int Id { get; set; }
        public string Head { get; set; }
        public string Body { get; set; }
        public string Creator { get; set; }
        public DateTime Born { get; set; } = DateTime.Now;
        public DateTime Updated { get; set; } = DateTime.Now;
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