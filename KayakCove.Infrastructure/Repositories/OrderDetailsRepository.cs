using KayakCove.Domain.Entities;
using KayakCove.Infrastructure.Data;
using KayakCove.Infrastructure.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace KayakCove.Infrastructure.Repositories;

public class OrderDetailsRepository(ApplicationDbContext context) : IOrderDetailsRepository
{
    private readonly ApplicationDbContext _context = context;


    /// <summary>
    /// Fetch all order details from database.
    /// </summary>
    /// <returns>List of OrderDetails</returns>
    public async Task<IEnumerable<OrderDetails>> GetAllOrderDetailsAsync()
    {
        return await _context.OrderDetails.Include(p => p.Product).ToListAsync();
    }


    /// <summary>
    /// Fetch all order details with specific OrderId.
    /// </summary>
    /// <param name="id">Integer representing the Id of a specific order.</param>
    /// <returns>List of OrderDetails for a specific order.</returns>
    public async Task<IEnumerable<OrderDetails>> GetAllOrderDetailsForASpecificOrderAsync(int orderId)
    {
        return await _context.OrderDetails.Where(o => o.OrderId == orderId).Include(p => p.Product).ToListAsync();
    }


    /// <summary>
    /// Fetches a single OrderDetail based on Id.
    /// </summary>
    /// <param name="id">Integer representing the Id of an OrderDetail.</param>
    /// <returns>An OrderDetail object</returns>
    public async Task<OrderDetails> GetOrderDetailsByIdAsync(int id)
    {
        return await _context.OrderDetails.FindAsync(id);
    }


    /// <summary>
    /// Add a new OrderDetail to the database.
    /// </summary>
    /// <param name="orderDetails">OrderDetails object representing the new OrderDetail.</param>
    /// <returns>The OrderDetails object created.</returns>
    public async Task<OrderDetails> CreateOrderDetailsAsync(OrderDetails orderDetails)
    {
        await _context.OrderDetails.AddAsync(orderDetails);
        await _context.SaveChangesAsync();
        return orderDetails;
    }


    /// <summary>
    /// Insert an updated OrderDetails object to the database.
    /// </summary>
    /// <param name="orderDetails">OrderDetails object that should be updated.</param>
    /// <returns>Returns true for success otherwise false.</returns>
    public async Task<bool> UpdateOrderDetailsAsync(OrderDetails orderDetails)
    {
        _context.OrderDetails.Update(orderDetails);
        var result = await _context.SaveChangesAsync();
        if (result > 0) return true;
        else return false;
    }


    /// <summary>
    /// Delete an OrderDetails object based on Id.
    /// </summary>
    /// <param name="id">Integer representing the OrderDetails id.</param>
    /// <returns>True for success otherwise false.</returns>
    public async Task<bool> DeleteOrderDetailsAsync(int id)
    {
        var orderDetailsToDelete = await _context.Orders.FindAsync(id);
        if (orderDetailsToDelete is null) return false;

        _context.Orders.Remove(orderDetailsToDelete);
        await _context.SaveChangesAsync();
        return true;
    }
}
