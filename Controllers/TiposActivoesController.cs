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
    public class TiposActivoesController : Controller
    {
        private readonly ActivosFijosContext _context;

        public TiposActivoesController(ActivosFijosContext context)
        {
            _context = context;
        }

        // GET: TiposActivoes
        public async Task<IActionResult> Index()
        {
            return View(await _context.TiposActivos.ToListAsync());
        }

        // GET: TiposActivoes/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var tiposActivo = await _context.TiposActivos
                .FirstOrDefaultAsync(m => m.IdtiposActivos == id);
            if (tiposActivo == null)
            {
                return NotFound();
            }

            return View(tiposActivo);
        }

        // GET: TiposActivoes/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: TiposActivoes/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("IdtiposActivos,Descripicion,CuentaContableCompra,CuentaContableDepreciacion,Estado")] TiposActivo tiposActivo)
        {
            if (ModelState.IsValid)
            {
                _context.Add(tiposActivo);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(tiposActivo);
        }

        // GET: TiposActivoes/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var tiposActivo = await _context.TiposActivos.FindAsync(id);
            if (tiposActivo == null)
            {
                return NotFound();
            }
            return View(tiposActivo);
        }

        // POST: TiposActivoes/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("IdtiposActivos,Descripicion,CuentaContableCompra,CuentaContableDepreciacion,Estado")] TiposActivo tiposActivo)
        {
            if (id != tiposActivo.IdtiposActivos)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(tiposActivo);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!TiposActivoExists(tiposActivo.IdtiposActivos))
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
            return View(tiposActivo);
        }

        // GET: TiposActivoes/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var tiposActivo = await _context.TiposActivos
                .FirstOrDefaultAsync(m => m.IdtiposActivos == id);
            if (tiposActivo == null)
            {
                return NotFound();
            }

            return View(tiposActivo);
        }

        // POST: TiposActivoes/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var tiposActivo = await _context.TiposActivos.FindAsync(id);
            if (tiposActivo != null)
            {
                _context.TiposActivos.Remove(tiposActivo);
            }

            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool TiposActivoExists(int id)
        {
            return _context.TiposActivos.Any(e => e.IdtiposActivos == id);
        }
    }
}
