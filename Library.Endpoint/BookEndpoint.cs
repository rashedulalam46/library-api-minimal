using Library.Application.DTOs;
using Library.Application.Interfaces;
using Library.Domain.Entities;


namespace LibraryApiMinimal.Endpoint;

public static class BookEndpoint
{
    public static void MapBookEndpoints(this WebApplication app)
    {
        var group = app.MapGroup("/api/books")
                       .WithTags("Books");

        // ✅ GET all books
        group.MapGet("/", async (IBookRepository repo) =>
        {
            var books = await repo.GetAllAsync();
            return Results.Ok(books);
        })
        .WithName("GetAllBooks")
        .WithSummary("Get a list of all books")
        .Produces<IEnumerable<BookReadDto>>(StatusCodes.Status200OK);

        // ✅ GET book by ID
        group.MapGet("/{id:int}", async (IBookRepository repo, int id) =>
        {
            var book = await repo.GetByIdAsync(id);
            return book is not null ? Results.Ok(book) : Results.NotFound();
        })
        .WithName("GetBookById")
        .WithSummary("Get details of a specific book by ID")
        .Produces<Books>(StatusCodes.Status200OK)
        .Produces(StatusCodes.Status404NotFound);

        // ✅ POST (Add new book)
        group.MapPost("/", async (IBookRepository repo, Books book) =>
        {
            var created = await repo.AddAsync(book);
            return Results.Created($"/api/books/{created.book_id}", created);
        })
        .WithName("CreateBook")
        .WithSummary("Add a new book")
        .Produces<Books>(StatusCodes.Status201Created);

        // ✅ PUT (Update existing book)
        group.MapPut("/{id:int}", async (IBookRepository repo, int id, Books updatedBook) =>
        {
            if (id != updatedBook.book_id)
                return Results.BadRequest("Book ID mismatch.");

            var book = await repo.UpdateAsync(updatedBook);
            return book is not null ? Results.Ok(book) : Results.NotFound();
        })
        .WithName("UpdateBook")
        .WithSummary("Update details of an existing book")
        .Produces<Books>(StatusCodes.Status200OK)
        .Produces(StatusCodes.Status404NotFound)
        .Produces(StatusCodes.Status400BadRequest);

        // ✅ DELETE (Remove a book)
        group.MapDelete("/{id:int}", async (IBookRepository repo, int id) =>
        {
            var deleted = await repo.DeleteAsync(id);
            return deleted ? Results.NoContent() : Results.NotFound();
        })
        .WithName("DeleteBook")
        .WithSummary("Delete a book by ID")
        .Produces(StatusCodes.Status204NoContent)
        .Produces(StatusCodes.Status404NotFound);
    }
}
