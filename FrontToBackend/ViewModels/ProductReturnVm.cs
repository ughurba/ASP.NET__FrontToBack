namespace FrontToBackend.ViewModels
{
    public class ProductReturnVm
    {
        public int id { get; set; }
        public string Name { get; set; }
        public string imgUrl { get; set; }
        public double Price { get; set; }
        public int CategoryId { get; set; }
        public string category { get; set; }
    }
}
