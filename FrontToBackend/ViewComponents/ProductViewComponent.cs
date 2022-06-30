using FrontToBackend.DAL;
using FrontToBackend.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace FrontToBackend.ViewComponents
{
    public class ProductViewComponent : ViewComponent
    {




        private readonly AppDbContext _context;

        public ProductViewComponent(AppDbContext context)
        {
            _context = context;
        }
        public async Task<IViewComponentResult> InvokeAsync()
        {
            List<Product> products = _context.Products.Include(p => p.category).ToList();


            return View(await Task.FromResult(products));
        }





    }
}
