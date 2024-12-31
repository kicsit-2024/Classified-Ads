using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using ClassifiedAds.Data;
using ClassifiedAds.Models;
using ClassifiedAds.Helpers;

namespace ClassifiedAds.Controllers
{
    public class CategoriesController : Controller
    {
        private readonly AppDbContext _context;

        public CategoriesController(AppDbContext context)
        {
            _context = context;
        }

        // GET: Categories
        public async Task<IActionResult> Index()
        {
            return View(await _context.Categories.ToListAsync());
        }

        // GET: Categories/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var category = await _context.Categories
                .FirstOrDefaultAsync(m => m.Id == id);
            if (category == null)
            {
                return NotFound();
            }

            return View(category);
        }

        // GET: Categories/Create
        public IActionResult Create(int? id)
        {
            if (id > 0)
            {
                var model = _context.Categories.Include(m => m.SpecsGroups).ThenInclude(m => m.Specs).FirstOrDefault(m => m.Id == id);
                if (model == null) { return NotFound(); }
                return View(model);
            }
            return View();
        }

        // POST: Categories/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(Category model)
        {
            if (ModelState.IsValid)
            {
                if (!FileUploadHelper.TryUpload(model.Logo, "categories", out string result))
                {
                    if (model.Id == 0)
                    {
                        ModelState.AddModelError("Logo", result);
                        return View(model);
                    }
                }
                else
                {
                    model.LogoUrl = result;
                }
                if (model.Id > 0)
                {
                    _context.Update(model);
                    if (string.IsNullOrEmpty(model.LogoUrl))
                    {
                        _context.Entry(model).Property(m => m.LogoUrl).IsModified = false;
                    }
                }
                else
                {
                    _context.Add(model);
                }

                model.SpecsGroups.Where(m => m.Token?.Length > 11).ToList().ForEach(m => m.Token = CoreHelper.GetUniqueToken());
                model.SpecsGroups.ToList().ForEach(g => {
                    g.Specs.ToList().ForEach(s => {
                        if(s.RecordUpdateType ==  RecordUpdateType.Delete)
                        {
                            _context.Entry(s).State = EntityState.Deleted;
                        }
                        s.Token = CoreHelper.GetUniqueToken();
                    });
                });
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            var errors = ModelState.Values.Where(m => m.Errors.Any()).ToList();
            return View(model);
        }

        // GET: Categories/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var category = await _context.Categories.FindAsync(id);
            if (category == null)
            {
                return NotFound();
            }
            return View(category);
        }

        // POST: Categories/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Name,Description,LogoUrl,Id,UserId,Token")] Category category)
        {
            if (id != category.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(category);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!CategoryExists(category.Id))
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
            return View(category);
        }

        // GET: Categories/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var category = await _context.Categories
                .FirstOrDefaultAsync(m => m.Id == id);
            if (category == null)
            {
                return NotFound();
            }

            return View(category);
        }

        // POST: Categories/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var category = await _context.Categories.FindAsync(id);
            if (category != null)
            {
                _context.Categories.Remove(category);
            }

            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool CategoryExists(int id)
        {
            return _context.Categories.Any(e => e.Id == id);
        }
    }
}
