using System;

namespace FrontToBackend.Models
{
    public class Blog
    {
        public int id { get; set; }
        public string imgUrl { get; set; }
        public string Name { get; set; }
        public string desc { get; set; }
        public DateTime data { get; set; }
    }
}
