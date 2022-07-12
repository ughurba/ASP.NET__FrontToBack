using FrontToBackend.Models;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace FrontToBackend.DAL
{
    public class AppDbContext : IdentityDbContext<AppUser>
    {
        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options)
        {

        }
        public DbSet<Slider> Sliders { get; set; }
        public DbSet<SliderContent> SliderContents { get; set; }
        public DbSet<Category> categories { get; set; }
        public DbSet<Product> Products { get; set; }
        public DbSet<Expert> experts { get; set; }
        public DbSet<Blog> blogs { get; set; }
        public DbSet<sliderBottom> sliderBottom { get; set; }
        public DbSet<instagramSlider> instagramSliders { get; set; }
        public DbSet<Bio> Bios { get; set; }
    }
}
