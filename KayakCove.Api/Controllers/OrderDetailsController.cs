using KayakCove.Application.DTOs;
using KayakCove.Application.Services;
using Microsoft.AspNetCore.Mvc;

namespace KayakCove.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class OrderDetailsController(OrderDetailsService orderDetailsService) : ControllerBase
    {
        private readonly OrderDetailsService _orderDetailsService = orderDetailsService;


        /// <summary>
        /// Get all OrderDetails from database.
        /// </summary>
        /// <returns>200 Ok with a list of OrderDetailsDtos if successful otherwise a 404 Not Found.</returns>
        [HttpGet]
        public async Task<IActionResult> GetAllOrderDetails()
        {
            var result = await _orderDetailsService.GetAllOrderDetailsAsync();
            return result == null ? NotFound() : Ok(result);
        }


        /// <summary>
        /// Get an OrderDetails using id.
        /// </summary>
        /// <param name="id">Integer representing the id.</param>
        /// <returns>200 Ok with object if successful otherwise 404 Not Found.</returns>
        [HttpGet("{id}")]
        public async Task<IActionResult> GetOrderDetailsById(int id)
        {
            var result = await _orderDetailsService.GetOrderDetailsByIdAsync(id);
            return result == null ? NotFound() : Ok(result);
        }


        /// <summary>
        /// Create a new OrderDetails.
        /// </summary>
        /// <param name="orderDetailsDto">The OrderDto object to be created.</param>
        /// <returns>Status Ok 200 with the newly created object.</returns>
        [HttpPost]
        public async Task<IActionResult> CreateOrderDetails([FromBody] OrderDetailsDto orderDetailsDto)
        {
            var newOrderDetailsDto = await _orderDetailsService.CreateOrderDetailsAsync(orderDetailsDto);
            return Ok(newOrderDetailsDto);
        }


        /// <summary>
        /// Update an OrderDetails.
        /// </summary>
        /// <param name="id">Integer representing the id.</param>
        /// <param name="orderDetailsDto">DTO object to be updated.</param>
        /// <returns>204 no content if successful, 404 not found if no order is found in DB and 400 bad request if id and Order.Id is a mismatch.</returns>
        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateOrderDetails(int id, [FromBody] OrderDetailsDto orderDetailsDto)
        {
            if (id != orderDetailsDto.Id) return BadRequest();
            var updateSuccessful = await _orderDetailsService.UpdateOrderDetailsAsync(orderDetailsDto);
            if (!updateSuccessful) return NotFound();
            return NoContent();
        }


        /// <summary>
        /// Delete OrderDetails using id.
        /// </summary>
        /// <param name="id">Integer representing the id</param>
        /// <returns>204 No content is successful otherwise 404 Not found.</returns>
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteOrder(int id)
        {
            var deleteSuccessful = await _orderDetailsService.DeleteOrderDetailsAsync(id);
            if (!deleteSuccessful) return NotFound();
            return NoContent();
        }
    }
}
