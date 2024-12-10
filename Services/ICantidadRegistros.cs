using CasoPractico2.Models;

namespace CasoPractico2.Services
{
    public interface ICantidadRegistros
    {
        Task<int> cantidadUsuarios();
        Task<int> cantidadEventos();
        Task<int> cantidadReservastotales();
        Task<int> cantidadReservarXEvento(int EventoID);
    }
}
