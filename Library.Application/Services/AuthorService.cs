using Library.Application.Interfaces;
using Library.Domain.Entities;

namespace Library.Application.Services;

public class AuthorService
{
    
    private readonly IAuthorRepository _repo;
    private readonly Random _random = new Random();
    public AuthorService(IAuthorRepository repo)
    {
        _repo = repo;
    }

    public Task<IEnumerable<Authors>> GetAuthorsAsync()
    {
        return _repo.GetAllAsync();
    }
    public Task<Authors?> GetAuthorAsync(int id)
    {
        return _repo.GetByIdAsync(id);
    }
    public async Task<Authors> AddAuthorAsync(Authors author)
    {

        int authorId;
        do
        {
            authorId = _random.Next(1000, 9999);
        }
        while (await _repo.ExistsByAuthorIdAsync(authorId));

        author.author_id = authorId;
        author.create_date = DateTime.UtcNow;        
        author.country = string.IsNullOrEmpty(author.country) ? null : author.country.ToUpper();
        return await _repo.AddAsync(author);
    }
    public Task<Authors?> UpdateAuthorAsync(Authors author)
    {
        author.country = string.IsNullOrEmpty(author.country) ? null : author.country.ToUpper();
        return _repo.UpdateAsync(author);
    }
    public Task<bool> DeleteAuthorAsync(int id)
    {
        return _repo.DeleteAsync(id);
    }
}