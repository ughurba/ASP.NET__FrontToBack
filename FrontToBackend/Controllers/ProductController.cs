using FrontToBackend.DAL;
using FrontToBackend.Models;
using FrontToBackend.ViewModels;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;

namespace FrontToBackend.Controllers
{
    public class ProductController : Controller
    {
        private readonly AppDbContext _context;

        public ProductController(AppDbContext context)
        {
            _context = context;
        }

        public IActionResult Index()
        {
            ViewBag.ProductCount = _context.Products.Count();
            List<Product> products = _context.Products.Take(8).Include((p => p.category)).ToList();
            return View(products);
        }
        public IActionResult LoadMore(int skip)
        {
            //List<ProductReturnVm> products = _context.Products.Select(p => new ProductReturnVm {
            //    id = p.id,
            //    Name = p.Name,
            //    category = p.category.Name,
            //    Price = p.Price,
            //    imgUrl = p.imgUrl,
            //    CategoryId = p.CategoryId
            //}).ToList();

            //List<Product> products = _context.Products.Skip(2).Take(2).Include(p => p.category).ToList();
            //List<ProductReturnVm> productReturnVms = new List<ProductReturnVm>();
          
            List<Product> products = _context.Products.Skip(skip).Take(2).Include(p=>p.category).ToList();  
            return PartialView("LoadMorePartial",products);
        }
    }
}
