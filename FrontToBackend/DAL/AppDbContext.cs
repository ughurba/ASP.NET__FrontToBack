﻿using FrontToBackend.Models;
using Microsoft.EntityFrameworkCore;

namespace FrontToBackend.DAL
{
    public class AppDbContext:DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options):base(options)
        {

        }
        public DbSet<Slider> Sliders { get; set; }
        public DbSet <SliderContent> SliderContents { get; set; }
        public DbSet <Category> categories { get; set; }
        public DbSet <Product> products { get; set; }
        public DbSet<Expert> experts { get; set; }
        public DbSet<Blog> blogs { get; set; }
        public DbSet<sliderBottom> sliderBottom { get; set; }
        public DbSet<instagramSlider> instagramSliders { get; set; }

    }
}