
namespace Restaurante.UI.Authentication;

public interface IAuthenticationService
{
    Task<bool> LoginAsync(LoginRequest request);
    Task LogoutAsync();
    Task<bool> RegisterAsync(RegisterUserRequest request);
    Task<bool> IsUserAuthenticated();
    Task<int> GetUserIdAsync();
}