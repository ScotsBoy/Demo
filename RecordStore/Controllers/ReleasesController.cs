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
    public class ReleasesController : Controller
    {
        private readonly RecordshopContext _context;

        public ReleasesController(RecordshopContext context)
        {
            _context = context;
        }

        // GET: Releases
        public async Task<IActionResult> Index()
        {
            var recordshopContext = _context.Releases.Include(r => r.Artist).Include(r => r.Medium).Include(r => r.ReleaseType);
            return View(await recordshopContext.ToListAsync());
        }

        // GET: Releases/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var release = await _context.Releases
                .Include(r => r.Artist)
                .Include(r => r.Medium)
                .Include(r => r.ReleaseType)
                .FirstOrDefaultAsync(m => m.ReleaseId == id);
            if (release == null)
            {
                return NotFound();
            }

            return View(release);
        }

        // GET: Releases/Create
        public IActionResult Create()
        {
            ViewData["ArtistId"] = new SelectList(_context.Artists, "ArtistId", "Name");
            ViewData["MediumId"] = new SelectList(_context.Media, "MediumId", "Name");
            ViewData["ReleaseTypeId"] = new SelectList(_context.ReleaseTypes, "ReleaseTypeId", "Name");
            return View();
        }

        // POST: Releases/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("ReleaseId,ArtistId,Name,ReleaseTypeId,MediumId,Runtime,ReleaseDate")] Release release)
        {

                _context.Add(release);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));

        }

        // GET: Releases/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var release = await _context.Releases.FindAsync(id);
            if (release == null)
            {
                return NotFound();
            }
            ViewData["ArtistId"] = new SelectList(_context.Artists, "ArtistId", "Name", release.ArtistId);
            ViewData["MediumId"] = new SelectList(_context.Media, "MediumId", "Name", release.MediumId);
            ViewData["ReleaseTypeId"] = new SelectList(_context.ReleaseTypes, "ReleaseTypeId", "Name", release.ReleaseTypeId);
            return View(release);
        }

        // POST: Releases/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("ReleaseId,ArtistId,Name,ReleaseTypeId,MediumId,Runtime,ReleaseDate")] Release release)
        {
            if (id != release.ReleaseId)
            {
                return NotFound();
            }

                try
                {
                    _context.Update(release);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!ReleaseExists(release.ReleaseId))
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

        // GET: Releases/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var release = await _context.Releases
                .Include(r => r.Artist)
                .Include(r => r.Medium)
                .Include(r => r.ReleaseType)
                .FirstOrDefaultAsync(m => m.ReleaseId == id);
            if (release == null)
            {
                return NotFound();
            }

            return View(release);
        }

        // POST: Releases/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var release = await _context.Releases.FindAsync(id);
            if (release != null)
            {
                _context.Releases.Remove(release);
            }

            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool ReleaseExists(int id)
        {
            return _context.Releases.Any(e => e.ReleaseId == id);
        }
    }
}
