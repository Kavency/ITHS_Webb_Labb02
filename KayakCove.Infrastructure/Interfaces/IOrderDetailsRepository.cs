using KayakCove.Domain.Entities;

namespace KayakCove.Infrastructure.Interfaces;

public interface IOrderDetailsRepository
{
    Task<IEnumerable<OrderDetails>> GetAllOrdersAsync();
    Task<OrderDetails> GetOrderByIdAsync(int id);
    Task<bool> CreateOrderAsync(OrderDetails orderDetails);
    Task<bool> UpdateOrderAsync(OrderDetails orderDetails);
    Task<bool> DeleteOrderAsync(int id);
}
