using avirisofic.Models.DB;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;

namespace avirisofic.Controllers
{
    public class ReservaNaturalsController : Controller
    {
        private readonly TurismoAvesDb3Context _context;

        public ReservaNaturalsController(TurismoAvesDb3Context context)
        {
            _context = context;
        }

        // GET: ReservaNaturals
        public async Task<IActionResult> Index()
        {
            var turismoAvesDb3Context = _context.ReservaNaturals.Include(r => r.CreadoPorNavigation).Include(r => r.IdMunicipioNavigation);
            return View(await turismoAvesDb3Context.ToListAsync());
        }

        // GET: ReservaNaturals/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var reservaNatural = await _context.ReservaNaturals
                .Include(r => r.CreadoPorNavigation)
                .Include(r => r.IdMunicipioNavigation)
                .FirstOrDefaultAsync(m => m.IdReserva == id);
            if (reservaNatural == null)
            {
                return NotFound();
            }

            return View(reservaNatural);
        }

        // GET: ReservaNaturals/Create
        public IActionResult Create()
        {
            ViewData["CreadoPor"] = new SelectList(_context.Usuarios, "IdUsuario", "IdUsuario");
            ViewData["IdMunicipio"] = new SelectList(_context.Municipios, "IdMunicipio", "IdMunicipio");
            return View();
        }

        // POST: ReservaNaturals/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("IdReserva,Nombre,Descripcion,Ubicacion,CupoDiarioDefault,Activa,IdMunicipio,CreadoPor,FechaCreacion,ImagenRef")] ReservaNatural reservaNatural)
        {
            if (ModelState.IsValid)
            {
                _context.Add(reservaNatural);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["CreadoPor"] = new SelectList(_context.Usuarios, "IdUsuario", "IdUsuario", reservaNatural.CreadoPor);
            ViewData["IdMunicipio"] = new SelectList(_context.Municipios, "IdMunicipio", "IdMunicipio", reservaNatural.IdMunicipio);
            return View(reservaNatural);
        }

        // GET: ReservaNaturals/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var reservaNatural = await _context.ReservaNaturals.FindAsync(id);
            if (reservaNatural == null)
            {
                return NotFound();
            }
            ViewData["CreadoPor"] = new SelectList(_context.Usuarios, "IdUsuario", "IdUsuario", reservaNatural.CreadoPor);
            ViewData["IdMunicipio"] = new SelectList(_context.Municipios, "IdMunicipio", "IdMunicipio", reservaNatural.IdMunicipio);
            return View(reservaNatural);
        }

        // POST: ReservaNaturals/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("IdReserva,Nombre,Descripcion,Ubicacion,CupoDiarioDefault,Activa,IdMunicipio,CreadoPor,FechaCreacion,ImagenRef")] ReservaNatural reservaNatural)
        {
            if (id != reservaNatural.IdReserva)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(reservaNatural);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!ReservaNaturalExists(reservaNatural.IdReserva))
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
            ViewData["CreadoPor"] = new SelectList(_context.Usuarios, "IdUsuario", "IdUsuario", reservaNatural.CreadoPor);
            ViewData["IdMunicipio"] = new SelectList(_context.Municipios, "IdMunicipio", "IdMunicipio", reservaNatural.IdMunicipio);
            return View(reservaNatural);
        }

        // GET: ReservaNaturals/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var reservaNatural = await _context.ReservaNaturals
                .Include(r => r.CreadoPorNavigation)
                .Include(r => r.IdMunicipioNavigation)
                .FirstOrDefaultAsync(m => m.IdReserva == id);
            if (reservaNatural == null)
            {
                return NotFound();
            }

            return View(reservaNatural);
        }

        // POST: ReservaNaturals/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var reservaNatural = await _context.ReservaNaturals.FindAsync(id);
            if (reservaNatural != null)
            {
                _context.ReservaNaturals.Remove(reservaNatural);
            }

            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool ReservaNaturalExists(int id)
        {
            return _context.ReservaNaturals.Any(e => e.IdReserva == id);
        }
    }
}
