using KayakCove.Application.DTOs;

namespace KayakCove.Web.ApiServices
{
    /// <summary>
    /// Class that handles OrderDetails related API calls from the UI layer.
    /// </summary>
    public class OrderDetailsApiService(IHttpClientFactory httpClient)
    {
        private readonly HttpClient _httpClient = httpClient.CreateClient("ApiClient");


        /// <summary>
        /// Calls the API GetAllOrderDetails.
        /// </summary>
        /// <returns>A list of OrderDetailsDtos.</returns>
        public async Task<IEnumerable<OrderDetailsDto>> GetAllOrderDetailsAsync()
        {
            return await _httpClient.GetFromJsonAsync<List<OrderDetailsDto>>("orderdetails");
        }


        /// <summary>
        /// Calls the API GetAllOrderDetailsForASpecificOrder.
        /// </summary>
        /// <returns>A list of OrderDetailsDtos for a specific order.</returns>
        public async Task<IEnumerable<OrderDetailsDto>> GetAllOrderDetailsForASpecificOrderAsync(int id)
        {
            return await _httpClient.GetFromJsonAsync<List<OrderDetailsDto>>($"orderdetails/{id}/allspecificorders");
        }


        /// <summary>
        /// Calls the API GetOrderDetailsById.
        /// </summary>
        /// <param name="id">Integer representing the id.</param>
        /// <returns>OrderDetailsDto object.</returns>
        public async Task<OrderDetailsDto> GetOrdeDetailsByIdAsync(int id)
        {
            var response = await _httpClient.GetFromJsonAsync<OrderDetailsDto>($"orderdetails/{id}");
            return response;
        }


        /// <summary>
        /// Calls the API CreateOrderDetails.
        /// </summary>
        /// <param name="orderDetailsDto">The object to be created.</param>
        /// <returns>The newly created object.</returns>
        public async Task<OrderDetailsDto> CreateOrderDetailsAsync(OrderDetailsDto orderDetailsDto)
        {
            var response = await _httpClient.PostAsJsonAsync("orderdetails", orderDetailsDto);
            var newOrderDetailsDto = await response.Content.ReadFromJsonAsync<OrderDetailsDto>();
            return newOrderDetailsDto;
        }


        /// <summary>
        /// Calls the API UpdateOrderDetails.
        /// </summary>
        /// <param name="orderDetailsDto">The object to be updated.</param>
        /// <returns>True for success otherwise false.</returns>
        public async Task<bool> UpdateOrderDetailsAsync(OrderDetailsDto orderDetailsDto)
        {
            var response = await _httpClient.PutAsJsonAsync($"orderdetails/{orderDetailsDto.Id}", orderDetailsDto);
            response.EnsureSuccessStatusCode();
            var result = await response.Content.ReadFromJsonAsync<bool>();
            return result;
        }


        /// <summary>
        /// Calls the API DeleteOrderDetails.
        /// </summary>
        /// <param name="id">Integer representing order id.</param>
        /// <returns>True for success otherwise false.</returns>
        public async Task<bool> DeleteOrderAsync(int id)
        {
            var response = await _httpClient.DeleteAsync($"orderdetails/{id}");
            response.EnsureSuccessStatusCode();
            var result = await response.Content.ReadFromJsonAsync<bool>();
            return result;
        }

    }
}
