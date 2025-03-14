using KayakCove.Domain.Entities;
using KayakCove.Infrastructure.Interfaces;

namespace KayakCove.Application.Services;

public class CategoryService
{
    private readonly ICategoryRepository _categoryRepository;

    public CategoryService(ICategoryRepository categoryRepository)
    {
        this._categoryRepository = categoryRepository;
    }

    public Task<IEnumerable<Category>> GetAllCategoriesAsync() => _categoryRepository.GetAllCategoriesAsync();
    public Task<Category> GetCategoryByIdAsync(int id) => _categoryRepository.GetCategoryByIdAsync(id);
    public Task CreateCategoryAsync(Category category) => _categoryRepository.CreateCategoryAsync(category);
    public Task UpdateCategoryAsync(Category category) => _categoryRepository.UpdateCategoryAsync(category);
    public Task DeleteCategoryAsync(int id) => _categoryRepository.DeleteCategoryAsync(id);
}
