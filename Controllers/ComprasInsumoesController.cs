using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using DevelopmentAS.Models;

namespace DevelopmentAS.Controllers
{
    public class ComprasInsumoesController : Controller
    {
        private readonly DevelopmentAsContext _context;

        public ComprasInsumoesController(DevelopmentAsContext context)
        {
            _context = context;
        }

        // GET: ComprasInsumoes
        public async Task<IActionResult> Index()
        {
            var developmentAsContext = _context.ComprasInsumos.Include(c => c.IdComprasNavigation).Include(c => c.IdInsumoNavigation);
            return View(await developmentAsContext.ToListAsync());
        }

        // GET: ComprasInsumoes/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var comprasInsumo = await _context.ComprasInsumos
                .Include(c => c.IdComprasNavigation)
                .Include(c => c.IdInsumoNavigation)
                .FirstOrDefaultAsync(m => m.IdCompInsu == id);
            if (comprasInsumo == null)
            {
                return NotFound();
            }

            return View(comprasInsumo);
        }

        // GET: ComprasInsumoes/Create
        public IActionResult Create()
        {
            ViewData["IdCompras"] = new SelectList(_context.Compras, "Idcompra", "Idcompra");
            ViewData["IdInsumo"] = new SelectList(_context.Insumos, "IdInsumo", "IdInsumo");
            return View();
        }

        // POST: ComprasInsumoes/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("IdCompInsu,IdCompras,IdInsumo,CantidadIns,PrecioUnita,Iva,Total")] ComprasInsumo comprasInsumo)
        {
            if (ModelState.IsValid)
            {
                _context.Add(comprasInsumo);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["IdCompras"] = new SelectList(_context.Compras, "Idcompra", "Idcompra", comprasInsumo.IdCompras);
            ViewData["IdInsumo"] = new SelectList(_context.Insumos, "IdInsumo", "IdInsumo", comprasInsumo.IdInsumo);
            return View(comprasInsumo);
        }

        // GET: ComprasInsumoes/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var comprasInsumo = await _context.ComprasInsumos.FindAsync(id);
            if (comprasInsumo == null)
            {
                return NotFound();
            }
            ViewData["IdCompras"] = new SelectList(_context.Compras, "Idcompra", "Idcompra", comprasInsumo.IdCompras);
            ViewData["IdInsumo"] = new SelectList(_context.Insumos, "IdInsumo", "IdInsumo", comprasInsumo.IdInsumo);
            return View(comprasInsumo);
        }

        // POST: ComprasInsumoes/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("IdCompInsu,IdCompras,IdInsumo,CantidadIns,PrecioUnita,Iva,Total")] ComprasInsumo comprasInsumo)
        {
            if (id != comprasInsumo.IdCompInsu)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(comprasInsumo);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!ComprasInsumoExists(comprasInsumo.IdCompInsu))
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
            ViewData["IdCompras"] = new SelectList(_context.Compras, "Idcompra", "Idcompra", comprasInsumo.IdCompras);
            ViewData["IdInsumo"] = new SelectList(_context.Insumos, "IdInsumo", "IdInsumo", comprasInsumo.IdInsumo);
            return View(comprasInsumo);
        }

        // GET: ComprasInsumoes/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var comprasInsumo = await _context.ComprasInsumos
                .Include(c => c.IdComprasNavigation)
                .Include(c => c.IdInsumoNavigation)
                .FirstOrDefaultAsync(m => m.IdCompInsu == id);
            if (comprasInsumo == null)
            {
                return NotFound();
            }

            return View(comprasInsumo);
        }

        // POST: ComprasInsumoes/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var comprasInsumo = await _context.ComprasInsumos.FindAsync(id);
            if (comprasInsumo != null)
            {
                _context.ComprasInsumos.Remove(comprasInsumo);
            }

            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool ComprasInsumoExists(int id)
        {
            return _context.ComprasInsumos.Any(e => e.IdCompInsu == id);
        }
    }
}
