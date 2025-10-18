using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Library.Application.Interfaces;
using Library.Domain.Entities;
using Library.Infrastructure.Data;
using Library.Application.DTOs;

namespace Library.Infrastructure.Repositories;

public class DropdownRepository : IDropdownRepository
{
    private readonly LibraryDbContext _context;

    public DropdownRepository(LibraryDbContext context)
    {
        _context = context;
    }

    public async Task<IEnumerable<DropdownItem>> GetCountryDropdownAsync()
    {
        return await _context.Countries
            .Select(c => new DropdownItem
            {
                Value = c.country_id.ToString(),
                Text = c.country_name
            })
            .OrderBy(c => c.Text)
            .ToListAsync();
    }


    public async Task<IEnumerable<DropdownItem>> GetAuthorDropdownAsync()
    {
        return await _context.Authors
            .Select(a => new DropdownItem
            {
                Value = a.author_id.ToString(),
                Text = a.author_name
            })
            .OrderBy(a => a.Text)
            .ToListAsync();
    }


    public async Task<IEnumerable<DropdownItem>> GetPublisherDropdownAsync()
    {
        return await _context.Publishers
            .Select(p => new DropdownItem
            {
                Value = p.publisher_id.ToString(),
                Text = p.publisher_name
            })
            .OrderBy(p => p.Text)
            .ToListAsync();
    }


    public async Task<IEnumerable<DropdownItem>> GetCategoryDropdownAsync()
    {
        return await _context.Categories
            .Select(c => new DropdownItem
            {
                Value = c.category_id.ToString(),
                Text = c.category_name
            })
            .OrderBy(c => c.Text)
            .ToListAsync();
    }


}