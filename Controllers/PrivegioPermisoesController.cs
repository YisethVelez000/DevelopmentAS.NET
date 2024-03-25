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
    public class PrivegioPermisoesController : Controller
    {
        private readonly DevelopmentAsContext _context;

        public PrivegioPermisoesController(DevelopmentAsContext context)
        {
            _context = context;
        }

        // GET: PrivegioPermisoes
        public async Task<IActionResult> Index()
        {
            var developmentAsContext = _context.PrivegioPermisos.Include(p => p.IdPermisoNavigation).Include(p => p.IdPrivilegioNavigation);
            return View(await developmentAsContext.ToListAsync());
        }

        // GET: PrivegioPermisoes/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var privegioPermiso = await _context.PrivegioPermisos
                .Include(p => p.IdPermisoNavigation)
                .Include(p => p.IdPrivilegioNavigation)
                .FirstOrDefaultAsync(m => m.IdPriPer == id);
            if (privegioPermiso == null)
            {
                return NotFound();
            }

            return View(privegioPermiso);
        }

        // GET: PrivegioPermisoes/Create
        public IActionResult Create()
        {
            ViewData["IdPermiso"] = new SelectList(_context.Permisos, "IdPermiso", "IdPermiso");
            ViewData["IdPrivilegio"] = new SelectList(_context.Privilegios, "IdPrivilegio", "IdPrivilegio");
            return View();
        }

        // POST: PrivegioPermisoes/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("IdPriPer,IdPermiso,IdPrivilegio")] PrivegioPermiso privegioPermiso)
        {
            if (ModelState.IsValid)
            {
                _context.Add(privegioPermiso);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["IdPermiso"] = new SelectList(_context.Permisos, "IdPermiso", "IdPermiso", privegioPermiso.IdPermiso);
            ViewData["IdPrivilegio"] = new SelectList(_context.Privilegios, "IdPrivilegio", "IdPrivilegio", privegioPermiso.IdPrivilegio);
            return View(privegioPermiso);
        }

        // GET: PrivegioPermisoes/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var privegioPermiso = await _context.PrivegioPermisos.FindAsync(id);
            if (privegioPermiso == null)
            {
                return NotFound();
            }
            ViewData["IdPermiso"] = new SelectList(_context.Permisos, "IdPermiso", "IdPermiso", privegioPermiso.IdPermiso);
            ViewData["IdPrivilegio"] = new SelectList(_context.Privilegios, "IdPrivilegio", "IdPrivilegio", privegioPermiso.IdPrivilegio);
            return View(privegioPermiso);
        }

        // POST: PrivegioPermisoes/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("IdPriPer,IdPermiso,IdPrivilegio")] PrivegioPermiso privegioPermiso)
        {
            if (id != privegioPermiso.IdPriPer)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(privegioPermiso);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!PrivegioPermisoExists(privegioPermiso.IdPriPer))
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
            ViewData["IdPermiso"] = new SelectList(_context.Permisos, "IdPermiso", "IdPermiso", privegioPermiso.IdPermiso);
            ViewData["IdPrivilegio"] = new SelectList(_context.Privilegios, "IdPrivilegio", "IdPrivilegio", privegioPermiso.IdPrivilegio);
            return View(privegioPermiso);
        }

        // GET: PrivegioPermisoes/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var privegioPermiso = await _context.PrivegioPermisos
                .Include(p => p.IdPermisoNavigation)
                .Include(p => p.IdPrivilegioNavigation)
                .FirstOrDefaultAsync(m => m.IdPriPer == id);
            if (privegioPermiso == null)
            {
                return NotFound();
            }

            return View(privegioPermiso);
        }

        // POST: PrivegioPermisoes/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var privegioPermiso = await _context.PrivegioPermisos.FindAsync(id);
            if (privegioPermiso != null)
            {
                _context.PrivegioPermisos.Remove(privegioPermiso);
            }

            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool PrivegioPermisoExists(int id)
        {
            return _context.PrivegioPermisos.Any(e => e.IdPriPer == id);
        }
    }
}
