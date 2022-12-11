using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using EntityFramework.Models;

namespace EntityFramework.Controllers
{
    public class PublicacionesController : Controller
    {
        private readonly EntityFrameworkContext _context;

        public PublicacionesController(EntityFrameworkContext context)
        {
            _context = context;
        }

        // GET: Publicaciones
        public async Task<IActionResult> Index()
        {
              return View(await _context.Publicaciones.ToListAsync());
        }

        // GET: Publicaciones/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null || _context.Publicaciones == null)
            {
                return NotFound();
            }

            var publicacione = await _context.Publicaciones
                .FirstOrDefaultAsync(m => m.PublicacionId == id);
            if (publicacione == null)
            {
                return NotFound();
            }

            return View(publicacione);
        }

        // GET: Publicaciones/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Publicaciones/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("PublicacionId,ProductoId,TpublicacionWebProductoId,TcodigoDePublicacionWeb,Nombre,TemplateDetalleCompletoId,StockMinimo,Activo,VigenciaDesde,VigenciaHasta,CodProducto,ServicioId")] Publicacione publicacione)
        {
            if (ModelState.IsValid)
            {
                _context.Add(publicacione);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(publicacione);
        }

        // GET: Publicaciones/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null || _context.Publicaciones == null)
            {
                return NotFound();
            }

            var publicacione = await _context.Publicaciones.FindAsync(id);
            if (publicacione == null)
            {
                return NotFound();
            }
            return View(publicacione);
        }

        // POST: Publicaciones/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("PublicacionId,ProductoId,TpublicacionWebProductoId,TcodigoDePublicacionWeb,Nombre,TemplateDetalleCompletoId,StockMinimo,Activo,VigenciaDesde,VigenciaHasta,CodProducto,ServicioId")] Publicacione publicacione)
        {
            if (id != publicacione.PublicacionId)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(publicacione);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!PublicacioneExists(publicacione.PublicacionId))
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
            return View(publicacione);
        }

        // GET: Publicaciones/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null || _context.Publicaciones == null)
            {
                return NotFound();
            }

            var publicacione = await _context.Publicaciones
                .FirstOrDefaultAsync(m => m.PublicacionId == id);
            if (publicacione == null)
            {
                return NotFound();
            }

            return View(publicacione);
        }

        // POST: Publicaciones/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            if (_context.Publicaciones == null)
            {
                return Problem("Entity set 'EntityFrameworkContext.Publicaciones'  is null.");
            }
            var publicacione = await _context.Publicaciones.FindAsync(id);
            if (publicacione != null)
            {
                _context.Publicaciones.Remove(publicacione);
            }
            
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool PublicacioneExists(int id)
        {
          return _context.Publicaciones.Any(e => e.PublicacionId == id);
        }
    }
}
