using Blazored.LocalStorage;
using Blazored.SessionStorage;
using Microsoft.AspNetCore.Components.Authorization;
using System.Security.Claims;

namespace Restaurante.UI.Authentication;

public class AuthStateProvider : AuthenticationStateProvider
{
    private readonly ILocalStorageService _localStorageService;
    private readonly AuthenticationState _anonymous;

    public AuthStateProvider(ILocalStorageService localStorageService)
    {
        _localStorageService = localStorageService;
        _anonymous = new AuthenticationState(new ClaimsPrincipal(new ClaimsIdentity()));
    }

    public override async Task<AuthenticationState> GetAuthenticationStateAsync()
    {
        var token = await _localStorageService.GetItemAsync<string>(SessionVariables.AuthToken);

        if (string.IsNullOrWhiteSpace(token))
            return _anonymous;
        
        var authenticationUser = this.GetAuthenticationUser(token);
        return new AuthenticationState(authenticationUser);
    }


    public async Task NotifyUserAsAuthenticated(string token)
    {
        var authenticationUser = this.GetAuthenticationUser(token);
        NotifyAuthenticationStateChanged(Task.FromResult(new AuthenticationState(authenticationUser)));

        await _localStorageService.SetItemAsync<string>(SessionVariables.AuthToken, token);
    }

    public async Task NotifyUserLogout()
    {
        await _localStorageService.RemoveItemAsync(SessionVariables.AuthToken);
        NotifyAuthenticationStateChanged(Task.FromResult(_anonymous));
    }

    private ClaimsPrincipal GetAuthenticationUser(string token)
    {
        var claims = JwtParser.ParseClaimsFromJwt(token);
        var authenticationUser = new ClaimsPrincipal(new ClaimsIdentity(claims, "JwtAuthType"));
        
        return authenticationUser;
    }
}
