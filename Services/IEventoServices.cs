using CasoPractico2.Models;

namespace CasoPractico2.Services
{
    public interface IEventoServices
    {
        Task<bool> guardar(Evento evento);
        Task<bool> modificar(Evento evento);
        Task<IEnumerable<Evento>> Listado();
        Task<bool> eliminar(int id);
        Task<Evento> ObtenerEvento(int? id);
    }
}
