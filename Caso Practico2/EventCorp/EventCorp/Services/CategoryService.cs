using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using EventCorp.Data;
using EventCorp.Models;
using Microsoft.EntityFrameworkCore;

namespace EventCorp.Services
{
    public class CategoryService : ICategoryService
    {
        private readonly EventCorpDbContext _context;

        public CategoryService(EventCorpDbContext context)
        {
            _context = context;
        }

        public async Task<IEnumerable<Categoria>> GetAllCategoriesAsync()
        {
            return await _context.Categorias.ToListAsync();
        }

        public async Task<Categoria> GetCategoryByIdAsync(int id)
        {
            return await _context.Categorias.FindAsync(id);
        }

        public async Task AddCategoryAsync(Categoria categoria)
        {
            categoria.FechaRegistro = DateTime.Now;
            await _context.Categorias.AddAsync(categoria);
            await _context.SaveChangesAsync();
        }

        public async Task UpdateCategoryAsync(Categoria categoria)
        {
            _context.Categorias.Update(categoria);
            await _context.SaveChangesAsync();
        }

        public async Task DeleteCategoryAsync(int id)
        {
            var category = await _context.Categorias.FindAsync(id);
            if (category != null)
            {
                _context.Categorias.Remove(category);
                await _context.SaveChangesAsync();
            }
        }
    }
}