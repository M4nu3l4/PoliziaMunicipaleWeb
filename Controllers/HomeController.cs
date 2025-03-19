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

        
        private readonly CopsContext _context;

        
        public HomeController(CopsContext context)
        {
            _context = context; 
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
