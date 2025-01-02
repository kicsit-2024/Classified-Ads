using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using ClassifiedAds.Data;
using ClassifiedAds.Models;

namespace ClassifiedAds.Controllers
{
    public class LovOptionsController : Controller
    {
        private readonly AppDbContext _context;

        public LovOptionsController(AppDbContext context)
        {
            _context = context;
        }

        // GET: LovOptions
        public async Task<IActionResult> Index()
        {
            var appDbContext = _context.LovOption.Include(l => l.Lov);
            return View(await appDbContext.ToListAsync());
        }

        // GET: LovOptions/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var lovOption = await _context.LovOption
                .Include(l => l.Lov)
                .FirstOrDefaultAsync(m => m.Id == id);
            if (lovOption == null)
            {
                return NotFound();
            }

            return View(lovOption);
        }

        // GET: LovOptions/Create
        public IActionResult Create()
        {
            ViewData["LovId"] = new SelectList(_context.Lovs, "Id", "Title");
            return View();
        }

        // POST: LovOptions/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Value,Text,LovId,Id,UserId,Token")] LovOption lovOption)
        {
            if (ModelState.IsValid)
            {
                _context.Add(lovOption);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["LovId"] = new SelectList(_context.Lovs, "Id", "Title", lovOption.LovId);
            return View(lovOption);
        }

        // GET: LovOptions/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var lovOption = await _context.LovOption.FindAsync(id);
            if (lovOption == null)
            {
                return NotFound();
            }
            ViewData["LovId"] = new SelectList(_context.Lovs, "Id", "Title", lovOption.LovId);
            return View(lovOption);
        }

        // POST: LovOptions/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Value,Text,LovId,Id,UserId,Token")] LovOption lovOption)
        {
            if (id != lovOption.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(lovOption);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!LovOptionExists(lovOption.Id))
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
            ViewData["LovId"] = new SelectList(_context.Lovs, "Id", "Title", lovOption.LovId);
            return View(lovOption);
        }

        // GET: LovOptions/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var lovOption = await _context.LovOption
                .Include(l => l.Lov)
                .FirstOrDefaultAsync(m => m.Id == id);
            if (lovOption == null)
            {
                return NotFound();
            }

            return View(lovOption);
        }

        // POST: LovOptions/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var lovOption = await _context.LovOption.FindAsync(id);
            if (lovOption != null)
            {
                _context.LovOption.Remove(lovOption);
            }

            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool LovOptionExists(int id)
        {
            return _context.LovOption.Any(e => e.Id == id);
        }
    }
}
