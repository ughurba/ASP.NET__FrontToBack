using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace FrontToBackend.Models
{
    public class Category
    {
        public int id { get; set; }
        [Required,MaxLength(100)]
        public string Name{ get; set; }
        [Required, MaxLength(200)]
        public string Desc{ get; set; }
        public List <Product> products { get; set; }
    }
}
