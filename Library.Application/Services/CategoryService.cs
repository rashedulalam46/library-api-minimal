using Library.Application.Interfaces;
using Library.Domain.Entities;

namespace Library.Application.Services;

public class CategoryService
{
    private readonly ICategoryRepository _repo;
       private readonly Random _random = new Random();

    public CategoryService(ICategoryRepository repo)
    {
        _repo = repo;
    }


    public Task<IEnumerable<Categories>> GetCategoriesAsync()
    {
        return _repo.GetAllAsync();
    }
    public Task<Categories?> GetCategoryAsync(int id)
    {
        return _repo.GetByIdAsync(id);
    }
    public async Task<Categories> AddCategoryAsync(Categories category)
    {
        int categoryId;
        do
        {
            categoryId = _random.Next(1000, 9999);
        }
        while (await _repo.ExistsByCategoryIdAsync(categoryId));

        category.category_id = categoryId;
        category.create_date = DateTime.UtcNow;
        return await _repo.AddAsync(category);
    }
    public Task<Categories?> UpdateCategoryAsync(Categories category)
    {
        return _repo.UpdateAsync(category);
    }
    public Task<bool> DeleteCategoryAsync(int id)
    {
        return _repo.DeleteAsync(id);
    }
}