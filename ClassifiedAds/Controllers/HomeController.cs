using ClassifiedAds.Data;
using ClassifiedAds.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Diagnostics;

namespace ClassifiedAds.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private readonly AppDbContext _context;

        public HomeController(ILogger<HomeController> logger, AppDbContext context)
        {
            _logger = logger;
            _context = context;
        }

        public IActionResult Index()
        {
            //var categories = _context.Categories.Include(m => m.Ads).ToList();
            //var categories = _context.Categories.Select(m => new CategoryViewModel
            //{
            //    Id = m.Id,
            //    Name = m.Name,
            //    Description = m.Description,
            //    LogoUrl = m.LogoUrl,
            //    AdsCount = m.Ads.Count()
            //}).ToList();

            return View();
        }

        public IActionResult Privacy()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
