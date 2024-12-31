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
    public class LovsController : Controller
    {
        private readonly AppDbContext _context;

        public LovsController(AppDbContext context)
        {
            _context = context;
        }

        // GET: Lovs
        public async Task<IActionResult> Index()
        {
            return View(await _context.Lovs.ToListAsync());
        }

        // GET: Lovs/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var lov = await _context.Lovs
                .FirstOrDefaultAsync(m => m.Id == id);
            if (lov == null)
            {
                return NotFound();
            }

            return View(lov);
        }

        // GET: Lovs/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Lovs/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Title,ShortCode,Id,UserId,Token")] Lov lov)
        {
            if (ModelState.IsValid)
            {
                _context.Add(lov);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(lov);
        }

        // GET: Lovs/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var lov = await _context.Lovs.FindAsync(id);
            if (lov == null)
            {
                return NotFound();
            }
            return View(lov);
        }

        // POST: Lovs/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Title,ShortCode,Id,UserId,Token")] Lov lov)
        {
            if (id != lov.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(lov);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!LovExists(lov.Id))
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
            return View(lov);
        }

        // GET: Lovs/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var lov = await _context.Lovs
                .FirstOrDefaultAsync(m => m.Id == id);
            if (lov == null)
            {
                return NotFound();
            }

            return View(lov);
        }

        // POST: Lovs/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var lov = await _context.Lovs.FindAsync(id);
            if (lov != null)
            {
                _context.Lovs.Remove(lov);
            }

            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool LovExists(int id)
        {
            return _context.Lovs.Any(e => e.Id == id);
        }
    }
}
