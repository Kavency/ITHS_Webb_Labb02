using KayakCove.Infrastructure.Interfaces;
using KayakCove.Domain.Entities;
using KayakCove.Application.DTOs;

namespace KayakCove.Application.Services;

class OrderService(IOrderRepository orderRepository)
{
    private readonly IOrderRepository _orderRepository = orderRepository;


    /// <summary>
    /// Get all orders async by calling the repository layer.
    /// </summary>
    /// <returns>A list of OrderDtos.</returns>
    public async Task<IEnumerable<OrderDto>> GetAllOrdersAsync()
    {
        var orders = await _orderRepository.GetAllOrdersAsync();
        return EntityAndDtoConvertion(orders) as IEnumerable<OrderDto>;
    }


    /// <summary>
    /// Get a specific order by Id from the repository layer.
    /// </summary>
    /// <param name="id">Integer representing the Id.</param>
    /// <returns>A single OrderDto object.</returns>
    public async Task<OrderDto> GetOrderByIdAsync(int id)
    {
        var order = await _orderRepository.GetOrderByIdAsync(id);
        return EntityAndDtoConvertion(order) as OrderDto;
    }


    /// <summary>
    /// Create a new order by converting OrderDto to Order object and passing it to the repository layer.
    /// </summary>
    /// <param name="orderDto">Dto to be converted.</param>
    /// <returns>Returns true for success otherwise false.</returns>
    public async Task<bool> CreateOrderAsync(OrderDto orderDto)
    {
        var order = EntityAndDtoConvertion(orderDto) as Order;
        var result = await _orderRepository.CreateOrderAsync(order);
        return result;
    }


    /// <summary>
    /// Update an order by converting OrderDto to Order Object and passing it to the repository layer.
    /// </summary>
    /// <param name="orderDto">Dto to be converted.</param>
    /// <returns>Returns true for success otherwise false.</returns>
    public async Task<bool> UpdateOrderAsync(OrderDto orderDto)
    {
        var order = EntityAndDtoConvertion(orderDto) as Order;
        var result = await _orderRepository.UpdateOrderAsync(order);
        return result;
    }


    /// <summary>
    /// Pass along the order id to the repository layer.
    /// </summary>
    /// <param name="id">Integer representing the Id.</param>
    /// <returns>Returns true for success otherwise false.</returns>
    public async Task<bool> DeleteOrderAsync(int id)
    {
        return await _orderRepository.DeleteOrderAsync(id);
    }


    /// <summary>
    /// Converts the input containing either a list of Orders, a single Order object or a single OrderDto.
    /// </summary>
    /// <typeparam name="TInput">Generic type placeholder for input.</typeparam>
    /// <param name="input">The input that needs to be converted.</param>
    /// <returns>Either a single Order, a single DTO or a list of DTOs depending on input.</returns>
    /// <exception cref="InvalidOperationException">Throws an exception if input an unsupported type.</exception>
    private object EntityAndDtoConvertion<TInput>(TInput input)
    {
        if(input is IEnumerable<Order> orderList)
        {
            var dtoList = orderList.Select(o => new OrderDto 
            {
                Id = o.Id,
                UserId = o.UserId,
                OrderDate = o.OrderDate,
                OrderStatus = o.OrderStatus,
                GrandTotal = o.GrandTotal
            });

            return dtoList;
        }
        else if(input is Order order)
        {
            OrderDto newOrderDto = new OrderDto 
            { 
                Id = order.Id, 
                UserId = order.UserId,
                OrderDate = order.OrderDate,
                OrderStatus = order.OrderStatus,
                GrandTotal = order.GrandTotal
            };

            return newOrderDto;
        }
        else if (input is OrderDto orderDto)
        {
            Order newOrder = new Order
            {
                Id = orderDto.Id,
                UserId = orderDto.UserId,
                OrderDate = orderDto.OrderDate,
                OrderStatus = orderDto.OrderStatus,
                GrandTotal = orderDto.GrandTotal
            };

            return newOrder;
        }

        throw new InvalidOperationException("The input is of an unsupported type.");
    }
}
