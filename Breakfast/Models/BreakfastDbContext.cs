using Breakfast.Models;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace Breakfast.Models
{
    public class BreakfastDbContext : IdentityDbContext
    {
        public BreakfastDbContext(DbContextOptions options):base(options)
        {
        }

        public DbSet<Client> Clients { get; set; }
        public DbSet<OrderHdr> OrderHdrs { get; set; }
        public DbSet<OrderDtl> OrderDtls { get; set; }
        public DbSet<OrderBasket > Basket { get; set; }
        public DbSet<Product> Products { get; set; }
        public DbSet<Category> Categories { get; set; }


        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            
            BreakfasDbInitizalize init = new BreakfasDbInitizalize(modelBuilder);
            
            init.AddAdmin();
            init.AddCategory();
            init.AddProducts();
            init.AddOrder();

        }

    }
}
