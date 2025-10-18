using System.Collections.Generic;
using System.Threading.Tasks;
using Library.Domain.Entities;

namespace Library.Application.Interfaces;

public interface IAuthorRepository
{
    Task<Authors?> GetByIdAsync(int id);
    Task<IEnumerable<Authors>> GetAllAsync();
    Task<Authors> AddAsync(Authors author);
    Task<Authors?> UpdateAsync(Authors author);
    Task<bool> DeleteAsync(int id);
    Task<bool> ExistsByAuthorIdAsync(int authorId);
}

