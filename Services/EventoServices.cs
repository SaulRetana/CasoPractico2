using Microsoft.EntityFrameworkCore;
using CasoPractico2.Models;

namespace CasoPractico2.Services
{
    public class EventoServices : IEventoServices
    {
        private readonly EventCorpContext _context;
        public EventoServices(EventCorpContext context)
        {
            _context = context;
        }
        private bool EventoExists(int id)
        {
            return _context.Evento.Any(e => e.Id == id);
        }
        public async Task<bool> eliminar(int id)
        {
            try
            {
                var evento = await _context.Evento.FindAsync(id);
                if (evento != null)
                {
                    _context.Evento.Remove(evento);
                }
                return true;
            }
            catch (Exception ex) 
            {
                return false;
            }
        }

        public async Task<bool> guardar(Evento evento)
        {
            try
            {
                _context.Add(evento);
                await _context.SaveChangesAsync();
                return true;
            }
            catch (Exception ex)
            {
                return false;            
            }            
        }

        public async Task<IEnumerable<Evento>> Listado()
        {
            var Lista = await _context.Evento.ToArrayAsync();
            return Lista;
        }

        public async Task<bool> modificar(Evento evento)
        {
            try
            {
                _context.Update(evento);
                await _context.SaveChangesAsync();
                return true;
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!EventoExists(evento.Id))
                {
                    return false;
                }
                else
                {
                    throw;
                }
            }
        }
        public async Task<Evento> ObtenerEvento(int? id)
        {
            var evento = await _context.Evento.FindAsync(id);
            return evento;
        }
    }
}
