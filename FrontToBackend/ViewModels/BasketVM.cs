namespace FrontToBackend.ViewModels
{
    public class BasketVM
    {
        public int id { get; set; }
        public string Name { get; set; }
        public string imgUrl { get; set; }
        public double Price { get; set; }
        public double Sum { get; set; }
        public int CategoryId { get; set; }
     
        public int ProductCount { get; set; }
    }
}
