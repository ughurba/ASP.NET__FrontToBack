using FrontToBackend.DAL;
using FrontToBackend.Models;
using FrontToBackend.ViewModels;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Linq;

namespace FrontToBackend.Controllers
{
    public class HomeController : Controller
    {
        private readonly AppDbContext _context;
        public HomeController(AppDbContext context)
        {
                _context = context;
        }

        public IActionResult Index()
        {
            List<Slider> sliders = _context.Sliders.ToList();
            SliderContent sliderContent = _context.SliderContents.FirstOrDefault();
            List<Category>categories = _context.categories.ToList();
            List<Product> products = _context.products.ToList();
            List<Expert> experts = _context.experts.ToList();
            List<Blog> blogs = _context.blogs.ToList();
            List<sliderBottom> sliderBottom = _context.sliderBottom.ToList();
            List<instagramSlider> instagramSliders = _context.instagramSliders.ToList();
            HomeVM home = new HomeVM();
            home.sliders = sliders;
            home.sliderContent = sliderContent;
            home.categories = categories;
            home.products= products;
            home.experts = experts;
            home.blogs = blogs;
            home.sliderBottom = sliderBottom;
            home.instagramSliders = instagramSliders;

            
            
        
            return View(home);
        }
    }
}
