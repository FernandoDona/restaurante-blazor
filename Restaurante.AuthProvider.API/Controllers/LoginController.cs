using Microsoft.AspNetCore.Mvc;
using Restaurante.AuthProvider.API.Model;
using Restaurante.AuthProvider.API.Services;

namespace Restaurante.AuthProvider.API.Controllers;
[ApiController]
[Route("api/v1/[controller]")]
public class LoginController : ControllerBase
{
    private LoginService _loginService;
    private TokenService _tokenService;

    public LoginController(LoginService loginService, TokenService tokenService)
    {
        _loginService = loginService;
        _tokenService = tokenService;
    }

    [HttpPost]
    public async Task<IActionResult> Login(LoginRequest loginRequest)
    {
        var loginResult = await _loginService.LoginUserAsync(loginRequest);

        if (loginResult is null || string.IsNullOrEmpty(loginResult.Token))
            return Unauthorized("Não foi possível realizar o login.");

        return Ok(loginResult);
    }
}
