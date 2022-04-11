using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using ProyectoFinalResidencia.Data;
using ProyectoFinalResidencia.Models;

namespace ProyectoFinalResidencia.Controllers
{
    [Authorize]
    public class RamasEspecialidadsController : Controller
    {
        private readonly ApplicationDbContext _context;

        public RamasEspecialidadsController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: RamasEspecialidads
        public async Task<IActionResult> Index()
        {
            return View(await _context.RamaEspecialidad.ToListAsync());
        }

        // GET: RamasEspecialidads/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var ramasEspecialidad = await _context.RamaEspecialidad
                .FirstOrDefaultAsync(m => m.Id == id);
            if (ramasEspecialidad == null)
            {
                return NotFound();
            }

            return View(ramasEspecialidad);
        }

        // GET: RamasEspecialidads/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: RamasEspecialidads/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,Rama")] RamasEspecialidad ramasEspecialidad)
        {
            if (ModelState.IsValid)
            {
                _context.Add(ramasEspecialidad);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(ramasEspecialidad);
        }

        // GET: RamasEspecialidads/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var ramasEspecialidad = await _context.RamaEspecialidad.FindAsync(id);
            if (ramasEspecialidad == null)
            {
                return NotFound();
            }
            return View(ramasEspecialidad);
        }

        // POST: RamasEspecialidads/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,Rama")] RamasEspecialidad ramasEspecialidad)
        {
            if (id != ramasEspecialidad.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(ramasEspecialidad);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!RamasEspecialidadExists(ramasEspecialidad.Id))
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
            return View(ramasEspecialidad);
        }

        // GET: RamasEspecialidads/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var ramasEspecialidad = await _context.RamaEspecialidad
                .FirstOrDefaultAsync(m => m.Id == id);
            if (ramasEspecialidad == null)
            {
                return NotFound();
            }

            return View(ramasEspecialidad);
        }

        // POST: RamasEspecialidads/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var ramasEspecialidad = await _context.RamaEspecialidad.FindAsync(id);
            _context.RamaEspecialidad.Remove(ramasEspecialidad);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool RamasEspecialidadExists(int id)
        {
            return _context.RamaEspecialidad.Any(e => e.Id == id);
        }
    }
}
