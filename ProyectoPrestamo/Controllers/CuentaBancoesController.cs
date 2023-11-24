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
    public class CuentaBancoesController : Controller
    {
        private readonly SistemaPrestamoContext _context;

        public CuentaBancoesController(SistemaPrestamoContext context)
        {
            _context = context;
        }

        // GET: CuentaBancoes
        public async Task<IActionResult> Index()
        {
            var sistemaPrestamoContext = _context.CuentaBancos.Include(c => c.IdClienteNavigation).Include(c => c.IdInversionNavigation);
            return View(await sistemaPrestamoContext.ToListAsync());
        }

        // GET: CuentaBancoes/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null || _context.CuentaBancos == null)
            {
                return NotFound();
            }

            var cuentaBanco = await _context.CuentaBancos
                .Include(c => c.IdClienteNavigation)
                .Include(c => c.IdInversionNavigation)
                .FirstOrDefaultAsync(m => m.IdBanco == id);
            if (cuentaBanco == null)
            {
                return NotFound();
            }

            return View(cuentaBanco);
        }

        // GET: CuentaBancoes/Create
        public IActionResult Create()
        {
            ViewData["IdCliente"] = new SelectList(_context.Clientes, "IdCliente", "IdCliente");
            ViewData["IdInversion"] = new SelectList(_context.Inversions, "IdInversion", "IdInversion");
            return View();
        }

        // POST: CuentaBancoes/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("IdBanco,Nombre,Numero,Tipo,IdCliente,IdInversion")] CuentaBanco cuentaBanco)
        {
            if (ModelState.IsValid)
            {
                _context.Add(cuentaBanco);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["IdCliente"] = new SelectList(_context.Clientes, "IdCliente", "IdCliente", cuentaBanco.IdCliente);
            ViewData["IdInversion"] = new SelectList(_context.Inversions, "IdInversion", "IdInversion", cuentaBanco.IdInversion);
            return View(cuentaBanco);
        }

        // GET: CuentaBancoes/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null || _context.CuentaBancos == null)
            {
                return NotFound();
            }

            var cuentaBanco = await _context.CuentaBancos.FindAsync(id);
            if (cuentaBanco == null)
            {
                return NotFound();
            }
            ViewData["IdCliente"] = new SelectList(_context.Clientes, "IdCliente", "IdCliente", cuentaBanco.IdCliente);
            ViewData["IdInversion"] = new SelectList(_context.Inversions, "IdInversion", "IdInversion", cuentaBanco.IdInversion);
            return View(cuentaBanco);
        }

        // POST: CuentaBancoes/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("IdBanco,Nombre,Numero,Tipo,IdCliente,IdInversion")] CuentaBanco cuentaBanco)
        {
            if (id != cuentaBanco.IdBanco)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(cuentaBanco);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!CuentaBancoExists(cuentaBanco.IdBanco))
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
            ViewData["IdCliente"] = new SelectList(_context.Clientes, "IdCliente", "IdCliente", cuentaBanco.IdCliente);
            ViewData["IdInversion"] = new SelectList(_context.Inversions, "IdInversion", "IdInversion", cuentaBanco.IdInversion);
            return View(cuentaBanco);
        }

        // GET: CuentaBancoes/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null || _context.CuentaBancos == null)
            {
                return NotFound();
            }

            var cuentaBanco = await _context.CuentaBancos
                .Include(c => c.IdClienteNavigation)
                .Include(c => c.IdInversionNavigation)
                .FirstOrDefaultAsync(m => m.IdBanco == id);
            if (cuentaBanco == null)
            {
                return NotFound();
            }

            return View(cuentaBanco);
        }

        // POST: CuentaBancoes/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            if (_context.CuentaBancos == null)
            {
                return Problem("Entity set 'SistemaPrestamoContext.CuentaBancos'  is null.");
            }
            var cuentaBanco = await _context.CuentaBancos.FindAsync(id);
            if (cuentaBanco != null)
            {
                _context.CuentaBancos.Remove(cuentaBanco);
            }
            
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool CuentaBancoExists(int id)
        {
          return _context.CuentaBancos.Any(e => e.IdBanco == id);
        }
    }
}
