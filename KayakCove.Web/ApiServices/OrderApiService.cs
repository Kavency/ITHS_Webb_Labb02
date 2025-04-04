using KayakCove.Application.DTOs;

namespace KayakCove.Web.ApiServices;

/// <summary>
/// Class that handles order related API calls from the UI layer.
/// </summary>
public class OrderApiService(IHttpClientFactory httpClient)
{
    private readonly HttpClient _httpClient = httpClient.CreateClient("ApiClient");


    /// <summary>
    /// Calls the API GetAllOrders.
    /// </summary>
    /// <returns>A list of OrderDtos.</returns>
    public async Task<IEnumerable<OrderDto>> GetAllOrdersAsync()
    {
        return await _httpClient.GetFromJsonAsync<List<OrderDto>>("order");
    }


    /// <summary>
    /// Calls the API GetOrderById.
    /// </summary>
    /// <param name="id">Integer representing the order id.</param>
    /// <returns>OrderDto object.</returns>
    public async Task<OrderDto> GetCategoryByIdAsync(int id)
    {
        var response = await _httpClient.GetFromJsonAsync<OrderDto>($"order/{id}");
        return response;
    }


    /// <summary>
    /// Calls the API CreateOrder.
    /// </summary>
    /// <param name="orderDto">The object to be created.</param>
    /// <returns>The creaded OrderDto object.</returns>
    public async Task<OrderDto> CreateCategoryAsync(OrderDto orderDto)
    {
        var response = await _httpClient.PostAsJsonAsync("order", orderDto);
        response.EnsureSuccessStatusCode();
        var createdOrder = await response.Content.ReadFromJsonAsync<OrderDto>();
        return createdOrder;
    }


    /// <summary>
    /// Calls the API UpdateOrder.
    /// </summary>
    /// <param name="orderDto">The object to be updated.</param>
    /// <returns>True for success otherwise false.</returns>
    public async Task<bool> UpdateOrderAsync(OrderDto orderDto)
    {
        var response = await _httpClient.PutAsJsonAsync($"order/{orderDto.Id}", orderDto);
        response.EnsureSuccessStatusCode();
        var result = await response.Content.ReadFromJsonAsync<bool>();
        return result;
    }


    /// <summary>
    /// Calls the API DeleteOrder.
    /// </summary>
    /// <param name="id">Integer representing order id.</param>
    /// <returns>True for success otherwise false.</returns>
    public async Task<bool> DeleteOrderAsync(int id)
    {
        var response = await _httpClient.DeleteAsync($"order/{id}");
        response.EnsureSuccessStatusCode();
        var result = await response.Content.ReadFromJsonAsync<bool>();
        return result;
    }
}
