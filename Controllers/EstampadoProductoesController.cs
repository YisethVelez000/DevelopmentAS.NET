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
    public class EstampadoProductoesController : Controller
    {
        private readonly DevelopmentAsContext _context;

        public EstampadoProductoesController(DevelopmentAsContext context)
        {
            _context = context;
        }

        // GET: EstampadoProductoes
        public async Task<IActionResult> Index()
        {
            var developmentAsContext = _context.EstampadoProductos.Include(e => e.IdCatalogoPNavigation);
            return View(await developmentAsContext.ToListAsync());
        }

        // GET: EstampadoProductoes/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var estampadoProducto = await _context.EstampadoProductos
                .Include(e => e.IdCatalogoPNavigation)
                .FirstOrDefaultAsync(m => m.IdEstampadoProducto == id);
            if (estampadoProducto == null)
            {
                return NotFound();
            }

            return View(estampadoProducto);
        }

        // GET: EstampadoProductoes/Create
        public IActionResult Create()
        {
            ViewData["IdCatalogoP"] = new SelectList(_context.CatalogoProductos, "IdcatalogoProducto", "IdcatalogoProducto");
            return View();
        }

        // POST: EstampadoProductoes/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("IdEstampadoProducto,IdCatalogoP,IdEstampado,Ubicacion,Subtotal")] EstampadoProducto estampadoProducto)
        {
            if (ModelState.IsValid)
            {
                _context.Add(estampadoProducto);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["IdCatalogoP"] = new SelectList(_context.CatalogoProductos, "IdcatalogoProducto", "IdcatalogoProducto", estampadoProducto.IdCatalogoP);
            return View(estampadoProducto);
        }

        // GET: EstampadoProductoes/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var estampadoProducto = await _context.EstampadoProductos.FindAsync(id);
            if (estampadoProducto == null)
            {
                return NotFound();
            }
            ViewData["IdCatalogoP"] = new SelectList(_context.CatalogoProductos, "IdcatalogoProducto", "IdcatalogoProducto", estampadoProducto.IdCatalogoP);
            return View(estampadoProducto);
        }

        // POST: EstampadoProductoes/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("IdEstampadoProducto,IdCatalogoP,IdEstampado,Ubicacion,Subtotal")] EstampadoProducto estampadoProducto)
        {
            if (id != estampadoProducto.IdEstampadoProducto)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(estampadoProducto);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!EstampadoProductoExists(estampadoProducto.IdEstampadoProducto))
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
            ViewData["IdCatalogoP"] = new SelectList(_context.CatalogoProductos, "IdcatalogoProducto", "IdcatalogoProducto", estampadoProducto.IdCatalogoP);
            return View(estampadoProducto);
        }

        // GET: EstampadoProductoes/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var estampadoProducto = await _context.EstampadoProductos
                .Include(e => e.IdCatalogoPNavigation)
                .FirstOrDefaultAsync(m => m.IdEstampadoProducto == id);
            if (estampadoProducto == null)
            {
                return NotFound();
            }

            return View(estampadoProducto);
        }

        // POST: EstampadoProductoes/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var estampadoProducto = await _context.EstampadoProductos.FindAsync(id);
            if (estampadoProducto != null)
            {
                _context.EstampadoProductos.Remove(estampadoProducto);
            }

            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool EstampadoProductoExists(int id)
        {
            return _context.EstampadoProductos.Any(e => e.IdEstampadoProducto == id);
        }
    }
}
