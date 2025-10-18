using System.Collections.Generic;
using System.Threading.Tasks;
using Library.Application.Interfaces;
using Library.Domain.Entities;
using Library.Infrastructure.Data;
using Microsoft.EntityFrameworkCore;

namespace Library.Infrastructure.Repositories;

public class CategoryRepository : ICategoryRepository
{
    private readonly LibraryDbContext _context;

    public CategoryRepository(LibraryDbContext context)
    {
        _context = context;
    }

    public async Task<IEnumerable<Categories>> GetAllAsync() =>
        await _context.Categories.OrderBy(c => c.category_name).ToListAsync();

    public async Task<Categories?> GetByIdAsync(int id) =>
        await _context.Categories.FindAsync(id);

    public async Task<Categories> AddAsync(Categories category)
    {
        await _context.Categories.AddAsync(category);
        await _context.SaveChangesAsync();
        return category;
    }

    public async Task<Categories?> UpdateAsync(Categories category)
    {
        var existing = await _context.Categories.FindAsync(category.category_id);
        if (existing == null) return null;

        // Manually update each property
        existing.category_name = category.category_name;
        existing.description = category.description;
        existing.active = category.active;

        await _context.SaveChangesAsync();
        return existing;
    }

    public async Task<bool> DeleteAsync(int id)
    {
        var existing = await _context.Categories.FindAsync(id);
        if (existing == null) return false;

        _context.Categories.Remove(existing);
        await _context.SaveChangesAsync();
        return true;
    }
    public async Task<bool> ExistsByCategoryIdAsync(int categoryId)
    {
        return await _context.Categories.AnyAsync(a => a.category_id == categoryId);
    }
}
