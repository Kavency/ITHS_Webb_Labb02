﻿using KayakCove.Domain.Entities;
using KayakCove.Infrastructure.Data;
using KayakCove.Infrastructure.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace KayakCove.Infrastructure.Repositories;

public class OrderRepository(ApplicationDbContext context) : IOrderRepository
{
    private readonly ApplicationDbContext _context = context;


    /// <summary>
    /// Fetch all orders from database.
    /// </summary>
    /// <returns>List of Orders</returns>
    public async Task<IEnumerable<Order>> GetAllOrdersAsync()
    {
        return await _context.Orders.Include(u => u.User).ToListAsync();
    }


    /// <summary>
    /// Fetches a single order based on Id.
    /// </summary>
    /// <param name="id">Integer representing the Id of an order.</param>
    /// <returns>An Order object</returns>
    public async Task<Order> GetOrderByIdAsync(int id)
    {
        return await _context.Orders.Include(u => u.User).FirstOrDefaultAsync(x => x.Id == id);
    }


    /// <summary>
    /// Add a new order to the database.
    /// </summary>
    /// <param name="order">Order object representing the new order.</param>
    /// <returns>Order object created.</returns>
    public async Task<Order> CreateOrderAsync(Order order)
    {
        await _context.Orders.AddAsync(order);
        await _context.SaveChangesAsync();
        return order;
    }
    

    /// <summary>
    /// Insert an update order object to the database.
    /// </summary>
    /// <param name="order">Order object that should be updated.</param>
    /// <returns>Returns true for success otherwise false.</returns>
    public async Task<bool> UpdateOrderAsync(Order order)
    {
        _context.Orders.Update(order);
        var result = await _context.SaveChangesAsync();
        if (result > 0) return true;
        else return false;
    }


    /// <summary>
    /// Delete an order based on Id.
    /// </summary>
    /// <param name="id">Integer representing the order id.</param>
    /// <returns>True for success otherwise false.</returns>
    public async Task<bool> DeleteOrderAsync(int id)
    {
        var orderToDelete = await _context.Orders.FindAsync(id);
        if (orderToDelete is null) return false;

        _context.Orders.Remove(orderToDelete);
        await _context.SaveChangesAsync();
        return true;
    }
}
