using KayakCove.Domain.Entities;

namespace KayakCove.Infrastructure.Interfaces;

interface IOrder
{
    Task<IEnumerable<Category>> GetAllOrdersAsync();
    Task<Category> GetOrderByIdAsync(int id);
    Task CreateOrderAsync(Category category);
    Task UpdateOrderAsync(Category category);
    Task<bool> DeleteOrderAsync(int id);
}
