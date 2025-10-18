using System.Collections.Generic;
using System.Threading.Tasks;
using Library.Application.DTOs;
using Library.Application.Interfaces;

namespace Library.Application.Services;

public class DropdownService
{
    private readonly IDropdownRepository _repo;
    private readonly Random _random = new Random();

    public DropdownService(IDropdownRepository repo)
    {
        _repo = repo;
    }


    public async Task<IEnumerable<DropdownItem>> GetCountryDropdownAsync()
    {
        return await _repo.GetCountryDropdownAsync();
    }

    public async Task<IEnumerable<DropdownItem>> GetAuthorDropdownAsync()
    {
        return await _repo.GetAuthorDropdownAsync();
    }
    

    public async Task<IEnumerable<DropdownItem>> GetPublisherDropdownAsync()
    {
        return await _repo.GetPublisherDropdownAsync();
    }

    public async Task<IEnumerable<DropdownItem>> GetCategoryDropdownAsync()
    {
        return await _repo.GetCategoryDropdownAsync();
    }
}