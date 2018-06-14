using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PieShop.Models
{
    public class PurchaseService : IPurchaseRepository
    {
        private readonly PieShopContext _context;

        public PurchaseService(PieShopContext context)
        {
            _context = context;
        }

        public IEnumerable<Purchase> GetAllPurchases()
        {
            return _context.Purchase.ToList();
        }

        public Purchase GetPurchaseByCustomerId(int id)
        {
            throw new NotImplementedException();
        }

        public Purchase GetPurchaseById(int id)
        {
            throw new NotImplementedException();
        }
    }
}
