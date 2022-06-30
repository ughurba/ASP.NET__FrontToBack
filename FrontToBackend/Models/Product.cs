namespace FrontToBackend.Models
{
    public class Product
    {
        public int id{ get; set; }
        public string  Name{ get; set; }
        public string imgUrl{ get; set; }
        public double Price { get; set; }
        public int CategoryId { get; set; }
        public Category category { get; set; }
        public int Count { get; set; }  
    }
}
