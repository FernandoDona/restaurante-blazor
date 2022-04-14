using FluentResults;
using Microsoft.AspNetCore.Identity;
using Restaurante.AuthProvider.API.Model;
using Restaurante.AuthProvider.API.Model.Dtos;
using System.Security.Claims;

namespace Restaurante.AuthProvider.API.Services;

public class LoginService
{
    private SignInManager<IdentityUser<int>> _signInManager;
    private TokenService _tokenService;

    public LoginService(SignInManager<IdentityUser<int>> signInManager, TokenService tokenService)
    {
        _signInManager = signInManager;
        _tokenService = tokenService;
    }

    internal async Task<LoginResult> LoginUserAsync(LoginRequest loginRequest)
    {
        var result = await _signInManager.PasswordSignInAsync(loginRequest.Username, loginRequest.Password, false, false);
        
        if (!result.Succeeded) 
            return null;

        var user = _signInManager.UserManager.Users.First(u => u.NormalizedUserName == loginRequest.Username.ToUpper());
        var token = _tokenService.CreateToken(user);

        return new LoginResult(user.UserName, token);
    }
}
