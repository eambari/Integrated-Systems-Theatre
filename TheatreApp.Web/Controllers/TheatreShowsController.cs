using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using TheatreApp.Web.Data;
using TheatreApp.Web.Models;

namespace TheatreApp.Web.Controllers
{
    public class TheatreShowsController : Controller
    {
        private readonly ApplicationDbContext _context;

        public TheatreShowsController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: TheatreShows
        public async Task<IActionResult> Index()
        {
            return View(await _context.Theatres.ToListAsync());
        }

        // GET: TheatreShows/Details/5
        public async Task<IActionResult> Details(Guid? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var theatre = await _context.Theatres
                .FirstOrDefaultAsync(m => m.Id == id);
            if (theatre == null)
            {
                return NotFound();
            }

            return View(theatre);
        }

        // GET: TheatreShows/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: TheatreShows/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,Title,Description,Place,ShowDate,ImageUrl")] Theatre theatre)
        {
            if (ModelState.IsValid)
            {
                theatre.Id = Guid.NewGuid();
                _context.Add(theatre);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(theatre);
        }

        // GET: TheatreShows/Edit/5
        public async Task<IActionResult> Edit(Guid? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var theatre = await _context.Theatres.FindAsync(id);
            if (theatre == null)
            {
                return NotFound();
            }
            return View(theatre);
        }

        // POST: TheatreShows/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(Guid id, [Bind("Id,Title,Description,Place,ShowDate,ImageUrl")] Theatre theatre)
        {
            if (id != theatre.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(theatre);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!TheatreExists(theatre.Id))
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
            return View(theatre);
        }

        // GET: TheatreShows/Delete/5
        public async Task<IActionResult> Delete(Guid? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var theatre = await _context.Theatres
                .FirstOrDefaultAsync(m => m.Id == id);
            if (theatre == null)
            {
                return NotFound();
            }

            return View(theatre);
        }

        // POST: TheatreShows/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(Guid id)
        {
            var theatre = await _context.Theatres.FindAsync(id);
            if (theatre != null)
            {
                _context.Theatres.Remove(theatre);
            }

            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool TheatreExists(Guid id)
        {
            return _context.Theatres.Any(e => e.Id == id);
        }
    }
}
