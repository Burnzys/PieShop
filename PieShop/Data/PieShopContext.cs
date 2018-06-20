using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace PieShop.Models
{
    public class PieShopContext : IdentityDbContext<IdentityUser>
    {
        public PieShopContext (DbContextOptions<PieShopContext> options)
            : base(options)
        {
        }

        public DbSet<Pie> Pie { get; set; }

        public DbSet<Customer> Customer { get; set; }

        public DbSet<Purchase> Purchase { get; set; }
    }
}
