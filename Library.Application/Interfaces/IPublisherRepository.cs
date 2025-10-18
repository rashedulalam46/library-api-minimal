using System.Collections.Generic;
using System.Threading.Tasks;
using Library.Domain.Entities;

namespace Library.Application.Interfaces;

public interface IPublisherRepository
{
    Task<Publishers?> GetByIdAsync(int id);
    Task<IEnumerable<Publishers>> GetAllAsync();
    Task<Publishers> AddAsync(Publishers publisher);
    Task<Publishers?> UpdateAsync(Publishers publisher);
    Task<bool> DeleteAsync(int id);
    Task<bool> ExistsByPublisherIdAsync(int publisherId);
}