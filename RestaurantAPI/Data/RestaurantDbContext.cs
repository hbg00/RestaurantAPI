using Microsoft.EntityFrameworkCore;
using RestaurantAPI.Entity;
using System.Data;

namespace RestaurantAPI.Data
{
    public class RestaurantDbContext : DbContext 
    {
        public RestaurantDbContext(DbContextOptions<RestaurantDbContext> options) : base(options)
        {
            
        }

        DbSet<Restaurant> Restaurants { get; set; }
        DbSet<Dish> Dishes { get; set; }
        DbSet<Address> Address { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Restaurant>()
                .Property(r => r.Name)
                .IsRequired()
                .HasMaxLength(25);

            modelBuilder.Entity<Dish>()
                .Property(d => d.Name)
                .IsRequired();

            modelBuilder.Entity<Address>()
                .Property(a => a.City)
                .IsRequired()
                .HasMaxLength(50);

            modelBuilder.Entity<Address>()
                .Property(a => a.Street)
                .IsRequired()
                .HasMaxLength(50);
        }

    }
}
