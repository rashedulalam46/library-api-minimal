using System.Collections.Generic;
using System.Threading.Tasks;
using Library.Application.DTOs;
using Library.Domain.Entities;

namespace Library.Application.Interfaces;

public interface IBookRepository
{
    Task<Books?> GetByIdAsync(int id);
    Task<IEnumerable<BookReadDto>> GetAllAsync();
    Task<Books> AddAsync(Books book);
    Task<Books?> UpdateAsync(Books book);
    Task<bool> DeleteAsync(int id);
    Task<bool> ExistsByBookIdAsync(int bookId);
}