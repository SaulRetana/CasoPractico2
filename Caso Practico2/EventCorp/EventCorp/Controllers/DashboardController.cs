using EventCorp.Data;
using EventCorp.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Linq;
using System.Threading.Tasks;

namespace EventCorp.Controllers
{
    public class DashboardController : Controller
    {
        private readonly EventCorpDbContext _context;

        public DashboardController(EventCorpDbContext context)
        {
            _context = context;
        }

        public async Task<IActionResult> Index()
        {
          
            var totalEventos = await _context.Eventos.CountAsync();

        
            var totalUsuariosActivos = await _context.Usuarios
                .Where(u => u.Rol == "Usuario" || u.Rol == "Organizador")
                .CountAsync();

       
            var mesActual = DateTime.Now.Month;
            var anioActual = DateTime.Now.Year;
            var asistentesMesActual = await _context.Inscripciones
                .Where(i => i.FechaInscripcion.Month == mesActual && i.FechaInscripcion.Year == anioActual)
                .CountAsync();

     
            var topEventos = await _context.Inscripciones
                .GroupBy(i => i.Evento)
                .Select(g => new {
                    Evento = g.Key.Titulo,
                    TotalAsistentes = g.Count()
                })
                .OrderByDescending(e => e.TotalAsistentes)
                .Take(5)
                .ToListAsync();

       
            ViewData["TotalEventos"] = totalEventos;
            ViewData["TotalUsuariosActivos"] = totalUsuariosActivos;
            ViewData["AsistentesMesActual"] = asistentesMesActual;
            ViewData["TopEventos"] = topEventos;

            return View();
        }
    }
}
