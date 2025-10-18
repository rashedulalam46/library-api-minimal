using Library.Application.Interfaces;
using Library.Domain.Entities;
using Microsoft.AspNetCore.Http;

namespace LibraryApiMinimal.Endpoint;

public static class CategoryEndpoint
{
    public static void MapCategoryEndpoints(this WebApplication app)
    {
        var group = app.MapGroup("/api/categories")
                       .WithTags("Categories");

        // GET all categories
        group.MapGet("/", async (ICategoryRepository repo) =>
        {
            var categories = await repo.GetAllAsync();
            return Results.Ok(categories);
        })
        .WithName("GetAllCategories")
        .WithSummary("Get a list of all categories")
        .Produces<IEnumerable<Categories>>(StatusCodes.Status200OK);

        // GET category by ID
        group.MapGet("/{id:int}", async (ICategoryRepository repo, int id) =>
        {
            var category = await repo.GetByIdAsync(id);
            return category is not null ? Results.Ok(category) : Results.NotFound();
        })
        .WithName("GetCategoryById")
        .WithSummary("Get details of a specific category by ID")
        .Produces<Categories>(StatusCodes.Status200OK)
        .Produces(StatusCodes.Status404NotFound);

        // POST (Add new category)
        group.MapPost("/", async (ICategoryRepository repo, Categories category) =>
        {
            var created = await repo.AddAsync(category);
            return Results.Created($"/api/categories/{created.category_id}", created);
        })
        .WithName("CreateCategory")
        .WithSummary("Add a new category")
        .Produces<Categories>(StatusCodes.Status201Created);

        // PUT (Update existing category)
        group.MapPut("/{id:int}", async (ICategoryRepository repo, int id, Categories updatedCategory) =>
        {
            if (id != updatedCategory.category_id)
                return Results.BadRequest("Category ID mismatch.");

            var category = await repo.UpdateAsync(updatedCategory);
            return category is not null ? Results.Ok(category) : Results.NotFound();
        })
        .WithName("UpdateCategory")
        .WithSummary("Update details of an existing category")
        .Produces<Categories>(StatusCodes.Status200OK)
        .Produces(StatusCodes.Status400BadRequest)
        .Produces(StatusCodes.Status404NotFound);

        // DELETE (Remove a category)
        group.MapDelete("/{id:int}", async (ICategoryRepository repo, int id) =>
        {
            var deleted = await repo.DeleteAsync(id);
            return deleted ? Results.NoContent() : Results.NotFound();
        })
        .WithName("DeleteCategory")
        .WithSummary("Delete a category by ID")
        .Produces(StatusCodes.Status204NoContent)
        .Produces(StatusCodes.Status404NotFound);
    }
}
