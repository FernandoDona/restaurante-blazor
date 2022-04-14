using Microsoft.AspNetCore.Mvc;
using Restaurante.AuthProvider.API.Model.Dtos;
using Restaurante.AuthProvider.API.Services;

namespace Restaurante.AuthProvider.API.Controllers;
[ApiController]
[Route("api/v1/[controller]")]
public class RegisterController : ControllerBase
{
    private readonly RegisterService _registerService;

    public RegisterController(RegisterService registerService)
    {
        _registerService = registerService;
    }

    [HttpPost]
    public async Task<IActionResult> Register(CreateUserDto createUserDto)
    {
        var result = await _registerService.RegisterUser(createUserDto);

        return result.Succeeded ? Ok() : BadRequest(result.Errors);
    }
}
