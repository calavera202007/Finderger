using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using Findergers.Models;

namespace Findergers.Controllers
{
    public class DesaparecidosController : Controller
    {
        private readonly FindergersContext _context;

        public DesaparecidosController(FindergersContext context)
        {
            _context = context;
        }

        // GET: Desaparecidos
        public async Task<IActionResult> Index()
        {
              return _context.Desaparecidos != null ? 
                          View(await _context.Desaparecidos.ToListAsync()) :
                          Problem("Entity set 'FindergersContext.Desaparecidos'  is null.");
        }

        // GET: Desaparecidos/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null || _context.Desaparecidos == null)
            {
                return NotFound();
            }

            var desaparecido = await _context.Desaparecidos
                .FirstOrDefaultAsync(m => m.Id == id);
            if (desaparecido == null)
            {
                return NotFound();
            }

            return View(desaparecido);
        }

        // GET: Desaparecidos/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Desaparecidos/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,Nombre,Edad,Descripcion,FechaDesaparicion,Imagen")] Desaparecido desaparecido)
        {
            if (ModelState.IsValid)
            {
                _context.Add(desaparecido);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(desaparecido);
        }

        // GET: Desaparecidos/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null || _context.Desaparecidos == null)
            {
                return NotFound();
            }

            var desaparecido = await _context.Desaparecidos.FindAsync(id);
            if (desaparecido == null)
            {
                return NotFound();
            }
            return View(desaparecido);
        }

        // POST: Desaparecidos/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,Nombre,Edad,Descripcion,FechaDesaparicion,Imagen")] Desaparecido desaparecido)
        {
            if (id != desaparecido.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(desaparecido);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!DesaparecidoExists(desaparecido.Id))
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
            return View(desaparecido);
        }

        // GET: Desaparecidos/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null || _context.Desaparecidos == null)
            {
                return NotFound();
            }

            var desaparecido = await _context.Desaparecidos
                .FirstOrDefaultAsync(m => m.Id == id);
            if (desaparecido == null)
            {
                return NotFound();
            }

            return View(desaparecido);
        }

        // POST: Desaparecidos/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            if (_context.Desaparecidos == null)
            {
                return Problem("Entity set 'FindergersContext.Desaparecidos'  is null.");
            }
            var desaparecido = await _context.Desaparecidos.FindAsync(id);
            if (desaparecido != null)
            {
                _context.Desaparecidos.Remove(desaparecido);
            }
            
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool DesaparecidoExists(int id)
        {
          return (_context.Desaparecidos?.Any(e => e.Id == id)).GetValueOrDefault();
        }
    }
}
