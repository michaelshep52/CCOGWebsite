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
    public class MinistriesController : Controller
    {
        private readonly ApplicationDbContext _context;

        public MinistriesController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: Ministries
        public async Task<IActionResult> Index()
        {
              return _context.Ministries != null ? 
                          View(await _context.Ministries.ToListAsync()) :
                          Problem("Entity set 'ApplicationDbContext.Ministries'  is null.");
        }

        // GET: Ministries/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null || _context.Ministries == null)
            {
                return NotFound();
            }

            var ministry = await _context.Ministries
                .FirstOrDefaultAsync(m => m.Id == id);
            if (ministry == null)
            {
                return NotFound();
            }

            return View(ministry);
        }

        // GET: Ministries/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Ministries/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,Name,Details")] Ministry ministry)
        {
            if (ModelState.IsValid)
            {
                _context.Add(ministry);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(ministry);
        }

        // GET: Ministries/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null || _context.Ministries == null)
            {
                return NotFound();
            }

            var ministry = await _context.Ministries.FindAsync(id);
            if (ministry == null)
            {
                return NotFound();
            }
            return View(ministry);
        }

        // POST: Ministries/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,Name,Details")] Ministry ministry)
        {
            if (id != ministry.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(ministry);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!MinistryExists(ministry.Id))
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
            return View(ministry);
        }

        // GET: Ministries/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null || _context.Ministries == null)
            {
                return NotFound();
            }

            var ministry = await _context.Ministries
                .FirstOrDefaultAsync(m => m.Id == id);
            if (ministry == null)
            {
                return NotFound();
            }

            return View(ministry);
        }

        // POST: Ministries/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            if (_context.Ministries == null)
            {
                return Problem("Entity set 'ApplicationDbContext.Ministries'  is null.");
            }
            var ministry = await _context.Ministries.FindAsync(id);
            if (ministry != null)
            {
                _context.Ministries.Remove(ministry);
            }
            
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool MinistryExists(int id)
        {
          return (_context.Ministries?.Any(e => e.Id == id)).GetValueOrDefault();
        }
    }
}
