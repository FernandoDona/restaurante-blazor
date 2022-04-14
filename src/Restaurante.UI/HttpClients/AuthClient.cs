namespace Restaurante.UI.HttpClients;

public class AuthClient
{
    private readonly HttpClient _httpClient;

    public AuthClient(HttpClient httpClient)
    {
        _httpClient = httpClient;
    }

    public async Task<LoginResult> SignIn(LoginRequest loginRequest)
    {
        var response = await _httpClient.PostAsJsonAsync("/api/v1/login", loginRequest);

        if (response.IsSuccessStatusCode == false)
            return null;

        return await response.Content.ReadFromJsonAsync<LoginResult>();
    }

    public async Task<bool> Register(RegisterUserRequest registerUserRequest)
    {
        var response = await _httpClient.PostAsJsonAsync("/api/v1/register", registerUserRequest);

        if (response.IsSuccessStatusCode == false)
            return false;

        return true;
    }
}
