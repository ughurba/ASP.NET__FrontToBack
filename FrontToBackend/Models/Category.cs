using System.Collections.Generic;

namespace FrontToBackend.Models
{
    public class Category
    {
        public int id { get; set; }
        public string Name{ get; set; }
        public List <Product> products { get; set; }
    }
}
