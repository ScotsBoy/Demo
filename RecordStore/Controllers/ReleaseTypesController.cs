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
    public class ReleaseTypesController : Controller
    {
        private readonly RecordshopContext _context;

        public ReleaseTypesController(RecordshopContext context)
        {
            _context = context;
        }

        // GET: ReleaseTypes
        public async Task<IActionResult> Index()
        {
            return View(await _context.ReleaseTypes.ToListAsync());
        }

        // GET: ReleaseTypes/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var releaseType = await _context.ReleaseTypes
                .FirstOrDefaultAsync(m => m.ReleaseTypeId == id);
            if (releaseType == null)
            {
                return NotFound();
            }

            return View(releaseType);
        }

        // GET: ReleaseTypes/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: ReleaseTypes/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("ReleaseTypeId,Name")] ReleaseType releaseType)
        {
            if (ModelState.IsValid)
            {
                _context.Add(releaseType);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(releaseType);
        }

        // GET: ReleaseTypes/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var releaseType = await _context.ReleaseTypes.FindAsync(id);
            if (releaseType == null)
            {
                return NotFound();
            }
            return View(releaseType);
        }

        // POST: ReleaseTypes/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("ReleaseTypeId,Name")] ReleaseType releaseType)
        {
            if (id != releaseType.ReleaseTypeId)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(releaseType);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!ReleaseTypeExists(releaseType.ReleaseTypeId))
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
            return View(releaseType);
        }

        // GET: ReleaseTypes/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var releaseType = await _context.ReleaseTypes
                .FirstOrDefaultAsync(m => m.ReleaseTypeId == id);
            if (releaseType == null)
            {
                return NotFound();
            }

            return View(releaseType);
        }

        // POST: ReleaseTypes/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var releaseType = await _context.ReleaseTypes.FindAsync(id);
            if (releaseType != null)
            {
                _context.ReleaseTypes.Remove(releaseType);
            }

            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool ReleaseTypeExists(int id)
        {
            return _context.ReleaseTypes.Any(e => e.ReleaseTypeId == id);
        }
    }
}
