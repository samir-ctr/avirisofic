using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using avirisofic.Models.DB;

namespace avirisofic.Controllers
{
    public class CatalogoavesController : Controller
    {
        private readonly TurismoAvesDb3Context _context;

        public CatalogoavesController(TurismoAvesDb3Context context)
        {
            _context = context;
        }

        // GET: Catalogoaves
        public async Task<IActionResult> Index()
        {
            return View(await _context.Catalogoaves.ToListAsync());
        }

        // GET: Catalogoaves/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var catalogoave = await _context.Catalogoaves
                .FirstOrDefaultAsync(m => m.Aveid == id);
            if (catalogoave == null)
            {
                return NotFound();
            }

            return View(catalogoave);
        }

        // GET: Catalogoaves/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Catalogoaves/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Aveid,Genero")] Catalogoave catalogoave)
        {
            if (ModelState.IsValid)
            {
                _context.Add(catalogoave);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(catalogoave);
        }

        // GET: Catalogoaves/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var catalogoave = await _context.Catalogoaves.FindAsync(id);
            if (catalogoave == null)
            {
                return NotFound();
            }
            return View(catalogoave);
        }

        // POST: Catalogoaves/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Aveid,Genero")] Catalogoave catalogoave)
        {
            if (id != catalogoave.Aveid)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(catalogoave);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!CatalogoaveExists(catalogoave.Aveid))
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
            return View(catalogoave);
        }

        // GET: Catalogoaves/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var catalogoave = await _context.Catalogoaves
                .FirstOrDefaultAsync(m => m.Aveid == id);
            if (catalogoave == null)
            {
                return NotFound();
            }

            return View(catalogoave);
        }

        // POST: Catalogoaves/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var catalogoave = await _context.Catalogoaves.FindAsync(id);
            if (catalogoave != null)
            {
                _context.Catalogoaves.Remove(catalogoave);
            }

            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool CatalogoaveExists(int id)
        {
            return _context.Catalogoaves.Any(e => e.Aveid == id);
        }
    }
}
