using Microsoft.AspNetCore.Components.Authorization;

namespace Restaurante.UI;

public class CheckoutService
{
    private readonly AuthStateProvider _authStateProvider;

    public CheckoutService(AuthenticationStateProvider authStateProvider)
    {
        _authStateProvider = authStateProvider as AuthStateProvider;
    }

    
}
