
using Microsoft.EntityFrameworkCore;
using CasoPractico2.Models;

namespace CasoPractico2.Services
{
    public class CantidadRegistros : ICantidadRegistros
    {
        private readonly EventCorpContext _context;
        public CantidadRegistros(EventCorpContext context)
        {
            _context = context;
        }
        public async Task<int> cantidadEventos()
        {
            return await _context.Evento.CountAsync();
        }

        public async Task<int> cantidadReservarXEvento(int EventoID)
        {
            return await _context.Reserva.Where(x=>x.EventoId == EventoID).CountAsync();
        }

        public async Task<int> cantidadReservastotales()
        {
            return await _context.Reserva.CountAsync();
        }

        public async Task<int> cantidadUsuarios()
        {
            return await _context.Usuario.CountAsync();
        }
    }
}
