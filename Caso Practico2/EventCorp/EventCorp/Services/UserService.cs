using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using EventCorp.Data;
using EventCorp.Models;
using Microsoft.EntityFrameworkCore;

namespace EventCorp.Services
{
    public class UserService : IUserService
    {
        private readonly EventCorpDbContext _context;

        public UserService(EventCorpDbContext context)
        {
            _context = context;
        }

        public async Task<IEnumerable<Usuario>> GetAllUsersAsync()
        {
            return await _context.Usuarios.ToListAsync();
        }

        public async Task<Usuario> GetUserByIdAsync(int id)
        {
            return await _context.Usuarios.FindAsync(id);
        }

        public async Task AddUserAsync(Usuario usuario)
        {
            await _context.Usuarios.AddAsync(usuario);
            await _context.SaveChangesAsync();
        }

        public async Task UpdateUserAsync(Usuario usuario)
        {
            _context.Usuarios.Update(usuario);
            await _context.SaveChangesAsync();
        }

        public async Task DeleteUserAsync(int id)
        {
            var usuario = await _context.Usuarios.FindAsync(id);
            if (usuario != null)
            {
                _context.Usuarios.Remove(usuario);
                await _context.SaveChangesAsync();
            }
        }
    }
}