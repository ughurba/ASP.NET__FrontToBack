using FrontToBackend.DAL;
using FrontToBackend.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace FrontToBackend.Areas.AdminPanel.Controllers
{
    [Area("AdminPanel")]
    [Authorize]
    public class CategoryController : Controller
    {
        private readonly AppDbContext _context;

        public CategoryController(AppDbContext context)
        {
            _context = context;
        }

        public IActionResult Index()
        {

            List<Category> categories = _context.categories.ToList();
             return View(categories);
        }

        [AllowAnonymous]
        public IActionResult Create()
        {
            return View();
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task <IActionResult> Create(Category category)
        {
            if (!ModelState.IsValid)
            {
                return View();
            }
            bool existNameCategory = _context.categories.Any(c => c.Name == category.Name); 
            if (existNameCategory)
            {
                ModelState.AddModelError("Name", "bu adli category var");
                return View();
            }
            Category newCategory = new Category
            {
                Name = category.Name,
                Desc = category.Desc,
            };
            await _context.categories.AddAsync(newCategory);
            await _context.SaveChangesAsync();


            return RedirectToAction("Index");  
        }
        public async Task<IActionResult> Detail(int? id)
        {
            if (id == null) return NotFound();
            Category dbCategory = await _context.categories.FindAsync(id);
            if (dbCategory == null) return NotFound();
            return View(dbCategory);
        }
        public async Task<IActionResult> Update(int? id)
        {
            if (id == null) return NotFound();
            Category dbCategory = await _context.categories.FindAsync(id);
            if(dbCategory == null) return NotFound();

            return View(dbCategory);
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Update(Category category)
        {
            if (!ModelState.IsValid)
            {
                return View();
            }
            Category dbCategory = _context.categories.FirstOrDefault(c => c.id == category.id);
            Category dbCategoryName = _context.categories.FirstOrDefault(c => c.Name.ToLower() == category.Name.ToLower());
            if(dbCategoryName != null)
            {
                if(dbCategoryName.Name != dbCategory.Name)
                {
                    ModelState.AddModelError("Name", "bu adli category var");
                    return View();
                }
            }

          
            dbCategory.Name = category.Name;
            dbCategory.Desc = category.Desc;
            await _context.SaveChangesAsync();
            return RedirectToAction("Index");
        }

        public IActionResult Delete(int? id)
        {
            Category dbCategory = _context.categories.FirstOrDefault(c => c.id == id);
            if (dbCategory == null) return View();
            _context.categories.Remove(dbCategory);
            _context.SaveChanges();
            return RedirectToAction("index");
        }

    }
}
