using EventCorp.Data;
using EventCorp.Models;
using Microsoft.EntityFrameworkCore;

namespace EventCorp.Services
{
        public class RegistrationService : IRegistrationService
        {
            private readonly EventCorpDbContext _context;

            public RegistrationService(EventCorpDbContext context)
            {
                _context = context;
            }

            public async Task<IEnumerable<Inscripcion>> GetInscripcionesByEventoAsync(int eventoId)
            {
                return await _context.Inscripciones
                                     .Where(i => i.EventoId == eventoId)
                                     .Include(i => i.Usuario)
                                     .ToListAsync();
            }

        public async Task<bool> RegisterUserAsync(int eventoId, int usuarioId)
        {
            var evento = await _context.Eventos
                .Include(e => e.Inscripciones) // Aseguramos que se carguen las inscripciones del evento
                .FirstOrDefaultAsync(e => e.Id == eventoId);

            var usuario = await _context.Usuarios.FindAsync(usuarioId);

            if (evento == null || usuario == null)
                return false;

            if (evento.CupoMaximo <= evento.Inscripciones.Count()) // Ahora funciona correctamente
                return false;  // El evento está lleno

            var inscripcion = new Inscripcion
            {
                EventoId = eventoId,
                UsuarioId = usuarioId,
                FechaInscripcion = DateTime.Now
            };

            _context.Inscripciones.Add(inscripcion);
                await _context.SaveChangesAsync();
                return true;
            }

            public async Task<bool> UnregisterUserAsync(int eventoId, int usuarioId)
            {
                var inscripcion = await _context.Inscripciones
                                                 .FirstOrDefaultAsync(i => i.EventoId == eventoId && i.UsuarioId == usuarioId);

                if (inscripcion == null)
                    return false;

                _context.Inscripciones.Remove(inscripcion);
                await _context.SaveChangesAsync();
                return true;
            }
        }
    }
