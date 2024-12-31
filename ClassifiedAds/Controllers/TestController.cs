using ClassifiedAds.Data;
using ClassifiedAds.Helpers;
using Microsoft.AspNetCore.Mvc;

namespace ClassifiedAds.Controllers
{
    public class TestController(AppDbContext db) : Controller
    {
        public IActionResult Index()
        {
            var categories = db.Categories.ToList();
            categories.ForEach(m => m.Token = CoreHelper.GetUniqueToken());

            var specGroups = db.CategorySpecGroups.ToList();
            specGroups.ForEach(m => m.Token = CoreHelper.GetUniqueToken());

            var specs = db.CategorySpecs.ToList();
            specs.ForEach(m => m.Token = CoreHelper.GetUniqueToken());

            int r = db.SaveChanges();
            return View();
        }
    }
}
