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
    public class FichasTecnicasController : Controller
    {
        private readonly DevelopmentAsContext _context;

        public FichasTecnicasController(DevelopmentAsContext context)
        {
            _context = context;
        }

        // GET: FichasTecnicas
        public async Task<IActionResult> Index()
        {
            return View(await _context.FichasTecnicas.ToListAsync());
        }

        // GET: FichasTecnicas/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var fichasTecnica = await _context.FichasTecnicas
                .FirstOrDefaultAsync(m => m.IdFicha == id);
            if (fichasTecnica == null)
            {
                return NotFound();
            }

            return View(fichasTecnica);
        }

        // GET: FichasTecnicas/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: FichasTecnicas/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("IdFicha,NombreFichaTecnica,Cantidad,EstadoFicha,Talla")] FichasTecnica fichasTecnica)
        {
            if (ModelState.IsValid)
            {
                _context.Add(fichasTecnica);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(fichasTecnica);
        }

        // GET: FichasTecnicas/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var fichasTecnica = await _context.FichasTecnicas.FindAsync(id);
            if (fichasTecnica == null)
            {
                return NotFound();
            }
            return View(fichasTecnica);
        }

        // POST: FichasTecnicas/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("IdFicha,NombreFichaTecnica,Cantidad,EstadoFicha,Talla")] FichasTecnica fichasTecnica)
        {
            if (id != fichasTecnica.IdFicha)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(fichasTecnica);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!FichasTecnicaExists(fichasTecnica.IdFicha))
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
            return View(fichasTecnica);
        }

        // GET: FichasTecnicas/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var fichasTecnica = await _context.FichasTecnicas
                .FirstOrDefaultAsync(m => m.IdFicha == id);
            if (fichasTecnica == null)
            {
                return NotFound();
            }

            return View(fichasTecnica);
        }

        // POST: FichasTecnicas/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var fichasTecnica = await _context.FichasTecnicas.FindAsync(id);
            if (fichasTecnica != null)
            {
                _context.FichasTecnicas.Remove(fichasTecnica);
            }

            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool FichasTecnicaExists(int id)
        {
            return _context.FichasTecnicas.Any(e => e.IdFicha == id);
        }
    }
}
