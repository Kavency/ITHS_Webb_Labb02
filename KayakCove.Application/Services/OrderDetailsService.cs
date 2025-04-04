using KayakCove.Application.DTOs;
using KayakCove.Domain.Entities;
using KayakCove.Infrastructure.Interfaces;

namespace KayakCove.Application.Services;

public class OrderDetailsService(IOrderDetailsRepository orderDetailsRepository)
{
    private readonly IOrderDetailsRepository _orderDetailsRepository = orderDetailsRepository;


    /// <summary>
    /// Get all OrderDetails async by calling the repository layer.
    /// </summary>
    /// <returns>A list of OrderDetailsDtos.</returns>
    public async Task<IEnumerable<OrderDetailsDto>> GetAllOrderDetailsAsync()
    {
        var orderDetails = await _orderDetailsRepository.GetAllOrderDetailsAsync();
        return EntityAndDtoConvertion(orderDetails) as IEnumerable<OrderDetailsDto>;
    }


    /// <summary>
    /// Get a specific OrderDetails by Id from the repository layer.
    /// </summary>
    /// <param name="id">Integer representing the Id.</param>
    /// <returns>A single OrderDetailsDto object.</returns>
    public async Task<OrderDetailsDto> GetOrderDetailsByIdAsync(int id)
    {
        var orderDetails = await _orderDetailsRepository.GetOrderDetailsByIdAsync(id);
        return EntityAndDtoConvertion(orderDetails) as OrderDetailsDto;
    }


    /// <summary>
    /// Create a new OrderDetails by passing it to the repository layer.
    /// </summary>
    /// <param name="orderDetialsDto">Dto to be converted.</param>
    /// <returns>Returns true for success otherwise false.</returns>
    public async Task<OrderDetailsDto> CreateOrderDetailsAsync(OrderDetailsDto orderDetailsDto)
    {
        var orderDetails = EntityAndDtoConvertion(orderDetailsDto) as OrderDetails;
        var result = await _orderDetailsRepository.CreateOrderDetailsAsync(orderDetails);
        var newOrderDetailsDto = EntityAndDtoConvertion(orderDetails) as OrderDetailsDto;
        return newOrderDetailsDto;
    }


    /// <summary>
    /// Update an OrderDetails by passing it to the repository layer.
    /// </summary>
    /// <param name="orderDetailsDto">Dto to be converted.</param>
    /// <returns>Returns true for success otherwise false.</returns>
    public async Task<bool> UpdateOrderDetailsAsync(OrderDetailsDto orderDetailsDto)
    {
        var orderDetails = EntityAndDtoConvertion(orderDetailsDto) as OrderDetails;
        var result = await _orderDetailsRepository.UpdateOrderDetailsAsync(orderDetails);
        return result;
    }


    /// <summary>
    /// Pass along the OrderDetails id to the repository layer.
    /// </summary>
    /// <param name="id">Integer representing the Id.</param>
    /// <returns>Returns true for success otherwise false.</returns>
    public async Task<bool> DeleteOrderDetailsAsync(int id)
    {
        return await _orderDetailsRepository.DeleteOrderDetailsAsync(id);
    }


    /// <summary>
    /// Converts the input containing either a list of OrderDetails, a single OrderDetails object or a single OrderDetailsDto.
    /// </summary>
    /// <typeparam name="TInput">Generic type placeholder for input.</typeparam>
    /// <param name="input">The input that needs to be converted.</param>
    /// <returns>Either a single OrderDetails, a single DTO or a list of DTOs depending on input.</returns>
    /// <exception cref="InvalidOperationException">Throws an exception if input an unsupported type.</exception>
    private object EntityAndDtoConvertion<TInput>(TInput input)
    {
        if (input is IEnumerable<OrderDetails> orderList)
        {
            var dtoList = orderList.Select(o => new OrderDetailsDto
            {
                Id = o.Id,
                OrderId = o.OrderId,
                ProductId = o.ProductId,
                Quantity = o.Quantity,
                UnitPrice = o.UnitPrice
            });

            return dtoList;
        }
        else if (input is OrderDetails order)
        {
            OrderDetailsDto newOrderDto = new OrderDetailsDto
            {
                Id = order.Id,
                OrderId = order.OrderId,
                ProductId = order.ProductId,
                Quantity = order.Quantity,
                UnitPrice = order.UnitPrice
            };

            return newOrderDto;
        }
        else if (input is OrderDetailsDto orderDto)
        {
            OrderDetails newOrder = new OrderDetails
            {
                Id = orderDto.Id,
                OrderId = orderDto.OrderId,
                ProductId = orderDto.ProductId,
                Quantity = orderDto.Quantity,
                UnitPrice = orderDto.UnitPrice
            };

            return newOrder;
        }

        throw new InvalidOperationException("The input is of an unsupported type.");
    }
}
