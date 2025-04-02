using Microsoft.JSInterop;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;

namespace KayakCove.Web.ApiServices;

public class AuthenticationService
{
    private readonly IServiceProvider _serviceProvider;

    public AuthenticationService(IServiceProvider serviceProvider)
    {
        _serviceProvider = serviceProvider;
    }

    public async Task SetTokenAsync(string token)
    {
        var jsRuntime = _serviceProvider.GetRequiredService<IJSRuntime>();
        await jsRuntime.InvokeVoidAsync("sessionStorage.setItem", "authToken", token);
    }

    public async Task<string> GetTokenAsync()
    {
        var jsRuntime = _serviceProvider.GetRequiredService<IJSRuntime>();
        return await jsRuntime.InvokeAsync<string>("sessionStorage.getItem", "authToken");
    }

    public async Task<bool> IsLoggedInAsync()
    {
        var token = await GetTokenAsync();
        return !string.IsNullOrEmpty(token);
    }

    public async Task LogoutAsync()
    {
        var jsRuntime = _serviceProvider.GetRequiredService<IJSRuntime>();
        await jsRuntime.InvokeVoidAsync("sessionStorage.removeItem", "authToken");
    }

    public async Task<string> GetRoleAsync()
    {
        var jsRuntime = _serviceProvider.GetRequiredService<IJSRuntime>();
        var token = await jsRuntime.InvokeAsync<string>("sessionStorage.getItem", "authToken");

        if (string.IsNullOrEmpty(token))
            return null;

        var handler = new JwtSecurityTokenHandler();
        var jwtToken = handler.ReadJwtToken(token);

        var roleClaim = jwtToken.Claims.FirstOrDefault(c => c.Type == ClaimTypes.Role);
        return roleClaim?.Value;
    }

}