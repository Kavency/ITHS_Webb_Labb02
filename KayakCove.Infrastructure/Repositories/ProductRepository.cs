using KayakCove.Domain.Entities;
using KayakCove.Infrastructure.Data;
using KayakCove.Infrastructure.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace KayakCove.Infrastructure.Repositories;

class ProductRepository : IProductRepository
{
    private readonly ApplicationDbContext _context;

    public ProductRepository(ApplicationDbContext context)
    {
        this._context = context;
    }

    public async Task<IEnumerable<Product>> GetAllProductsAsync()
    {
        return await _context.Products.ToListAsync();
    }

    public async Task<Product> GetProductByIdAsync(int id)
    {
        return await _context.Products.FindAsync(id);
    }
    
    public async Task AddProductAsync(Product product)
    {
        _context.Products.Add(product);
        await _context.SaveChangesAsync();
    }

    public async Task UpdateProductAsync(Product product)
    {
        _context.Products.Update(product);
        await _context.SaveChangesAsync();
    }
 
    public async Task DeleteProductAsync(int id)
    {
        var product = await _context.Products.FindAsync(id);

        if (product is not null)
        {
            _context.Products.Remove(product);
            await _context.SaveChangesAsync();
        }
    }
}
