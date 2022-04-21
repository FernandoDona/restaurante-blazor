using Microsoft.AspNetCore.Components.Authorization;
using Restaurante.UI.HttpClients;
using System.Security.Claims;

namespace Restaurante.UI.Services;

public class AuthenticationService : IAuthenticationService
{
    private readonly AuthClient _authClient;
    private readonly AuthStateProvider _authStateProvider;

    public AuthenticationService(AuthClient authClient, AuthenticationStateProvider authStateProvider)
    {
        _authClient = authClient;
        _authStateProvider = authStateProvider as AuthStateProvider;
    }

    public async Task<bool> LoginAsync(LoginRequest request)
    {
        try
        {
            var loginResult = await _authClient.SignIn(request);

            if (loginResult is null || string.IsNullOrWhiteSpace(loginResult.Token))
                return false;

            await _authStateProvider.NotifyUserAsAuthenticated(loginResult.Token);
            return true;
        }
        catch (Exception)
        {
            return false;
        }
    }

    public Task LogoutAsync()
    {
        return _authStateProvider.NotifyUserLogout();
    }

    public async Task<bool> IsUserAuthenticated()
    {
        var authenticationState = await _authStateProvider.GetAuthenticationStateAsync();

        return authenticationState.User.Identity.IsAuthenticated;
    }

    public async Task<bool> RegisterAsync(RegisterUserRequest request)
    {
        try
        {
            return await _authClient.Register(request);
        }
        catch (Exception)
        {
            return false;
        }
    }

    public async Task<int> GetUserIdAsync()
    {
        var authState = await _authStateProvider.GetAuthenticationStateAsync();
        var id = int.Parse(authState.User.Claims.Where(c => c.Type == ClaimTypes.NameIdentifier).First().Value);
        
        return id;
    }
}
