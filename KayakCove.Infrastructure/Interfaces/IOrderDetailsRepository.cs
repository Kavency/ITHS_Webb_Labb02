using KayakCove.Domain.Entities;

namespace KayakCove.Infrastructure.Interfaces;

interface IOrderDetailsRepository
{
    Task<IEnumerable<OrderDetails>> GetAllOrdersAsync();
    Task<OrderDetails> GetOrderByIdAsync(int id);
    Task<OrderDetails> CreateOrderAsync(OrderDetails orderDetails);
    Task<OrderDetails> UpdateOrderAsync(OrderDetails orderDetails);
    Task<bool> DeleteOrderAsync(int id);
}
