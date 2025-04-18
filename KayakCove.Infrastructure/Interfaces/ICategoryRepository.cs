using KayakCove.Domain.Entities;

namespace KayakCove.Infrastructure.Interfaces;

public interface ICategoryRepository
{
    Task<IEnumerable<Category>> GetAllCategoriesAsync();
    Task<Category> GetCategoryByIdAsync(int id);
    Task CreateCategoryAsync(Category category);
    Task UpdateCategoryAsync(Category category);
    Task<bool> DeleteCategoryAsync(int id);
}
