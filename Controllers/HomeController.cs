using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Cops.Data;
using Cops.Models;

namespace Cops.Controllers
{
    public class HomeController : Controller
    {
        
    public IActionResult Index()
        {
            return View();  
        }

        // Aggiungi la proprietà per il contesto
        private readonly CopsContext _context;

        // Costruttore che inietta il contesto
        public HomeController(CopsContext context)
        {
            _context = context; // Assegna il contesto al campo privato
        }

        // GET: Home/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var anagrafica = await _context.Anagrafica
                .Include(a => a.IdAnagrafica)  
                .FirstOrDefaultAsync(m => m.IdAnagrafica == id);

            if (anagrafica == null)
            {
                return NotFound();
            }

            return View(anagrafica); 
        }

    }

}
