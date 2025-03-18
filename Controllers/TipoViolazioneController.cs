using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Cops.Data;
using Cops.Models;

namespace Cops.Controllers
{
    public class TipoViolazioneController : Controller
    {
        private readonly CopsContext _context;

        public TipoViolazioneController(CopsContext context)
        {
            _context = context;
        }

        // GET: TipoViolazione/Index
        public async Task<IActionResult> Index()
        {
            var tipoViolazioni = await _context.TipoViolazione.ToListAsync();
            return View(tipoViolazioni);
        }
    }
}

