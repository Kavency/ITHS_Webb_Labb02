using KayakCove.Application.DTOs;
using System.Text;
using System.Text.Json;

namespace KayakCove.Web.ApiServices;

public class ProductApiService
{
    private readonly HttpClient _httpClient;

    public ProductApiService(IHttpClientFactory httpClient)
    {
        this._httpClient = httpClient.CreateClient("apiClient");
        _httpClient.BaseAddress = new Uri("https://localhost:7247/api/");
    }

    public async Task<IEnumerable<ProductDto>> GetAllProductsAsync()
    {
        return await _httpClient.GetFromJsonAsync<List<ProductDto>>("products");
    }

    public async Task<ProductDto> GetProductByIdAsync(int id)
    {
        var response = await _httpClient.GetAsync($"products/{id}");
        response.EnsureSuccessStatusCode();
        var jsonResponse = await response.Content.ReadAsStringAsync();
        var productDto = DeserializeToObject(jsonResponse);
        return productDto;
    }

    public async Task<ProductDto> CreateProductAsync(ProductDto dto)
    {
        var jsonContent = SerializeFromObject(dto);
        Console.WriteLine("------------------------------");
        Console.WriteLine(jsonContent.Headers); 
        Console.WriteLine("------------------------------");
        var response = await _httpClient.PostAsync("products", jsonContent);
        response.EnsureSuccessStatusCode();
        var jsonResponse = await response.Content.ReadAsStringAsync();
        var productDto = DeserializeToObject(jsonResponse);
        return productDto;
    }


    public async Task<bool> UpdateProductAsync(int id, ProductDto dto)
    {
        Console.WriteLine("ApiService");
        var jsonContent = SerializeFromObject(dto);
        var response = await _httpClient.PutAsync($"products/{id}", jsonContent);
        if (response.IsSuccessStatusCode)
            return true;
        else
            return false;
    }


    private StringContent SerializeFromObject(ProductDto dtoToSerialize)
    {
        return new StringContent(JsonSerializer.Serialize(dtoToSerialize), Encoding.UTF8, "application/json");
    }

    private ProductDto DeserializeToObject(string httpResponse)
    {
        return JsonSerializer.Deserialize<ProductDto>(httpResponse, new JsonSerializerOptions { PropertyNameCaseInsensitive = true });
    }


}
