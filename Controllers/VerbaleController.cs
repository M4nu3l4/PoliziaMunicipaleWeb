using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using Cops.Data;
using Cops.Models;

namespace Cops.Controllers
{
    public class VerbaleController : Controller
    {
        private readonly CopsContext _context;

        public VerbaleController(CopsContext context)
        {
            _context = context;
        }

        // GET: Verbale
        public async Task<IActionResult> Index()
        {
            var verbali = await _context.Verbale
                                        .Include(v => v.Anagrafica)
                                        .Include(v => v.TipoViolazione)
                                        .ToListAsync();
            return View(verbali);
        }

        // GET: Verbale/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null) return NotFound();

            var verbale = await _context.Verbale
                .Include(v => v.Anagrafica)
                .Include(v => v.TipoViolazione)
                .FirstOrDefaultAsync(v => v.IdVerbale == id);

            if (verbale == null) return NotFound();
            return View(verbale);
        }

        // GET: Verbale/Create
        public IActionResult Create()
        {
            ViewData["IdAnagrafica"] = new SelectList(_context.Anagrafica, "IdAnagrafica", "Citta");
            ViewData["IdViolazione"] = new SelectList(_context.TipoViolazione, "IdViolazione", "Descrizione");
            return View();
        }

        // POST: Verbale/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("IdVerbale,IdAnagrafica,IdViolazione,Cod_Fisc,DataViolazione,IndirizzoViolazione,Descrizione,Nominativo_Agente,DataTrascrizioneVerbale,Importo,DecurtamentoPunti")] Verbale verbale)
        {
            if (ModelState.IsValid)
            {
                _context.Add(verbale);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }

            ViewData["IdAnagrafica"] = new SelectList(_context.Anagrafica, "IdAnagrafica", "Citta", verbale.IdAnagrafica);
            ViewData["IdViolazione"] = new SelectList(_context.TipoViolazione, "IdViolazione", "Descrizione", verbale.IdViolazione);
            return View(verbale);
        }

        // GET: Verbale/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null) return NotFound();

            var verbale = await _context.Verbale.FindAsync(id);
            if (verbale == null) return NotFound();

            ViewData["IdAnagrafica"] = new SelectList(_context.Anagrafica, "IdAnagrafica", "Citta", verbale.IdAnagrafica);
            ViewData["IdViolazione"] = new SelectList(_context.TipoViolazione, "IdViolazione", "Descrizione", verbale.IdViolazione);
            return View(verbale);
        }

        // POST: Verbale/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("IdVerbale,IdAnagrafica,IdViolazione,Cod_Fisc,DataViolazione,IndirizzoViolazione,Descrizione,Nominativo_Agente,DataTrascrizioneVerbale,Importo,DecurtamentoPunti")] Verbale verbale)
        {
            if (id != verbale.IdVerbale) return NotFound();

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(verbale);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!VerbaleExists(verbale.IdVerbale)) return NotFound();
                    else throw;
                }
                return RedirectToAction(nameof(Index));
            }

            ViewData["IdAnagrafica"] = new SelectList(_context.Anagrafica, "IdAnagrafica", "Citta", verbale.IdAnagrafica);
            ViewData["IdViolazione"] = new SelectList(_context.TipoViolazione, "IdViolazione", "Descrizione", verbale.IdViolazione);
            return View(verbale);
        }

        // GET: Verbale/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null) return NotFound();

            var verbale = await _context.Verbale
                .Include(v => v.Anagrafica)
                .Include(v => v.TipoViolazione)
                .FirstOrDefaultAsync(m => m.IdVerbale == id);

            if (verbale == null) return NotFound();

            return View(verbale);
        }

        // POST: Verbale/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var verbale = await _context.Verbale.FindAsync(id);
            if (verbale != null)
            {
                _context.Verbale.Remove(verbale);
                await _context.SaveChangesAsync();
            }
            return RedirectToAction(nameof(Index));
        }

        private bool VerbaleExists(int id)
        {
            return _context.Verbale.Any(e => e.IdVerbale == id);
        }
    }
}
