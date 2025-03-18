using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Cops.Data;
using Cops.Models;

namespace Cops.Controllers
{
    public class CittadinoController : Controller
    {
        private readonly CopsContext _context;

        public CittadinoController(CopsContext context)
        {
            _context = context;
        }

        // GET: Cittadino/Index
        public async Task<IActionResult> Index(string codiceFiscale)
        {
            
            var verbali = await _context.Verbale
                .Include(v => v.Anagrafica) 
                .Where(v => v.Anagrafica.Cod_Fisc == codiceFiscale)  
                .ToListAsync();

          
            ViewData["CodiceFiscale"] = codiceFiscale;

            return View(verbali);
        }
    }
}


