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
    public class AdolecentesController : Controller
    {
        private readonly ApplicationDbContext _context;



        public AdolecentesController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: Adolecentes
        public async Task<IActionResult> Index()
        {
            return View(await _context.Adolecentes.Include(adolecente => adolecente.Familia).ToListAsync());
        }

        // GET: Adolecentes/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var adolecentes = await _context.Adolecentes
                .FirstOrDefaultAsync(m => m.Id == id);
            if (adolecentes == null)
            {
                return NotFound();
            }

            return View(adolecentes);
        }

        // GET: Adolecentes/Create
        public IActionResult Create()
        {
            ViewData["familiaId"] = new SelectList(_context.Familias, "Id", "NombreFamilia");
            return View();
        }

        // POST: Adolecentes/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,Nombre,Apellido,Edad,Dni,Genero,fechaNacimiento,LugarNacimiento,Nacionalidad,Uder,Jusgado,Escuela,Nivel,Curso,TratamientoMedico,TratamientoPsicologico,Medicamento,ReevinculacionesFamiliares,familiaId")] Adolecentes adolecentes)
        {
            if (ModelState.IsValid)
            {
                _context.Add(adolecentes);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["familiaId"] = new SelectList(_context.Familias, "Id", "NombreFamilia", adolecentes.familiaId);
            return View(adolecentes);
        }

        // GET: Adolecentes/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var adolecentes = await _context.Adolecentes.FindAsync(id);
            if (adolecentes == null)
            {
                return NotFound();
            }

            ViewData["familiaId"] = new SelectList(_context.Familias, "Id", "NombreFamilia", adolecentes.familiaId);

            return View(adolecentes);
        }

        // POST: Adolecentes/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,Nombre,Apellido,Edad,Dni,Genero,fechaNacimiento,LugarNacimiento,Nacionalidad,Uder,Jusgado,Escuela,Nivel,Curso,TratamientoMedico,TratamientoPsicologico,Medicamento,ReevinculacionesFamiliares,familiaId")] Adolecentes adolecentes)
        {
            if (id != adolecentes.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(adolecentes);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!AdolecentesExists(adolecentes.Id))
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

            ViewData["familiaId"] = new SelectList(_context.Familias, "Id", "NombreFamilia", adolecentes.familiaId);

            return View(adolecentes);
        }

        // GET: Adolecentes/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var adolecentes = await _context.Adolecentes
                .FirstOrDefaultAsync(m => m.Id == id);
            if (adolecentes == null)
            {
                return NotFound();
            }

            return View(adolecentes);
        }

        // POST: Adolecentes/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var adolecentes = await _context.Adolecentes.FindAsync(id);
            _context.Adolecentes.Remove(adolecentes);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool AdolecentesExists(int id)
        {
            return _context.Adolecentes.Any(e => e.Id == id);
        }
    }
}
