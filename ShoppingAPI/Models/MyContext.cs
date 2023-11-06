using Microsoft.EntityFrameworkCore;
using ShoppingAPI.Models;

namespace ShoppingAPI.Models
{
    public class MyContext : DbContext
    {
        public MyContext(DbContextOptions<MyContext> options) : base(options) { }

        public DbSet<Slider> Sliders { get; set; }
        public DbSet<SliderGroup> SliderGroups { get; set; }
        public DbSet<SliderGallery> SliderGallerys { get; set; }    

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.HasDefaultSchema("Shop");
            //modelBuilder.Entity<Slider>().HasKey(s => s.SliderId);
            //modelBuilder.Entity<Slider>().ToTable("HomeSliders");
            //modelBuilder.Entity<Slider>().Property(s=>s.Description).HasMaxLength(150);

            modelBuilder.Entity<Slider>().HasQueryFilter(s => s.Description != null);
        }
    }
}
