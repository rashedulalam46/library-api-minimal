using Library.Application.Interfaces;
using Library.Domain.Entities;

namespace LibraryApiMinimal.Endpoint;

public static class PublisherEndpoint
{
    public static void MapPublisherEndpoints(this WebApplication app)
    {
        var group = app.MapGroup("/api/publishers")
                       .WithTags("Publishers");

        // ✅ GET all publishers
        group.MapGet("/", async (IPublisherRepository repo) =>
        {
            var publishers = await repo.GetAllAsync();
            return Results.Ok(publishers);
        })
        .WithName("GetAllPublishers")
        .WithSummary("Get a list of all publishers")
        .Produces<IEnumerable<Publishers>>(StatusCodes.Status200OK);

        // ✅ GET publisher by ID
        group.MapGet("/{id:int}", async (IPublisherRepository repo, int id) =>
        {
            var publisher = await repo.GetByIdAsync(id);
            return publisher is not null ? Results.Ok(publisher) : Results.NotFound();
        })
        .WithName("GetPublisherById")
        .WithSummary("Get details of a specific publisher by ID")
        .Produces<Publishers>(StatusCodes.Status200OK)
        .Produces(StatusCodes.Status404NotFound);

        // ✅ POST (Add new publisher)
        group.MapPost("/", async (IPublisherRepository repo, Publishers publisher) =>
        {
            var created = await repo.AddAsync(publisher);
            return Results.Created($"/api/publishers/{created.publisher_id}", created);
        })
        .WithName("CreatePublisher")
        .WithSummary("Add a new publisher")
        .Produces<Publishers>(StatusCodes.Status201Created);

        // ✅ PUT (Update existing publisher)
        group.MapPut("/{id:int}", async (IPublisherRepository repo, int id, Publishers updatedPublisher) =>
        {
            if (id != updatedPublisher.publisher_id)
                return Results.BadRequest("Publisher ID mismatch.");

            var publisher = await repo.UpdateAsync(updatedPublisher);
            return publisher is not null ? Results.Ok(publisher) : Results.NotFound();
        })
        .WithName("UpdatePublisher")
        .WithSummary("Update details of an existing publisher")
        .Produces<Publishers>(StatusCodes.Status200OK)
        .Produces(StatusCodes.Status400BadRequest)
        .Produces(StatusCodes.Status404NotFound);

        // ✅ DELETE (Remove a publisher)
        group.MapDelete("/{id:int}", async (IPublisherRepository repo, int id) =>
        {
            var deleted = await repo.DeleteAsync(id);
            return deleted ? Results.NoContent() : Results.NotFound();
        })
        .WithName("DeletePublisher")
        .WithSummary("Delete a publisher by ID")
        .Produces(StatusCodes.Status204NoContent)
        .Produces(StatusCodes.Status404NotFound);
    }
}
