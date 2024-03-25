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
    public class OrdenProduccionsController : Controller
    {
        private readonly DevelopmentAsContext _context;

        public OrdenProduccionsController(DevelopmentAsContext context)
        {
            _context = context;
        }

        // GET: OrdenProduccions
        public async Task<IActionResult> Index()
        {
            return View(await _context.OrdenProduccions.ToListAsync());
        }

        // GET: OrdenProduccions/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var ordenProduccion = await _context.OrdenProduccions
                .FirstOrDefaultAsync(m => m.NroOrdenProduccion == id);
            if (ordenProduccion == null)
            {
                return NotFound();
            }

            return View(ordenProduccion);
        }

        // GET: OrdenProduccions/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: OrdenProduccions/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("NroOrdenProduccion,FechaEstimada,Estado")] OrdenProduccion ordenProduccion)
        {
            if (ModelState.IsValid)
            {
                _context.Add(ordenProduccion);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(ordenProduccion);
        }

        // GET: OrdenProduccions/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var ordenProduccion = await _context.OrdenProduccions.FindAsync(id);
            if (ordenProduccion == null)
            {
                return NotFound();
            }
            return View(ordenProduccion);
        }

        // POST: OrdenProduccions/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("NroOrdenProduccion,FechaEstimada,Estado")] OrdenProduccion ordenProduccion)
        {
            if (id != ordenProduccion.NroOrdenProduccion)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(ordenProduccion);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!OrdenProduccionExists(ordenProduccion.NroOrdenProduccion))
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
            return View(ordenProduccion);
        }

        // GET: OrdenProduccions/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var ordenProduccion = await _context.OrdenProduccions
                .FirstOrDefaultAsync(m => m.NroOrdenProduccion == id);
            if (ordenProduccion == null)
            {
                return NotFound();
            }

            return View(ordenProduccion);
        }

        // POST: OrdenProduccions/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var ordenProduccion = await _context.OrdenProduccions.FindAsync(id);
            if (ordenProduccion != null)
            {
                _context.OrdenProduccions.Remove(ordenProduccion);
            }

            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool OrdenProduccionExists(int id)
        {
            return _context.OrdenProduccions.Any(e => e.NroOrdenProduccion == id);
        }
    }
}
