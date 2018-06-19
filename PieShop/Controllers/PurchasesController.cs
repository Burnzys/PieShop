using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using PieShop.Models;
using PieShop.ViewModel;

namespace PieShop.Controllers
{
    public class PurchasesController : Controller
    {
        private readonly PieShopContext _context;

        private readonly IPurchaseRepository _purchaseRepository;
        private readonly IPieRepository _pieRepository;
        private readonly ICustomerRepository _customerRepository;

        public PurchasesController(IPurchaseRepository purchaseRepository, 
            IPieRepository pieRepository, ICustomerRepository customerRepository)
        {
            _purchaseRepository = purchaseRepository;
            _pieRepository = pieRepository;
            _customerRepository = customerRepository;
        }

        // GET: Purchases
        public IActionResult Index()
        {
            var purchases = _purchaseRepository.GetAllPurchases();
            return View(purchases);
        }

        // GET: Purchases/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            /* We can use our purchaseRepo to get the purcase we need
               then by using the purchase object along with the pieRepo
               and the customerRepo we can get the Pie object and Customer object
               this can then be set for the PiePurchase object and passed to the View
             */
            var purchase = _purchaseRepository.GetPurchaseById(id);
            PiePurchase piePurchase = new PiePurchase
            {
                Pie = _pieRepository.GetPieById(purchase.PieId),
                Customer = _customerRepository.GetCustomerById(purchase.CustomerId)
            };

            if (purchase == null)
            {
                return NotFound();
            }

            return View(piePurchase);
        }

        // GET: Purchases/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Purchases/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,PieId,CustomerId")] Purchase purchase)
        {
            if (ModelState.IsValid)
            {
                _purchaseRepository.Save(purchase);

                return RedirectToAction(nameof(Index));
            }
            return View(purchase);
        }

        // GET: Purchases/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var purchase = await _context.Purchase.SingleOrDefaultAsync(m => m.Id == id);
            if (purchase == null)
            {
                return NotFound();
            }
            return View(purchase);
        }

        // POST: Purchases/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,PieId,CustomerId")] Purchase purchase)
        {
            if (id != purchase.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(purchase);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!PurchaseExists(purchase.Id))
                    {
                        return NotFound();
                    }
                    else
                    {
                        throw;
                    }
                }
                return RedirectToAction(nameof(Index));
            }
            return View(purchase);
        }

        // GET: Purchases/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var purchase = await _context.Purchase
                .SingleOrDefaultAsync(m => m.Id == id);
            if (purchase == null)
            {
                return NotFound();
            }

            return View(purchase);
        }

        // POST: Purchases/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var purchase = await _context.Purchase.SingleOrDefaultAsync(m => m.Id == id);
            _context.Purchase.Remove(purchase);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool PurchaseExists(int id)
        {
            return _context.Purchase.Any(e => e.Id == id);
        }
    }
}
