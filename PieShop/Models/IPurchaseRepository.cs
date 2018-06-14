using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PieShop.Models
{
    public interface IPurchaseRepository
    {
        IEnumerable<Purchase> GetAllPurchases();
        Purchase GetPurchaseById(int? id);
        Purchase GetPurchaseByCustomerId(int? id);
    }
}
