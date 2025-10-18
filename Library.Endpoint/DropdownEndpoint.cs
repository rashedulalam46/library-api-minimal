using Library.Application.DTOs;
using Library.Application.Interfaces;
using Microsoft.AspNetCore.Http;

namespace LibraryApiMinimal.Endpoint;

public static class DropdownEndpoint
{
    public static void MapDropdownEndpoints(this WebApplication app)
    {
        var group = app.MapGroup("/api/dropdown")
                       .WithTags("Dropdowns");

        // ✅ GET: /api/dropdown/countries
        group.MapGet("/countries", async (IDropdownRepository repo) =>
        {
            var countries = await repo.GetCountryDropdownAsync();
            return Results.Ok(countries);
        })
        .WithName("GetCountriesDropdown")
        .WithSummary("Get list of countries for dropdown")
        .Produces<IEnumerable<DropdownItem>>(StatusCodes.Status200OK);

        // ✅ GET: /api/dropdown/authors
        group.MapGet("/authors", async (IDropdownRepository repo) =>
        {
            var authors = await repo.GetAuthorDropdownAsync();
            return Results.Ok(authors);
        })
        .WithName("GetAuthorsDropdown")
        .WithSummary("Get list of authors for dropdown")
        .Produces<IEnumerable<DropdownItem>>(StatusCodes.Status200OK);

        // ✅ GET: /api/dropdown/publishers
        group.MapGet("/publishers", async (IDropdownRepository repo) =>
        {
            var publishers = await repo.GetPublisherDropdownAsync();
            return Results.Ok(publishers);
        })
        .WithName("GetPublishersDropdown")
        .WithSummary("Get list of publishers for dropdown")
        .Produces<IEnumerable<DropdownItem>>(StatusCodes.Status200OK);

        // ✅ GET: /api/dropdown/categories
        group.MapGet("/categories", async (IDropdownRepository repo) =>
        {
            var categories = await repo.GetCategoryDropdownAsync();
            return Results.Ok(categories);
        })
        .WithName("GetCategoriesDropdown")
        .WithSummary("Get list of categories for dropdown")
        .Produces<IEnumerable<DropdownItem>>(StatusCodes.Status200OK);
    }
}
