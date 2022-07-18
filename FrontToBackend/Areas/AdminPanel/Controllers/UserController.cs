using FrontToBackend.Models;
using FrontToBackend.ViewModels;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace FrontToBackend.Areas.AdminPanel.Controllers
{
    [Area("AdminPanel")]
    public class UserController : Controller
    {
        private readonly UserManager<AppUser> _userManager;
        private readonly SignInManager<AppUser> _signInManager;
        private readonly RoleManager<IdentityRole> _roleManager;

        public UserController(UserManager<AppUser> userManager, SignInManager<AppUser> signInManager, RoleManager<IdentityRole> roleManager)
        {
            _userManager = userManager;
            _signInManager = signInManager;
            _roleManager = roleManager;
        }

        public IActionResult Index(string search)
        {
            if(search == null)
            {
                var users = _userManager.Users.ToList();
                return View(users);
            }
            var searchUsers = _userManager.Users.Where(u => u.FullName.ToLower().Contains(search.ToLower())).ToList();
            return View(searchUsers);
        }

         public async Task <IActionResult >Update(string id)
        {

            AppUser user = await _userManager.FindByIdAsync(id);
            var userRoles = await _userManager.GetRolesAsync(user);
            var roles =  _roleManager.Roles.ToList();
            RoleVM rolevm = new RoleVM
            {
                FullName=user.FullName,
                roles=roles,
                userRoles = userRoles,
                userId = user.Id
            };
            return View(rolevm);
        }
        [HttpPost]

        public async Task<IActionResult> Update(List<string>roles,string id)
        {
            AppUser user = await _userManager.FindByIdAsync(id);
            var userRoles = await _userManager.GetRolesAsync(user);

            var addRoles = roles.Except(userRoles);
            var removeRoles = userRoles.Except(roles);

            await _userManager.AddToRolesAsync(user, addRoles);
            await _userManager.RemoveFromRolesAsync(user, removeRoles);
            return RedirectToAction("index");
        }
    }
}
