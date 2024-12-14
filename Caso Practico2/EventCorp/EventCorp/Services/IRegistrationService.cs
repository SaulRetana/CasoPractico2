using EventCorp.Models;
using System.Threading.Tasks;

namespace EventCorp.Services
{
    public interface IRegistrationService
    {
        Task<IEnumerable<Inscripcion>> GetInscripcionesByEventoAsync(int eventoId);
        Task<bool> RegisterUserAsync(int eventoId, int usuarioId);
        Task<bool> UnregisterUserAsync(int eventoId, int usuarioId);
    }
}
