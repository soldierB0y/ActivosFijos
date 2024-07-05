using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using ActivosFijos.Models;

namespace ActivosFijos.Controllers
{
    public class AsientosContablesController : Controller
    {
        private readonly ActivosFijosContext _context;

        public AsientosContablesController(ActivosFijosContext context)
        {
            _context = context;
        }

        // GET: AsientosContables
        public async Task<IActionResult> Index()
        {
            return View(await _context.AsientosContables.ToListAsync());
        }

        // GET: AsientosContables/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var asientosContable = await _context.AsientosContables
                .FirstOrDefaultAsync(m => m.Idasiento == id);
            if (asientosContable == null)
            {
                return NotFound();
            }

            return View(asientosContable);
        }

        // GET: AsientosContables/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: AsientosContables/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Idasiento,Descripcion,IdtipoInventario,CuentaContable,TipoMovimiento,FechaAsiento,MontoAsiento,Estado")] AsientosContable asientosContable)
        {
            if (ModelState.IsValid)
            {
                _context.Add(asientosContable);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(asientosContable);
        }

        // GET: AsientosContables/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var asientosContable = await _context.AsientosContables.FindAsync(id);
            if (asientosContable == null)
            {
                return NotFound();
            }
            return View(asientosContable);
        }

        // POST: AsientosContables/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Idasiento,Descripcion,IdtipoInventario,CuentaContable,TipoMovimiento,FechaAsiento,MontoAsiento,Estado")] AsientosContable asientosContable)
        {
            if (id != asientosContable.Idasiento)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(asientosContable);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!AsientosContableExists(asientosContable.Idasiento))
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
            return View(asientosContable);
        }

        // GET: AsientosContables/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var asientosContable = await _context.AsientosContables
                .FirstOrDefaultAsync(m => m.Idasiento == id);
            if (asientosContable == null)
            {
                return NotFound();
            }

            return View(asientosContable);
        }

        // POST: AsientosContables/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var asientosContable = await _context.AsientosContables.FindAsync(id);
            if (asientosContable != null)
            {
                _context.AsientosContables.Remove(asientosContable);
            }

            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool AsientosContableExists(int id)
        {
            return _context.AsientosContables.Any(e => e.Idasiento == id);
        }
    }
}
