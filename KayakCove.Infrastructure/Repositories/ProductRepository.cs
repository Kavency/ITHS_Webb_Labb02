using KayakCove.Domain.Entities;
using KayakCove.Infrastructure.Data;
using KayakCove.Infrastructure.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace KayakCove.Infrastructure.Repositories;

public class ProductRepository : IProductRepository
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
    
    public async Task<bool> CreateProductAsync(Product product)
    {
        _context.Products.Add(product);
        var result = await _context.SaveChangesAsync();
        if (result > 0)
            return true;
        else
            return false;
    }

    public async Task<bool> UpdateProductAsync(Product product)
    {
        _context.Products.Update(product);
        var result = await _context.SaveChangesAsync();
        if (result > 0) 
            return true;
        else 
            return false;
    }
 
    public async Task<bool> DeleteProductAsync(int id)
    {
        var product = await _context.Products.FindAsync(id);
        if (product is null) return false;

        _context.Products.Remove(product);
        await _context.SaveChangesAsync();
        return true;
    }
}
