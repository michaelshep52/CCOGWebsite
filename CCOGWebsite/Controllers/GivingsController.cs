using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using CCOGWebsite.Data;
using CCOGWebsite.Models;

namespace CCOGWebsite.Controllers
{
    public class GivingsController : Controller
    {
        private readonly ApplicationDbContext _context;

        public GivingsController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: Givings
        public async Task<IActionResult> Index()
        {
              return _context.Givings != null ? 
                          View(await _context.Givings.ToListAsync()) :
                          Problem("Entity set 'ApplicationDbContext.Givings'  is null.");
        }

        // GET: Givings/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null || _context.Givings == null)
            {
                return NotFound();
            }

            var giving = await _context.Givings
                .FirstOrDefaultAsync(m => m.Id == id);
            if (giving == null)
            {
                return NotFound();
            }

            return View(giving);
        }

        // GET: Givings/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Givings/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,Amount,GivingTowards")] Giving giving)
        {
            if (ModelState.IsValid)
            {
                _context.Add(giving);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(giving);
        }

        // GET: Givings/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null || _context.Givings == null)
            {
                return NotFound();
            }

            var giving = await _context.Givings.FindAsync(id);
            if (giving == null)
            {
                return NotFound();
            }
            return View(giving);
        }

        // POST: Givings/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,Amount,GivingTowards")] Giving giving)
        {
            if (id != giving.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(giving);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!GivingExists(giving.Id))
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
            return View(giving);
        }

        // GET: Givings/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null || _context.Givings == null)
            {
                return NotFound();
            }

            var giving = await _context.Givings
                .FirstOrDefaultAsync(m => m.Id == id);
            if (giving == null)
            {
                return NotFound();
            }

            return View(giving);
        }

        // POST: Givings/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            if (_context.Givings == null)
            {
                return Problem("Entity set 'ApplicationDbContext.Givings'  is null.");
            }
            var giving = await _context.Givings.FindAsync(id);
            if (giving != null)
            {
                _context.Givings.Remove(giving);
            }
            
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool GivingExists(int id)
        {
          return (_context.Givings?.Any(e => e.Id == id)).GetValueOrDefault();
        }
    }
}
