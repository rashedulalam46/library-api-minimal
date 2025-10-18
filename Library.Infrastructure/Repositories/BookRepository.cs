
using Library.Application.DTOs;
using Library.Application.Interfaces;
using Library.Domain.Entities;
using Library.Infrastructure.Data;
using Microsoft.EntityFrameworkCore;

namespace Library.Repositories;

public class BookRepository : IBookRepository
{
    private readonly LibraryDbContext _context;
    public BookRepository(LibraryDbContext context)
    {
        _context = context;
    }

    public async Task<IEnumerable<BookReadDto>> GetAllAsync()
    {
        var query = from b in _context.Books
                    join a in _context.Authors
                        on b.author_id equals a.author_id
                    join c in _context.Categories
                        on b.category_id equals c.category_id
                    join p in _context.Publishers
                        on b.publisher_id equals p.publisher_id
                    select new BookReadDto
                    {
                        book_id = b.book_id,
                        title = b.title,
                        description = b.description,
                        author_id = b.author_id,
                        category_id = b.category_id,
                        publisher_id = b.publisher_id,
                        author_name = a.author_name,
                        category_name = c.category_name,
                        publisher_name = p.publisher_name,
                        isbn = b.ISBN,
                        price = b.price,
                        active = b.active,
                        publish_date = b.publish_date
                    };

        return await query.OrderBy(b => b.title).ToListAsync();
    }


    public async Task<Books?> GetByIdAsync(int id) =>
        await _context.Books.FindAsync(id);

    public async Task<Books> AddAsync(Books book)
    {
        _context.Books.Add(book);
        await _context.SaveChangesAsync();
        return book;
    }

    public async Task<Books?> UpdateAsync(Books book)
    {
        var existing = await _context.Books.FindAsync(book.book_id);
        if (existing == null) return null;

        existing.title = book.title;
        existing.description = book.description;            
        existing.author_id = book.author_id;
        existing.category_id = book.category_id;
        existing.publisher_id = book.publisher_id;          
        existing.ISBN = book.ISBN;
        existing.price = book.price;

        await _context.SaveChangesAsync();
        return existing;
    }

    public async Task<bool> DeleteAsync(int id)
    {
        var book = await _context.Books.FindAsync(id);
        if (book == null) return false;

        _context.Books.Remove(book);
        await _context.SaveChangesAsync();
        return true;
    }
    public async Task<bool> ExistsByBookIdAsync(int bookId)
    {
        return await _context.Books.AnyAsync(a => a.book_id == bookId);
    }
}
