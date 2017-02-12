using System;

namespace Camp.Mvc.Swatter.Models
{
    public class HomeModel
    {
        public string MachineName { get; set; }
        public string UserName { get; set; }
        public string UserNameDirty { get; set; }
        public DateTime DateTime { get; set; }
        public int UserAge { get; set; }
    }
}