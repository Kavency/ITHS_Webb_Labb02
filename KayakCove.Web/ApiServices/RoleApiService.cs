using KayakCove.Application.DTOs;
using System.Text.Json;

namespace KayakCove.Web.ApiServices
{
    public class RoleApiService
    {
        private readonly HttpClient _httpClient;

        public RoleApiService(IHttpClientFactory httpClient)
        {
            this._httpClient = httpClient.CreateClient("apiClient");
            _httpClient.BaseAddress = new Uri("https://localhost:7247/api/");
        }

        public async Task<IEnumerable<RoleDto>> GetAllRolesAsync()
        {
            return await _httpClient.GetFromJsonAsync<List<RoleDto>>("role");
        }

        public async Task<RoleDto> GetRoleByIdAsync(int id)
        {
            var response = await _httpClient.GetAsync($"role/{id}");
            response.EnsureSuccessStatusCode();
            var jsonResponse = await response.Content.ReadAsStringAsync();
            return JsonSerializer.Deserialize<RoleDto>(jsonResponse, new JsonSerializerOptions { PropertyNameCaseInsensitive = true });
        }
    }
}
