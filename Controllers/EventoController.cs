using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using CasoPractico2.Models;
using CasoPractico2.Services;

namespace CasoPractico2.Controllers
{
    public class EventoController : Controller
    {
        private readonly IEventoServices _services;

        public EventoController(IEventoServices services)
        {
            _services = services;
        }

        // GET: Evento
        public async Task<IActionResult> Index()
        {
            return View(await _services.Listado());
        }

        // GET: Evento/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var evento = await _services.ObtenerEvento(id);
            if (evento == null)
            {
                return NotFound();
            }

            return View(evento);
        }

        // GET: Evento/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Evento/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,Nombre,Fecha,Hora,Lugar,CapacidadMaxima")] Evento evento)
        {
            if (ModelState.IsValid)
            {
                await _services.guardar(evento);
                return RedirectToAction(nameof(Index));
            }
            return View(evento);
        }

        // GET: Evento/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var evento = await _services.ObtenerEvento(id);
            if (evento == null)
            {
                return NotFound();
            }
            return View(evento);
        }

        // POST: Evento/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,Nombre,Fecha,Hora,Lugar,CapacidadMaxima")] Evento evento)
        {
            if (id != evento.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                await _services.modificar(evento);               
                return RedirectToAction(nameof(Index));
            }
            return View(evento);
        }

        // GET: Evento/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var evento = await _services.ObtenerEvento(id);
            if (evento == null)
            {
                return NotFound();
            }

            return View(evento);
        }

        // POST: Evento/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {           
            await _services.eliminar(id);
            return RedirectToAction(nameof(Index));
        }
        public async Task<IActionResult> ReservasEvento(int? id, [FromServices]EventCorpContext _context)
        {
            if (id == null)
            {
                return NotFound();
            }
            var evento = await _context.Evento.Include(x => x.Reservas).ThenInclude(x=>x.Usuario)
                .FirstOrDefaultAsync(m => m.Id == id);
            if (evento == null)
            {
                return NotFound();
            }
            TempData["Mensaje"] = "Proceso Finalizado";
            return View(evento);
        }
    }
}
