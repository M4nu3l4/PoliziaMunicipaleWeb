using Cops.Data;
using Cops.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

public class AnagraficaController : Controller
{
    private readonly CopsContext _context;

    public AnagraficaController(CopsContext context)
    {
        _context = context;
    }
    public async Task<IActionResult> Index(string codiceFiscale)
    {
        // Verifica se è stato passato un codice fiscale, se no ritorna una lista vuota
        if (string.IsNullOrEmpty(codiceFiscale))
        {
            return View(new List<Verbale>());
        }

        // Ottieni i verbali relativi al codice fiscale
        var verbali = await _context.Verbale
            .Include(v => v.Anagrafica) // Include la relazione con l'anagrafica
            .Include(v => v.TipoViolazione) // Include la relazione con il tipo di violazione
            .Where(v => v.Anagrafica.Cod_Fisc == codiceFiscale) // Filtra per codice fiscale
            .ToListAsync();

        // Passa la lista dei verbali alla vista
        return View(verbali);
    }




    // Azione Details per visualizzare il dettaglio di un singolo elemento
    public async Task<IActionResult> Details(int id)
    {
        var anagrafica = await _context.Anagrafica.FindAsync(id);
        if (anagrafica == null)
        {
            return NotFound();
        }

        return View(anagrafica);
    }

    // GET: Cittadino
    public async Task<IActionResult> Cittadino(string codFisc, int? idVerbale)
    {
        var verbali = await _context.Verbale
            .Include(v => v.Anagrafica) // Include l'anagrafica
            .Include(v => v.TipoViolazione)
            .Where(v => string.IsNullOrEmpty(codFisc) || v.Anagrafica.Cod_Fisc == codFisc) // Accesso a codFisc tramite Anagrafica
            .Where(v => !idVerbale.HasValue || v.IdVerbale == idVerbale)
            .ToListAsync();

        return View(verbali);
    }

}
