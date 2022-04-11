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
    public class FamiliasController : Controller
    {
        private readonly ApplicationDbContext _context;

        public FamiliasController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: Familias
        public async Task<IActionResult> Index()
        {
            return View(await _context.Familias.ToListAsync());
        }

        // GET: Familias/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var familias = await _context.Familias
                .FirstOrDefaultAsync(m => m.Id == id);
            if (familias == null)
            {
                return NotFound();
            }

            return View(familias);
        }

        // GET: Familias/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Familias/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,NombreFamilia,Telefono,Domicilio")] Familias familias)
        {
            if (ModelState.IsValid)
            {
                _context.Add(familias);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(familias);
        }

        // GET: Familias/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var familias = await _context.Familias.FindAsync(id);
            if (familias == null)
            {
                return NotFound();
            }
            return View(familias);
        }

        // POST: Familias/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,NombreFamilia,Telefono,Domicilio")] Familias familias)
        {
            if (id != familias.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(familias);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!FamiliasExists(familias.Id))
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
            return View(familias);
        }

        // GET: Familias/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var familias = await _context.Familias
                .FirstOrDefaultAsync(m => m.Id == id);
            if (familias == null)
            {
                return NotFound();
            }

            return View(familias);
        }

        // POST: Familias/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var familias = await _context.Familias.FindAsync(id);
            _context.Familias.Remove(familias);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool FamiliasExists(int id)
        {
            return _context.Familias.Any(e => e.Id == id);
        }
    }
}
