using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using RecordStore.Models;

namespace RecordStore.Controllers
{
    public class MediaController : Controller
    {
        private readonly RecordshopContext _context;

        public MediaController(RecordshopContext context)
        {
            _context = context;
        }

        // GET: Media
        public async Task<IActionResult> Index()
        {
            return View(await _context.Media.ToListAsync());
        }

        // GET: Media/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var medium = await _context.Media
                .FirstOrDefaultAsync(m => m.MediumId == id);
            if (medium == null)
            {
                return NotFound();
            }

            return View(medium);
        }

        // GET: Media/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Media/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("MediumId,Name")] Medium medium)
        {
            if (ModelState.IsValid)
            {
                _context.Add(medium);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(medium);
        }

        // GET: Media/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var medium = await _context.Media.FindAsync(id);
            if (medium == null)
            {
                return NotFound();
            }
            return View(medium);
        }

        // POST: Media/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("MediumId,Name")] Medium medium)
        {
            if (id != medium.MediumId)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(medium);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!MediumExists(medium.MediumId))
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
            return View(medium);
        }

        // GET: Media/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var medium = await _context.Media
                .FirstOrDefaultAsync(m => m.MediumId == id);
            if (medium == null)
            {
                return NotFound();
            }

            return View(medium);
        }

        // POST: Media/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var medium = await _context.Media.FindAsync(id);
            if (medium != null)
            {
                _context.Media.Remove(medium);
            }

            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool MediumExists(int id)
        {
            return _context.Media.Any(e => e.MediumId == id);
        }
    }
}
