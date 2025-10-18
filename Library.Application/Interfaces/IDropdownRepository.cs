using Library.Application.DTOs;
using Library.Domain.Entities;

namespace Library.Application.Interfaces;

public interface IDropdownRepository
{
    Task<IEnumerable<DropdownItem>> GetCountryDropdownAsync();
    Task<IEnumerable<DropdownItem>> GetAuthorDropdownAsync();
    Task<IEnumerable<DropdownItem>> GetPublisherDropdownAsync();
    Task<IEnumerable<DropdownItem>> GetCategoryDropdownAsync();
}