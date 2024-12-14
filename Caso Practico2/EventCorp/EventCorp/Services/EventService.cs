using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using EventCorp.Data;
using EventCorp.Models;
using EventCorp.Services;
using Microsoft.EntityFrameworkCore;

public class EventoService : IEventService
{
    private readonly EventCorpDbContext _context;

    public EventoService(EventCorpDbContext context)
    {
        _context = context;
    }

    public async Task<IEnumerable<Evento>> GetAllEventsAsync()
    {
        return await _context.Eventos
            .Include(e => e.Categoria)
            .ToListAsync();
    }

    public async Task<Evento> GetEventByIdAsync(int id)
    {
        return await _context.Eventos
            .Include(e => e.Categoria)
            .FirstOrDefaultAsync(e => e.Id == id);
    }

    public async Task AddEventAsync(Evento eventoEntity)
    {
        eventoEntity.FechaRegistro = DateTime.Now;
        await _context.Eventos.AddAsync(eventoEntity);
        await _context.SaveChangesAsync();
    }

    public async Task UpdateEventAsync(Evento eventoEntity)
    {
        _context.Eventos.Update(eventoEntity);
        await _context.SaveChangesAsync();
    }

    public async Task DeleteEventAsync(int id)
    {
        var eventoEntity = await _context.Eventos.FindAsync(id);
        if (eventoEntity != null)
        {
            _context.Eventos.Remove(eventoEntity);
            await _context.SaveChangesAsync();
        }
    }

    public async Task<IEnumerable<Evento>> GetAvailableEventsAsync()
    {
        return await _context.Eventos
            .Where(e => e.Fecha >= DateTime.Now && e.CupoMaximo > 0)
            .ToListAsync();
    }
}
