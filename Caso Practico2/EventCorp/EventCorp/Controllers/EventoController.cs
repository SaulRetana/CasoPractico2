using EventCorp.Data;
using EventCorp.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace EventCorp.Controllers
{
    public class EventoController : Controller
    {
        private readonly EventCorpDbContext _context;

        public EventoController(EventCorpDbContext context)
        {
            _context = context;
        }

        public async Task<IActionResult> Index()
        {
            return View(await _context.Eventos.ToListAsync());
        }

        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Titulo,Descripcion,CategoriaId,Fecha,Hora,Duracion,Ubicacion,CupoMaximo")] Evento evento)
        {
            if (evento.Fecha < DateTime.Now)
            {
                ModelState.AddModelError("Fecha", "La fecha no puede ser en el pasado.");
            }
            if (evento.Duracion <= 0)
            {
                ModelState.AddModelError("Duracion", "La duración debe ser mayor a 0.");
            }
            if (evento.CupoMaximo <= 0)
            {
                ModelState.AddModelError("CupoMaximo", "El cupo máximo debe ser mayor a 0.");
            }

            if (ModelState.IsValid)
            {
                _context.Add(evento);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(evento);
        }
    }
}
