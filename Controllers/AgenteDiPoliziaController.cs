using Cops.Data;
using Cops.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace Cops.Controllers
{
    public class AgenteDiPoliziaController : Controller
    {
        private readonly CopsContext _context;

        public AgenteDiPoliziaController(CopsContext context)
        {
            _context = context;
        }

        public IActionResult Login()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Login(string username, string password)
        {
            if (username == "agente" && password.Length >= 8 &&
                password.Any(char.IsLower) && password.Any(char.IsUpper) && password.Any(ch => "!-/@#$\\,*%&".Contains(ch)))
            {
                return RedirectToAction("Index", "AgenteDiPolizia");
            }

            ViewBag.Error = "Credenziali non valide";
            return View();
        }

        public async Task<IActionResult> Index(string Cod_Fisc)
        {
            if (string.IsNullOrEmpty(Cod_Fisc))
            {
                // Se non viene inserito alcun codice fiscale, mostra tutti i verbali
                var tuttiVerbali = await _context.Verbale
                    .Include(v => v.Anagrafica)
                    .Include(v => v.TipoViolazione)
                    .ToListAsync();

                ViewData["Message"] = "Tutti i verbali caricati.";
                return View(tuttiVerbali);
            }

            Console.WriteLine("Ricerca per Codice Fiscale: " + Cod_Fisc);

            var trasgressore = await _context.Anagrafica.FirstOrDefaultAsync(a => a.Cod_Fisc == Cod_Fisc);

            if (trasgressore == null)
            {
                Console.WriteLine($"Codice Fiscale {Cod_Fisc} non trovato nel DB.");
                ViewData["Message"] = $"Nessun trasgressore trovato per il codice fiscale: {Cod_Fisc}";
                return View(new List<Verbale>());
            }

            var verbali = await _context.Verbale
                .Include(v => v.Anagrafica)
                .Include(v => v.TipoViolazione)
                .Where(v => v.IdAnagrafica == trasgressore.IdAnagrafica)
                .ToListAsync();

            if (!verbali.Any())
            {
                ViewData["Message"] = $"Nessun verbale trovato per il codice fiscale: {Cod_Fisc}";
                return View(new List<Verbale>());
            }

            return View(verbali);
        }





        [HttpPost]
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var verbale = await _context.Verbale.FindAsync(id);
            if (verbale == null)
            {
                return NotFound();
            }

            return View(verbale);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("IdVerbale,Cod_Fisc,IdViolazione,DecurtamentoPunti,Importo,DataViolazione")] Verbale verbale)
        {
            if (id != verbale.IdVerbale)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                _context.Update(verbale);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(verbale);
        }

        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Cod_Fisc,IdViolazione,DecurtamentoPunti,Importo,DataViolazione")] Verbale verbale)
        {
            if (ModelState.IsValid)
            {
                _context.Add(verbale);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(verbale);
        }


        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var verbale = await _context.Verbale.FindAsync(id);
            if (verbale == null)
            {
                return NotFound();
            }

            return View(verbale);
        }

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





        public async Task<IActionResult> VisualizzaTrasgressori()
        {
            // Recupera tutti i trasgressori dal database
            var trasgressori = await _context.Anagrafica.ToListAsync();

            if (!trasgressori.Any())
            {
                ViewData["Message"] = "Nessun trasgressore trovato nel sistema.";
                return View(new List<Anagrafica>());
            }

            return View(trasgressori);
        }


        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var verbale = await _context.Verbale
                                        .Include(v => v.Anagrafica)
                                        .Include(v => v.TipoViolazione)
                                        .FirstOrDefaultAsync(m => m.IdVerbale == id);

            if (verbale == null)
            {
                return NotFound();
            }

            return View(verbale);
        }
    }
}

