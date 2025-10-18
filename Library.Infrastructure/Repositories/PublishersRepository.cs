using System.Collections.Generic;
using System.Threading.Tasks;
using Library.Application.Interfaces;
using Library.Domain.Entities;
using Library.Infrastructure.Data;
using Microsoft.EntityFrameworkCore;

namespace Library.Infrastructure.Repositories;

public class PublishersRepository : IPublishersRepository
{
    private readonly LibraryDbContext _context;

    public PublishersRepository(LibraryDbContext context)
    {
        _context = context;
    }

    // Get all publishers
    public async Task<IEnumerable<Publishers>> GetAllAsync() =>
        await _context.Publishers.OrderBy(p => p.publisher_name).ToListAsync();

    // Get a publisher by ID
    public async Task<Publishers?> GetByIdAsync(int id) =>
        await _context.Publishers.FindAsync(id);

    // Add a new publisher
    public async Task<Publishers> AddAsync(Publishers publisher)
    {
        await _context.Publishers.AddAsync(publisher);
        await _context.SaveChangesAsync();
        return publisher;
    }

    // Update an existing publisher
    public async Task<Publishers?> UpdateAsync(Publishers publisher)
    {
        var existing = await _context.Publishers.FindAsync(publisher.publisher_id);
        if (existing == null) return null;

        // Manually update fields
        existing.publisher_name = publisher.publisher_name;
        existing.address = publisher.address;
        existing.phone = publisher.phone;
        existing.email = publisher.email;
        existing.active = publisher.active;

        await _context.SaveChangesAsync();
        return existing;
    }

    // Delete a publisher
    public async Task<bool> DeleteAsync(int id)
    {
        var existing = await _context.Publishers.FindAsync(id);
        if (existing == null) return false;

        _context.Publishers.Remove(existing);
        await _context.SaveChangesAsync();
        return true;
    }
    public async Task<bool> ExistsByPublisherIdAsync(int publisherId)
    {
        return await _context.Publishers.AnyAsync(a => a.publisher_id == publisherId);
    }
}
