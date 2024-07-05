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
    public class ActivosFijoesController : Controller
    {
        private readonly ActivosFijosContext _context;

        public ActivosFijoesController(ActivosFijosContext context)
        {
            _context = context;
        }

        // GET: ActivosFijoes
        public async Task<IActionResult> Index()
        {
            var activosFijosContext = _context.ActivosFijos.Include(a => a.IddepartamentoNavigation);
            return View(await activosFijosContext.ToListAsync());
        }

        // GET: ActivosFijoes/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var activosFijo = await _context.ActivosFijos
                .Include(a => a.IddepartamentoNavigation)
                .FirstOrDefaultAsync(m => m.IdactivosFijos == id);
            if (activosFijo == null)
            {
                return NotFound();
            }

            return View(activosFijo);
        }

        // GET: ActivosFijoes/Create
        public IActionResult Create()
        {
            ViewData["Iddepartamento"] = new SelectList(_context.Departamentos, "Iddepartamentos", "Iddepartamentos");
            return View();
        }

        // POST: ActivosFijoes/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("IdactivosFijos,Iddepartamento,Descripcion,TipoActivo,FechaRegistro,ValorCompra,DepreciacionAcumulada,CuentaCompra,CuentaDepreciacion")] ActivosFijo activosFijo)
        {
            if (ModelState.IsValid)
            {
                _context.Add(activosFijo);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["Iddepartamento"] = new SelectList(_context.Departamentos, "Iddepartamentos", "Iddepartamentos", activosFijo.Iddepartamento);
            return View(activosFijo);
        }

        // GET: ActivosFijoes/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var activosFijo = await _context.ActivosFijos.FindAsync(id);
            if (activosFijo == null)
            {
                return NotFound();
            }
            ViewData["Iddepartamento"] = new SelectList(_context.Departamentos, "Iddepartamentos", "Iddepartamentos", activosFijo.Iddepartamento);
            return View(activosFijo);
        }

        // POST: ActivosFijoes/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("IdactivosFijos,Iddepartamento,Descripcion,TipoActivo,FechaRegistro,ValorCompra,DepreciacionAcumulada,CuentaCompra,CuentaDepreciacion")] ActivosFijo activosFijo)
        {
            if (id != activosFijo.IdactivosFijos)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(activosFijo);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!ActivosFijoExists(activosFijo.IdactivosFijos))
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
            ViewData["Iddepartamento"] = new SelectList(_context.Departamentos, "Iddepartamentos", "Iddepartamentos", activosFijo.Iddepartamento);
            return View(activosFijo);
        }

        // GET: ActivosFijoes/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var activosFijo = await _context.ActivosFijos
                .Include(a => a.IddepartamentoNavigation)
                .FirstOrDefaultAsync(m => m.IdactivosFijos == id);
            if (activosFijo == null)
            {
                return NotFound();
            }

            return View(activosFijo);
        }

        // POST: ActivosFijoes/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var activosFijo = await _context.ActivosFijos.FindAsync(id);
            if (activosFijo != null)
            {
                _context.ActivosFijos.Remove(activosFijo);
            }

            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool ActivosFijoExists(int id)
        {
            return _context.ActivosFijos.Any(e => e.IdactivosFijos == id);
        }
    }
}
