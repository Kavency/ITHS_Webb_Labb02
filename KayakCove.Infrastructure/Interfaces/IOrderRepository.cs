using KayakCove.Domain.Entities;

namespace KayakCove.Infrastructure.Interfaces;

public interface IOrderRepository
{
    Task<IEnumerable<Order>> GetAllOrdersAsync();
    Task<Order> GetOrderByIdAsync(int id);
    Task<bool> CreateOrderAsync(Order order);
    Task<bool> UpdateOrderAsync(Order order);
    Task<bool> DeleteOrderAsync(int id);
}
