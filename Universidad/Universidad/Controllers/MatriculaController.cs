using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using Universidad.Models;

namespace Universidad.Controllers
{
    public class MatriculaController : Controller
    {
        private readonly PARCIALDBContext _context;

        public MatriculaController(PARCIALDBContext context)
        {
            _context = context;
        }

        // GET: Matricula
        public async Task<IActionResult> Index()
        {
            var pARCIALDBContext = _context.Matricula.Include(m => m.IdalumnoNavigation).Include(m => m.IdmateriaNavigation).Include(m => m.IdprofesorNavigation);
            return View(await pARCIALDBContext.ToListAsync());
        }

        // GET: Matricula/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var matricula = await _context.Matricula
                .Include(m => m.IdalumnoNavigation)
                .Include(m => m.IdmateriaNavigation)
                .Include(m => m.IdprofesorNavigation)
                .SingleOrDefaultAsync(m => m.Idmatricula == id);
            if (matricula == null)
            {
                return NotFound();
            }

            return View(matricula);
        }

        // GET: Matricula/Create
        public IActionResult Create()
        {
            ViewData["Idalumno"] = new SelectList(_context.Alumno, "Idalumno", "Idalumno");
            ViewData["Idmateria"] = new SelectList(_context.Materia, "Idmateria", "Idmateria");
            ViewData["Idprofesor"] = new SelectList(_context.Profesor, "Idprofesor", "Idprofesor");
            return View();
        }

        // POST: Matricula/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Idmatricula,Idalumno,Idprofesor,Idmateria,Nota")] Matricula matricula)
        {
            if (ModelState.IsValid)
            {
                _context.Add(matricula);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["Idalumno"] = new SelectList(_context.Alumno, "Idalumno", "Idalumno", matricula.Idalumno);
            ViewData["Idmateria"] = new SelectList(_context.Materia, "Idmateria", "Idmateria", matricula.Idmateria);
            ViewData["Idprofesor"] = new SelectList(_context.Profesor, "Idprofesor", "Idprofesor", matricula.Idprofesor);
            return View(matricula);
        }

        // GET: Matricula/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var matricula = await _context.Matricula.SingleOrDefaultAsync(m => m.Idmatricula == id);
            if (matricula == null)
            {
                return NotFound();
            }
            ViewData["Idalumno"] = new SelectList(_context.Alumno, "Idalumno", "Idalumno", matricula.Idalumno);
            ViewData["Idmateria"] = new SelectList(_context.Materia, "Idmateria", "Idmateria", matricula.Idmateria);
            ViewData["Idprofesor"] = new SelectList(_context.Profesor, "Idprofesor", "Idprofesor", matricula.Idprofesor);
            return View(matricula);
        }

        // POST: Matricula/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Idmatricula,Idalumno,Idprofesor,Idmateria,Nota")] Matricula matricula)
        {
            if (id != matricula.Idmatricula)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(matricula);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!MatriculaExists(matricula.Idmatricula))
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
            ViewData["Idalumno"] = new SelectList(_context.Alumno, "Idalumno", "Idalumno", matricula.Idalumno);
            ViewData["Idmateria"] = new SelectList(_context.Materia, "Idmateria", "Idmateria", matricula.Idmateria);
            ViewData["Idprofesor"] = new SelectList(_context.Profesor, "Idprofesor", "Idprofesor", matricula.Idprofesor);
            return View(matricula);
        }

        // GET: Matricula/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var matricula = await _context.Matricula
                .Include(m => m.IdalumnoNavigation)
                .Include(m => m.IdmateriaNavigation)
                .Include(m => m.IdprofesorNavigation)
                .SingleOrDefaultAsync(m => m.Idmatricula == id);
            if (matricula == null)
            {
                return NotFound();
            }

            return View(matricula);
        }

        // POST: Matricula/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var matricula = await _context.Matricula.SingleOrDefaultAsync(m => m.Idmatricula == id);
            _context.Matricula.Remove(matricula);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool MatriculaExists(int id)
        {
            return _context.Matricula.Any(e => e.Idmatricula == id);
        }
    }
}
