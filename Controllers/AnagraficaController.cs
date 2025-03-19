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
    public async Task<IActionResult> Index(string Cod_Fisc)
    {
        
        if (string.IsNullOrEmpty(Cod_Fisc))
        {
            return View(new List<Verbale>());
        }

       
        var verbali = await _context.Verbale
            .Include(v => v.Anagrafica) 
            .Include(v => v.TipoViolazione) 
            .Where(v => v.Anagrafica.Cod_Fisc == Cod_Fisc) 
            .ToListAsync();

        return View(verbali);
    }


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
    public async Task<IActionResult> Cittadino(string Cod_Fisc, int? idVerbale)
    {
        var verbali = await _context.Verbale
            .Include(v => v.Anagrafica) 
            .Include(v => v.TipoViolazione)
            .Where(v => string.IsNullOrEmpty(Cod_Fisc) || v.Anagrafica.Cod_Fisc == Cod_Fisc)  
            .Where(v => !idVerbale.HasValue || v.IdVerbale == idVerbale)
            .ToListAsync();

        return View(verbali);
    }

}//in anagrafica devo popolare i records cod_fisc
