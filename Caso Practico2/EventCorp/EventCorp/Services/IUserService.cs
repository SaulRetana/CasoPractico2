using System.Collections.Generic;
using System.Threading.Tasks;
using EventCorp.Data;
using EventCorp.Models;

namespace EventCorp.Services
{
    public interface IUserService
    {
        Task<IEnumerable<Usuario>> GetAllUsersAsync();
        Task<Usuario> GetUserByIdAsync(int id);
        Task AddUserAsync(Usuario usuario);
        Task UpdateUserAsync(Usuario usuario);
        Task DeleteUserAsync(int id);
    }
}