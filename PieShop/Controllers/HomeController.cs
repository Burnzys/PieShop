using System;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using PieShop.Models;

namespace PieShop.Controllers
{
    [Authorize]
    public class HomeController : Controller
    {
        private readonly IPieRepository _pieRepository;

        public HomeController(IPieRepository pieRepository)
        {
            _pieRepository = pieRepository;
        }

        public IActionResult Index()
        {
            var Pies = _pieRepository.GetAllPies().OrderBy(p => p.Name);
            return View(Pies);
        }

        public IActionResult Details(int? id)
        {
            var Pie = _pieRepository.GetPieById(id);

            return View(Pie);
        }

        // GET: Pies/Create
        public IActionResult Create()
        {
            Console.WriteLine("Method called");
            return View();
        }

        // POST: Pies/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Name,ShortDescription,LongDescription,Price,ImageUrl,ThumbnailUrl,IsPieOfTheWeek,PieType")] Pie pie)
        {
            Console.WriteLine(ModelState.IsValid);
            if (ModelState.IsValid)
            {
                _pieRepository.Save(pie);

                Console.WriteLine("Pie has been saved");

                return RedirectToAction(nameof(Index));
            }
            return View(pie);
        }

        public IActionResult About()
        {
            ViewData["Message"] = "Your application description page.";

            return View();
        }

        public IActionResult Contact()
        {
            ViewData["Message"] = "Your contact page.";

            return View();
        }

        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
