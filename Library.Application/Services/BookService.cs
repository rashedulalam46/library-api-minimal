using Library.Application.DTOs;
using Library.Application.Interfaces;
using Library.Domain.Entities;

namespace Library.Application.Services;

public class BookService
{
    private readonly IBookRepository _repo;
    private readonly Random _random = new Random();
    public BookService(IBookRepository repo)
    {
        _repo = repo;
    }

    public Task<IEnumerable<BookReadDto>> GetBooksAsync()
    {
        return _repo.GetAllAsync();
    }
    public Task<Books?> GetBookAsync(int id)
    {
        return _repo.GetByIdAsync(id);
    }
    public async Task<Books> AddBookAsync(Books book)
    {
        int bookId;
        do
        {
            bookId = _random.Next(1000, 9999);
        }
        while (await _repo.ExistsByBookIdAsync(bookId));

        book.book_id = bookId;
        book.publish_date = DateTime.UtcNow;
        return await _repo.AddAsync(book);
    }
    public Task<Books?> UpdateBookAsync(Books book)
    {
        return _repo.UpdateAsync(book);
    }
    public Task<bool> DeleteBookAsync(int id)
    {
        return _repo.DeleteAsync(id);
    }
}

