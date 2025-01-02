using ClassifiedAds.Data;
using ClassifiedAds.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace ClassifiedAds.Controllers
{
    public class AdsController(AppDbContext db) : Controller
    {
        public IActionResult Create(int id, string token)
        {
            var category = db.Categories.Where(m => m.Id == id && m.Token == token)
                .Include(m => m.SpecsGroups)
                .ThenInclude(m => m.Specs).FirstOrDefault();
            if (category == null) return NotFound();
            ViewBag.Category = category;

            return View();
        }

        [HttpPost]
        public IActionResult Create(Ad model)
        {
            if (ModelState.IsValid)
            {
                db.Add(model);
                int r = db.SaveChanges();
            }
            return View(model);
        }
    }
}
