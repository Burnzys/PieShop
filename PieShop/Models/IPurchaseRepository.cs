using System.Collections.Generic;

namespace PieShop.Models
{
    public interface IPurchaseRepository
    {
        IEnumerable<Purchase> GetAllPurchases();
        Purchase GetPurchaseById(int? id);
        Purchase GetPurchaseByCustomerId(int? id);
        int GetPieId(int? id);
        void Save(Purchase purchase);
    }
}
