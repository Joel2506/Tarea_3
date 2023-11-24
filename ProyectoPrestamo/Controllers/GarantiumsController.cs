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
    public class GarantiumsController : Controller
    {
        private readonly SistemaPrestamoContext _context;

        public GarantiumsController(SistemaPrestamoContext context)
        {
            _context = context;
        }

        // GET: Garantiums
        public async Task<IActionResult> Index()
        {
            var sistemaPrestamoContext = _context.Garantia.Include(g => g.IdPrestamoNavigation);
            return View(await sistemaPrestamoContext.ToListAsync());
        }

        // GET: Garantiums/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null || _context.Garantia == null)
            {
                return NotFound();
            }

            var garantium = await _context.Garantia
                .Include(g => g.IdPrestamoNavigation)
                .FirstOrDefaultAsync(m => m.IdGarantia == id);
            if (garantium == null)
            {
                return NotFound();
            }

            return View(garantium);
        }

        // GET: Garantiums/Create
        public IActionResult Create()
        {
            ViewData["IdPrestamo"] = new SelectList(_context.Prestamos, "IdPrestamo", "IdPrestamo");
            return View();
        }

        // POST: Garantiums/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("IdGarantia,Tipo,Valor,Ubicacion,IdPrestamo")] Garantium garantium)
        {
            if (ModelState.IsValid)
            {
                _context.Add(garantium);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["IdPrestamo"] = new SelectList(_context.Prestamos, "IdPrestamo", "IdPrestamo", garantium.IdPrestamo);
            return View(garantium);
        }

        // GET: Garantiums/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null || _context.Garantia == null)
            {
                return NotFound();
            }

            var garantium = await _context.Garantia.FindAsync(id);
            if (garantium == null)
            {
                return NotFound();
            }
            ViewData["IdPrestamo"] = new SelectList(_context.Prestamos, "IdPrestamo", "IdPrestamo", garantium.IdPrestamo);
            return View(garantium);
        }

        // POST: Garantiums/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("IdGarantia,Tipo,Valor,Ubicacion,IdPrestamo")] Garantium garantium)
        {
            if (id != garantium.IdGarantia)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(garantium);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!GarantiumExists(garantium.IdGarantia))
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
            ViewData["IdPrestamo"] = new SelectList(_context.Prestamos, "IdPrestamo", "IdPrestamo", garantium.IdPrestamo);
            return View(garantium);
        }

        // GET: Garantiums/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null || _context.Garantia == null)
            {
                return NotFound();
            }

            var garantium = await _context.Garantia
                .Include(g => g.IdPrestamoNavigation)
                .FirstOrDefaultAsync(m => m.IdGarantia == id);
            if (garantium == null)
            {
                return NotFound();
            }

            return View(garantium);
        }

        // POST: Garantiums/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            if (_context.Garantia == null)
            {
                return Problem("Entity set 'SistemaPrestamoContext.Garantia'  is null.");
            }
            var garantium = await _context.Garantia.FindAsync(id);
            if (garantium != null)
            {
                _context.Garantia.Remove(garantium);
            }
            
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool GarantiumExists(int id)
        {
          return _context.Garantia.Any(e => e.IdGarantia == id);
        }
    }
}
