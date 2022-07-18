using FrontToBackend.DAL;
using FrontToBackend.Models;
using FrontToBackend.ViewModels;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;

namespace FrontToBackend.Controllers
{
    public class BasketController : Controller
    {
        private readonly AppDbContext _context;

        public BasketController(AppDbContext context)
        {
            _context = context;
        }

        public IActionResult Index()
        {
            return View();
        }
        public IActionResult AddItem(int? id)
        {
            if (id == null) return NotFound();
            Product dbProduct = _context.Products.FirstOrDefault(p => p.id == id);

            if (dbProduct == null) return NotFound();
            List<BasketVM> products;

            if (Request.Cookies["basket"] == null)
            {
                products = new List<BasketVM>();

            }
            else
            {

                string baskets = Request.Cookies["basket"];
                products = JsonConvert.DeserializeObject<List<BasketVM>>(baskets);

            }
            BasketVM exsiProduct = products.FirstOrDefault(products => products.id == id);
            if (exsiProduct == null)
            {
                BasketVM basketVM = new BasketVM
                {
                    id = dbProduct.id,

                    ProductCount = 1,
                    Price = dbProduct.Price,
                    Sum = dbProduct.Price

                };
                products.Add(basketVM);
            }
            else
            {
                exsiProduct.ProductCount++;
            }

            Response.Cookies.Append("basket", JsonConvert.SerializeObject(products), new CookieOptions { MaxAge = TimeSpan.FromDays(14) });

            return Json(products.Count);
        }

        public IActionResult ShowItem()
        {
            string basket = Request.Cookies["basket"];
            List<BasketVM> products;
            if (basket != null)
            {
                products = JsonConvert.DeserializeObject<List<BasketVM>>(basket);
                foreach (var item in products)
                {
                    Product dbProduct = _context.Products.FirstOrDefault(p => p.id == item.id);
                    item.Price = dbProduct.Price;
                    item.Name = dbProduct.Name;
                    item.imgUrl = dbProduct.imgUrl;
                    item.CategoryId = dbProduct.CategoryId;
                }

            }
            else
            {
                products = new List<BasketVM>();
            }

            return View(products);
        }

        public IActionResult Plus(int? id)
        {

            List<BasketVM> products;
            string basket = Request.Cookies["basket"];
            products = JsonConvert.DeserializeObject<List<BasketVM>>(basket);
            BasketVM product = products.Find(p => p.id == id);


            product.ProductCount = product.ProductCount + 1;
            product.Sum = product.Price * product.ProductCount;
            Response.Cookies.Append("basket", JsonConvert.SerializeObject(products), new CookieOptions { MaxAge = TimeSpan.FromDays(14) });
            var productPlusObj = new
            {
                productPrice = product.Sum,
                productCount = product.ProductCount,
            };
            return Json(productPlusObj);
        }

        public IActionResult Minus(int? id)
        {
            List<BasketVM> products;
            string basket = Request.Cookies["basket"];
            products = JsonConvert.DeserializeObject<List<BasketVM>>(basket);
            BasketVM product = products.Find(p => p.id == id);
            var productMinusObj = new Object();


            if (product.ProductCount <= 1)
            {
                products.Remove(product);
                Response.Cookies.Append("basket", JsonConvert.SerializeObject(products), new CookieOptions { MaxAge = TimeSpan.FromDays(14) });
                products = JsonConvert.DeserializeObject<List<BasketVM>>(basket);

            }
            else
            {
                product.ProductCount = product.ProductCount - 1;
                product.Sum = product.Price * product.ProductCount;
                Response.Cookies.Append("basket", JsonConvert.SerializeObject(products), new CookieOptions { MaxAge = TimeSpan.FromDays(14) });

                productMinusObj = new
                {
                    productPrice = product.Sum,
                    productCount = product.ProductCount
                };


            }

            return Json(productMinusObj);
        }
        public IActionResult SizeBasket()
        {
            List<BasketVM> goods;
            string basket = Request.Cookies["basket"];
            if(basket != null)
            {
                goods = JsonConvert.DeserializeObject<List<BasketVM>>(basket);
                return Json(goods.Count);
            }


            return Json("");

        }
        public IActionResult Remove(int? id)
        {

            List<BasketVM> goods;
            string basket = Request.Cookies["basket"];
            goods = JsonConvert.DeserializeObject<List<BasketVM>>(basket);

            goods.RemoveAll(item => item.id == id);
            Response.Cookies.Append("basket", JsonConvert.SerializeObject(goods), new CookieOptions { MaxAge = TimeSpan.FromDays(14) });
            goods = JsonConvert.DeserializeObject<List<BasketVM>>(basket);
            return Json(goods.Count);
        }
    }
}
