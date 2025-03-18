using Cops.Data;
using Cops.Models;
using Cops.Models.ViewModels;
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
            List<Verbale> verbale;

            if (string.IsNullOrEmpty(Cod_Fisc))
            {
                verbale = await _context.Verbale
                    .Include(v => v.Anagrafica)
                    .Include(v => v.TipoViolazione)
                    .ToListAsync();
            }
            else
            {
                verbale = await _context.Verbale
                    .Include(v => v.Anagrafica)
                    .Include(v => v.TipoViolazione)
                    .Where(v => v.Anagrafica.Cod_Fisc == Cod_Fisc) 
                    .ToListAsync();
            }

          
            if (verbale == null || !verbale.Any())
            {
                ViewData["Message"] = "Nessun verbale trovato per il codice fiscale inserito.";
                return View(new List<Verbale>());
            }

            return View(verbale);
        }


        [HttpPost]
        public IActionResult Edit(int id, Verbale verbale)
        {
            if (id != verbale.IdVerbale)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                _context.Update(verbale);
                _context.SaveChanges();
                return RedirectToAction(nameof(Index));
            }

            return View(verbale);
        }

        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public IActionResult DeleteConfirmed(int id)
        {
            var verbale = _context.Verbale.Find(id);
            if (verbale != null)
            {
                _context.Verbale.Remove(verbale);
                _context.SaveChanges();
            }

            return RedirectToAction("Index", "AgenteDiPolizia");
        }

        public async Task<IActionResult> VisualizzaViolazione(string codFisc)
        {
            var trasgressore = await _context.Anagrafica.FirstOrDefaultAsync(a => a.Cod_Fisc == codFisc);
            if (trasgressore == null)
            {
                return NotFound();
            }

            var verbali = await _context.Verbale
                                        .Include(v => v.Anagrafica)
                                        .Include(v => v.TipoViolazione)
                                        .Where(v => v.IdAnagrafica == trasgressore.IdAnagrafica)
                                        .ToListAsync();

            foreach (var verbale in verbali)
            {
                verbale.DecurtamentoPunti = verbale.DecurtamentoPunti ?? 0;
                verbale.Importo = verbale.Importo ?? 0.00m;
            }

            return View(verbali);
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

