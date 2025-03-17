using KayakCove.Application.DTOs;
using KayakCove.Domain.Entities;
using System.Text;
using System.Text.Json;

namespace KayakCove.Web.ApiServices
{
    public class CategoryApiService
    {
        private readonly HttpClient _httpClient;

        public CategoryApiService(IHttpClientFactory httpClient)
        {
            this._httpClient = httpClient.CreateClient("apiClient");
            _httpClient.BaseAddress = new Uri("https://localhost:7247/");
        }

        public async Task<IEnumerable<CategoryDto>> GetAllCategoriesAsync()
        {
            return await _httpClient.GetFromJsonAsync<List<CategoryDto>>("api/category");
        }

        public async Task<CategoryDto> GetCategoryByIdAsync(int id)
        {
            var response = await _httpClient.GetAsync($"api/category/{id}");

            response.EnsureSuccessStatusCode();
            var jsonResponse = await response.Content.ReadAsStringAsync();
            var categoryDto = JsonSerializer.Deserialize<CategoryDto>(jsonResponse, new JsonSerializerOptions { PropertyNameCaseInsensitive = true });
            return categoryDto;
        }

        public async Task<CategoryDto> CreateCategoryAsync(CategoryDto dto)
        {
            var jsonContent = new StringContent(JsonSerializer.Serialize(dto), Encoding.UTF8, "application/json");
            var response = await _httpClient.PostAsync("api/category", jsonContent);
            response.EnsureSuccessStatusCode();
            var jsonResponse = await response.Content.ReadAsStringAsync();
            var categoryDto = JsonSerializer.Deserialize<CategoryDto>(jsonResponse, new JsonSerializerOptions { PropertyNameCaseInsensitive = true });
            return categoryDto;
        }


        public async Task<bool> DeleteCategoryAsync(int id)
        {
            var result = await _httpClient.DeleteAsync($"api/category/{id}");
            if (result.IsSuccessStatusCode)
                return true;
            else
                return false;
        }
    }
}
