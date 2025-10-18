using System.Collections.Generic;
using System.Threading.Tasks;
using Library.Domain.Entities;

namespace Library.Application.Interfaces;

public interface ICategoryRepository
{
    Task<IEnumerable<Categories>> GetAllAsync();
    Task<Categories?> GetByIdAsync(int id);
    Task<Categories> AddAsync(Categories category);
    Task<Categories?> UpdateAsync(Categories category);
    Task<bool> DeleteAsync(int id);
    Task<bool> ExistsByCategoryIdAsync(int categoryId);
}