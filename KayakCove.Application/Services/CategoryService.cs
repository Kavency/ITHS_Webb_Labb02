using KayakCove.Application.DTOs;
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

    public async Task<IEnumerable<CategoryDto>> GetAllCategoriesAsync()
    {
        var categories = await _categoryRepository.GetAllCategoriesAsync();
        
        var categoryDtos = categories.Select(category => new CategoryDto
        {
            Id = category.Id,
            Name = category.Name
        });

        return categoryDtos;
    }
    public async Task<CategoryDto> GetCategoryByIdAsync(int id)
    {
        var entity = await _categoryRepository.GetCategoryByIdAsync(id);
        var categoryDto = ConvertEntityToDto(entity);
        return categoryDto;
    }
    public async Task CreateCategoryAsync(CategoryDto categoryDto)
    {
        var entity = ConvertDtoToEntity(categoryDto);
        await _categoryRepository.CreateCategoryAsync(entity);
    }

    public async Task UpdateCategoryAsync(CategoryDto categoryDto)
    {
        var entity = await _categoryRepository.GetCategoryByIdAsync(categoryDto.Id);

        entity.Name = categoryDto.Name;

        await _categoryRepository.UpdateCategoryAsync(entity);
    }

    public async Task<bool> DeleteCategoryAsync(int id)
    {
        var result = await _categoryRepository.DeleteCategoryAsync(id);
        return result;
    }

    private Category ConvertDtoToEntity(CategoryDto Dto)
    {
        return new Category { Id = Dto.Id, Name = Dto.Name };
    }

    private CategoryDto ConvertEntityToDto(Category Entity)
    {
        return new CategoryDto { Id = Entity.Id, Name = Entity.Name };
    }

}
