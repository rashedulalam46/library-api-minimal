using Library.Application.Interfaces;
using Library.Domain.Entities;
using Library.Infrastructure.Data;
using Microsoft.EntityFrameworkCore;

namespace Library.Infrastructure.Repositories;

public class AuthorRepository : IAuthorRepository
{
    private readonly LibraryDbContext _context;

    public AuthorRepository(LibraryDbContext context)
    {
        _context = context;
    }

    public async Task<IEnumerable<Authors>> GetAllAsync() =>
        await _context.Authors.OrderBy(a => a.author_name).ToListAsync();

    public async Task<Authors?> GetByIdAsync(int id) =>
        await _context.Authors.FindAsync(id);

    public async Task<Authors> AddAsync(Authors author)
    {
        await _context.Authors.AddAsync(author);
        await _context.SaveChangesAsync();
        return author;
    }

    public async Task<Authors?> UpdateAsync(Authors author)
    {
        var existing = await _context.Authors.FindAsync(author.author_id);
        if (existing == null) return null;

        existing.author_name = author.author_name;
        existing.country = author.country;
        existing.address = author.address;
        existing.phone = author.phone;
        existing.email = author.email;
        existing.active = author.active;

        await _context.SaveChangesAsync();
        return existing;
    }

    public async Task<bool> DeleteAsync(int id)
    {
        var author = await _context.Authors.FindAsync(id);
        if (author == null) return false;

        _context.Authors.Remove(author);
        await _context.SaveChangesAsync();
        return true;
    }
    public async Task<bool> ExistsByAuthorIdAsync(int authorId)
    {
        return await _context.Authors.AnyAsync(a => a.author_id == authorId);
    }
}
