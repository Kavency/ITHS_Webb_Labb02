using KayakCove.Application.DTOs;
using KayakCove.Application.Services;
using Microsoft.AspNetCore.Mvc;

namespace KayakCove.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class OrderController(OrderService orderService) : ControllerBase
    {
        private readonly OrderService _orderService = orderService;


        /// <summary>
        /// Get all orders from database.
        /// </summary>
        /// <returns>200 Ok with a list of OrderDtos if successful otherwise a 404 Not Found.</returns>
        [HttpGet]
        public async Task<IActionResult> GetAllOrders()
        {
            var result = await _orderService.GetAllOrdersAsync();
            return result == null ? NotFound() : Ok(result);
        }


        /// <summary>
        /// Get an order using id.
        /// </summary>
        /// <param name="id">Integer representing the order id.</param>
        /// <returns>200 Ok with object if successful otherwise 404 Not Found.</returns>
        [HttpGet("{id}")]
        public async Task<IActionResult> GetOrderById(int id)
        {
            var result = await _orderService.GetOrderByIdAsync(id);
            return result == null ? NotFound() : Ok(result);
        }


        /// <summary>
        /// Create a new order.
        /// </summary>
        /// <param name="orderDto">The OrderDto object to be created.</param>
        /// <returns>201 created with the newly created object.</returns>
        [HttpPost]
        public async Task<IActionResult> CreateOrder([FromBody]OrderDto orderDto)
        {
            await _orderService.CreateOrderAsync(orderDto);
            return CreatedAtAction(nameof(GetOrderById), new { id = orderDto.Id, orderDto });
        }


        /// <summary>
        /// Update an order.
        /// </summary>
        /// <param name="id">Integer representing the order id.</param>
        /// <param name="orderDto">Order Dto object to be updated.</param>
        /// <returns>204 no content if successful, 404 not found if no order is found in DB and 400 bad request if id and Order.Id is a mismatch.</returns>
        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateOrder(int id, [FromBody]OrderDto orderDto)
        {
            if (id != orderDto.Id) return BadRequest();
            var updateSuccessful = await _orderService.UpdateOrderAsync(orderDto);
            if (!updateSuccessful) return NotFound();
            return NoContent();
        }


        /// <summary>
        /// Delete order using order id.
        /// </summary>
        /// <param name="id">Integer representing order id</param>
        /// <returns>204 No content is successful otherwise 404 Not found.</returns>
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteOrder(int id)
        {
            var deleteSuccessful = await _orderService.DeleteOrderAsync(id);
            if (!deleteSuccessful) return NotFound();
            return NoContent();
        }
    }
}
