using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using PieShop.Models;

namespace PieShop.Models
{
    public class PieShopContext : IdentityDbContext<IdentityUser>
    {
        public PieShopContext (DbContextOptions<PieShopContext> options)
            : base(options)
        {
        }

        public DbSet<PieShop.Models.Pie> Pie { get; set; }

        public DbSet<PieShop.Models.Customer> Customer { get; set; }

        public DbSet<PieShop.Models.Purchase> Purchase { get; set; }
    }
}
