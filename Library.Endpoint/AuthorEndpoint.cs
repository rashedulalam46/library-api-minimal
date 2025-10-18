using Library.Application.Interfaces;
using Library.Domain.Entities;
using Microsoft.AspNetCore.Http;

namespace LibraryApiMinimal.Endpoint;

public static class AuthorEndpoint
{
    public static void MapAuthorEndpoints(this WebApplication app)
    {
        var group = app.MapGroup("/api/authors")
                       .WithTags("Authors");

        // ✅ GET all authors
        group.MapGet("/", async (IAuthorRepository repo) =>
        {
            var authors = await repo.GetAllAsync();
            return Results.Ok(authors);
        })
        .WithName("GetAllAuthors")
        .WithSummary("Get a list of all authors")
        .Produces<IEnumerable<Authors>>(StatusCodes.Status200OK);

        // ✅ GET author by ID
        group.MapGet("/{id:int}", async (IAuthorRepository repo, int id) =>
        {
            var author = await repo.GetByIdAsync(id);
            return author is not null ? Results.Ok(author) : Results.NotFound();
        })
        .WithName("GetAuthorById")
        .WithSummary("Get details of a specific author by ID")
        .Produces<Authors>(StatusCodes.Status200OK)
        .Produces(StatusCodes.Status404NotFound);

        // ✅ POST (Add new author)
        group.MapPost("/", async (IAuthorRepository repo, Authors author) =>
        {
            var created = await repo.AddAsync(author);
            return Results.Created($"/api/authors/{created.author_id}", created);
        })
        .WithName("CreateAuthor")
        .WithSummary("Add a new author")
        .Produces<Authors>(StatusCodes.Status201Created);

        // ✅ PUT (Update existing author)
        group.MapPut("/{id:int}", async (IAuthorRepository repo, int id, Authors updatedAuthor) =>
        {
            if (id != updatedAuthor.author_id)
                return Results.BadRequest("Author ID mismatch.");

            var author = await repo.UpdateAsync(updatedAuthor);
            return author is not null ? Results.Ok(author) : Results.NotFound();
        })
        .WithName("UpdateAuthor")
        .WithSummary("Update details of an existing author")
        .Produces<Authors>(StatusCodes.Status200OK)
        .Produces(StatusCodes.Status400BadRequest)
        .Produces(StatusCodes.Status404NotFound);

        // ✅ DELETE (Remove an author)
        group.MapDelete("/{id:int}", async (IAuthorRepository repo, int id) =>
        {
            var deleted = await repo.DeleteAsync(id);
            return deleted ? Results.NoContent() : Results.NotFound();
        })
        .WithName("DeleteAuthor")
        .WithSummary("Delete an author by ID")
        .Produces(StatusCodes.Status204NoContent)
        .Produces(StatusCodes.Status404NotFound);
    }
}
