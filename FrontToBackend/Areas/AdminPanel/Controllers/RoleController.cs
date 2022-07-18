using FrontToBackend.Models;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using System.Linq;
using System.Threading.Tasks;

namespace FrontToBackend.Areas.AdminPanel.Controllers
{
    [Area("AdminPanel")]
    public class RoleController : Controller
    {
       
        private readonly UserManager<AppUser> _userManager;
        private readonly SignInManager<AppUser> _signInManager;
        private readonly RoleManager<IdentityRole> _roleManager;

        public RoleController(UserManager<AppUser> userManager, SignInManager<AppUser> signInManager, RoleManager<IdentityRole> roleManager)
        {
            _userManager = userManager;
            _signInManager = signInManager;
            _roleManager = roleManager;
        }

        public IActionResult Index()
        {
            return View(_roleManager.Roles.ToList());
        }

       
        public IActionResult Create()
        {
            return View();
        }
        [HttpPost]
        public async Task< IActionResult >Create(string role)
        {
            var result = await _roleManager.CreateAsync(new IdentityRole { Name = role });
            return RedirectToAction("index");
        }
        public async Task< IActionResult >Delete(string id)
        {
            var result = await _roleManager.FindByIdAsync(id);
           await  _roleManager.DeleteAsync(result);
            return RedirectToAction("index");
        }
    }
}
