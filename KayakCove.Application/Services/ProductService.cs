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

    public Task<IEnumerable<Product>> GetAllProductsAsync() => _productRepository.GetAllProductsAsync();
    public Task<Product> GetProductByIdAsync(int id) => _productRepository.GetProductByIdAsync(id);
    public Task AddProductAsync(Product product) => _productRepository.AddProductAsync(product);
    public Task UpdateProductAsync(Product product) => _productRepository.UpdateProductAsync(product);
    public Task DeleteProductAsync(int id) => _productRepository.DeleteProductAsync(id);
}
