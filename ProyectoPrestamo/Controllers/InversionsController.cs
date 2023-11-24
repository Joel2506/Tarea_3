using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using ProyectoPrestamo.Models;

namespace ProyectoPrestamo.Controllers
{
    public class InversionsController : Controller
    {
        private readonly SistemaPrestamoContext _context;

        public InversionsController(SistemaPrestamoContext context)
        {
            _context = context;
        }

        // GET: Inversions
        public async Task<IActionResult> Index()
        {
              return View(await _context.Inversions.ToListAsync());
        }

        // GET: Inversions/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null || _context.Inversions == null)
            {
                return NotFound();
            }

            var inversion = await _context.Inversions
                .FirstOrDefaultAsync(m => m.IdInversion == id);
            if (inversion == null)
            {
                return NotFound();
            }

            return View(inversion);
        }

        // GET: Inversions/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Inversions/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("IdInversion,IdCliente,Monto,Periodo,Interes")] Inversion inversion)
        {
            if (ModelState.IsValid)
            {
                _context.Add(inversion);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(inversion);
        }

        // GET: Inversions/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null || _context.Inversions == null)
            {
                return NotFound();
            }

            var inversion = await _context.Inversions.FindAsync(id);
            if (inversion == null)
            {
                return NotFound();
            }
            return View(inversion);
        }

        // POST: Inversions/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("IdInversion,IdCliente,Monto,Periodo,Interes")] Inversion inversion)
        {
            if (id != inversion.IdInversion)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(inversion);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!InversionExists(inversion.IdInversion))
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
            return View(inversion);
        }

        // GET: Inversions/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null || _context.Inversions == null)
            {
                return NotFound();
            }

            var inversion = await _context.Inversions
                .FirstOrDefaultAsync(m => m.IdInversion == id);
            if (inversion == null)
            {
                return NotFound();
            }

            return View(inversion);
        }

        // POST: Inversions/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            if (_context.Inversions == null)
            {
                return Problem("Entity set 'SistemaPrestamoContext.Inversions'  is null.");
            }
            var inversion = await _context.Inversions.FindAsync(id);
            if (inversion != null)
            {
                _context.Inversions.Remove(inversion);
            }
            
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool InversionExists(int id)
        {
          return _context.Inversions.Any(e => e.IdInversion == id);
        }
    }
}
