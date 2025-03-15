using KayakCove.Application.DTOs;
using KayakCove.Domain.Entities;
using KayakCove.Infrastructure.Interfaces;

namespace KayakCove.Application.Services;

public class ProductService
{
    private readonly IProductRepository _productRepository;

    public ProductService(IProductRepository productRepository)
    {
        this._productRepository = productRepository;
    }

    public async Task<IEnumerable<ProductDto>> GetAllProductsAsync()
    {
        var products = await _productRepository.GetAllProductsAsync();

        var productDtos = products.Select(p => new ProductDto
        {
            Id = p.Id,
            Name = p.Name,
            Description = p.Description,
            ImageUri = p.ImageUri,
            Price = p.Price,
            Quantity = p.Quantity,
            HasExpired = p.HasExpired,
            CategoryId = p.CategoryId
        });

        return productDtos;
    }

    public async Task<ProductDto> GetProductByIdAsync(int id)
    {
        var entity = await _productRepository.GetProductByIdAsync(id);
        var productDto = ConvertEntityToDto(entity);
        return productDto;
    }

    public async Task<bool> CreateProductAsync(ProductDto dto)
    {
        var product = ConvertDtoToEntity(dto);
        var result = await _productRepository.CreateProductAsync(product);
        return result;
    }
    public async Task<bool> UpdateProductAsync(ProductDto dto)
    {
        var product = await _productRepository.GetProductByIdAsync(dto.Id);

        product.Name = dto.Name;
        product.Description = dto.Description;
        product.ImageUri = dto.ImageUri;
        product.Price = dto.Price;
        product.Quantity = dto.Quantity;
        product.HasExpired = dto.HasExpired;
        product.CategoryId = dto.CategoryId;

        var result = await _productRepository.UpdateProductAsync(product);
        return result;
    }
    public async Task<bool> DeleteProductAsync(int id)
    {
        var result = await _productRepository.DeleteProductAsync(id);
        return result;
    }


    private ProductDto ConvertEntityToDto(Product entity)
    {
        return new ProductDto
        {
            Id = entity.Id,
            Name = entity.Name,
            Description = entity.Description,
            ImageUri = entity.ImageUri,
            Price = entity.Price,
            Quantity = entity.Quantity,
            HasExpired = entity.HasExpired,
            CategoryId = entity.CategoryId
        };
    }


    private Product ConvertDtoToEntity(ProductDto dto)
    {
        return new Product
        {
            Id = dto.Id,
            Name = dto.Name,
            Description = dto.Description,
            ImageUri = dto.ImageUri,
            Price = dto.Price,
            Quantity = dto.Quantity,
            HasExpired = dto.HasExpired,
            CategoryId = dto.CategoryId
        };
    }
}
