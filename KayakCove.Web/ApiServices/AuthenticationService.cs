using Microsoft.JSInterop;

namespace KayakCove.Web.ApiServices;

public class AuthenticationService
{
    private readonly IJSRuntime _jsRuntime;

    public AuthenticationService(IJSRuntime jsRuntime)
    {
        _jsRuntime = jsRuntime;
    }

    public async Task<bool> IsLoggedInAsync()
    {
        var result = await _jsRuntime.InvokeAsync<string>("localStorage.getItem", "isLoggedIn");
        return result == "true";
    }

    public async Task LoginAsync(int id, string username)
    {
        await _jsRuntime.InvokeVoidAsync("localStorage.setItem", "isLoggedIn", "true");
        await _jsRuntime.InvokeVoidAsync("localStorage.setItem", "id", id);
        await _jsRuntime.InvokeVoidAsync("localStorage.setItem", "username", username);
    }

    public async Task LogoutAsync()
    {
        await _jsRuntime.InvokeVoidAsync("localStorage.removeItem", "isLoggedIn");
        await _jsRuntime.InvokeVoidAsync("localStorage.removeItem", "id");
        await _jsRuntime.InvokeVoidAsync("localStorage.removeItem", "username");
    }
}