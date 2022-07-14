using FrontToBackend.DAL;
using FrontToBackend.Extention;
using FrontToBackend.Models;
using FrontToBackend.ViewModels;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;

namespace FrontToBackend.Areas.AdminPanel.Controllers
{
    [Area("AdminPanel")]
    public class ProductController : Controller
    {
        private readonly AppDbContext _context;
        private readonly IWebHostEnvironment _env;
        public ProductController(AppDbContext context, IWebHostEnvironment env)
        {

            _context = context;
            _env = env;
        }

        public IActionResult Index(int page = 1, int take = 3)
        {
            List<Product> products = _context.Products.Include(p=>p.category).Skip((page - 1) * take).Take(take).ToList();
            PagintaionVM<Product> pagintaionVM = new PagintaionVM<Product>(products, PageCount(take), page);

            return View(pagintaionVM);

        }
        private int PageCount(int take)
        {
            List<Product> products = _context.Products.ToList();
            return (int)Math.Ceiling((decimal)(products.Count() / take));
        }
        public async Task<IActionResult> Detail(int? id)
        {
            if (id == null) return NotFound();
            Product dbProduct = await _context.Products.Include(p => p.category).FirstOrDefaultAsync(p => p.id == id);
            if (dbProduct == null) return NotFound();
            return View(dbProduct);
        }
        public IActionResult Create()
        {

            ViewBag.Categories = _context.categories.ToList();
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Create(Product product)
        {
            ViewBag.Categories = _context.categories.ToList();
            if (product.Photo == null)
            {
                ModelState.AddModelError("Photo", "Bosh exist");
                return View();
            }
            if (product.CategoryId == 0)
            {
                ModelState.AddModelError("CategoryId", "Category sec");
                return View();
            }
            if (!product.Photo.IsImage())
            {
                ModelState.AddModelError("Photo", "only shekil");
                return View();
            }
            if (product.Photo.ValidSize(200))
            {
                ModelState.AddModelError("Photo", "olcu over size");
                return View();
            }

            Product newProduct = new Product
            {
                Price = product.Price,
                Name = product.Name,
                CategoryId = product.CategoryId,
                imgUrl = product.Photo.SaveImage(_env, "img")
            };
            _context.Add(newProduct);
            _context.SaveChanges();
            ViewBag.Categories = _context.categories.ToList();
            return RedirectToAction("index");
        }


        public IActionResult Delete(int? id)
        {
            Product dbProduct = _context.Products.FirstOrDefault(c => c.id == id);
            if (dbProduct == null) return View();
            string path = Path.Combine(_env.WebRootPath, "img", dbProduct.imgUrl);
            Helper.Helper.DeleteImage(path);

            _context.Products.Remove(dbProduct);
            _context.SaveChanges();
            return RedirectToAction("index");
        }



        public async Task<IActionResult> Update(int? id)
        {

            ViewBag.Categories = _context.categories.ToList();

            if (id == null) return NotFound();
            Product dbProduct = await _context.Products.FindAsync(id);
            if (dbProduct == null) return NotFound();


            return View(dbProduct);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Update(Product product)
        {

            ViewBag.Categories = _context.categories.ToList();
            if (!ModelState.IsValid)
            {
                return View();
            }
            Product dbProduct = _context.Products.FirstOrDefault(c => c.id == product.id);


            if (product.Photo == null)
            {
                ModelState.AddModelError("Photo", "boshdur");

                return View();
            }
            if (product.CategoryId == 0)
            {
                ModelState.AddModelError("CategoryId", "Category sec");
                return View();
            }
            if (!product.Photo.IsImage())
            {
                ModelState.AddModelError("Photo", "only shekil");
                return View();
            }
            if (product.Photo.ValidSize(200))
            {
                ModelState.AddModelError("Photo", "olcu over size");
                return View();
            }

            string path = Path.Combine(_env.WebRootPath, "img", dbProduct.imgUrl);
            System.IO.File.Delete(path);


            dbProduct.Photo = product.Photo;
            dbProduct.Name = product.Name;
            dbProduct.imgUrl = product.Photo.SaveImage(_env, "img");
            dbProduct.CategoryId = product.CategoryId;
            _context.SaveChanges();

            return RedirectToAction("index");
        }
    }
}
