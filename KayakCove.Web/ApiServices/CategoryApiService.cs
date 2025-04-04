using KayakCove.Application.DTOs;
using System.Text;
using System.Text.Json;

namespace KayakCove.Web.ApiServices
{
    public class CategoryApiService
    {
        private readonly HttpClient _httpClient;

        public CategoryApiService(IHttpClientFactory httpClient)
        {
            this._httpClient = httpClient.CreateClient("ApiClient");
        }

        public async Task<IEnumerable<CategoryDto>> GetAllCategoriesAsync()
        {
            return await _httpClient.GetFromJsonAsync<List<CategoryDto>>("category");
        }

        public async Task<CategoryDto> GetCategoryByIdAsync(int id)
        {
            var response = await _httpClient.GetAsync($"category/{id}");
            response.EnsureSuccessStatusCode();
            var jsonResponse = await response.Content.ReadAsStringAsync();
            var categoryDto = DeserializeToObject(jsonResponse);
            return categoryDto;
        }


        public async Task<bool> UpdateCategoryAsync(CategoryDto dto)
        {
            var jsonContent = SerializeFromObject(dto);
            var response = await _httpClient.PutAsync($"category/{dto.Id}", jsonContent);
            if (response.IsSuccessStatusCode)
                return true;
            else
                return false;
        }


        public async Task<CategoryDto> CreateCategoryAsync(CategoryDto dto)
        {
            var jsonContent = SerializeFromObject(dto);
            var response = await _httpClient.PostAsync("category", jsonContent);
            response.EnsureSuccessStatusCode();
            var jsonResponse = await response.Content.ReadAsStringAsync();
            var categoryDto = DeserializeToObject(jsonResponse);
            return categoryDto;
        }


        public async Task<bool> DeleteCategoryAsync(int id)
        {
            var result = await _httpClient.DeleteAsync($"category/{id}");
            if (result.IsSuccessStatusCode)
                return true;
            else
                return false;
        }

        private StringContent SerializeFromObject(CategoryDto dtoToSerialize)
        {
            return new StringContent(JsonSerializer.Serialize(dtoToSerialize), Encoding.UTF8, "application/json");
        }

        private CategoryDto DeserializeToObject(string httpResponse)
        {
            return JsonSerializer.Deserialize<CategoryDto>(httpResponse, new JsonSerializerOptions { PropertyNameCaseInsensitive = true });
        }
    }
}
