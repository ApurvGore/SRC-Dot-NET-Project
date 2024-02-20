using CanteenManagement.Models;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using System.Reflection.Emit;

namespace CanteenManagement
{
    public class ApplicationDbContext : IdentityDbContext<ApplicationUser>
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options):base(options)
        {

        }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);

            builder.Entity<Item>(entity =>
            {
                // Other configurations...

                entity.Property(e => e.Price)
                    .HasColumnType("decimal(18,2)"); // Adjust precision and scale as needed
            });
        }

        public DbSet<Order> Order { get; set; }
        public DbSet<Item> Item { get; set; }

        //public DbSet<Employee> Employee { get; set; }
    }
}
