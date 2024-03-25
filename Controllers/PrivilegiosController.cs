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
    public class PrivilegiosController : Controller
    {
        private readonly DevelopmentAsContext _context;

        public PrivilegiosController(DevelopmentAsContext context)
        {
            _context = context;
        }

        // GET: Privilegios
        public async Task<IActionResult> Index()
        {
            return View(await _context.Privilegios.ToListAsync());
        }

        // GET: Privilegios/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var privilegio = await _context.Privilegios
                .FirstOrDefaultAsync(m => m.IdPrivilegio == id);
            if (privilegio == null)
            {
                return NotFound();
            }

            return View(privilegio);
        }

        // GET: Privilegios/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Privilegios/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("IdPrivilegio,NombrePrivilegio")] Privilegio privilegio)
        {
            if (ModelState.IsValid)
            {
                _context.Add(privilegio);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(privilegio);
        }

        // GET: Privilegios/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var privilegio = await _context.Privilegios.FindAsync(id);
            if (privilegio == null)
            {
                return NotFound();
            }
            return View(privilegio);
        }

        // POST: Privilegios/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("IdPrivilegio,NombrePrivilegio")] Privilegio privilegio)
        {
            if (id != privilegio.IdPrivilegio)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(privilegio);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!PrivilegioExists(privilegio.IdPrivilegio))
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
            return View(privilegio);
        }

        // GET: Privilegios/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var privilegio = await _context.Privilegios
                .FirstOrDefaultAsync(m => m.IdPrivilegio == id);
            if (privilegio == null)
            {
                return NotFound();
            }

            return View(privilegio);
        }

        // POST: Privilegios/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var privilegio = await _context.Privilegios.FindAsync(id);
            if (privilegio != null)
            {
                _context.Privilegios.Remove(privilegio);
            }

            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool PrivilegioExists(int id)
        {
            return _context.Privilegios.Any(e => e.IdPrivilegio == id);
        }
    }
}
