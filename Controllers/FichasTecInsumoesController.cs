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
    public class FichasTecInsumoesController : Controller
    {
        private readonly DevelopmentAsContext _context;

        public FichasTecInsumoesController(DevelopmentAsContext context)
        {
            _context = context;
        }

        // GET: FichasTecInsumoes
        public async Task<IActionResult> Index()
        {
            var developmentAsContext = _context.FichasTecInsumos.Include(f => f.IdFichaNavigation).Include(f => f.IdInsumoNavigation);
            return View(await developmentAsContext.ToListAsync());
        }

        // GET: FichasTecInsumoes/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var fichasTecInsumo = await _context.FichasTecInsumos
                .Include(f => f.IdFichaNavigation)
                .Include(f => f.IdInsumoNavigation)
                .FirstOrDefaultAsync(m => m.IdFichaTecIns == id);
            if (fichasTecInsumo == null)
            {
                return NotFound();
            }

            return View(fichasTecInsumo);
        }

        // GET: FichasTecInsumoes/Create
        public IActionResult Create()
        {
            ViewData["IdFicha"] = new SelectList(_context.FichasTecnicas, "IdFicha", "IdFicha");
            ViewData["IdInsumo"] = new SelectList(_context.Insumos, "IdInsumo", "IdInsumo");
            return View();
        }

        // POST: FichasTecInsumoes/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("IdFichaTecIns,IdFicha,IdInsumo,Cantidad")] FichasTecInsumo fichasTecInsumo)
        {
            if (ModelState.IsValid)
            {
                _context.Add(fichasTecInsumo);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["IdFicha"] = new SelectList(_context.FichasTecnicas, "IdFicha", "IdFicha", fichasTecInsumo.IdFicha);
            ViewData["IdInsumo"] = new SelectList(_context.Insumos, "IdInsumo", "IdInsumo", fichasTecInsumo.IdInsumo);
            return View(fichasTecInsumo);
        }

        // GET: FichasTecInsumoes/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var fichasTecInsumo = await _context.FichasTecInsumos.FindAsync(id);
            if (fichasTecInsumo == null)
            {
                return NotFound();
            }
            ViewData["IdFicha"] = new SelectList(_context.FichasTecnicas, "IdFicha", "IdFicha", fichasTecInsumo.IdFicha);
            ViewData["IdInsumo"] = new SelectList(_context.Insumos, "IdInsumo", "IdInsumo", fichasTecInsumo.IdInsumo);
            return View(fichasTecInsumo);
        }

        // POST: FichasTecInsumoes/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("IdFichaTecIns,IdFicha,IdInsumo,Cantidad")] FichasTecInsumo fichasTecInsumo)
        {
            if (id != fichasTecInsumo.IdFichaTecIns)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(fichasTecInsumo);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!FichasTecInsumoExists(fichasTecInsumo.IdFichaTecIns))
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
            ViewData["IdFicha"] = new SelectList(_context.FichasTecnicas, "IdFicha", "IdFicha", fichasTecInsumo.IdFicha);
            ViewData["IdInsumo"] = new SelectList(_context.Insumos, "IdInsumo", "IdInsumo", fichasTecInsumo.IdInsumo);
            return View(fichasTecInsumo);
        }

        // GET: FichasTecInsumoes/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var fichasTecInsumo = await _context.FichasTecInsumos
                .Include(f => f.IdFichaNavigation)
                .Include(f => f.IdInsumoNavigation)
                .FirstOrDefaultAsync(m => m.IdFichaTecIns == id);
            if (fichasTecInsumo == null)
            {
                return NotFound();
            }

            return View(fichasTecInsumo);
        }

        // POST: FichasTecInsumoes/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var fichasTecInsumo = await _context.FichasTecInsumos.FindAsync(id);
            if (fichasTecInsumo != null)
            {
                _context.FichasTecInsumos.Remove(fichasTecInsumo);
            }

            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool FichasTecInsumoExists(int id)
        {
            return _context.FichasTecInsumos.Any(e => e.IdFichaTecIns == id);
        }
    }
}
