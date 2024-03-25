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
    public class DetalleOrdenProduccionsController : Controller
    {
        private readonly DevelopmentAsContext _context;

        public DetalleOrdenProduccionsController(DevelopmentAsContext context)
        {
            _context = context;
        }

        // GET: DetalleOrdenProduccions
        public async Task<IActionResult> Index()
        {
            var developmentAsContext = _context.DetalleOrdenProduccions.Include(d => d.NroOrdenProduccionNavigation);
            return View(await developmentAsContext.ToListAsync());
        }

        // GET: DetalleOrdenProduccions/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var detalleOrdenProduccion = await _context.DetalleOrdenProduccions
                .Include(d => d.NroOrdenProduccionNavigation)
                .FirstOrDefaultAsync(m => m.IdDetalleOrdenProduccion == id);
            if (detalleOrdenProduccion == null)
            {
                return NotFound();
            }

            return View(detalleOrdenProduccion);
        }

        // GET: DetalleOrdenProduccions/Create
        public IActionResult Create()
        {
            ViewData["NroOrdenProduccion"] = new SelectList(_context.OrdenProduccions, "NroOrdenProduccion", "NroOrdenProduccion");
            return View();
        }

        // POST: DetalleOrdenProduccions/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("IdDetalleOrdenProduccion,NroOrdenProduccion,Tallas,Productos,Cantidad")] DetalleOrdenProduccion detalleOrdenProduccion)
        {
            if (ModelState.IsValid)
            {
                _context.Add(detalleOrdenProduccion);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["NroOrdenProduccion"] = new SelectList(_context.OrdenProduccions, "NroOrdenProduccion", "NroOrdenProduccion", detalleOrdenProduccion.NroOrdenProduccion);
            return View(detalleOrdenProduccion);
        }

        // GET: DetalleOrdenProduccions/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var detalleOrdenProduccion = await _context.DetalleOrdenProduccions.FindAsync(id);
            if (detalleOrdenProduccion == null)
            {
                return NotFound();
            }
            ViewData["NroOrdenProduccion"] = new SelectList(_context.OrdenProduccions, "NroOrdenProduccion", "NroOrdenProduccion", detalleOrdenProduccion.NroOrdenProduccion);
            return View(detalleOrdenProduccion);
        }

        // POST: DetalleOrdenProduccions/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("IdDetalleOrdenProduccion,NroOrdenProduccion,Tallas,Productos,Cantidad")] DetalleOrdenProduccion detalleOrdenProduccion)
        {
            if (id != detalleOrdenProduccion.IdDetalleOrdenProduccion)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(detalleOrdenProduccion);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!DetalleOrdenProduccionExists(detalleOrdenProduccion.IdDetalleOrdenProduccion))
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
            ViewData["NroOrdenProduccion"] = new SelectList(_context.OrdenProduccions, "NroOrdenProduccion", "NroOrdenProduccion", detalleOrdenProduccion.NroOrdenProduccion);
            return View(detalleOrdenProduccion);
        }

        // GET: DetalleOrdenProduccions/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var detalleOrdenProduccion = await _context.DetalleOrdenProduccions
                .Include(d => d.NroOrdenProduccionNavigation)
                .FirstOrDefaultAsync(m => m.IdDetalleOrdenProduccion == id);
            if (detalleOrdenProduccion == null)
            {
                return NotFound();
            }

            return View(detalleOrdenProduccion);
        }

        // POST: DetalleOrdenProduccions/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var detalleOrdenProduccion = await _context.DetalleOrdenProduccions.FindAsync(id);
            if (detalleOrdenProduccion != null)
            {
                _context.DetalleOrdenProduccions.Remove(detalleOrdenProduccion);
            }

            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool DetalleOrdenProduccionExists(int id)
        {
            return _context.DetalleOrdenProduccions.Any(e => e.IdDetalleOrdenProduccion == id);
        }
    }
}
