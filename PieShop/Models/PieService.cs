using System;
using System.Collections.Generic;
using System.Linq;

namespace PieShop.Models
{
    public class PieService : IPieRepository
    {
        private readonly PieShopContext _context;

        public PieService(PieShopContext pieShopContext)
        {
            _context = pieShopContext;
        }

        public IEnumerable<Pie> GetAllPies()
        {
            return _context.Pie.ToList();
        }

        public Pie GetPieById(int? Id)
        {
            return _context.Pie.FirstOrDefault(p => p.Id == Id);
        }

        public void Save(Pie pie)
        {
            _context.Pie.Add(pie);
            _context.SaveChanges();

            Console.WriteLine("Pie is saved");
        }
    }
}
