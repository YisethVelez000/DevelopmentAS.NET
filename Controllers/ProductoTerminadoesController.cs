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
    public class ProductoTerminadoesController : Controller
    {
        private readonly DevelopmentAsContext _context;

        public ProductoTerminadoesController(DevelopmentAsContext context)
        {
            _context = context;
        }

        // GET: ProductoTerminadoes
        public async Task<IActionResult> Index()
        {
            var developmentAsContext = _context.ProductoTerminados.Include(p => p.IdFichaTecNavigation);
            return View(await developmentAsContext.ToListAsync());
        }

        // GET: ProductoTerminadoes/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var productoTerminado = await _context.ProductoTerminados
                .Include(p => p.IdFichaTecNavigation)
                .FirstOrDefaultAsync(m => m.IdProductoTerminado == id);
            if (productoTerminado == null)
            {
                return NotFound();
            }

            return View(productoTerminado);
        }

        // GET: ProductoTerminadoes/Create
        public IActionResult Create()
        {
            ViewData["IdFichaTec"] = new SelectList(_context.FichasTecnicas, "IdFicha", "IdFicha");
            return View();
        }

        // POST: ProductoTerminadoes/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("IdProductoTerminado,IdFichaTec,IdEstampado,TipoEstampado")] ProductoTerminado productoTerminado)
        {
            if (ModelState.IsValid)
            {
                _context.Add(productoTerminado);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["IdFichaTec"] = new SelectList(_context.FichasTecnicas, "IdFicha", "IdFicha", productoTerminado.IdFichaTec);
            return View(productoTerminado);
        }

        // GET: ProductoTerminadoes/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var productoTerminado = await _context.ProductoTerminados.FindAsync(id);
            if (productoTerminado == null)
            {
                return NotFound();
            }
            ViewData["IdFichaTec"] = new SelectList(_context.FichasTecnicas, "IdFicha", "IdFicha", productoTerminado.IdFichaTec);
            return View(productoTerminado);
        }

        // POST: ProductoTerminadoes/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("IdProductoTerminado,IdFichaTec,IdEstampado,TipoEstampado")] ProductoTerminado productoTerminado)
        {
            if (id != productoTerminado.IdProductoTerminado)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(productoTerminado);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!ProductoTerminadoExists(productoTerminado.IdProductoTerminado))
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
            ViewData["IdFichaTec"] = new SelectList(_context.FichasTecnicas, "IdFicha", "IdFicha", productoTerminado.IdFichaTec);
            return View(productoTerminado);
        }

        // GET: ProductoTerminadoes/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var productoTerminado = await _context.ProductoTerminados
                .Include(p => p.IdFichaTecNavigation)
                .FirstOrDefaultAsync(m => m.IdProductoTerminado == id);
            if (productoTerminado == null)
            {
                return NotFound();
            }

            return View(productoTerminado);
        }

        // POST: ProductoTerminadoes/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var productoTerminado = await _context.ProductoTerminados.FindAsync(id);
            if (productoTerminado != null)
            {
                _context.ProductoTerminados.Remove(productoTerminado);
            }

            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool ProductoTerminadoExists(int id)
        {
            return _context.ProductoTerminados.Any(e => e.IdProductoTerminado == id);
        }
    }
}
