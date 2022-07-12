using FrontToBackend.DAL;
using FrontToBackend.Models;
using FrontToBackend.ViewModels;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace FrontToBackend.ViewComponents
{
    public class HeaderViewComponent:ViewComponent
    {
        private readonly AppDbContext _context;
        private readonly UserManager<AppUser> _userManager;

   

        public HeaderViewComponent(AppDbContext context, UserManager<AppUser> userManager)
        {
            _userManager = userManager;
            _context = context;
        }
        public async Task<IViewComponentResult> InvokeAsync()
        {
            ViewBag.User = "";
            if (User.Identity.IsAuthenticated)
            {   AppUser user = await _userManager.FindByNameAsync(User.Identity.Name);
                ViewBag.User = user.FullName;
            }
            ViewBag.BasketCount = 0;
            ViewBag.TotalPrice = 0;
            double totalPrice = 0;
            string basket = Request.Cookies["basket"];
            if (basket!= null)
            {
                List<BasketVM> products = JsonConvert.DeserializeObject<List<BasketVM>>(basket);
                ViewBag.BasketCount = products.Count();

                foreach (var item in products)
                {
                    totalPrice += item.Price * item.ProductCount;
                }
            }
            ViewBag.TotalPrice = totalPrice;
           Bio bio = _context.Bios.FirstOrDefault() ;
           
            return View(await Task.FromResult(bio));

        }
    }
}
