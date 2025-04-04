﻿using KayakCove.Domain.Entities;

namespace KayakCove.Infrastructure.Interfaces;

public interface IOrderDetailsRepository
{
    Task<IEnumerable<OrderDetails>> GetAllOrderDetailsAsync();
    Task<OrderDetails> GetOrderDetailsByIdAsync(int id);
    Task<OrderDetails> CreateOrderDetailsAsync(OrderDetails orderDetails);
    Task<bool> UpdateOrderDetailsAsync(OrderDetails orderDetails);
    Task<bool> DeleteOrderDetailsAsync(int id);
}
