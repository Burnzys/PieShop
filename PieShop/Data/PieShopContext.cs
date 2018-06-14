using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;

namespace PieShop.Models
{
    public class PieShopContext : DbContext
    {
        public PieShopContext (DbContextOptions<PieShopContext> options)
            : base(options)
        {
        }

        public DbSet<PieShop.Models.Customer> Customer { get; set; }
    }
}
