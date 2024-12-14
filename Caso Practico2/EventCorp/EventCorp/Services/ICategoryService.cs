using System.Collections.Generic;
using System.Threading.Tasks;
using EventCorp.Data;
using EventCorp.Models;

namespace EventCorp.Services
{
    public interface ICategoryService
    {
        Task<IEnumerable<Categoria>> GetAllCategoriesAsync();
        Task<Categoria> GetCategoryByIdAsync(int id);
        Task AddCategoryAsync(Categoria category);
        Task UpdateCategoryAsync(Categoria category);
        Task DeleteCategoryAsync(int id);
    }
}
