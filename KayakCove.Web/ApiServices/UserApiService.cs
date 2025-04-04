using KayakCove.Application.DTOs;
using System.Text.Json;

namespace KayakCove.Web.ApiServices;

public class UserApiService(IHttpClientFactory httpClient)
{
    private readonly HttpClient _httpClient = httpClient.CreateClient("ApiClient");


    public async Task<TokenResponseDto> AuthenticateUserAsync(LoginRequestDto loginRequest)
    {
            var response = await _httpClient.PostAsJsonAsync("authenticate/login", loginRequest);
            var responseData = await response.Content.ReadFromJsonAsync<TokenResponseDto>();
            return responseData;
    }


    public async Task<IEnumerable<UserDto>> GetAllUsersAsync()
    {
        return await _httpClient.GetFromJsonAsync<List<UserDto>>("user");
    }


    public async Task<UserDto> GetUserByIdAsync(int id)
    {
        return await _httpClient.GetFromJsonAsync<UserDto>($"user/{id}");
    }


    public async Task<UserDto> CreateUserAsync(UserDto dto)
    {
        var response = await _httpClient.PostAsJsonAsync("user", dto);
        response.EnsureSuccessStatusCode();
        var jsonResponse = await response.Content.ReadAsStringAsync();
        var userDto = JsonSerializer.Deserialize<UserDto>(jsonResponse, new JsonSerializerOptions { PropertyNameCaseInsensitive = true });
        return userDto;
    }


    public async Task<bool> UpdateUserAsync(int id, UserDto dto)
    {
        var response = await _httpClient.PutAsJsonAsync($"user/{id}", dto);
        if (response.IsSuccessStatusCode)
            return true;
        else
            return false;
    }


    public async Task<bool> DeleteUserAsync(int id)
    {
        var response = await _httpClient.DeleteAsync($"user/{id}");
        if (response.IsSuccessStatusCode)
            return true;
        else
            return false;
    }
}
